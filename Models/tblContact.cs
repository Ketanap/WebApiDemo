using System.ComponentModel.DataAnnotations;
namespace WebApiDemo.Models;

public class tblContact
{
    [Key]
    public int ContactId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Contact { get; set; }
    public string? Address { get; set; }
    
     public tblUser User { get; set; }
}
