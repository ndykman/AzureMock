using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Mock.Storage.Table
{
    public class MockTableResultSegment : ITableResultSegment
    { 
        public IEnumerator<ICloudTable> GetEnumerator()
        {
            return Results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IList<ICloudTable> Results { get; set; }
        public TableContinuationToken ContinuationToken { get; set; }
    }
}
