using System.Threading.Tasks;
using System.Web.Http;
using Quality.Measurement.System.Shared.BusinessLogic;
using Quality.Measurement.System.Shared.Helpers.Unity;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Api.Services
{
    public class UserController : ApiController
    {
        private readonly IUserLogic _userLogic;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController()
        {
            _userLogic = Factory.CreateInstance<IUserLogic>();
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserController(IUserLogic userRepository)
        {
            if (userRepository != null)
            {
                _userLogic = userRepository;
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
            User userDetail = await _userLogic.Get(userInfo.UserId);
            return Ok(new User()
            {
                UserName = "Hello Vishesh",
                UserId = 2
            });
        }
    }
}