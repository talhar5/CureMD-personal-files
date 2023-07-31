using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogAPI2.Models;
using BlogAPI2.BusinessLayer;
using System.Diagnostics;



namespace BlogAPI2.Controllers
{
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        public BL bl = new BL();
        [HttpPost]
        [Route("signup")]
        public IHttpActionResult SignUp([FromBody] UserDto user)
        {
            Debug.WriteLine("siginup");
            try
            {
                if (user == null) return BadRequest("Credentials are required");
                if(user.FirstName == null || user.LastName == null || user.Email == null || user.Password == null)
                {
                    return BadRequest("Credentials are required");
                }
                if (user.FirstName.Length == 0 || user.LastName.Length == 0 || user.Email.Length == 0 || user.Password.Length == 0)
                {
                    return BadRequest("Credentials are required");
                }

                if (bl.IsRegistered(user.Email))
                {
                    return Content(HttpStatusCode.Conflict, "Provided Email is already registered");
                }

                bl.RegisterUser(user);
                return Ok("User has been registered successfully");
            } catch(Exception e)
            {
                Debug.WriteLine(e.GetType());
                return Content(HttpStatusCode.InternalServerError, $"Internal Server Error {e.Message}");
            }
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserDto user)
        {
            Debug.WriteLine("Login");
            try
            {
                if(user == null || user.Email == null || user.Password == null)
                {
                    return BadRequest("Credentials are required");
                }
                User user_ = bl.GetUserByEmail(user.Email);
                if (user_ == null) return BadRequest("Invalid Credentials");
                if(!bl.VerifyPasswordHash(user.Password, user_.PasswordHash, user_.PasswordSalt))
                {
                    Debug.WriteLine(bl.VerifyPasswordHash(user.Password, user_.PasswordHash, user_.PasswordSalt));
                    return BadRequest("Invalid Credentials");
                }
                string jwtToken = bl.GenerateToken(user_);
                return Ok(new { UserId = user_.Id, Token = jwtToken });
            } catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}