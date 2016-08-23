using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Data.Repository;
using Quality.Measurement.System.Shared.BusinessLogic;
using Quality.Measurement.System.Shared.Helpers.Constants;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.BusinessLogic
{
    public class UserLogic : IUserLogic
    {

        /// <summary>
        /// The _user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserLogic(IUserRepository userRepository)
        {
            if (userRepository != null)
            {
                _userRepository = userRepository;
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
            return await _userRepository.Get(commandParameter);
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}