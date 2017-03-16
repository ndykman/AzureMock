using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace NModelsoft.Azure.Storage.Blob
{
    /// <summary>
    /// Represents a container in the Windows Azure Blob service.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Containers hold directories, which are encapsulated as <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobDirectory"/> objects, and directories hold block blobs and page blobs. Directories can also contain sub-directories.
    /// </remarks>
    /// 
    /// <summary>
    /// Represents a container in the Windows Azure Blob service.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Containers hold directories, which are encapsulated as <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobDirectory"/> objects, and directories hold block blobs and page blobs. Directories can also contain sub-directories.
    /// </remarks>
    public interface ICloudBlobContainer
    {
        /// <summary>
        /// Gets the service client for the container.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// A client object that specifies the endpoint for the Blob service.
        /// </value>
        ICloudBlobClient ServiceClient { get; }

        /// <summary>
        /// Gets the container's URI.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The absolute URI to the container.
        /// </value>
        Uri Uri { get; }

        /// <summary>
        /// Gets the name of the container.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The container's name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the container's metadata.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The container's metadata.
        /// </value>
        IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Gets the container's system properties.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The container's properties.
        /// </value>
        BlobContainerProperties Properties { get; }

        /// <summary>
        /// Creates the container.
        /// 
        /// </summary>
        /// <param name="requestOptions">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation. This object
        ///             is used to track requests to the storage service, and to provide additional runtime information about the operation. </param>
        [DoesServiceRequest]
        void Create(BlobRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to create a container.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to create a container.
        /// 
        /// </summary>
        /// <param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreate(BlobRequestOptions options, OperationContext operationContext,
                                                  AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to create a container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndCreate(IAsyncResult asyncResult);

        /// <summary>
        /// Creates the container if it does not already exist.
        /// 
        /// </summary>
        /// <param name="requestOptions">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// <c>true</c> if the container did not already exist and was created; otherwise <c>false</c>.
        /// </returns>
        [DoesServiceRequest]
        bool CreateIfNotExists(BlobRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// 
        /// </summary>
        /// <param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginCreateIfNotExists(BlobRequestOptions options,
                                                             OperationContext operationContext, AsyncCallback callback,
                                                             object state);

        /// <summary>
        /// Returns the result of an asynchronous request to create the container if it does not already exist.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// <c>true</c> if the container did not already exist and was created; otherwise, <c>false</c>.
        /// </returns>
        bool EndCreateIfNotExists(IAsyncResult asyncResult);

        /// <summary>
        /// Deletes the container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void Delete(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                          OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDelete(AccessCondition accessCondition, BlobRequestOptions options,
                                                  OperationContext operationContext, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to delete a container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndDelete(IAsyncResult asyncResult);

        /// <summary>
        /// Deletes the container if it already exists.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// <c>true</c> if the container did not already exist and was created; otherwise <c>false</c>.
        /// </returns>
        [DoesServiceRequest]
        bool DeleteIfExists(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                  OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to delete the container if it already exists.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous request to delete the container if it already exists.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginDeleteIfExists(AccessCondition accessCondition, BlobRequestOptions options,
                                                          OperationContext operationContext, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Returns the result of an asynchronous request to delete the container if it already exists.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// <c>true</c> if the container did not already exist and was created; otherwise, <c>false</c>.
        /// </returns>
        bool EndDeleteIfExists(IAsyncResult asyncResult);

        /// <summary>
        /// Gets a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// A reference to the blob.
        /// </returns>
        [DoesServiceRequest]
        ICloudBlob GetBlobReferenceFromServer(string blobName, AccessCondition accessCondition = null,
                                                    BlobRequestOptions options = null,
                                                    OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to get a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetBlobReferenceFromServer(string blobName, AsyncCallback callback,
                                                                      object state);

        /// <summary>
        /// Begins an asynchronous operation to get a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetBlobReferenceFromServer(string blobName, AccessCondition accessCondition,
                                                                      BlobRequestOptions options,
                                                                      OperationContext operationContext,
                                                                      AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to get a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A reference to the blob.
        /// </returns>
        ICloudBlob EndGetBlobReferenceFromServer(IAsyncResult asyncResult);

        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// An enumerable collection of objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/> and are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<IListBlobItem> ListBlobs(string prefix = null, bool useFlatBlobListing = false,
                                                   BlobListingDetails blobListingDetails = BlobListingDetails.None,
                                                   BlobRequestOptions options = null,
                                                   OperationContext operationContext = null);

        /// <summary>
        /// Returns a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <returns>
        /// A result segment containing objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/>.
        /// </returns>
        [DoesServiceRequest]
        BlobResultSegment ListBlobsSegmented(BlobContinuationToken currentToken);

        /// <summary>
        /// Returns a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A continuation token returned by a previous listing operation.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// A result segment containing objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/>.
        /// </returns>
        [DoesServiceRequest]
        BlobResultSegment ListBlobsSegmented(string prefix, bool useFlatBlobListing,
                                                   BlobListingDetails blobListingDetails, int? maxResults,
                                                   BlobContinuationToken currentToken, BlobRequestOptions options,
                                                   OperationContext operationContext);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListBlobsSegmented(BlobContinuationToken currentToken, AsyncCallback callback,
                                                              object state);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A continuation token returned by a previous listing operation.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListBlobsSegmented(string prefix, bool useFlatBlobListing,
                                                              BlobListingDetails blobListingDetails, int? maxResults,
                                                              BlobContinuationToken currentToken,
                                                              BlobRequestOptions options,
                                                              OperationContext operationContext, AsyncCallback callback,
                                                              object state);

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A result segment containing objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/>.
        /// </returns>
        BlobResultSegment EndListBlobsSegmented(IAsyncResult asyncResult);

        /// <summary>
        /// Sets permissions for the container.
        /// 
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void SetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition = null,
                                  BlobRequestOptions options = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// 
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// 
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetPermissions(BlobContainerPermissions permissions,
                                                          AccessCondition accessCondition, BlobRequestOptions options,
                                                          OperationContext operationContext, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Returns the result of an asynchronous request to set permissions for the container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndSetPermissions(IAsyncResult asyncResult);

        /// <summary>
        /// Gets the permissions settings for the container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// The container's permissions.
        /// </returns>
        [DoesServiceRequest]
        BlobContainerPermissions GetPermissions(AccessCondition accessCondition = null,
                                                      BlobRequestOptions options = null,
                                                      OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetPermissions(AccessCondition accessCondition, BlobRequestOptions options,
                                                          OperationContext operationContext, AsyncCallback callback,
                                                          object state);

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// The container's permissions.
        /// </returns>
        BlobContainerPermissions EndGetPermissions(IAsyncResult asyncResult);

        /// <summary>
        /// Checks existence of the container.
        /// 
        /// </summary>
        /// <param name="requestOptions">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// <c>true</c> if the container exists.
        /// </returns>
        [DoesServiceRequest]
        bool Exists(BlobRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to check existence of the container.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExists(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous request to check existence of the container.
        /// 
        /// </summary>
        /// <param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginExists(BlobRequestOptions options, OperationContext operationContext,
                                                  AsyncCallback callback, object state);

        /// <summary>
        /// Returns the asynchronous result of the request to check existence of the container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// <c>true</c> if the container exists.
        /// </returns>
        bool EndExists(IAsyncResult asyncResult);

        /// <summary>
        /// Retrieves the container's attributes.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void FetchAttributes(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                   OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginFetchAttributes(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginFetchAttributes(AccessCondition accessCondition, BlobRequestOptions options,
                                                           OperationContext operationContext, AsyncCallback callback,
                                                           object state);

        /// <summary>
        /// Ends an asynchronous operation to retrieve the container's attributes.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndFetchAttributes(IAsyncResult asyncResult);

        /// <summary>
        /// Sets the container's user-defined metadata.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void SetMetadata(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                               OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetMetadata(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">An <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options,
                                                       OperationContext operationContext, AsyncCallback callback,
                                                       object state);

        /// <summary>
        /// Ends an asynchronous request operation to set user-defined metadata on the container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        void EndSetMetadata(IAsyncResult asyncResult);

        /// <summary>
        /// Acquires a lease on this container.
        /// 
        /// </summary>
        /// <param name="leaseTime">A <see cref="T:System.TimeSpan"/> representing the span of time for which to acquire the lease,
        ///             which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        ///             greater than zero.</param><param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// The ID of the acquired lease.
        /// </returns>
        [DoesServiceRequest]
        string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition = null,
                                  BlobRequestOptions options = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this container.
        /// 
        /// </summary>
        /// <param name="leaseTime">A <see cref="T:System.TimeSpan"/> representing the span of time for which to acquire the lease,
        ///             which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        ///             greater than zero.</param><param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId,
                                                        AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this container.
        /// 
        /// </summary>
        /// <param name="leaseTime">A <see cref="T:System.TimeSpan"/> representing the span of time for which to acquire the lease,
        ///             which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        ///             greater than zero.</param><param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId,
                                                        AccessCondition accessCondition, BlobRequestOptions options,
                                                        OperationContext operationContext, AsyncCallback callback,
                                                        object state);

        /// <summary>
        /// Ends an asynchronous operation to acquire a lease on this container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>
        /// The ID of the acquired lease.
        /// </returns>
        string EndAcquireLease(IAsyncResult asyncResult);

        /// <summary>
        /// Renews a lease on this container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void RenewLease(AccessCondition accessCondition, BlobRequestOptions options = null,
                              OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback,
                                                      object state);

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, BlobRequestOptions options,
                                                      OperationContext operationContext, AsyncCallback callback,
                                                      object state);

        /// <summary>
        /// Ends an asynchronous operation to renew a lease on this container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        void EndRenewLease(IAsyncResult asyncResult);

        /// <summary>
        /// Changes the lease ID on this container.
        /// 
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// The new lease ID.
        /// </returns>
        [DoesServiceRequest]
        string ChangeLease(string proposedLeaseId, AccessCondition accessCondition = null,
                                 BlobRequestOptions options = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this container.
        /// 
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition,
                                                       AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this container.
        /// 
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition,
                                                       BlobRequestOptions options, OperationContext operationContext,
                                                       AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to change the lease on this container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>
        /// The new lease ID.
        /// </returns>
        string EndChangeLease(IAsyncResult asyncResult);

        /// <summary>
        /// Releases the lease on this container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void ReleaseLease(AccessCondition accessCondition, BlobRequestOptions options = null,
                                OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback,
                                                        object state);

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this container.
        /// 
        /// </summary>
        /// <param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, BlobRequestOptions options,
                                                        OperationContext operationContext, AsyncCallback callback,
                                                        object state);

        /// <summary>
        /// Ends an asynchronous operation to release the lease on this container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        void EndReleaseLease(IAsyncResult asyncResult);

        /// <summary>
        /// Breaks the current lease on this container.
        /// 
        /// </summary>
        /// <param name="breakPeriod">A <see cref="T:System.TimeSpan"/> representing the amount of time to allow the lease to remain,
        ///             which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        ///             or zero for infinite leases.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> representing the amount of time before the lease ends, to the second.
        /// </returns>
        [DoesServiceRequest]
        TimeSpan BreakLease(TimeSpan? breakPeriod = null, AccessCondition accessCondition = null,
                                  BlobRequestOptions options = null, OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to break the current lease on this container.
        /// 
        /// </summary>
        /// <param name="breakPeriod">A <see cref="T:System.TimeSpan"/> representing the amount of time to allow the lease to remain,
        ///             which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        ///             or zero for infinite leases.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to break the current lease on this container.
        /// 
        /// </summary>
        /// <param name="breakPeriod">A <see cref="T:System.TimeSpan"/> representing the amount of time to allow the lease to remain,
        ///             which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        ///             or zero for infinite leases.</param><param name="accessCondition">An <see cref="T:Microsoft.WindowsAzure.Storage.AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">The options for this operation. If <c>null</c>, default options will be used.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition,
                                                      BlobRequestOptions options, OperationContext operationContext,
                                                      AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to break the current lease on this container.
        /// 
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> representing the amount of time before the lease ends, to the second.
        /// </returns>
        TimeSpan EndBreakLease(IAsyncResult asyncResult);

        /// <summary>
        /// Returns a shared access signature for the container.
        /// 
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <returns>
        /// A shared access signature.
        /// </returns>
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy);

        /// <summary>
        /// Returns a shared access signature for the container.
        /// 
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param><param name="groupPolicyIdentifier">A container-level access policy.</param>
        /// <returns>
        /// A shared access signature.
        /// </returns>
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier);

        /// <summary>
        /// Gets a reference to a page blob in this container.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>
        /// A reference to a page blob.
        /// </returns>
        CloudPageBlob GetPageBlobReference(string blobName);

        /// <summary>
        /// Returns a reference to a page blob in this virtual directory.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the page blob.</param><param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>
        /// A reference to a page blob.
        /// </returns>
        CloudPageBlob GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime);

        /// <summary>
        /// Gets a reference to a block blob in this container.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>
        /// A reference to a block blob.
        /// </returns>
        CloudBlockBlob GetBlockBlobReference(string blobName);

        /// <summary>
        /// Gets a reference to a block blob in this container.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param><param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>
        /// A reference to a block blob.
        /// </returns>
        CloudBlockBlob GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime);

        /// <summary>
        /// Gets a reference to a virtual blob directory beneath this container.
        /// 
        /// </summary>
        /// <param name="relativeAddress">The name of the virtual blob directory.</param>
        /// <returns>
        /// A reference to a virtual blob directory.
        /// </returns>
        ICloudBlobDirectory GetDirectoryReference(string relativeAddress);
    }
}
