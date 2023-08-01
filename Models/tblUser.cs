using System.ComponentModel.DataAnnotations;
namespace WebApiDemo.Models;
public class tblUser
{
    [Key]
    public int UserId {get;set;}
    public string UserName {get;set;}
    public string? Email {get;set;}
    public string? Password{get;set;}
    public string? Address {get;set;}
    public string? Gender {get;set;}
    

}