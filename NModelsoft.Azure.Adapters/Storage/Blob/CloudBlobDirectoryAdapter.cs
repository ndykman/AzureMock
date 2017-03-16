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
    public class CloudBlobDirectoryAdapter : ICloudBlobDirectory
    {
        public Uri Uri { get; private set; }
        public string Prefix { get; private set; }

        public IEnumerable<IListBlobItem> ListBlobs(bool useFlatBlobListing = false, BlobListingDetails blobListingDetails = BlobListingDetails.None,
                                     BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment ListBlobsSegmented(BlobContinuationToken currentToken)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment ListBlobsSegmented(bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults,
                                                    BlobContinuationToken currentToken, BlobRequestOptions options,
                                                    OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginListBlobsSegmented(BlobContinuationToken currentToken, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginListBlobsSegmented(bool useFlatBlobListing, BlobListingDetails blobListingDetails,
                                                               int? maxResults, BlobContinuationToken currentToken,
                                                               BlobRequestOptions options, OperationContext operationContext,
                                                               AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment EndListBlobsSegmented(IAsyncResult asyncResult)
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

        public CloudBlobDirectory GetSubdirectoryReference(string itemName)
        {
            throw new NotImplementedException();
        }

        public CloudBlobClient ServiceClient { get; private set; }
        public CloudBlobDirectory Parent { get; private set; }
        public CloudBlobContainer Container { get; private set; }
        public StorageUri StorageUri { get; private set; }
    }
}
