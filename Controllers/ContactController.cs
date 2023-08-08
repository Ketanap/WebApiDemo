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
    public class ContactController : ControllerBase
    {
        ApiDBContext context = new ApiDBContext();
        [HttpGet]
        public IEnumerable<tblContact> Get()
        {
               return context.tblContact.ToList(); 
        }

        [HttpGet("{id}")]
        public tblContact Get(int id)
        {
               return context.tblContact.Where(
                    data =>data.ContactId==id).FirstOrDefault();; 
        }
        [HttpPost]
        public string Insert(VMContact data)
        {
            tblContact newContact=new tblContact();
            newContact.UserId=data.UserId;
            newContact.Name=data.Name;
            newContact.Address =data.Address ;
            newContact.Email = data.Email ;
            newContact.Contact =data.Contact ;
            context.tblContact.Add (newContact);        
            context.SaveChanges();
            return "Success";
        }

        [HttpPut("{id}")]
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