using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Jop_Portal.Models
{
    public class Account
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public String Name { get; set; }
        public String? Photo { get; set; }
        public string? About {  get; set; }
        public int Reports {  get; set; }

        public IdentityUser User { get; set; }

    }
}
