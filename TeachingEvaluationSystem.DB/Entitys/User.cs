using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class User
    {
        public User()
        {
            UserClasses = new List<UserClass>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public int? ClassId { get; set; }
        public Class? Class { get; set; }
        public virtual List<UserClass> UserClasses { get; set; }
        [NotMapped]
        public bool Check { get; set; } = false;
    }
}
