using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogAPI2.BusinessLayer;
using BlogAPI2.Models;

namespace BlogAPI2.Controllers
{
    [RoutePrefix("api/v1/categories")]
    public class CategoryController : ApiController
    {
        private readonly BL bl = new BL();

        // to get all categories
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                var categories = bl.GetAllCategories();
                return Ok(categories);
            } catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // to insert a new category
        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertCategory([FromBody] Category category)
        {
            try
            {
                if (category == null) return BadRequest("CategoryName is required");
                if(category.Name == null || category.Name.Length == 0) return BadRequest("CategoryName is required");
                bool result = bl.InsertCategory(category);
                return Ok($"The new category '{category.Name}' has been added");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}