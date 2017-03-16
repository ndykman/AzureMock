using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace NModelsoft.Azure.Storage.Table
{
    public interface ITableResultSegment : IEnumerable<ICloudTable>
    {
        /// <summary>
        /// Gets an enumerable collection of ICloudTable results.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// An enumerable collection of results.
        /// </value>
        IList<ICloudTable> Results { get; }

        /// <summary>
        /// Gets a continuation token to use to retrieve the next set of results with a subsequent call to the operation.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// The continuation token.
        /// </value>
        TableContinuationToken ContinuationToken { get; }
    }
}
