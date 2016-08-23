using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Quality.Measurement.System.Shared.Models;
using Quality.Measurement.System.Shared.Helpers.Constants;


namespace Quality.Measurement.System.Data.Repository
{
    public class BaseRepository
    {
        private Database _databaseObj;
        private DbCommand _databaseCommandObj;
        private DbConnection _databaseConnectionObj;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        public BaseRepository()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            _databaseObj = DatabaseFactory.CreateDatabase(GeneralConstants.QualityMeasurementConnectionString);
        }

        /// <summary>
        /// Executes the reader asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<DbDataReader> ExecuteReaderAsync()
        {
            //Execute Reader to get the result data
            DbDataReader dataReader = await _databaseCommandObj.ExecuteReaderAsync();
            if (dataReader != null && dataReader.HasRows)
            {
                return dataReader;
            }
            throw new Exception();
        }

        /// <summary>
        /// Executes the non query asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<int> ExecuteNonQueryAsync()
        {
            return await _databaseCommandObj.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// Executes the scalar asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<object> ExecuteScalarAsync()
        {
            return await _databaseCommandObj.ExecuteScalarAsync();
        }



        /// <summary>
        /// Initializes the database objects.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        internal void InitializeDbObjects(CommandParameter commandParameter)
        {
            if (commandParameter.CommandName == null)
                throw new ArgumentNullException(
                $"Command Name is not sent in CommandParameter class to initialize DB object. to create DB object.");

            _databaseConnectionObj = _databaseObj.CreateConnection();

            if (_databaseConnectionObj != null)
            {
                _databaseConnectionObj.Open();
                _databaseCommandObj = _databaseConnectionObj.CreateCommand();

                //Set command type, in our sample we will use stored procedure
                _databaseCommandObj.CommandType = commandParameter.CommandType;
                _databaseCommandObj.CommandText = commandParameter.CommandName;

                if (commandParameter.Parameters != null && commandParameter.Parameters.Any())
                {
                    foreach (SqlParameter sqlParameter in commandParameter.Parameters)
                    {
                        _databaseObj.AddInParameter(_databaseCommandObj, sqlParameter.ParameterName, sqlParameter.DbType,
                            sqlParameter.Value);
                    }
                }
            }
            else
            {
                throw new Exception(
                    $"Failed to create DB object using connection string '{GeneralConstants.QualityMeasurementConnectionString}' in app/web.config.");
            }
        }


        ///// <summary>
        ///// Executes the reader asynchronous.
        ///// </summary>
        ///// <param name="commandName">Name of the command.</param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public async Task<DbDataReader> ExecuteReaderAsync(string commandName)
        //{
        //    DatabaseConnectionObj = DatabaseObj.CreateConnection();
        //    DatabaseConnectionObj.Open();
        //    DatabaseCommandObj = DatabaseConnectionObj.CreateCommand();

        //    //Set command type, in our sample we will use stored procedure
        //    DatabaseCommandObj.CommandType = CommandType.StoredProcedure;
        //    DatabaseCommandObj.CommandText = commandName;
        //    DbParameter db = new SqlParameter();
        //    db.ParameterName = "UserId";
        //    db.DbType = DbType.Int64;
        //    db.Value = DateTime.MaxValue;
        //    DatabaseObj.AddInParameter(DatabaseCommandObj, db.ParameterName, db.DbType, db.Value);

        //    //Execute Reader to get the result data
        //    DbDataReader dataReader = await DatabaseCommandObj.ExecuteReaderAsync();
        //    if (dataReader != null && dataReader.HasRows)
        //    {
        //        return dataReader;
        //    }
        //    throw new Exception();
        //}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _databaseCommandObj.Dispose();
            _databaseObj = null;
            _databaseConnectionObj.Dispose();
        }
    }
}
