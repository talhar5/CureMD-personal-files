using BlogAPI2.DB_Layer;
using BlogAPI2.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;


namespace BlogAPI2.BusinessLayer
{
    public class BL
    {
        public DataLayer dl = new DataLayer();

        // To insert a new user
        public string RegisterUser(UserDto userDto)
        {
            try
            {
                User user = new User();
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Email = userDto.Email;
                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                string response = dl.InsertNewUser(user);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("An exception of type " + ex.GetType().ToString()
                   + " is encountered in InsertUser due to "
                   + ex.Message, ex.InnerException);
            }
        }
        // to check if a user is registered or not by email
        public bool IsRegistered(string email)
        {
            return dl.IsRegistered(email);
        }

        // to get user by email
        public User GetUserByEmail(string email)
        {
            try
            {
                DataTable table = dl.GetUserByEmail(email);
                User user = new User();
                user.Email = table.Rows[0]["Email"].ToString();
                user.PasswordHash = (byte[])table.Rows[0]["PasswordHash"];
                user.PasswordSalt = (byte[])table.Rows[0]["PasswordSalt"];
                user.Id = Convert.ToInt32(table.Rows[0]["UserId"]);
                for (int i = 0; i < user.PasswordHash.Length; i++)
                {
                    Debug.Write(" " + user.PasswordHash[i]);
                }
                user.FirstName = table.Rows[0]["FirstName"].ToString();
                user.LastName = table.Rows[0]["LastName"].ToString();
                return user;
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                {
                    return null;
                }
                throw new Exception("An exception of type " + ex.GetType().ToString()
                   + " is encountered in InsertUser due to "
                   + ex.Message, ex.InnerException);
            }
        }


        //===============================================
        // POSTS SERVICES

        // --> to get all posts
        public List<Post> GetAllPosts()
        {
            try
            {
                List<Post> postsList = new List<Post>();
                DataTable table = dl.GetAllPosts();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        Post post = new Post();
                        post.Id = Convert.ToInt32(dataRow["PostId"]);
                        post.Title = dataRow["Title"].ToString();
                        post.Text = dataRow["PostBody"].ToString();
                        post.User.Id = Convert.ToInt32(dataRow["UserId"]);
                        post.Category.Name = dataRow["CategoryName"].ToString();
                        post.Category.Id = Convert.ToInt32(dataRow["CategoryId"]);
                        post.User.FirstName = dataRow["FirstName"].ToString();
                        post.User.LastName = dataRow["LastName"].ToString();
                        postsList.Add(post);
                    }
                }

                return postsList;
            }
            catch (Exception ex)
            {
                throw new Exception("An exception of type " + ex.GetType().ToString()
                   + " is encountered in GetAllUsers due to "
                   + ex.Message, ex.InnerException);
            }
        }

        // --> to add a new post
        public bool AddPost(Post post)
        {
            try
            {
                return dl.InsertPost(post);
            }
            catch (Exception ex)
            {
                throw new Exception("An exception of type " + ex.GetType().ToString()
                  + " is encountered in InsertPost due to "
                  + ex.Message, ex.InnerException);
            }
        }

        // --> to delete a post
        public bool DeletePost(int PostId)
        {
            try
            {
                return dl.DeletePost(PostId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of type {ex.GetType()} is encountered in bl.DeletePost" +
                    $"due to {ex.Message}, {ex.InnerException}");
            }
        }


        // to create password hash
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, (user.Id).ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(WebConfigurationManager.AppSettings["secretKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );
            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        //=============================================
        // COMMENTS SERVICES

        // --> to get comments on a post
        public List<Comment> GetComments(int PostId)
        {
            try
            {
                List<Comment> commentsList = new List<Comment>();

                DataTable data = dl.GetCommentsByPostId(PostId);

                foreach (DataRow row in data.Rows)
                {
                    Comment comment = new Comment();
                    comment.Id = Convert.ToInt32(row["CommentId"]);
                    comment.Text = row["CommentBody"].ToString();
                    comment.User.Id = Convert.ToInt32(row["UserId"]);
                    comment.Post.Id = Convert.ToInt32(row["PostId"]);
                    comment.User.FirstName = row["FirstName"].ToString();
                    comment.User.LastName = row["LastName"].ToString();
                    commentsList.Add(comment);
                }

                return commentsList;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of type {ex.GetType()} is encountered in bl.GetComments" +
                    $"due to {ex.Message}, {ex.InnerException}");
            }
        }

        // --> to insert a comment on a post
        public bool InsertComment(Comment comment)
        {
            try
            {
                return dl.InsertComment(comment);
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of type {ex.GetType()} is encountered in bl.InsertComment" +
                    $"due to {ex.Message}, {ex.InnerException}");
            }
        }

        // --> to delete a comment
        public bool DeleteComment(int CommentId)
        {
            try
            {
                return dl.DeleteComment(CommentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of type {ex.GetType()} is encountered in bl.DeleteComment" +
                    $"due to {ex.Message}, {ex.InnerException}");
            }
        }

        //=============================================
        // CATEGORY SERVICES

        // --> to get list of all categories
        public List<Category> GetAllCategories()
        {
            try
            {
                List<Category> categoriesList = new List<Category>();

                DataTable data = dl.GetAllCategories();
                foreach (DataRow row in data.Rows)
                {
                    Category category = new Category();
                    category.Id = Convert.ToInt32(row["CategoryId"]);
                    category.Name = row["CategoryName"].ToString();
                    categoriesList.Add(category);
                }

                return categoriesList;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of type {ex.GetType()} is encountered in bl.GetAllCategories" +
                    $"due to {ex.Message}, {ex.InnerException}");
            }
        }

        // --> to insert a category
        public bool InsertCategory(Category category)
        {
            try
            {
                return dl.InsertCategory(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of type {ex.GetType()} is encountered in bl.InsertCategory" +
                    $"due to {ex.Message}, {ex.InnerException}");
            }
        }
    }

}