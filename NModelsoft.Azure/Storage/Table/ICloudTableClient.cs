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

namespace NModelsoft.Azure.Storage.Table
{
    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Table Service. This client is used to configure and execute requests against the Table Service.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The service client encapsulates the base URI for the Table service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.
    /// </remarks>
    /// 
    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Table Service. This client is used to configure and execute requests against the Table Service.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The service client encapsulates the base URI for the Table Service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.
    /// </remarks>
    public interface ICloudTableClient
    {
        StorageCredentials Credentials { get; }

        /// <summary>
        /// Gets the base URI for the Blob service client.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The base URI used to construct the Blob service client.
        /// </value>
        Uri BaseUri { get; }

        /// <summary>
        /// Returns an enumerable collection of tables that begin with the specified prefix and that are retrieved lazily.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An enumerable collection of tables that are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<ICloudTable> ListTables();

        /// <summary>
        /// Returns an enumerable collection of tables, which are retrieved lazily, that begin with the specified prefix.
        /// 
        /// </summary>
        /// <param name="prefix">The table name prefix.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>
        /// An enumerable collection of tables that are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<ICloudTable> ListTables(string prefix, TableRequestOptions requestOptions = null,
                                                 OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of tables
        ///             in the storage account.
        /// 
        /// </summary>
        /// <param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> returned by a previous listing operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListTablesSegmented(TableContinuationToken currentToken,
                                                               AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection
        ///             of tables beginning with the specified prefix.
        /// 
        /// </summary>
        /// <param name="prefix">The table name prefix.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> returned by a previous listing operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListTablesSegmented(string prefix, TableContinuationToken currentToken,
                                                               AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection
        ///             of tables beginning with the specified prefix.
        /// 
        /// </summary>
        /// <param name="prefix">The table name prefix.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is zero the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> returned by a previous listing operation.</param><param name="requestOptions">The server timeout, maximum execution time, and retry policies for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListTablesSegmented(string prefix, int? maxResults,
                                                               TableContinuationToken currentToken,
                                                               TableRequestOptions requestOptions,
                                                               OperationContext operationContext,
                                                               AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection
        ///             of tables.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A result segment containing tables.
        /// </returns>
        ITableResultSegment EndListTablesSegmented(IAsyncResult asyncResult);

        /// <summary>
        /// Returns an enumerable collection of tables in the storage account.
        /// 
        /// </summary>
        /// <param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>
        /// An enumerable collection of tables.
        /// </returns>
        [DoesServiceRequest]
        ITableResultSegment ListTablesSegmented(TableContinuationToken currentToken);

        /// <summary>
        /// Returns an enumerable collection of tables, which are retrieved lazily, that begin with the specified prefix.
        /// 
        /// </summary>
        /// <param name="prefix">The table name prefix.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>
        /// An enumerable collection of tables that are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        ITableResultSegment ListTablesSegmented(string prefix, TableContinuationToken currentToken);

        /// <summary>
        /// Returns an enumerable collection of tables that begin with the specified prefix and that are retrieved lazily.
        /// 
        /// </summary>
        /// <param name="prefix">The table name prefix.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is zero the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableContinuationToken"/> returned by a previous listing operation.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>
        /// An enumerable collection of tables that are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        ITableResultSegment ListTablesSegmented(string prefix, int? maxResults,
                                                     TableContinuationToken currentToken,
                                                     TableRequestOptions requestOptions = null,
                                                     OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the table service.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the table service.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetServiceProperties(TableRequestOptions requestOptions,
                                                                OperationContext operationContext,
                                                                AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to get the properties of the table service.
        /// 
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="M:Microsoft.WindowsAzure.Storage.Table.CloudTableClient.BeginGetServiceProperties(System.AsyncCallback,System.Object)"/>.</param>
        /// <returns>
        /// The table service properties.
        /// </returns>
        ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult);

        /// <summary>
        /// Gets the properties of the table service.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>
        /// The table service properties as a <see cref="T:Microsoft.WindowsAzure.Storage.Shared.Protocol.ServiceProperties"/> object.
        /// </returns>
        [DoesServiceRequest]
        ServiceProperties GetServiceProperties(TableRequestOptions requestOptions = null,
                                                     OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the table service.
        /// 
        /// </summary>
        /// <param name="properties">The table service properties.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback,
                                                                object state);

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the table service.
        /// 
        /// </summary>
        /// <param name="properties">The table service properties.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties,
                                                                TableRequestOptions requestOptions,
                                                                OperationContext operationContext,
                                                                AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to set the properties of the table service.
        /// 
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="M:Microsoft.WindowsAzure.Storage.Table.CloudTableClient.BeginSetServiceProperties(Microsoft.WindowsAzure.Storage.Shared.Protocol.ServiceProperties,System.AsyncCallback,System.Object)"/></param>
        void EndSetServiceProperties(IAsyncResult asyncResult);


        /// <summary>
        /// Sets the properties of the table service.
        /// 
        /// </summary>
        /// <param name="properties">The table service properties.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Table.TableRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that provides information on how the operation executed.</param>
        [DoesServiceRequest]
        void SetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions = null,
                                        OperationContext operationContext = null);

        /// <summary>
        /// Gets a reference to the table at the specified address.
        /// 
        /// </summary>
        /// <param name="tableAddress">Either the name of the table, or the absolute URI to the table.</param>
        /// <returns>
        /// A reference to the table.
        /// </returns>
        ICloudTable GetTableReference(string tableAddress);
    }
}
