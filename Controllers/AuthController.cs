using firstrole.Interfaces;
using firstrole.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstrole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("login")]
        public string Login([FromBody] LoginRequest obj)
        {
            var token = _auth.Login(obj);
            return token;
        }

        [HttpPost("assignRole")]
        public bool AssignRoleToUser([FromBody] AddUserRole userRole)
        {
            var addedUserRole = _auth.AssignRoleToUser(userRole);
            return addedUserRole;
        }

        [HttpPost("addUser")]
        public User AddUser([FromBody] User user)
        {
            var addeduser = _auth.AddUser(user);
            return addeduser;
        }

        [HttpPost("addRole")]
        public Role AddRole([FromBody] Role role)
        {
            var addedRole = _auth.AddRole(role);
            return addedRole;
        } 
    }
}
