using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        ApiDBContext context = new ApiDBContext();
        [HttpGet(Name = "GetUser")]
        public IEnumerable<tblUser> Get()
        {
               return context.tblUser.ToList(); 
        }
        
        [Route("SignUp")]
        [HttpPost]
        public string SignUp(tblUser u)
        {
            context.tblUser.Add (u);        
            context.SaveChanges();
            return "Success";
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(VMLogin u)
        {
            IConfigurationRoot _configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var udata= context.tblUser.Where (eu=>eu.Email ==u.Email && eu.Password ==u.Password ).FirstOrDefault();
            if(udata!=null)
            {
                //return "Success";
                  var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", udata.UserId.ToString()),
                        new Claim("UserName", udata.UserName),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

    }
}