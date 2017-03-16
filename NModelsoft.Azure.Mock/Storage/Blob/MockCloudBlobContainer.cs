using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;

namespace NModelsoft.Azure.Mock.Storage.Blob
{
    public class MockCloudBlobContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> class.
        /// 
        /// </summary>
        /// <param name="containerAddress">The absolute URI to the container.</param>
        public MockCloudBlobContainer(Uri containerAddress)
            : this(containerAddress, (StorageCredentials)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer"/> class.
        /// 
        /// </summary>
        /// <param name="containerAddress">The absolute URI to the container.</param><param name="credentials">The account credentials.</param>
        public MockCloudBlobContainer(Uri containerAddress, StorageCredentials credentials)
        {

        }
    }
}
