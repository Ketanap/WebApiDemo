using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.ViewModels
{
    public class VMContact
    {
        
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }

    }
}