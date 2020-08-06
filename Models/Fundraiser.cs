using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Fundraiser
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string OrgName { get; set; }
    [Required]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Logo { get; set; }
    public int Id { get; set; }

  }
}