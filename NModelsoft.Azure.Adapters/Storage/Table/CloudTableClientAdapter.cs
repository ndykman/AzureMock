using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Adapters.Storage.Table
{
    public class CloudTableClientAdapter : ICloudTableClient
    {
        private CloudTableClient _cloudTableClient;

        public StorageCredentials Credentials
        {
            get { return _cloudTableClient.Credentials; }
        }
        public Uri BaseUri { get { return _cloudTableClient.BaseUri; } }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Table.CloudTableClient"/> class using the specified Blob service endpoint
        ///             and anonymous credentials.
        /// 
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        public CloudTableClientAdapter(Uri baseUri)
            : this(baseUri, (StorageCredentials)null)
        {
           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Table.CloudTableClient"/> class using the specified Blob service endpoint
        ///             and account credentials.
        /// 
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param><param name="credentials">The account credentials.</param>
        public CloudTableClientAdapter(Uri baseUri, StorageCredentials credentials)
        {
            _cloudTableClient = new CloudTableClient(baseUri, credentials);
        }

        public CloudTableClientAdapter(CloudTableClient cloudTableClient)
        {
            _cloudTableClient = cloudTableClient;
        }

        public IEnumerable<ICloudTable> ListTables()
        {
            return _cloudTableClient.ListTables().Select(ct => new CloudTableAdapter(ct)).AsEnumerable();
        }

        public IEnumerable<ICloudTable> ListTables(string prefix, TableRequestOptions requestOptions = null,
                                      OperationContext operationContext = null)
        {
            return _cloudTableClient.ListTables(prefix,requestOptions,operationContext).Select(ct => new CloudTableAdapter(ct)).AsEnumerable();
        }

        public ICancellableAsyncResult BeginListTablesSegmented(TableContinuationToken currentToken, AsyncCallback callback,
                                                                object state)
        {
            return _cloudTableClient.BeginListTablesSegmented(currentToken, r =>
            {
                var t = new AdapterAsyncResult<ITableResultSegment>(r,
                                                                    new TableResultSegmentAdapter(
                                                                        r.AsyncState as TableResultSegment));
                callback(t);
            }, state);
        }

        public ICancellableAsyncResult BeginListTablesSegmented(string prefix, TableContinuationToken currentToken,
                                                                AsyncCallback callback, object state)
        {
            return _cloudTableClient.BeginListTablesSegmented(prefix,
                currentToken, 
                r =>
                    {
                        var t = new AdapterAsyncResult<ITableResultSegment>(r,
                                                                            new TableResultSegmentAdapter(
                                                                                r.AsyncState as TableResultSegment));
                        callback(t);
                    }, 
                state);
        }

        public ICancellableAsyncResult BeginListTablesSegmented(string prefix, int? maxResults, TableContinuationToken currentToken,
                                                                TableRequestOptions requestOptions, OperationContext operationContext,
                                                                AsyncCallback callback, object state)
        {
            return _cloudTableClient.BeginListTablesSegmented(prefix,maxResults,currentToken, requestOptions, operationContext,
                  r =>
                    {
                        var t = new AdapterAsyncResult<ITableResultSegment>(r,
                                                                            new TableResultSegmentAdapter(
                                                                                r.AsyncState as TableResultSegment));
                        callback(t);
                    }, state);
        }

        public ITableResultSegment EndListTablesSegmented(IAsyncResult asyncResult)
        {
            return new TableResultSegmentAdapter(asyncResult.AsyncState as TableResultSegment);
        }

        public ITableResultSegment ListTablesSegmented(TableContinuationToken currentToken)
        {
            return new TableResultSegmentAdapter(_cloudTableClient.ListTablesSegmented(currentToken));
        }

        public ITableResultSegment ListTablesSegmented(string prefix, TableContinuationToken currentToken)
        {
            return new TableResultSegmentAdapter(_cloudTableClient.ListTablesSegmented(prefix,currentToken));
        }

        public ITableResultSegment ListTablesSegmented(string prefix, int? maxResults, TableContinuationToken currentToken,
                                                      TableRequestOptions requestOptions = null,
                                                      OperationContext operationContext = null)
        {
            return
                new TableResultSegmentAdapter(_cloudTableClient.ListTablesSegmented(prefix, maxResults, currentToken,
                                                                                    requestOptions, operationContext));
        }

        public ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return _cloudTableClient.BeginGetServiceProperties(callback, state);
        }

        public ICancellableAsyncResult BeginGetServiceProperties(TableRequestOptions requestOptions, OperationContext operationContext,
                                                                 AsyncCallback callback, object state)
        {
            return _cloudTableClient.BeginGetServiceProperties(requestOptions, operationContext, callback, state);
        }

        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            return _cloudTableClient.EndGetServiceProperties(asyncResult);
        }

        public ServiceProperties GetServiceProperties(TableRequestOptions requestOptions = null,
                                                      OperationContext operationContext = null)
        {
            return _cloudTableClient.GetServiceProperties(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return _cloudTableClient.BeginSetServiceProperties(properties, callback, state);
        }

        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions,
                                                                 OperationContext operationContext, AsyncCallback callback,
                                                                 object state)
        {
            return _cloudTableClient.BeginSetServiceProperties(properties, requestOptions, operationContext, callback,
                                                               state);
        }

        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            _cloudTableClient.EndSetServiceProperties(asyncResult);
        }

        public void SetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions = null,
                                         OperationContext operationContext = null)
        {
            _cloudTableClient.SetServiceProperties(properties, requestOptions, operationContext);
        }
        
        public ICloudTable GetTableReference(string tableAddress)
        {
            return new CloudTableAdapter(_cloudTableClient.GetTableReference(tableAddress));
        }
    }
}
