using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogAPI2.BusinessLayer;

namespace BlogAPI2.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        readonly BL bl = new BL();
        
        [HttpPost]
        [Route("users/test")]
        public IHttpActionResult Test()
        {
            return Ok("ok");
        } 

        
    }
}