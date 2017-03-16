using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using NModelsoft.Azure.Storage.Blob;

namespace NModelsoft.Azure.Adapters.Storage.Blob
{
    public class CloudBlobClientAdapter : ICloudBlobClient
    {
        public StorageCredentials Credentials { get; private set; }
        public Uri BaseUri { get; private set; }
        public IRetryPolicy RetryPolicy { get; set; }
        public TimeSpan? ServerTimeout { get; set; }
        public TimeSpan? MaximumExecutionTime { get; set; }
        public string DefaultDelimiter { get; set; }
        public long SingleBlobUploadThresholdInBytes { get; set; }
        public int ParallelOperationThreadCount { get; set; }
        public IEnumerable<ICloudBlobContainer> ListContainers()
        {
            throw new NotImplementedException();
        }

        public ContainerResultSegment EndListContainersSegmented(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment EndListBlobsSegmented(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetBlobReferenceFromServer(Uri blobUri, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICloudBlob EndGetBlobReferenceFromServer(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public ICloudBlobContainer GetRootContainerReference()
        {
            throw new NotImplementedException();
        }

        public ICloudBlobContainer GetContainerReference(string containerName)
        {
            throw new NotImplementedException();
        }

        public void SetServiceProperties(ServiceProperties properties, BlobRequestOptions requestOptions = null,
                                         OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, BlobRequestOptions requestOptions,
                                                                 OperationContext operationContext, AsyncCallback callback,
                                                                 object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ServiceProperties GetServiceProperties(BlobRequestOptions requestOptions = null,
                                                      OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetServiceProperties(BlobRequestOptions requestOptions, OperationContext operationContext,
                                                                 AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginGetBlobReferenceFromServer(Uri blobUri, AccessCondition accessCondition,
                                                                       BlobRequestOptions options, OperationContext operationContext,
                                                                       AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICloudBlob GetBlobReferenceFromServer(Uri blobUri, AccessCondition accessCondition = null,
                                                     BlobRequestOptions options = null, OperationContext operationContext = null)
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

        public ICancellableAsyncResult BeginListBlobsSegmented(string prefix, BlobContinuationToken currentToken,
                                                               AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment ListBlobsSegmented(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails,
                                                    int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options,
                                                    OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public BlobResultSegment ListBlobsSegmented(string prefix, BlobContinuationToken currentToken)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IListBlobItem> ListBlobs(string prefix, bool useFlatBlobListing = false, BlobListingDetails blobListingDetails = BlobListingDetails.None,
                                     BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded,
                                                                    int? maxResults, BlobContinuationToken continuationToken,
                                                                    BlobRequestOptions options, OperationContext operationContext,
                                                                    AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ICancellableAsyncResult BeginListContainersSegmented(BlobContinuationToken continuationToken, AsyncCallback callback,
                                                                    object state)
        {
            throw new NotImplementedException();
        }

        public ContainerResultSegment ListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded, int? maxResults,
                                                              BlobContinuationToken currentToken, BlobRequestOptions options = null,
                                                              OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public ContainerResultSegment ListContainersSegmented(BlobContinuationToken currentToken)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICloudBlobContainer> ListContainers(string prefix, ContainerListingDetails detailsIncluded, BlobRequestOptions options = null,
                                          OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }
    }
}
