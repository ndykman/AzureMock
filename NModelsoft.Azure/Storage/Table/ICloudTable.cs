using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace NModelsoft.Azure.Storage.Table
{
    /// <summary>
    /// Represents a Windows Azure Table.
    /// 
    /// </summary>
    /// 
    /// <summary>
    /// Represents a Windows Azure Table.
    /// 
    /// </summary>
    public interface ICloudTable
    {
        /// <summary>
        /// Gets the <see cref="T:Microsoft.WindowsAzure.Storage.Table.CloudTableClient"/> object that represents the Table service.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// A client object that specifies the Table service endpoint.
        /// </value>
        ICloudTableClient ServiceClient { get; }

        /// <summary>
        /// Gets the table name.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The table name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the URI that identifies the table.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The address of the table.
        /// </value>
        Uri Uri { get; }

        /// <summary>
        /// Executes the operation on a table, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="operation">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableOperation"/> object that represents the operation to perform.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableResult"/> containing the result of executing the operation on the table.
        /// </returns>
        [DoesServiceRequest]
        TableResult Execute(TableOperation operation, TableRequestOptions requestOptions = null,
                                  OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous table operation.
        /// 
        /// </summary>
        /// <param name="operation">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableOperation"/> object that represents the operation to perform.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecute(TableOperation operation, AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous table operation using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="operation">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableOperation"/> object that represents the operation to perform.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecute(TableOperation operation, TableRequestOptions requestOptions,
                                                   OperationContext operationContext, AsyncCallback callback,
                                                   object state);

        /// <summary>
        /// Ends an asynchronous table operation.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableResult"/> containing the result executing the operation on the table.
        /// </returns>
        TableResult EndExecute(IAsyncResult asyncResult);

        /// <summary>
        /// Executes a batch operation on a table as an atomic operation, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="batch">The <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableBatchOperation"/> object representing the operations to execute on the table.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// An enumerable collection of <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableResult"/> objects that contains the results, in order, of each operation in the <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableBatchOperation"/> on the table.
        /// </returns>
        [DoesServiceRequest]
        IList<TableResult> ExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions = null,
                                              OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to execute a batch of operations on a table.
        /// 
        /// </summary>
        /// <param name="batch">The <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableBatchOperation"/> object representing the operations to execute on the table.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to execute a batch of operations on a table, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="batch">The <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableBatchOperation"/> object representing the operations to execute on the table.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions,
                                                        OperationContext operationContext, AsyncCallback callback,
                                                        object state);

        /// <summary>
        /// Ends an asynchronous batch of operations on a table.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A enumerable collection of type <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableResult"/> that contains the results, in order, of each operation in the <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableBatchOperation"/> on the table.
        /// </returns>
        [DoesServiceRequest]
        IList<TableResult> EndExecuteBatch(IAsyncResult asyncResult);

        /// <summary>
        /// Executes a query on a table, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> representing the query to execute.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// An enumerable collection of <see cref="T:Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity"/> objects, representing table entities returned by the query.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<DynamicTableEntity> ExecuteQuery(TableQuery query, TableRequestOptions requestOptions = null,
                                                           OperationContext operationContext = null);

        /// <summary>
        /// Executes a query in segmented mode with the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token, <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/>, and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> representing the query to execute.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuerySegment`1"/> object containing the results of executing the query.
        /// </returns>
        [DoesServiceRequest]
        ITableQuerySegment<DynamicTableEntity> ExecuteQuerySegmented(TableQuery query,
                                                                          TableContinuationToken token,
                                                                          TableRequestOptions requestOptions = null,
                                                                          OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous segmented query operation using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token.
        /// 
        /// </summary>
        /// <param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> representing the query to execute.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                                 AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token, <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/>, and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> representing the query to execute.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token,
                                                                 TableRequestOptions requestOptions,
                                                                 OperationContext operationContext,
                                                                 AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous segmented query operation.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuerySegment`1"/> object containing the results of executing the query.
        /// </returns>
        ITableQuerySegment<DynamicTableEntity> EndExecuteQuerySegmented(IAsyncResult asyncResult);

        /// <summary>
        /// Executes a query on a table, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><param name="query">A TableQuery instance specifying the table to query and the query parameters to use, specialized for a type T implementing TableEntity.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// An enumerable collection, specialized for type <c>TElement</c>, of the results of executing the query.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<TElement> ExecuteQuery<TElement>(TableQuery<TElement> query,
                                                           TableRequestOptions requestOptions = null,
                                                           OperationContext operationContext = null)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Queries a table in segmented mode using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token, <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/>, and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuerySegment`1"/>, specialized for type <c>TElement</c>, containing the results of executing the query.
        /// </returns>
        [DoesServiceRequest]
        ITableQuerySegment<TElement> ExecuteQuerySegmented<TElement>(TableQuery<TElement> query,
                                                                          TableContinuationToken token,
                                                                          TableRequestOptions requestOptions = null,
                                                                          OperationContext operationContext = null)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query,
                                                                           TableContinuationToken token,
                                                                           AsyncCallback callback, object state)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query,
                                                                           TableContinuationToken token,
                                                                           TableRequestOptions requestOptions,
                                                                           OperationContext operationContext,
                                                                           AsyncCallback callback, object state)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Ends an asynchronous segmented table query operation.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuerySegment`1"/>, specialized for type <c>TElement</c>, containing the results of executing the query.
        /// </returns>
        ITableQuerySegment<TElement> EndExecuteQuerySegmented<TElement>(IAsyncResult asyncResult);

        /// <summary>
        /// Executes a query, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>, applying the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> to the result.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><typeparam name="R">The type into which the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> will project the query results.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="resolver">An <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// An enumerable collection, containing the projection into type <c>R</c>, of the results of executing the query.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<R> ExecuteQuery<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver,
                                                       TableRequestOptions requestOptions = null,
                                                       OperationContext operationContext = null)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Executes a query in segmented mode with the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>, applying the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> to the results.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><typeparam name="R">The type into which the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> will project the query results.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="resolver">An <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuerySegment`1"/> containing the projection into type <c>R</c> of the results of executing the query.
        /// </returns>
        [DoesServiceRequest]
        ITableQuerySegment<R> ExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query,
                                                                      EntityResolver<R> resolver,
                                                                      TableContinuationToken token,
                                                                      TableRequestOptions requestOptions = null,
                                                                      OperationContext operationContext = null)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode, using the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> and <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><typeparam name="R">The type into which the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> will project the query results.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="resolver">An <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query,
                                                                        EntityResolver<R> resolver,
                                                                        TableContinuationToken token,
                                                                        AsyncCallback callback, object state)
            where TElement : ITableEntity, new();
        /// <summary>
        /// Begins an asynchronous operation to execute a query in segmented mode with the specified <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> continuation token, <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/>, and <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/>, applies the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> to the results.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><typeparam name="R">The type into which the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> will project the query results.</typeparam><param name="query">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param><param name="resolver">An <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param><param name="token">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query,
                                                                              EntityResolver<R> resolver,
                                                                              TableContinuationToken token,
                                                                              TableRequestOptions requestOptions,
                                                                              OperationContext operationContext,
                                                                              AsyncCallback callback, object state)
           where TElement : ITableEntity, new();

        /// <summary>
        /// Ends an asynchronous segmented table query operation.
        /// 
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam><typeparam name="R">The type into which the <see cref="T:Microsoft.WindowsAzure.Storage.Table.EntityResolver"/> will project the query results.</typeparam><param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableQuerySegment`1"/> containing the projection into type <c>R</c> of the results of executing the query.
        /// </returns>
        ITableQuerySegment<R> EndExecuteQuerySegmented<TElement, R>(IAsyncResult asyncResult);

        /// <summary>
        /// Begins an asynchronous operation to create a table.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to create a table.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreate(TableRequestOptions requestOptions, OperationContext operationContext,
                                                  AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to create a table.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndCreate(IAsyncResult asyncResult);

        /// <summary>
        /// Creates a table.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        [DoesServiceRequest]
        void Create(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to create a table if it does not already exist.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to create a table if it does not already exist.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreateIfNotExists(TableRequestOptions requestOptions,
                                                             OperationContext operationContext, AsyncCallback callback,
                                                             object state);

        /// <summary>
        /// Ends an asynchronous operation to determine whether a table exists.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// <c>true</c> if table exists; otherwise, <c>false</c>.
        /// </returns>
        bool EndCreateIfNotExists(IAsyncResult asyncResult);

        /// <summary>
        /// Creates the table if it does not already exist.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// <c>true</c> if table was created; otherwise, <c>false</c>.
        /// </returns>
        [DoesServiceRequest]
        bool CreateIfNotExists(TableRequestOptions requestOptions = null,
                                     OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to delete a table.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to delete a table.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDelete(TableRequestOptions requestOptions, OperationContext operationContext,
                                                  AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to delete a table.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndDelete(IAsyncResult asyncResult);

        /// <summary>
        /// Deletes a table.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        [DoesServiceRequest]
        void Delete(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to delete the tables if it exists.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to delete the tables if it exists.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDeleteIfExists(TableRequestOptions requestOptions,
                                                          OperationContext operationContext, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Ends an asynchronous operation to delete the tables if it exists.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// <c>true</c> if the table was deleted; otherwise, <c>false</c>.
        /// </returns>
        bool EndDeleteIfExists(IAsyncResult asyncResult);

        /// <summary>
        /// Deletes the table if it exists.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// <c>true</c> if the table was deleted; otherwise, <c>false</c>.
        /// </returns>
        [DoesServiceRequest]
        bool DeleteIfExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to determine whether a table exists.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExists(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to determine whether a table exists.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExists(TableRequestOptions requestOptions, OperationContext operationContext,
                                                  AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to determine whether a table exists.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// <c>true</c> if table exists; otherwise, <c>false</c>.
        /// </returns>
        bool EndExists(IAsyncResult asyncResult);

        /// <summary>
        /// Checks whether the table exists.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// <c>true</c> if table exists; otherwise, <c>false</c>.
        /// </returns>
        [DoesServiceRequest]
        bool Exists(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the table.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the table.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetPermissions(TableRequestOptions requestOptions,
                                                          OperationContext operationContext, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the table.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// The table's permissions.
        /// </returns>
        TablePermissions EndGetPermissions(IAsyncResult asyncResult);

        /// <summary>
        /// Gets the permissions settings for the table.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        /// <returns>
        /// The table's permissions.
        /// </returns>
        [DoesServiceRequest]
        TablePermissions GetPermissions(TableRequestOptions requestOptions = null,
                                              OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to set permissions for the table.
        /// 
        /// </summary>
        /// <param name="permissions">The permissions to apply to the table.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Begins an asynchronous request to set permissions for the table.
        /// 
        /// </summary>
        /// <param name="permissions">The permissions to apply to the table.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions,
                                                          TableRequestOptions requestOptions,
                                                          OperationContext operationContext, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the table.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndSetPermissions(IAsyncResult asyncResult);

        /// <summary>
        /// Sets the permissions settings for the table.
        /// 
        /// </summary>
        /// <param name="permissions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TablePermissions"/> object that represents the permissions to set.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object for tracking the current operation.</param>
        [DoesServiceRequest]
        void SetPermissions(TablePermissions permissions, TableRequestOptions requestOptions = null,
                                  OperationContext operationContext = null);

        /// <summary>
        /// Returns a shared access signature for the table.
        /// 
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param><param name="accessPolicyIdentifier">An access policy identifier.</param><param name="startPartitionKey">The start partition key, or null.</param><param name="startRowKey">The start row key, or null.</param><param name="endPartitionKey">The end partition key, or null.</param><param name="endRowKey">The end row key, or null.</param>
        /// <returns>
        /// A shared access signature.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the current credentials don't support creating a shared access signature.</exception>
        string GetSharedAccessSignature(SharedAccessTablePolicy policy, string accessPolicyIdentifier,
                                              string startPartitionKey, string startRowKey, string endPartitionKey,
                                              string endRowKey);

        /// <summary>
        /// Returns the name of the table.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The name of the table.
        /// </returns>
        string ToString();
    }
}
