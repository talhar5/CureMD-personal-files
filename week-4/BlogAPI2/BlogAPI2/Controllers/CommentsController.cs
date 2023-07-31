using BlogAPI2.BusinessLayer;
using BlogAPI2.Models;
using System;
using System.Net;
using System.Web.Http;

namespace BlogAPI2.Controllers
{
    [RoutePrefix("api/v1/comments")]
    public class CommentsController : ApiController
    {
        private readonly BL bl = new BL();

        // to get comments on a post
        [HttpGet]
        [Route("{PostId}")]
        public IHttpActionResult GetComments(int PostId)
        {
            try
            {
                var comments = bl.GetComments(PostId);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // --> to insert a comment
        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertComment([FromBody] CommentDto commentDto)
        {
            try
            {
                if (commentDto == null) return BadRequest("Comment data is missing");
                if (commentDto.Text == null || commentDto.Text.Length == 0) return BadRequest("Comment body is missing");
                if (commentDto.UserId == 0) return BadRequest("UserId is missing");
                if (commentDto.PostId == 0) return BadRequest("PostId is missing");

                Comment comment = new Comment();
                comment.Text = commentDto.Text;
                comment.User.Id = commentDto.UserId;
                comment.Post.Id = commentDto.PostId;
                bool result = bl.InsertComment(comment);
                if (result)
                {
                    return Ok("Comment has been posted");
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "Internal Server Error");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // --> to delete a comment
        [HttpDelete]
        [Route("{CommentId}")]
        public IHttpActionResult DeleteComment(int CommentId)
        {
            try
            {
                bool result = bl.DeleteComment(CommentId);
                if (result)
                {
                    return Ok("Comment has been deleted");
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "Couldn't delete the comment");

                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}