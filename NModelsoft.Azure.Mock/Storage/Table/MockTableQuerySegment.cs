using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Mock.Storage.Table
{
    public class MockTableQuerySegment<T> : ITableQuerySegment<T>
    {
        public TableContinuationToken ContinuationToken { get; set; }
        public List<T> Results { get; set; }
    }
}
