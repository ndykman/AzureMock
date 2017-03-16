// Type: Microsoft.WindowsAzure.Storage.Blob.CloudBlobDirectory
// Assembly: Microsoft.WindowsAzure.Storage, Version=2.0.0.0, Culture=neutral, KeyToken=31bf3856ad364e35
// Assembly location: C:\Program Files\Microsoft SDKs\Windows Azure\.NET SDK\v2.0\ref\Microsoft.WindowsAzure.Storage.dll

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core.Util;
using System;
using System.Collections.Generic;

namespace NModelsoft.Azure.Storage.Blob
{
    /// <summary>
    /// Represents a virtual directory of blobs, designated by a delimiter character.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Containers, which are encapsulated as <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> objects, hold directories, and directories hold block blobs and page blobs. Directories can also contain sub-directories.
    /// </remarks>
    /// 
    /// <summary>
    /// Represents a virtual directory of blobs on the client which emulates a hierarchical data store by using delimiter characters.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Containers, which are encapsulated as <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> objects, hold directories, and directories hold block blobs and page blobs. Directories can also contain sub-directories.
    /// </remarks>
    public interface ICloudBlobDirectory : IListBlobItem
    {
        /// <summary>
        /// Gets the service client for the virtual directory.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// A client object that specifies the endpoint for the Windows Azure Blob service.
        /// </value>
        CloudBlobClient ServiceClient { get; }

        /// <summary>
        /// Gets the prefix.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The prefix.
        /// </value>
        string Prefix { get; }

        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// 
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="options">An object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// An enumerable collection of objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/> and are retrieved lazily.
        /// </returns>
        [DoesServiceRequest]
        IEnumerable<IListBlobItem> ListBlobs(bool useFlatBlobListing = false,
                                                   BlobListingDetails blobListingDetails = BlobListingDetails.None,
                                                   BlobRequestOptions options = null,
                                                   OperationContext operationContext = null);

        /// <summary>
        /// 
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
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A continuation token returned by a previous listing operation.</param><param name="options">An object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>
        /// A result segment containing objects that implement <see cref="T:Microsoft.WindowsAzure.Storage.Blob.IListBlobItem"/>.
        /// </returns>
        [DoesServiceRequest]
        BlobResultSegment ListBlobsSegmented(bool useFlatBlobListing, BlobListingDetails blobListingDetails,
                                                   int? maxResults, BlobContinuationToken currentToken,
                                                   BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:System.IAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListBlobsSegmented(BlobContinuationToken currentToken,
                                                              AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items
        ///             in the container.
        /// 
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param><param name="blobListingDetails">A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.BlobListingDetails"/> enumeration describing which items to include in the listing.</param><param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the
        ///             per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param><param name="currentToken">A continuation token returned by a previous listing operation.</param><param name="options">An object that specifies any additional options for the request.</param><param name="operationContext">An <see cref="T:Microsoft.WindowsAzure.Storage.OperationContext"/> object that represents the context for the current operation.</param><param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param><param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="T:System.IAsyncResult"/> that references the asynchronous operation.
        /// </returns>
        [DoesServiceRequest]
        ICancellableAsyncResult BeginListBlobsSegmented(bool useFlatBlobListing,
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
        /// Gets a reference to a page blob in this virtual directory.
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
        /// Gets a reference to a block blob in this virtual directory.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>
        /// A reference to a block blob.
        /// </returns>
        CloudBlockBlob GetBlockBlobReference(string blobName);

        /// <summary>
        /// Gets a reference to a block blob in this virtual directory.
        /// 
        /// </summary>
        /// <param name="blobName">The name of the blob.</param><param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>
        /// A reference to a block blob.
        /// </returns>
        CloudBlockBlob GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime);

        /// <summary>
        /// Returns a virtual subdirectory within this virtual directory.
        /// 
        /// </summary>
        /// <param name="itemName">The name of the virtual subdirectory.</param>
        /// <returns>
        /// A <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobDirectory"/> object representing the virtual subdirectory.
        /// </returns>
        CloudBlobDirectory GetSubdirectoryReference(string itemName);
    }
}
