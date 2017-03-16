using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NModelsoft.Azure.Adapters.Storage.Table
{
    public class AdapterAsyncResult<T> : IAsyncResult
    {
        public bool IsCompleted { get; set; }
        public WaitHandle AsyncWaitHandle { get; set; }
        public object AsyncState { get; set; }
        public bool CompletedSynchronously { get; set; }

        public AdapterAsyncResult(IAsyncResult result, T state)
        {
            IsCompleted = result.IsCompleted;
            AsyncWaitHandle = result.AsyncWaitHandle;
            AsyncState = state;
            CompletedSynchronously = result.CompletedSynchronously;
        }
    }
}
