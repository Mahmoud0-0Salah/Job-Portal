using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jop_Portal.Models
{
    public class BlockedEmails
    {
        [Key]
        [ForeignKey("User")]
        string Email;
        public IdentityUser User { get; set; }
    }
}
