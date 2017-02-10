using System.Threading.Tasks;
using System.Web.Http;
using Quality.Measurement.System.Shared.BusinessLogic;
using Quality.Measurement.System.Shared.Helpers.Unity;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Api.Services
{
    public class RoleController : ApiController
    {
        /// <summary>
        /// The _role logic
        /// </summary>
        private readonly ILogic<Role> _roleLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        public RoleController()
        {
            _roleLogic = Factory.CreateInstance<ILogic<Role>>();

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        /// <param name="roleLogic">The role logic.</param>
        public RoleController(ILogic<Role> roleLogic)
        {
            if (roleLogic != null)
            {
                _roleLogic = roleLogic;
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
            Role userDetail = await _roleLogic.Get(id);
            return Ok(userDetail);
        }

        /// <summary>
        /// Posts the specified role information.
        /// </summary>
        /// <param name="roleInfo">The role information.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(Role roleInfo)
        {
            Role roleDetails = await _roleLogic.Post(roleInfo);
            return Ok(roleDetails);
        }
    }
}