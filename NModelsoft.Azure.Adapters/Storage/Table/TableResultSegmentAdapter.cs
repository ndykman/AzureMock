using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using NModelsoft.Azure.Storage.Table;

namespace NModelsoft.Azure.Adapters.Storage.Table
{
    public class TableResultSegmentAdapter : ITableResultSegment 
    {
        public IEnumerator<ICloudTable> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IList<ICloudTable> Results { get; set; }
        public TableContinuationToken ContinuationToken { get; set; }

        public TableResultSegmentAdapter(TableResultSegment segment)
        {
            ContinuationToken = segment.ContinuationToken;
            Results = segment.Results.Select<CloudTable,ICloudTable>(ct => new CloudTableAdapter(ct)).ToList();
        }
    }
}
