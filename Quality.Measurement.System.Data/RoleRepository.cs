using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Data.Repository;
using Quality.Measurement.System.Shared.Helpers.Constants;
using Quality.Measurement.System.Shared.Helpers.DataSetExtensions;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Data.Repository
{
    public class RoleRepository : BaseRepository, IRepository<Role>
    {

        /// <summary>
        /// Gets the specified command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Role> Get(CommandParameter commandParameter)
        {
            InitializeDbObjects(commandParameter);
            using (DbDataReader dataReader = await ExecuteReaderAsync())
            {
                if (dataReader.HasRows)
                {
                    return MapTableToRoleObject(dataReader);
                }
            }
            throw new Exception();
        }


        /// <summary>
        /// Posts the specified command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Role> Post(CommandParameter commandParameter)
        {
            InitializeDbObjects(commandParameter);
            using (DbDataReader dataReader = await ExecuteReaderAsync())
            {
                if (dataReader.HasRows)
                {
                    return MapTableToRoleObject(dataReader);
                }
            }
            throw new Exception();
        }


        /// <summary>
        /// Maps the table to role object.
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static Role MapTableToRoleObject(DbDataReader dataReader)
        {
            DataTable dataTable = new DataTable();

            dataTable.Load(dataReader);
            // For multiple result set, we need to use dataReader.NextResult
            if (dataTable.IsTableDataPopulated())
            {
                IList<Role> roleList = dataTable.AsEnumerable().Select(row =>
                    new Role
                    {
                        RoleId = row.Field<int>(DatabaseFieldConstants.RoleId),
                        RoleName = row.Field<string>(DatabaseFieldConstants.RoleName),
                    }).ToList();
                return roleList.First();
            }
            throw new Exception();
        }
    }
}
