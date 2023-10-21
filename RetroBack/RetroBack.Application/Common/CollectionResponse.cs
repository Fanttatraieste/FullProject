using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Application.Common
{
    public class CollectionResponse<T>
    {
        public CollectionResponse(IList<T> records, int totalNumberOfRecords)
        {
            Records = records;
            TotalNumberOfRecords = totalNumberOfRecords;
        }

        public IList<T> Records { get; set; }

        public int TotalNumberOfRecords { get; set; }
    }
}
