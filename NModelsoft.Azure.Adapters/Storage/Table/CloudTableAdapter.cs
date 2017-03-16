using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Adapters.Storage.Table
{
    public class CloudTableAdapter : ICloudTable
    {
        private CloudTable _cloudTable;
        private CloudTableClientAdapter _cloudTableClientAdapter;
        public ICloudTableClient ServiceClient
        {
            get { return _cloudTableClientAdapter; }
        }
        public string Name { get; set; }
        public Uri Uri { get; set; }

        public CloudTableAdapter(Uri tableAbsoluteUri, StorageCredentials credentials)
        {
            _cloudTable = new CloudTable(tableAbsoluteUri, credentials);
            _cloudTableClientAdapter = new CloudTableClientAdapter(_cloudTable.ServiceClient);
        }

        public CloudTableAdapter(Uri address, CloudTableClient client)
        {
            _cloudTable = new CloudTable(address, client.Credentials);
            _cloudTableClientAdapter = new CloudTableClientAdapter(_cloudTable.ServiceClient);
        }

        public CloudTableAdapter(CloudTable cloudTable)
        {
            _cloudTable = cloudTable;
            _cloudTableClientAdapter = new CloudTableClientAdapter(_cloudTable.ServiceClient);
        }

        public TableResult Execute(TableOperation operation, TableRequestOptions requestOptions = null,
                                   OperationContext operationContext = null)
        {
            return _cloudTable.Execute(operation, requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginExecute(TableOperation operation, AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExecute(operation, callback, state);
        }

        public ICancellableAsyncResult BeginExecute(TableOperation operation, TableRequestOptions requestOptions,
                                                    OperationContext operationContext, AsyncCallback callback,
                                                    object state)
        {
            return _cloudTable.BeginExecute(operation, requestOptions, operationContext, callback, state);
        }

        public TableResult EndExecute(IAsyncResult asyncResult)
        {
            return _cloudTable.EndExecute(asyncResult);
        }

        public IList<TableResult> ExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions = null,
                                  OperationContext operationContext = null)
        {
            return _cloudTable.ExecuteBatch(batch,requestOptions,operationContext);
        }

        public ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExecuteBatch(batch, callback, state);
        }

        public ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions,
                                                         OperationContext operationContext, AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExecuteBatch(batch, requestOptions, operationContext, callback, state);
        }

        public IList<TableResult> EndExecuteBatch(IAsyncResult asyncResult)
        {
            return _cloudTable.EndExecuteBatch(asyncResult);
        }

        public IEnumerable<DynamicTableEntity> ExecuteQuery(TableQuery query, TableRequestOptions requestOptions = null,
                                        OperationContext operationContext = null)
        {
            return _cloudTable.ExecuteQuery(query,requestOptions,operationContext);
        }

        public ITableQuerySegment<DynamicTableEntity> ExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                       TableRequestOptions requestOptions = null,
                                                       OperationContext operationContext = null)
        {
            var result = _cloudTable.ExecuteQuerySegmented(query, token, requestOptions, operationContext);
            return new TableQuerySegmentAdapter<DynamicTableEntity>(result);
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                                  AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExecuteQuerySegmented(query, token, r =>
            {
                var t = new AdapterAsyncResult<ITableQuerySegment<DynamicTableEntity>>(r,
                                                                    new TableQuerySegmentAdapter<DynamicTableEntity>(
                                                                        r.AsyncState as TableQuerySegment<DynamicTableEntity>));
                callback(t);
            }, state);
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                                  TableRequestOptions requestOptions, OperationContext operationContext,
                                                                  AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExecuteQuerySegmented(query, token, requestOptions, operationContext, r =>
            {
                var t = new AdapterAsyncResult<ITableQuerySegment<DynamicTableEntity>>(r,
                                                                    new TableQuerySegmentAdapter<DynamicTableEntity>(
                                                                        r.AsyncState as TableQuerySegment<DynamicTableEntity>));
                callback(t);
            }, state);
        }

        public ITableQuerySegment<DynamicTableEntity> EndExecuteQuerySegmented(IAsyncResult asyncResult)
        {
            var result = _cloudTable.EndExecuteQuerySegmented(asyncResult);
            return new TableQuerySegmentAdapter<DynamicTableEntity>(result);
        }

        public IEnumerable<TElement> ExecuteQuery<TElement>(TableQuery<TElement> query, TableRequestOptions requestOptions = null,
                                                  OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            return _cloudTable.ExecuteQuery(query, requestOptions, operationContext);
        }

        public ITableQuerySegment<TElement> ExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token,
                                                                 TableRequestOptions requestOptions = null,
                                                                 OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            return new TableQuerySegmentAdapter<TElement>(_cloudTable.ExecuteQuerySegmented(query, token, requestOptions, operationContext));
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token,
                                                                            AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            return _cloudTable.BeginExecuteQuerySegmented(query, token, r =>
            {
                var t = new AdapterAsyncResult<ITableQuerySegment<TElement>>(r,
                                                                    new TableQuerySegmentAdapter<TElement>(
                                                                        r.AsyncState as TableQuerySegment<TElement>));
                callback(t);
            }, state);
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token,
                                                                            TableRequestOptions requestOptions,
                                                                            OperationContext operationContext, AsyncCallback callback,
                                                                            object state) where TElement : ITableEntity, new()
        {
            return _cloudTable.BeginExecuteQuerySegmented(query, token, requestOptions, operationContext, r =>
            {
                var t = new AdapterAsyncResult<ITableQuerySegment<TElement>>(r,
                                                                    new TableQuerySegmentAdapter<TElement>(
                                                                        r.AsyncState as TableQuerySegment<TElement>));
                callback(t);
            }, state);
        }

        public ITableQuerySegment<TElement> EndExecuteQuerySegmented<TElement>(IAsyncResult asyncResult)
        {
            return new TableQuerySegmentAdapter<TElement>(_cloudTable.EndExecuteQuerySegmented<TElement>(asyncResult));
        }

        public IEnumerable<R> ExecuteQuery<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                     TableRequestOptions requestOptions = null,
                                                     OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            return _cloudTable.ExecuteQuery(query, resolver, requestOptions, operationContext);
        }

        public ITableQuerySegment<R> ExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                                    TableContinuationToken token,
                                                                    TableRequestOptions requestOptions = null,
                                                                    OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            return
                new TableQuerySegmentAdapter<R>(_cloudTable.ExecuteQuerySegmented(query, resolver, token, requestOptions,
                                                                                  operationContext));
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                                               TableContinuationToken token, AsyncCallback callback,
                                                                               object state) where TElement : ITableEntity, new()
        {
            return _cloudTable.BeginExecuteQuerySegmented(query, resolver, token, r =>
            {
                var t = new AdapterAsyncResult<ITableQuerySegment<R>>(r,
                                                                    new TableQuerySegmentAdapter<R>(
                                                                        r.AsyncState as TableQuerySegment<R>));
                callback(t);
            }, state);
        }

        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                                               TableContinuationToken token,
                                                                               TableRequestOptions requestOptions,
                                                                               OperationContext operationContext,
                                                                               AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            return _cloudTable.BeginExecuteQuerySegmented(query, resolver, token, requestOptions, operationContext,
                                                          r =>
                                                          {
                                                              var t = new AdapterAsyncResult<ITableQuerySegment<R>>(r,
                                                                                                                  new TableQuerySegmentAdapter<R>(
                                                                                                                      r.AsyncState as TableQuerySegment<R>));
                                                              callback(t);
                                                          }, state);
        }

        public ITableQuerySegment<R> EndExecuteQuerySegmented<TElement, R>(IAsyncResult asyncResult)
        {
            return new TableQuerySegmentAdapter<R>(_cloudTable.EndExecuteQuerySegmented<R>(asyncResult));
        }

        public ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return _cloudTable.BeginCreate(callback, state);
        }

        public ICancellableAsyncResult BeginCreate(TableRequestOptions requestOptions, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            return _cloudTable.BeginCreate(requestOptions, operationContext, callback, state);
        }

        public void EndCreate(IAsyncResult asyncResult)
        {
            _cloudTable.EndCreate(asyncResult);
        }

        public void Create(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            _cloudTable.Create(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            return _cloudTable.BeginCreateIfNotExists(callback, state);
        }

        public ICancellableAsyncResult BeginCreateIfNotExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                              AsyncCallback callback, object state)
        {
            return _cloudTable.BeginCreateIfNotExists(requestOptions, operationContext, callback, state);
        }

        public bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            return _cloudTable.EndCreateIfNotExists(asyncResult);
        }

        public bool CreateIfNotExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return _cloudTable.CreateIfNotExists(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return _cloudTable.BeginDelete(callback, state);
        }

        public ICancellableAsyncResult BeginDelete(TableRequestOptions requestOptions, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            return _cloudTable.BeginDelete(requestOptions, operationContext, callback, state);
        }

        public void EndDelete(IAsyncResult asyncResult)
        {
            _cloudTable.EndDelete(asyncResult);
        }

        public void Delete(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            _cloudTable.Delete(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return _cloudTable.BeginDeleteIfExists(callback, state);
        }

        public ICancellableAsyncResult BeginDeleteIfExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                           AsyncCallback callback, object state)
        {
            return _cloudTable.BeginDeleteIfExists(requestOptions, operationContext, callback, state);
        }

        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            return _cloudTable.EndDeleteIfExists(asyncResult);
        }

        public bool DeleteIfExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return _cloudTable.DeleteIfExists(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExists(callback, state);
        }

        public ICancellableAsyncResult BeginExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            return _cloudTable.BeginExists(requestOptions, operationContext, callback, state);
        }

        public bool EndExists(IAsyncResult asyncResult)
        {
            return _cloudTable.EndExists(asyncResult);
        }

        public bool Exists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return _cloudTable.Exists(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return _cloudTable.BeginGetPermissions(callback, state);
        }

        public ICancellableAsyncResult BeginGetPermissions(TableRequestOptions requestOptions, OperationContext operationContext,
                                                           AsyncCallback callback, object state)
        {
            return _cloudTable.BeginGetPermissions(requestOptions, operationContext, callback, state);
        }

        public TablePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return _cloudTable.EndGetPermissions(asyncResult);
        }

        public TablePermissions GetPermissions(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return _cloudTable.GetPermissions(requestOptions, operationContext);
        }

        public ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, AsyncCallback callback, object state)
        {
            return _cloudTable.BeginSetPermissions(permissions, callback, state);
        }

        public ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, TableRequestOptions requestOptions,
                                                           OperationContext operationContext, AsyncCallback callback, object state)
        {

            return _cloudTable.BeginSetPermissions(permissions, requestOptions, operationContext, callback, state);
        }

        public void EndSetPermissions(IAsyncResult asyncResult)
        {
           _cloudTable.EndSetPermissions(asyncResult);
        }

        public void SetPermissions(TablePermissions permissions, TableRequestOptions requestOptions = null,
                                   OperationContext operationContext = null)
        {
            _cloudTable.SetPermissions(permissions, requestOptions, operationContext);
        }

        public string GetSharedAccessSignature(SharedAccessTablePolicy policy, string accessPolicyIdentifier, string startPartitionKey,
                                               string startRowKey, string endPartitionKey, string endRowKey)
        {
            return _cloudTable.GetSharedAccessSignature(policy, accessPolicyIdentifier, startPartitionKey, startRowKey,
                                                        endPartitionKey, endRowKey);
        }
    }
}
