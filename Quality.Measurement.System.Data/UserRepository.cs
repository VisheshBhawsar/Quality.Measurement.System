using System;
using System.Data;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Models;
using Quality.Measurement.System.Shared.Data.Repository;
using Quality.Measurement.System.Shared.Helpers.DataSetExtensions;
using Quality.Measurement.System.Shared.Helpers.Constants;

namespace Quality.Measurement.System.Data.Repository
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        /// <summary>
        /// Gets the specified command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<User> Get(CommandParameter commandParameter)
        {
            InitializeDbObjects(commandParameter);
            using (DbDataReader dataReader = await ExecuteReaderAsync())
            {
                if (dataReader.HasRows)
                {
                    return MapTableToUserObject(dataReader);
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
        public async Task<User> Post(CommandParameter commandParameter)
        {
            InitializeDbObjects(commandParameter);
            using (DbDataReader dataReader = await ExecuteReaderAsync())
            {
                if (dataReader.HasRows)
                {
                    return MapTableToUserObject(dataReader);
                }
            }
            throw new Exception();
        }

        /// <summary>
        /// Maps the table to user object.
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static User MapTableToUserObject(DbDataReader dataReader)
        {
            DataTable dataTable = new DataTable();

            dataTable.Load(dataReader);
            // For multiple result set, we need to use dataReader.NextResult
            if (dataTable.IsTableDataPopulated())
            {
                IList<User> userList = dataTable.AsEnumerable().Select(row =>
                    new User
                    {
                        UserId = row.Field<int>(DatabaseFieldConstants.UserId),
                        UserName = row.Field<string>(DatabaseFieldConstants.UserName),
                        FirstName = row.Field<string>(DatabaseFieldConstants.FirstName),
                        LastName = row.Field<string>(DatabaseFieldConstants.LastName)
                    }).ToList();
                return userList.First();
            }
            throw new Exception();
        }
    }
}