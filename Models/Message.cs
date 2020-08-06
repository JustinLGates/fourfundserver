using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Message
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Id { get; set; }
  }
}