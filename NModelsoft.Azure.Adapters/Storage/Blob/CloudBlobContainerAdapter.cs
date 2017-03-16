using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using NModelsoft.Azure.Storage.Blob;

namespace NModelsoft.Azure.Adapters.Storage.Blob
{
    public class CloudBlobContainerAdapter : ICloudBlobContainer
    {
        public ICloudBlobClient ServiceClient { get; private set; }
        public Uri Uri { get; private set; }
        public string Name { get; private set; }
        public IDictionary<string, string> Metadata { get; private set; }
        public BlobContainerProperties Properties { get; private set; }
        public void Create(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginCreate(BlobRequestOptions options, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndCreate(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public bool CreateIfNotExists(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginCreateIfNotExists(BlobRequestOptions options, OperationContext operationContext,
                                                              AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void Delete(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                           OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginDelete(AccessCondition accessCondition, BlobRequestOptions options,
                                                   OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDelete(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public bool DeleteIfExists(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                   OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginDeleteIfExists(AccessCondition accessCondition, BlobRequestOptions options,
                                                           OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public ICloudBlob GetBlobReferenceFromServer(string blobName, AccessCondition accessCondition = null,
                                                     BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetBlobReferenceFromServer(string blobName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetBlobReferenceFromServer(string blobName, AccessCondition accessCondition,
                                                                       BlobRequestOptions options, OperationContext operationContext,
                                                                       AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICloudBlob EndGetBlobReferenceFromServer(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IListBlobItem> ListBlobs(string prefix = null, bool useFlatBlobListing = false,
                                     BlobListingDetails blobListingDetails = BlobListingDetails.None, BlobRequestOptions options = null,
                                     OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment ListBlobsSegmented(BlobContinuationToken currentToken)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment ListBlobsSegmented(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails,
                                                    int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options,
                                                    OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginListBlobsSegmented(BlobContinuationToken currentToken, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginListBlobsSegmented(string prefix, bool useFlatBlobListing,
                                                               BlobListingDetails blobListingDetails, int? maxResults,
                                                               BlobContinuationToken currentToken, BlobRequestOptions options,
                                                               OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment EndListBlobsSegmented(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void SetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition = null,
                                   BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition,
                                                           BlobRequestOptions options, OperationContext operationContext,
                                                           AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public BlobContainerPermissions GetPermissions(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                                       OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetPermissions(AccessCondition accessCondition, BlobRequestOptions options,
                                                           OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public BlobContainerPermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public bool Exists(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginExists(BlobRequestOptions options, OperationContext operationContext,
                                                   AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public bool EndExists(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void FetchAttributes(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                    OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginFetchAttributes(AccessCondition accessCondition, BlobRequestOptions options,
                                                            OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void SetMetadata(AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options,
                                                        OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition = null,
                                   BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AsyncCallback callback,
                                                         object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition,
                                                         BlobRequestOptions options, OperationContext operationContext,
                                                         AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public string EndAcquireLease(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void RenewLease(AccessCondition accessCondition, BlobRequestOptions options = null,
                               OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, BlobRequestOptions options,
                                                       OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndRenewLease(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public string ChangeLease(string proposedLeaseId, AccessCondition accessCondition = null, BlobRequestOptions options = null,
                                  OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, AsyncCallback callback,
                                                        object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition,
                                                        BlobRequestOptions options, OperationContext operationContext,
                                                        AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public string EndChangeLease(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void ReleaseLease(AccessCondition accessCondition, BlobRequestOptions options = null,
                                 OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, BlobRequestOptions options,
                                                         OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndReleaseLease(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public TimeSpan BreakLease(TimeSpan? breakPeriod = null, AccessCondition accessCondition = null,
                                   BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition,
                                                       BlobRequestOptions options, OperationContext operationContext,
                                                       AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public TimeSpan EndBreakLease(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            throw new NotImplementedException();
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            throw new NotImplementedException();
        }

        public CloudPageBlob GetPageBlobReference(string blobName)
        {
            throw new NotImplementedException();
        }

        public CloudPageBlob GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            throw new NotImplementedException();
        }

        public CloudBlockBlob GetBlockBlobReference(string blobName)
        {
            throw new NotImplementedException();
        }

        public CloudBlockBlob GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            throw new NotImplementedException();
        }

        public ICloudBlobDirectory GetDirectoryReference(string relativeAddress)
        {
            throw new NotImplementedException();
        }
    }
}
