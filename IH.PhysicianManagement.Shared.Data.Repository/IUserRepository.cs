using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Shared.Data.Repository
{
    public interface IUserRepository: IDisposable
    {

        /// <summary>
        /// Gets the specified command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns></returns>
        Task<User> Get(CommandParameter commandParameter);
    }
}