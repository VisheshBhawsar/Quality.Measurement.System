using System;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Shared.Data.Repository
{
    public interface IRepository<T>: IDisposable  where T: class 
    {

        /// <summary>
        /// Gets the specified command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns></returns>
        Task<T> Get(CommandParameter commandParameter);

        /// <summary>
        /// Posts the specified command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns></returns>
        Task<T> Post(CommandParameter commandParameter);
    }
}