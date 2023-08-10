using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        ApiDBContext context = new ApiDBContext();
        [HttpGet]
        [Authorize]
        public IEnumerable<tblContact> Get()
        {
            var UserId = HttpContext.User.Claims.First(x => x.Type == "UserId").Value;
            return context.tblContact.Where( con =>con.UserId==Convert.ToInt32( UserId )).ToList(); 
        }

        [HttpGet("{id}")]
        [Authorize]
        public tblContact Get(int id)
        {
             var UserId = HttpContext.User.Claims.First(x => x.Type == "UserId").Value;
               return context.tblContact.Where(
                    data =>data.ContactId==id && data.UserId==Convert.ToInt32( UserId)).FirstOrDefault(); 
        }
        [HttpPost]
        [Authorize]
        public string Insert(VMContact data)
        {
             var UserId = HttpContext.User.Claims.First(x => x.Type == "UserId").Value;
            tblContact newContact=new tblContact();
            newContact.UserId=Convert.ToInt32( UserId);
            newContact.Name=data.Name;
            newContact.Address =data.Address ;
            newContact.Email = data.Email ;
            newContact.Contact =data.Contact ;
            context.tblContact.Add (newContact);        
            context.SaveChanges();
            return "Success";
        }

        [HttpPut("{id}")]
        [Authorize]
        public string Update(VMContact data,int id)
        {
           var editContact=context.tblContact.Where(
                    tbldata =>tbldata.ContactId==id).FirstOrDefault();    
                    editContact.Name=data.Name;
                    editContact.Address =data.Address ;
                    editContact.Email = data.Email ;
                    editContact.Contact =data.Contact ;
                    context.SaveChanges();
            return "Success";
        }

        [HttpDelete("{id}")]
        [Authorize]
        public string Delete(int id)
        {
             var delContact=context.tblContact.Where(
                    data =>data.ContactId==id).FirstOrDefault();
                   context.tblContact.Remove(delContact);
                   context.SaveChanges();
            return "Success";
        }
    }
}