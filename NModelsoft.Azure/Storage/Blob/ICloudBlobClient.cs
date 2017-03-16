using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace NModelsoft.Azure.Storage.Blob
{
    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Blob Service. This client is used to configure and execute requests against the Blob Service.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The service client encapsulates the base URI for the Blob service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.
    /// </remarks>
    /// 
    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Blob Service. This client is used to configure and execute requests against the Blob Service.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The service client encapsulates the base URI for the Blob service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.
    /// </remarks>
    public interface ICloudBlobClient
    {
        /// <summary>
        /// Gets the account credentials used to create the Blob service client.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The account credentials.
        /// </value>
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
        /// Gets or sets the default retry policy for requests made via the Blob service client.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The retry policy.
        /// </value>
        IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the default server and client timeout for requests.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The server and client timeout interval.
        /// </value>
        TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximum execution time accross all potential retries.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The maximum execution time accross all potential retries.
        /// </value>
        TimeSpan? MaximumExecutionTime { get; set; }

        /// <summary>
        /// Gets or sets the default delimiter that may be used to create a virtual directory structure of blobs.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The default delimiter.
        /// </value>
        string DefaultDelimiter { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of a blob in bytes that may be uploaded as a single blob.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The maximum size of a blob, in bytes, that may be uploaded as a single blob,
        ///             ranging from between 1 and 64 MB inclusive.
        /// </value>
        long SingleBlobUploadThresholdInBytes { get; set; }

        /// <summary>
        /// Gets or sets the number of blocks that may be simultaneously uploaded when uploading a blob that is greater than
        ///             the value specified by the <see cref="P:Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient.SingleBlobUploadThresholdInBytes"/> property in size.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The number of parallel operations that may proceed.
        /// </value>
        int ParallelOperationThreadCount { get; set; }

        /// <summary>
        /// Returns an enumerable collection of containers.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An enumerable collection of containers.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<ICloudBlobContainer> ListContainers();

        /// <summary>
        /// Returns an enumerable collection of containers whose names
        ///             begin with the specified prefix and that are retrieved lazily.
        /// 
        /// </summary>
        /// <param name="prefix">The container name prefix.</param><param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// An enumerable collection of containers that are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<ICloudBlobContainer> ListContainers(string prefix, ContainerListingDetails detailsIncluded,
                                                             BlobRequestOptions options = null,
                                                             OperationContext operationContext = null);

        /// <summary>
        /// Returns a result segment containing a collection of <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> objects.
        /// 
        /// </summary>
        /// <param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>
        /// A result segment of containers.
        /// </returns>
        [DoesServiceRequest]
        ContainerResultSegment ListContainersSegmented(BlobContinuationToken currentToken);

        /// <summary>
        /// Returns a result segment containing a collection of containers whose names begin with the specified prefix.
        /// 
        /// </summary>
        /// <param name="prefix">The container name prefix.</param><param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned
        ///             in the result segment, up to the per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobContinuationToken"/> returned by a previous listing operation.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// A result segment of containers.
        /// </returns>
        [DoesServiceRequest]
        ContainerResultSegment ListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded,
                                                             int? maxResults, BlobContinuationToken currentToken,
                                                             BlobRequestOptions options = null,
                                                             OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of containers.
        /// 
        /// </summary>
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListContainersSegmented(BlobContinuationToken continuationToken,
                                                                   AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of containers
        ///             whose names begin with the specified prefix.
        /// 
        /// </summary>
        /// <param name="prefix">The container name prefix.</param><param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned
        ///             in the result segment, up to the per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param><param name="continuationToken">A continuation token returned by a previous listing operation.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded,
                                                                   int? maxResults,
                                                                   BlobContinuationToken continuationToken,
                                                                   BlobRequestOptions options,
                                                                   OperationContext operationContext,
                                                                   AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of containers.
        /// 
        /// </summary>
        /// <param name="asyncResult">An <see cref="T:System.IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>
        /// A result segment of containers.
        /// </returns>
        ContainerResultSegment EndListContainersSegmented(IAsyncResult asyncResult);

        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// An enumerable collection of objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/> and are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<IListBlobItem> ListBlobs(string prefix, bool useFlatBlobListing = false,
                                                   BlobListingDetails blobListingDetails = BlobListingDetails.None,
                                                   BlobRequestOptions options = null,
                                                   OperationContext operationContext = null);

        /// <summary>
        /// Returns a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>
        /// A result segment containing objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/>.
        /// </returns>
        [DoesServiceRequest]
        BlobResultSegment ListBlobsSegmented(string prefix, BlobContinuationToken currentToken);

        /// <summary>
        /// Returns a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobContinuationToken"/> returned by a previous listing operation.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
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
        /// <param name="prefix">The blob name prefix.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobContinuationToken"/> returned by a previous listing operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListBlobsSegmented(string prefix, BlobContinuationToken currentToken,
                                                              AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param><param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobContinuationToken"/> returned by a previous listing operation.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
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
        /// Gets a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="blobUri">The URI of the blob.</param><param name="accessCondition">An object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// A reference to the blob.
        /// </returns>
        [DoesServiceRequest]
        ICloudBlob GetBlobReferenceFromServer(Uri blobUri, AccessCondition accessCondition = null,
                                                    BlobRequestOptions options = null,
                                                    OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to get a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="blobUri">The URI of the blob.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetBlobReferenceFromServer(Uri blobUri, AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to get a reference to a blob in this container.
        /// 
        /// </summary>
        /// <param name="blobUri">The URI of the blob.</param><param name="accessCondition">An object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param><param name="options">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetBlobReferenceFromServer(Uri blobUri, AccessCondition accessCondition,
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
        /// Begins an asynchronous operation to get the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginGetServiceProperties(BlobRequestOptions requestOptions,
                                                                OperationContext operationContext, AsyncCallback callback,
                                                                object state);

        /// <summary>
        /// Ends an asynchronous operation to get the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see><cref>BeginGetServiceProperties</cref></see>.</param>
        /// <returns>
        /// The blob service properties.
        /// </returns>
        ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult);

        /// <summary>
        /// Gets the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// The blob service properties.
        /// </returns>
        [DoesServiceRequest]
        ServiceProperties GetServiceProperties(BlobRequestOptions requestOptions = null,
                                                     OperationContext operationContext = null);

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="properties">The blob service properties.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback,
                                                                object state);

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="properties">The blob service properties.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.WindowsAzure.Storage.ICancellableAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties,
                                                                BlobRequestOptions requestOptions,
                                                                OperationContext operationContext, AsyncCallback callback,
                                                                object state);

        /// <summary>
        /// Ends an asynchronous operation to set the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see><cref>BeginSetServiceProperties</cref></see>.</param>
        void EndSetServiceProperties(IAsyncResult asyncResult);

        /// <summary>
        /// Sets the properties of the blob service.
        /// 
        /// </summary>
        /// <param name="properties">The blob service properties.</param><param name="requestOptions">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        void SetServiceProperties(ServiceProperties properties, BlobRequestOptions requestOptions = null,
                                        OperationContext operationContext = null);

        /// <summary>
        /// Returns a reference to a <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> object.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the root container.
        /// </returns>
        ICloudBlobContainer GetRootContainerReference();

        /// <summary>
        /// Returns a reference to a <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> object with the specified name.
        /// 
        /// </summary>
        /// <param name="containerName">The name of the container, or an absolute URI to the container.</param>
        /// <returns>
        /// A reference to a container.
        /// </returns>
        ICloudBlobContainer GetContainerReference(string containerName);
    }
}

