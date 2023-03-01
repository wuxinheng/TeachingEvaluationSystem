using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Route { get; set; }
        public List<Role>? Roles { get; set; }
        [NotMapped]
        public bool Check { get; set; } = false;
    }
}
