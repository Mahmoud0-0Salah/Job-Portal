using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jop_Portal.Models
{
    public class BlockedEmails
    {
        [Key]
        [ForeignKey("User")]
        public string id { get; set; }
        public string Email { get; set; }
        public IdentityUser User { get; set; }
    }
}
