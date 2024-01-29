using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jop_Portal.Models
{
    public class Reports
    {
        [Key]
        public int  Id { get; set; }

        public string UserId { get; set; }

        public string ReportedUserId { get; set; }
        public string Description { get; set; }

        public IdentityUser User { get; set; }

    }
}
