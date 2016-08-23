using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quality.Measurement.System.Shared.Helpers.DataSetExtensions
{
    public static class DataSetExtensions
    {
        /// <summary>
        /// Determines whether [is table data populated].
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static bool IsTableDataPopulated(this DataTable dataTable)
        {
            return dataTable != null && dataTable.Rows.Count > 0;
        }
    }
}
