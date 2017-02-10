using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Shared.Data.Repository
{
   public interface IDatabaseRepository : IDisposable
    {

        /// <summary>
        /// Databases the initialization.
        /// </summary>
        void DatabaseInitialization();
        /// <summary>
        /// Executes the reader asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<DbDataReader> ExecuteReaderAsync();
        /// <summary>
        /// Executes the non query asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> ExecuteNonQueryAsync();
        /// <summary>
        /// Executes the scalar asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<object> ExecuteScalarAsync();
        /// <summary>
        /// Initializes the database objects.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        void InitializeDbObjects(CommandParameter commandParameter);

    }
}
