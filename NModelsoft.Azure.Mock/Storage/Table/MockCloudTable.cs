using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Mock.Storage.Table
{
    public class TableAsyncResult : ICancellableAsyncResult
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

    public class MockCloudTable : ICloudTable
    {
        private ICloudTableClient _client;
        private Uri _uri;
        private List<DynamicTableEntity> _entries;
        private TablePermissions _permissions;
        private StorageCredentials _credentials;

        public ICloudTableClient ServiceClient { get { return _client; } }
        public string Name { get; set; }
        public Uri Uri { get { return _uri; } }

        public MockCloudTable(Uri tableAbsoluteUri, StorageCredentials credentials)
        {
            _client = null;
            _uri = tableAbsoluteUri;
            _entries = null;
            _permissions = new TablePermissions();
            _credentials = credentials;
        }

        public MockCloudTable(Uri address, ICloudTableClient client)
        {
            _uri = address;
            _client = client;
            _credentials = null;
            _entries = null;
            _permissions = new TablePermissions();
        }

        public TableResult Execute(TableOperation operation, TableRequestOptions requestOptions = null,
                                   OperationContext operationContext = null)
        {
            return ExecuteHelper(operation, operationContext);
        }

        public ICancellableAsyncResult BeginExecute(TableOperation operation, AsyncCallback callback, object state)
        {
            return BeginExecute(operation, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginExecute(TableOperation operation, TableRequestOptions requestOptions,
                                                    OperationContext operationContext, AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
                {
                    AsyncState = Execute(operation, requestOptions, operationContext),
                    AsyncWaitHandle = new Mutex(),
                    CompletedSynchronously = true,
                    IsCompleted = true
                };
            callback(result);
            return result;
        }

        public TableResult EndExecute(IAsyncResult asyncResult)
        {
            return asyncResult.AsyncState as TableResult;
        }

        public IList<TableResult> ExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions = null,
                                  OperationContext operationContext = null)
        {
            return batch.Select(operation => Execute(operation)).ToList();
        }

        public ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, AsyncCallback callback, object state)
        {
            return BeginExecuteBatch(batch, null, null, callback, state);
 
        }

        public ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions,
                                                         OperationContext operationContext, AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = ExecuteBatch(batch, requestOptions, operationContext),
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public IList<TableResult> EndExecuteBatch(IAsyncResult asyncResult)
        {
            return asyncResult.AsyncState as IList<TableResult>;
        }

        public IEnumerable<DynamicTableEntity> ExecuteQuery(TableQuery query, TableRequestOptions requestOptions = null,
                                        OperationContext operationContext = null)
        {
            var parser = new TableQueryParser();
            var filterExpression = parser.CreateFilterExpressionDynamic(query.FilterString).Compile();
            return _entries.Where(filterExpression).AsEnumerable();

        }

        public ITableQuerySegment<DynamicTableEntity> ExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                       TableRequestOptions requestOptions = null,
                                                       OperationContext operationContext = null)
        {
            return new MockTableQuerySegment<DynamicTableEntity>
                {
                    ContinuationToken = null,
                    Results = ExecuteQuery(query,requestOptions,operationContext).ToList()
                };
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                                  AsyncCallback callback, object state)
        {
            return BeginExecuteQuerySegmented(query, token, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                                  TableRequestOptions requestOptions, OperationContext operationContext,
                                                                  AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = ExecuteQuerySegmented(query, token, requestOptions, operationContext),
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public ITableQuerySegment<DynamicTableEntity> EndExecuteQuerySegmented(IAsyncResult asyncResult)
        {
            return asyncResult.AsyncState as ITableQuerySegment<DynamicTableEntity>;
        }

        public IEnumerable<TElement> ExecuteQuery<TElement>(TableQuery<TElement> query, TableRequestOptions requestOptions = null,
                                                  OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            var parser = new TableQueryParser();
            var filterExpression = parser.CreateFilterExpressionDynamic(query.FilterString).Compile();
            return _entries.Where(filterExpression).Select(e =>
                {
                    TElement newTElement = new TElement
                        {
                            ETag = e.ETag,
                            PartitionKey = e.PartitionKey,
                            RowKey = e.RowKey,
                            Timestamp = e.Timestamp,
                        };
                    newTElement.ReadEntity(e.Properties, operationContext);
                    return newTElement;
                }).AsEnumerable();
        }

        public ITableQuerySegment<TElement> ExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token,
                                                                 TableRequestOptions requestOptions = null,
                                                                 OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            return new MockTableQuerySegment<TElement>
                {
                    ContinuationToken = null,
                    Results = ExecuteQuery(query, requestOptions, operationContext).ToList()
                };
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token,
                                                                            AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            return BeginExecuteQuerySegmented(query, token, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token,
                                                                            TableRequestOptions requestOptions,
                                                                            OperationContext operationContext, AsyncCallback callback,
                                                                            object state) where TElement : ITableEntity, new()
        {
            var result = new TableAsyncResult
            {
                AsyncState = ExecuteQuerySegmented(query, token, requestOptions, operationContext),
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public ITableQuerySegment<TElement> EndExecuteQuerySegmented<TElement>(IAsyncResult asyncResult)
        {
            return asyncResult.AsyncState as ITableQuerySegment<TElement>;
        }

        public IEnumerable<R> ExecuteQuery<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                     TableRequestOptions requestOptions = null,
                                                     OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            var parser = new TableQueryParser();
            var filterExpression = parser.CreateFilterExpressionDynamic(query.FilterString).Compile();
            return
                _entries.Where(filterExpression)
                        .Select(e => resolver(e.PartitionKey, e.RowKey, e.Timestamp, e.Properties, e.ETag))
                        .AsEnumerable();
        }

        public ITableQuerySegment<R> ExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                                    TableContinuationToken token,
                                                                    TableRequestOptions requestOptions = null,
                                                                    OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            return new MockTableQuerySegment<R>
                {
                    ContinuationToken = null,
                    Results = ExecuteQuery(query, resolver, requestOptions, operationContext).ToList()
                };
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                                               TableContinuationToken token, AsyncCallback callback,
                                                                               object state) where TElement : ITableEntity, new()
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                                               TableContinuationToken token,
                                                                               TableRequestOptions requestOptions,
                                                                               OperationContext operationContext,
                                                                               AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            var result = new TableAsyncResult
            {
                AsyncState = ExecuteQuerySegmented(query, token, requestOptions, operationContext),
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public ITableQuerySegment<R> EndExecuteQuerySegmented<TElement, R>(IAsyncResult asyncResult)
        {
            return asyncResult.AsyncState as ITableQuerySegment<R>;
        }

        public ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return BeginCreate(null, null, callback, state);
        }

        public ICancellableAsyncResult BeginCreate(TableRequestOptions requestOptions, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            if (_entries == null)
            {
                _entries = new List<DynamicTableEntity>();
            }

            var result = new TableAsyncResult
            {
                AsyncState = state,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public void EndCreate(IAsyncResult asyncResult)
        {
            return;
        }

        public void Create(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            if (_entries == null)
            {
                _entries = new List<DynamicTableEntity>();
            }
        }

        public ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            return BeginCreateIfNotExists(null, null, callback, state);
        }

        public ICancellableAsyncResult BeginCreateIfNotExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                              AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = _entries == null,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };

            if (_entries == null)
            {
                _entries = new List<DynamicTableEntity>();
            }

            callback(result);
            return result;
        }

        public bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            return (bool) asyncResult.AsyncState;
        }

        public bool CreateIfNotExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            var wasCreated = _entries == null;
            if (wasCreated)
            {
                _entries = new List<DynamicTableEntity>();
            }
            return wasCreated;
        }

        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return BeginDelete(null, null, callback, state);
        }

        public ICancellableAsyncResult BeginDelete(TableRequestOptions requestOptions, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = state,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };

            if (_entries != null)
            {
                _entries.Clear();
                _entries = null;
            }

            return result;
        }

        public void EndDelete(IAsyncResult asyncResult)
        {
            return;
        }

        public void Delete(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            if (_entries != null)
            {
                _entries.Clear();
                _entries = null;
            }
        }

        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return BeginDeleteIfExists(null, null, callback, state);
        }

        public ICancellableAsyncResult BeginDeleteIfExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                           AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = _entries != null,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };

            if (_entries != null)
            {
                _entries.Clear();
                _entries = null;
            }

            return result;
        }

        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            return (bool) asyncResult.AsyncState;
        }

        public bool DeleteIfExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            var didExist = _entries != null;

            if (didExist)
            {
                _entries.Clear();
                _entries = null;
            }
            return didExist;
        }

        public ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            return BeginExists(null, null, callback, state);
        }

        public ICancellableAsyncResult BeginExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = _entries != null,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public bool EndExists(IAsyncResult asyncResult)
        {
            return (bool) asyncResult.AsyncState;
        }

        public bool Exists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return _entries != null;
        }

        public ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return BeginGetPermissions(null, null, callback, state);
        }

        public ICancellableAsyncResult BeginGetPermissions(TableRequestOptions requestOptions, OperationContext operationContext,
                                                           AsyncCallback callback, object state)
        {
            var result = new TableAsyncResult
            {
                AsyncState = _permissions,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public TablePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return asyncResult.AsyncState as TablePermissions;
        }

        public TablePermissions GetPermissions(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return _permissions;
        }

        public ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, AsyncCallback callback, object state)
        {
            return BeginSetPermissions(permissions, null, null, callback, state);
        }

        public ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, TableRequestOptions requestOptions,
                                                           OperationContext operationContext, AsyncCallback callback, object state)
        {
            _permissions = permissions;
            var result = new TableAsyncResult
            {
                AsyncState = _permissions,
                AsyncWaitHandle = new Mutex(),
                CompletedSynchronously = true,
                IsCompleted = true
            };
            callback(result);
            return result;
        }

        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            return;
        }

        public void SetPermissions(TablePermissions permissions, TableRequestOptions requestOptions = null,
                                   OperationContext operationContext = null)
        {
            _permissions = permissions;
        }

        public string GetSharedAccessSignature(SharedAccessTablePolicy policy, string accessPolicyIdentifier, string startPartitionKey,
                                               string startRowKey, string endPartitionKey, string endRowKey)
        {
            CloudTable ct;
            if (_credentials != null)
                ct = new CloudTable(_uri, _credentials);
            else
                ct = new CloudTable(_uri,new StorageCredentials());

            return ct.GetSharedAccessSignature(policy, accessPolicyIdentifier, startPartitionKey, startRowKey,
                                               endPartitionKey, endRowKey);
        }

       

        private ITableEntity GetEntity(string partitionKey, string rowKey)
        {
            if (!_entries.Any(e=>e.PartitionKey == partitionKey && e.RowKey == rowKey))
                return null;

            return _entries.First(e => e.PartitionKey == partitionKey && e.RowKey == rowKey);
        }

        private TResult GetEntity<TResult>(string partitionKey, string rowKey) where TResult : TableEntity, new()
        {
            OperationContext opContext = new OperationContext();

            if (!_entries.Any(e => e.PartitionKey == partitionKey && e.RowKey == rowKey))
                return null;

            var entity = _entries.First(e => e.PartitionKey == partitionKey && e.RowKey == rowKey);

            TResult result = new TResult
            {
                PartitionKey = partitionKey,
                RowKey = rowKey,
                ETag = entity.ETag,
                Timestamp = entity.Timestamp
            };

            result.ReadEntity(entity.Properties, opContext);
            return result;
        }

        private bool ContainsEntity(ITableEntity entity)
        {
            return _entries.Any(e => e.PartitionKey == entity.PartitionKey && e.RowKey == entity.RowKey);
        }

        private void DeleteEntity(ITableEntity entity, OperationContext context, TableResult result)
        {
            if (_entries.Any(e => e.PartitionKey == entity.PartitionKey && e.RowKey == entity.RowKey))
            {
                _entries.Remove(_entries.First(e => e.PartitionKey == entity.PartitionKey && e.RowKey == entity.RowKey));
            }
        }

        private void InsertEntity(ITableEntity entity, OperationContext opContext, TableResult result)
        {
            DynamicTableEntity newEntity = new DynamicTableEntity(entity.PartitionKey, entity.RowKey, entity.ETag,
                                                                  entity.WriteEntity(opContext));

            if (!ContainsEntity(entity))
            {
                _entries.Add(newEntity);
            }
            else
            {
                result.HttpStatusCode = 409;
                result.Result = entity;
            }
        }

        private void InsertOrMergeEntity(ITableEntity entity, OperationContext operationContext, TableResult result)
        {
            if (!ContainsEntity(entity))
                InsertEntity(entity, operationContext, result);

            var existingEntity = GetEntity(entity.PartitionKey, entity.RowKey);
            var existingValues = existingEntity.WriteEntity(operationContext);
            foreach (var pair in entity.WriteEntity(operationContext))
            {
                if (existingValues.ContainsKey(pair.Key))
                {
                    existingValues[pair.Key] = pair.Value;
                }
                else
                {
                    existingValues.Add(pair);
                }
            }
            result.Result = entity;
        }

        private void InsertOrReplaceEntity(ITableEntity entity, OperationContext operationContext, TableResult result)
        {
            if (!ContainsEntity(entity))
                InsertEntity(entity, operationContext, result);

            var existingEntity = GetEntity(entity.PartitionKey, entity.RowKey);
            existingEntity.ReadEntity(entity.WriteEntity(operationContext), operationContext);
            result.Result = entity;
        }

        private void MergeEntity(ITableEntity entity, OperationContext operationContext, TableResult result)
        {
            if (!ContainsEntity(entity))
            {
                result.HttpStatusCode = 400;
                result.Result = entity;
                return;
            }
            InsertOrMergeEntity(entity, operationContext, result);
        }

        private void ReplaceEntity(ITableEntity entity, OperationContext operationContext, TableResult result)
        {
            if (!ContainsEntity(entity))
            {
                result.HttpStatusCode = 400;
                result.Result = entity;
                return;
            }
            InsertOrReplaceEntity(entity, operationContext, result);
        }

        private IDictionary<string, EntityProperty> RetrieveEntity(string partitionKey, string rowKey,
                                                                   OperationContext operationContext, TableResult result)
        {
            if (!_entries.Any(e => e.PartitionKey == partitionKey && e.RowKey == rowKey))
            {
                result.HttpStatusCode = 404;
                result.Result = null;
                return null;
            }
            result.HttpStatusCode = 200;
            result.Result = _entries.First(e => e.PartitionKey == partitionKey && e.RowKey == rowKey);
            return ((DynamicTableEntity) result.Result).Properties;
        }

        private TableResult ExecuteHelper(TableOperation operation, OperationContext opContext)
        {
            var operationType = (TableOperationType)
                operation.GetType().GetProperty("OperationType",
                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).
                        GetValue(operation);
            var entity = (ITableEntity)
                operation.GetType().GetProperty("Entity",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).
                        GetValue(operation);

            var result = new TableResult
            {
                Etag = entity.ETag,
                HttpStatusCode = 200,
                Result = null
            };

            switch (operationType)
            {
                case TableOperationType.Delete:
                    DeleteEntity(entity, opContext, result);
                    break;
                case TableOperationType.Insert:
                    InsertEntity(entity, opContext, result);
                    break;
                case TableOperationType.InsertOrMerge:
                    InsertOrMergeEntity(entity, opContext, result);
                    break;
                case TableOperationType.InsertOrReplace:
                    InsertOrReplaceEntity(entity, opContext, result);
                    break;
                case TableOperationType.Merge:
                    MergeEntity(entity, opContext, result);
                    break;
                case TableOperationType.Replace:
                    ReplaceEntity(entity, opContext, result);
                    break;
                case TableOperationType.Retrieve:
                    var partitionKey = (string)
                        operation.GetType().GetProperty("RetrievePartitionKey",
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).
                       GetValue(operation);

                    var rowKey = (string)
                        operation.GetType().GetProperty("RetrieveRowKey",
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).
                                GetValue(operation);
                    var values = RetrieveEntity(partitionKey, rowKey, opContext, result);
                    if (values != null)
                    {
                        var eTag = ((DynamicTableEntity) result.Result).Timestamp; 
                        var resolver = (Delegate)
                            operation.GetType().GetProperty("RetrieveResolver",
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).
                                GetValue(operation);
                        result.Result = resolver.DynamicInvoke(partitionKey, rowKey, DateTimeOffset.UtcNow, values, eTag);
                    }
                    break;
            }
            return result;
        }
    }
}
