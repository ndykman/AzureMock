using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Adapters.Storage.Table
{
   
    public class TableQuerySegmentAdapter<T> : ITableQuerySegment<T>
    {
        public TableContinuationToken ContinuationToken { get; set; }
        public List<T> Results { get; set; }

        public TableQuerySegmentAdapter(TableQuerySegment<T> segment)
        {
            ContinuationToken = segment.ContinuationToken;
            Results = segment.Results;
        }
    }
}
