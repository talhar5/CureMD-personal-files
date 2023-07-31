using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace BlogAPI2.Middlewares
{
    public class AuthorizationModule : IHttpModule
    {
        public void Init(HttpApplication ctx)
        {
            ctx.AuthenticateRequest += OnAuthenticateRequest;
        }

        public void Dispose()
        {

        }
        private void OnAuthenticateRequest(object sender, EventArgs e)
        {


            HttpRequest req = HttpContext.Current.Request;
            string queryString = req.QueryString.ToString();
            if (queryString.Contains("auth=1"))
            {
                var authorizationHeader = req.Headers["Authorization"];

                if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    string token = authorizationHeader.Substring("Bearer ".Length).Trim();
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(WebConfigurationManager.AppSettings["secretKey"]));
                    try
                    {
                        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                        };
                        SecurityToken validatedToken;
                        var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                        HttpContext.Current.User = claimsPrincipal;
                    }
                    catch (Exception ex)
                    {
                        if(ex is SecurityTokenException)
                        {
                            HttpContext.Current.Response.StatusCode = 401;
                            HttpContext.Current.Response.End();
                        } else
                        {
                            HttpContext.Current.Response.StatusCode = 409;
                            HttpContext.Current.Response.End();
                        }
                        
                    }
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 401;
                    HttpContext.Current.Response.End();
                }
            }

        }
    }
}