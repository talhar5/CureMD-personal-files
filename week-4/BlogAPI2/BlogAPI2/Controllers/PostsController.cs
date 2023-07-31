using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using BlogAPI2.BusinessLayer;
using BlogAPI2.Models;
using System.Diagnostics;

namespace BlogAPI2.Controllers
{
    [RoutePrefix("api/v1")]

    public class PostsController : ApiController
    {
        BL bl = new BL();
        [HttpGet]
        [Route("posts")]
        public IHttpActionResult GetAllPosts()
        {
            try
            {
                var result = bl.GetAllPosts();
                return Ok(result);
            } catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("posts/create")]
        public IHttpActionResult CreateNewPost([FromBody] PostDto postDto)
        {
            try
            {
                if (postDto == null) return BadRequest("Post data is required");
                // check all prop are available
                // to be implemented
                Post post = new Post();
                post.Title = postDto.Title;
                post.Text = postDto.Text;
                post.Category.Id = postDto.CategoryId;
                post.User.Id = postDto.UserId;
                Debug.WriteLine(post.User.Id);
                bool result = bl.AddPost(post);

                if (result) return Content(HttpStatusCode.Created, "Post has been added");

                return Content(HttpStatusCode.InternalServerError, "Error while saving post");

                //ClaimsPrincipal user = HttpContext.Current.User as ClaimsPrincipal;
                //if (user != null && user.Identity.IsAuthenticated)
                //{
                //    if (postDto == null) return BadRequest("Post data is required");
                //    Post post = new Post();
                //    post.Title = postDto.Title;
                //    post.Text = postDto.Text;
                //    post.Category.Id = postDto.CategoryId;
                //    post.User.Id = Convert.ToInt32(user.Identity.Name);
                //    Debug.WriteLine(post.User.Id);
                //    bool result = bl.AddPost(post);

                //    if (result) return Content(HttpStatusCode.Created, "Post has been added");

                //    return Content(HttpStatusCode.InternalServerError, "Error while saving post");
                //} else
                //{
                //    return Unauthorized();
                //}
            } catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}