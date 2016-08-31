using System.Threading.Tasks;
using System.Web.Http;
using Quality.Measurement.System.Shared.BusinessLogic;
using Quality.Measurement.System.Shared.Helpers.Unity;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Api.Services
{
    public class UserController : ApiController
    {
        /// <summary>
        /// The _user logic
        /// </summary>
        private readonly ILogic<User> _userLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController()
        {
            _userLogic = Factory.CreateInstance<ILogic<User>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userLogic">The user logic.</param>
        public UserController(ILogic<User> userLogic)
        {
            if (userLogic != null)
            {
                _userLogic = userLogic;
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            User userDetail = await _userLogic.Get(id);
            return Ok(userDetail);
        }

        /// <summary>
        /// Posts the specified user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(User userInfo)
        {
            User userDetails = await _userLogic.Post(userInfo);
            return Ok(userDetails);
        }
    }
}