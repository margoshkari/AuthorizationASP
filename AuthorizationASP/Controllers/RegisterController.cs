using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace AuthorizationASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        SqlOperations operations = new SqlOperations();
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public StatusCodeResult Post(string login, string email, string password)
        {
            if(operations.isLoginExist(login) || operations.isEmailExist(email))
                return StatusCode(204);

            return StatusCode(200);
        }
    }
}
