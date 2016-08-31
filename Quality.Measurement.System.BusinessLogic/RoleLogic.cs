using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.BusinessLogic;
using Quality.Measurement.System.Shared.Data.Repository;
using Quality.Measurement.System.Shared.Helpers.Constants;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.BusinessLogic
{
    public class RoleLogic : ILogic<Role>
    {
        /// <summary>
        /// The role repository
        /// </summary>
        private readonly IRepository<Role> _roleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleLogic"/> class.
        /// </summary>
        /// <param name="roleRepository">The role repository.</param>
        public RoleLogic(IRepository<Role> roleRepository)
        {
            if (roleRepository != null)
            {
                _roleRepository = roleRepository;
            }
        }


        /// <summary>
        /// Gets the specified role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public async Task<Role> Get(long roleId)
        {
            CommandParameter commandParameter = new CommandParameter(CommandConstants.GetRoleDetails,
                CommandExecutionType.ExecuteReaderAsync)
            {
                Parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.RoleId,
                        Value = roleId
                    }
                }
            };
            return await _roleRepository.Get(commandParameter);
        }

        /// <summary>
        /// Posts the specified role information.
        /// </summary>
        /// <param name="roleInfo">The role information.</param>
        /// <returns></returns>
        public async Task<Role> Post(Role roleInfo)
        {
            CommandParameter commandParameter = new CommandParameter(CommandConstants.InsertRoleDetails,
                CommandExecutionType.ExecuteReaderAsync)
            {
                Parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.RoleId,
                        Value = roleInfo.RoleId
                    },
                    new SqlParameter()
                    {
                        ParameterName = DatabaseFieldConstants.RoleName,
                        Value = roleInfo.RoleName
                    }
                }
            };
            return await _roleRepository.Post(commandParameter);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _roleRepository.Dispose();
        }
    }

}
