using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using BlogAPI2.Models;
using System.Data;
using System.Diagnostics;

namespace BlogAPI2.DB_Layer
{
    public class DataLayer
    {
        private readonly string connectionString;
        public DataLayer()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        // ===================================================================
        // POSTS QUERIES

        // to get all posts
        public DataTable GetAllPosts()
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetAllPosts", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(table);

                    connection.Close();
                }
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in GetAllPosts due to {ex.Message} {ex.InnerException}");
            }
        }

        // to insert a new post
        public bool InsertPost(Post post)
        {
            try
            {
                int rowsAffected = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("InsertPost", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Title", post.Title);
                    command.Parameters.AddWithValue("@PostBody", post.Text);
                    command.Parameters.AddWithValue("@UserId", post.User.Id);
                    command.Parameters.AddWithValue("@CategoryId", post.Category.Id);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in InsertNewUser due to {ex.Message} {ex.InnerException}");
            }
        }

        // to get posts by userId
        public DataTable GetPostsByUserId(int UserId)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetPostsByUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserId", UserId);

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in GetPostsByUserId due to {ex.Message} {ex.InnerException}");
            }
        }

        // to get posts by category
        public DataTable GetPostsByCategoryId(int CategoryId)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetPostsByCategory", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoryId", CategoryId);

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in GetPostsByUserId due to {ex.Message} {ex.InnerException}");
            }
        }

        // to delete a post by id
        


        // Users Queries
        public DataTable GetListOfUsers()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetAllUsers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    connection.Close();
                }
                return dataTable;
            } catch (Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in GetAllUsers due to {ex.Message} {ex.InnerException}");
            }
        }

        public string InsertNewUser(User user)
        {
            try
            {
                string response = "";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("InsertUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);

                    command.Parameters.Add("@PKID", SqlDbType.Int, 32);
                    command.Parameters["@PKID"].Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    response = Convert.ToString(command.Parameters["@PKID"].Value);
                    connection.Close();
                }
                return response;
            } catch(Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in InsertNewUser due to {ex.Message} {ex.InnerException}");
            }
        }
        public bool IsRegistered(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("CheckUserByEmail", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    command.Parameters.Add("@IsRegistered", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();
                    return Convert.ToInt32(command.Parameters["@IsRegistered"].Value) == 1;
                }
            } catch (Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in IsRegistered due to {ex.Message} {ex.InnerException}");
            }
        }

        public DataTable GetUserByEmail(string email)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetUserByEmail", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(table);

                    connection.Close();
                }
                return table;
            } catch(Exception ex)
            {
                throw new Exception($"An exception of the type {ex.GetType().ToString()} " +
                    $"is encountered in GetUserByEmail due to {ex.Message} {ex.InnerException}");
            }
        }

      

       
    }
}