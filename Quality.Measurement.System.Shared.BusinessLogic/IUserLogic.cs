using System;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Shared.BusinessLogic
{
   public interface IUserLogic : IDisposable
    {

        /// <summary>
        /// Gets the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<User> Get(long userId);
    }
}