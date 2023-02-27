using System.ComponentModel.DataAnnotations;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public List<Role> Role { get; set; }
    }
}
