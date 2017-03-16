using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace NModelsoft.Azure.Storage.Table
{
    public interface ITableQuerySegment<T>
    {
        TableContinuationToken ContinuationToken { get; }
        List<T> Results { get; } 
    }
}
