using System;
using System.Threading.Tasks;

namespace Quality.Measurement.System.Shared.BusinessLogic
{
   public interface ILogic<T> : IDisposable where T: class
    {

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> Get(long id);



        /// <summary>
        /// Posts the specified information object.
        /// </summary>
        /// <param name="infoObject">The information object.</param>
        /// <returns></returns>
        Task<T> Post(T infoObject);
    }
}