using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Data.Repository;
using Quality.Measurement.System.Shared.BusinessLogic;
using Quality.Measurement.System.Shared.Helpers.Constants;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.BusinessLogic
{
    public class UserLogic : ILogic<User>
    {

        /// <summary>
        /// The _user repository
        /// </summary>
        private readonly IRepository<User> _repository;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic" /> class.
        /// </summary>
        /// <param name="repository">The _repository.</param>
        public UserLogic(IRepository<User> repository)
        {
            if (repository != null)
            {
                _repository = repository;
            }
        }


        /// <summary>
        /// Gets the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<User> Get(long userId)
        {
            CommandParameter commandParameter = new CommandParameter(CommandConstants.GetUserDetails,
                CommandExecutionType.ExecuteReaderAsync)
            {
                Parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.UserId,
                        Value = userId
                    }
                }
            };
            return await _repository.Get(commandParameter);
        }

        /// <summary>
        /// Posts the specified user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        public async Task<User> Post(User userInfo)
        {
            CommandParameter commandParameter = new CommandParameter(CommandConstants.InsertUserDetails,
                CommandExecutionType.ExecuteReaderAsync)
            {
                Parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.UserId,
                        Value = userInfo.UserId
                    },
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.UserName,
                        Value = userInfo.UserName
                    },
                    new  SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.FirstName,
                        Value = userInfo.FirstName
                    },
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.LastName,
                        Value = DatabaseFieldConstants.LastName
                    }
                }
            };
            return await _repository.Post(commandParameter);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}