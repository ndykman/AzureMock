using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Mock.Storage.Table
{
    public class ListTablesAsyncResult : ICancellableAsyncResult
    {
        public bool IsCompleted { get; set; }
        public WaitHandle AsyncWaitHandle { get; set; }
        public object AsyncState { get; set; }
        public bool CompletedSynchronously { get; set; }
        public string NextTableName { get; set; }
        public void Cancel()
        {
            // Do nothing.
            return;
        }
    }

    public class ServicePropertiesAsyncResult : ICancellableAsyncResult
    {
        public bool IsCompleted { get; set; }
        public WaitHandle AsyncWaitHandle { get; set; }
        public object AsyncState { get; set; }
        public bool CompletedSynchronously { get; set; }
        public void Cancel()
        {
            return;
        }
    }

    public class MockCloudTableClient : ICloudTableClient
    {
        private ServiceProperties _serviceProperties;
        private List<ICloudTable> _tables;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Table.CloudTableClient"/> class using the specified Blob service endpoint
        ///             and anonymous credentials.
        /// 
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        public MockCloudTableClient(Uri baseUri)
            : this(baseUri, (StorageCredentials)null)
        {
            _serviceProperties = new ServiceProperties
                {
                    DefaultServiceVersion = "2.0",
                    Logging = new LoggingProperties
                        {
                            LoggingOperations = LoggingOperations.None,
                            RetentionDays = null,
                            Version = "2.0"
                        }
                };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Table.CloudTableClient"/> class using the specified Blob service endpoint
        ///             and account credentials.
        /// 
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param><param name="credentials">The account credentials.</param>
        public MockCloudTableClient(Uri baseUri, StorageCredentials credentials)
        {
            BaseUri = baseUri;
            Credentials = credentials;
            ServerTimeout = TimeSpan.FromSeconds(30);
            MaximumExecutionTime = TimeSpan.FromMinutes(5);

            _tables = new List<ICloudTable>();
        }

        public StorageCredentials Credentials { get; private set; }
        public Uri BaseUri { get; set; }
        public IRetryPolicy RetryPolicy { get; set; }
        public TimeSpan? ServerTimeout { get; private set; }
        public TimeSpan? MaximumExecutionTime { get; private set; }

        public IEnumerable<ICloudTable> ListTables()
        {
            return _tables;
        }

        public IEnumerable<ICloudTable> ListTables(string prefix, TableRequestOptions requestOptions = null,
                                      OperationContext operationContext = null)
        {
            if (String.IsNullOrWhiteSpace(prefix))
            {
                return _tables;
            }

            return _tables.Where(p => p.Name.StartsWith(prefix));
        }

        public ICancellableAsyncResult BeginListTablesSegmented(TableContinuationToken currentToken, AsyncCallback callback,
                                                                object state)
        {
            return BeginListTablesSegmented(null, null, currentToken, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginListTablesSegmented(string prefix, TableContinuationToken currentToken,
                                                                AsyncCallback callback, object state)
        {
            return BeginListTablesSegmented(prefix, null, currentToken, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginListTablesSegmented(string prefix, int? maxResults, TableContinuationToken currentToken,
                                                                TableRequestOptions requestOptions, OperationContext operationContext,
                                                                AsyncCallback callback, object state)
        {
            string nextTableName;
            var results = GetCloudTables(prefix, maxResults, currentToken, out nextTableName);

            ListTablesAsyncResult result = new ListTablesAsyncResult
                {
                    AsyncState = results,
                    AsyncWaitHandle = new Mutex(),
                    CompletedSynchronously = true,
                    IsCompleted = true,
                    NextTableName = nextTableName
                };

            callback(result);

            return result;
        }

        public ITableResultSegment EndListTablesSegmented(IAsyncResult asyncResult)
        {
            var result = asyncResult as ListTablesAsyncResult;
            TableContinuationToken token;
            if (result.NextTableName != null)
            {
                token = new TableContinuationToken
                    {
                        NextTableName = result.NextTableName
                    };
            }
            else
            {
                token = null;
            }
            return new MockTableResultSegment
                {
                    ContinuationToken = token,
                    Results = result.AsyncState as IList<ICloudTable>
                };
        }

        public ITableResultSegment ListTablesSegmented(TableContinuationToken currentToken)
        {
            return ListTablesSegmented(null, null, currentToken);
        }

        public ITableResultSegment ListTablesSegmented(string prefix, TableContinuationToken currentToken)
        {
            return ListTablesSegmented(prefix, null, currentToken);
        }

        public ITableResultSegment ListTablesSegmented(string prefix, int? maxResults, TableContinuationToken currentToken,
                                                      TableRequestOptions requestOptions = null,
                                                      OperationContext operationContext = null)
        {
            string nextTableName;
            var result = GetCloudTables(prefix, maxResults, currentToken, out nextTableName);
            TableContinuationToken token;
            if (nextTableName != null)
            {
                token = new TableContinuationToken
                {
                    NextTableName = nextTableName
                };
            }
            else
            {
                token = null;
            }
            return new MockTableResultSegment
            {
                ContinuationToken = token,
                Results = result
            };
        }

        public ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return BeginGetServiceProperties(null, null, callback, state);

        }

        public ICancellableAsyncResult BeginGetServiceProperties(TableRequestOptions requestOptions, OperationContext operationContext,
                                                                 AsyncCallback callback, object state)
        {
            var result = new ServicePropertiesAsyncResult
            {
                AsyncState = _serviceProperties,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            var result = asyncResult as ServicePropertiesAsyncResult;
            return result.AsyncState as ServiceProperties;
        }

        public ServiceProperties GetServiceProperties(TableRequestOptions requestOptions = null,
                                                      OperationContext operationContext = null)
        {
            return _serviceProperties;
        }

        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return BeginSetServiceProperties(properties, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions,
                                                                 OperationContext operationContext, AsyncCallback callback,
                                                                 object state)
        {
            _serviceProperties = properties;
            var result = new ServicePropertiesAsyncResult
            {
                AsyncState = _serviceProperties,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;

        }

        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            return;
        }

        public void SetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions = null,
                                         OperationContext operationContext = null)
        {
            _serviceProperties = properties;
        }

        public ICloudTable GetTableReference(string tableAddress)
        {
            throw new NotImplementedException();
        }

        private List<ICloudTable> GetCloudTables(string prefix, int? maxResults, TableContinuationToken currentToken,
                                    out string nextTableName)
        {
            int numOfTables;
            List<ICloudTable> results;

            // Skip to the next table, if we have a currentToken.
            if (currentToken != null)
            {
                int index = _tables.IndexOf(_tables.Single(t => t.Name == currentToken.NextTableName));
                results = _tables.Skip(index + 1).ToList();
            }
            else
            {
                results = _tables;
            }

            // Compute the number of tables to return;
            if (!maxResults.HasValue || maxResults.Value == 0)
            {
                numOfTables = 5000;
            }
            else
            {
                numOfTables = maxResults.Value;
            }

            if (results.Count > numOfTables)
            {
                nextTableName = _tables.Skip(numOfTables + 1).First().Name;
            }
            else
            {
                nextTableName = null;
            }

            if (!String.IsNullOrWhiteSpace(prefix))
            {
                results = _tables.Where(t => t.Name.StartsWith(prefix)).ToList();
            }
            return results;
        }
    }
}
