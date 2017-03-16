using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;

namespace NModelsoft.Azure.Mock.Storage.Blob
{
    public class MockCloudBlobClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient"/> class using the specified Blob service endpoint
        ///             and anonymous credentials.
        /// 
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        public MockCloudBlobClient(Uri baseUri)
            : this(baseUri, (StorageCredentials)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient"/> class using the specified Blob service endpoint
        ///             and account credentials.
        /// 
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param><param name="credentials">The account credentials.</param>
        public MockCloudBlobClient(Uri baseUri, StorageCredentials credentials)
        {
        }
    }
}
