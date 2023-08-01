using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.ViewModels;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public IEnumerable<tblUser> Get()
        {
               var context = new ApiDBContext();
               return context.tblUser.ToList(); 
        }
        
        [Route("SignUp")]
        [HttpPost]
        public string SignUp(tblUser u)
        {
            var context = new ApiDBContext();
            context.tblUser.Add (u);        
            context.SaveChanges();
            return "Success";
        }

        [Route("Login")]
        [HttpPost]
        public string Login(VMLogin u)
        {
            var context = new ApiDBContext();
            var udata= context.tblUser.Where (eu=>eu.Email ==u.Email && eu.Password ==u.Password ).FirstOrDefault();
            if(udata!=null)
            {
                return "Success";
            }
            else
            {
                return "Invalid";
            }
        }

    }
}