using KralInsaat.Common.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Db
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        [Key]
        public override int Id
        {
            get => UserId;
            set => UserId = value;
        }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
