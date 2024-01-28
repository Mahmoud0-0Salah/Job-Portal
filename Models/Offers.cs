using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jop_Portal.Models
{
    public class Offers
    {
        [Key]
        public int Id { get; set; }
        public string JobTittle { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
