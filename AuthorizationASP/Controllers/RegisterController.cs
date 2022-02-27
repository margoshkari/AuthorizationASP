using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace AuthorizationASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        SqlOperations operations = new SqlOperations();
        private readonly ILogger<RegisterController> _logger;
        private const int secureCode = 12345;
        private string errorMsg = "User exist";

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }
        [HttpPost("User registration")]
        public ActionResult Post(string login, string email, string password, DateTime birthday)
        {
            if (operations.isLoginExist(login) || operations.isEmailExist(email) || !CheckLength(login, password) || !IsValidEmail(email) ||!CheckDate(birthday))
                return Problem(errorMsg);

            HashPass(ref password);

            if(!operations.AddUser(login, email, password, birthday))
                return StatusCode(500);

            return StatusCode(200);
        }

        [HttpPost("Admin registration")]
        public ActionResult PostAdmin(string login, string email, string password, DateTime birthday, int securecode)
        {
            if (securecode != secureCode || operations.isLoginExist(login) || operations.isEmailExist(email) 
                || !CheckLength(login, password) || !IsValidEmail(email) ||!CheckDate(birthday))
                return Problem(errorMsg);

            HashPass(ref password);

            if (!operations.AddAdmin(login, email, password, birthday))
                return StatusCode(500);

            return StatusCode(200);
        }
        
        private bool CheckDate(DateTime birthday)
        {
            int minYear = 1902, maxYear = 2004;
            if (birthday.Year < minYear || birthday.Year > maxYear || birthday.Month < 1 || birthday.Month > 12 
                || DateTime.DaysInMonth(birthday.Year, birthday.Month) < birthday.Day || birthday.Day < 1)
            {
                errorMsg = "Date is not exist!";
                return false;
            }
            
            return true;
        }
        private bool CheckLength(string login, string password)
        {
            if (login.Length < 5 || password.Length < 5)
            {
                errorMsg = "Length must be more than 5!";
                return false;
            }

            return true;
        }
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                errorMsg = "Mail is not valid!";
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                errorMsg = "Mail is not valid!";
                return false;
            }
        }
        private void HashPass(ref string pass)
        {
            pass = BCrypt.Net.BCrypt.HashPassword(pass);
        }
    }
}
