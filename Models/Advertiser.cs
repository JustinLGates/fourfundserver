

using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Advertiser
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string OrgName { get; set; }
    [Required]
    public string Logo { get; set; }

    public string Email { get; set; }
    public string Website { get; set; }
    public string PhoneNumber { get; set; }
    public string Location { get; set; }
    public int Id { get; set; }
  }
}