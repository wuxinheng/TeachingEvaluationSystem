using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB
{
    public class TeachingEvaluationSystemContextFactory : IDesignTimeDbContextFactory<TeachingEvaluationSystemDB>
    {
        public TeachingEvaluationSystemDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeachingEvaluationSystemDB>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeachingEvaluationSystemDB;Integrated Security=True;TrustServerCertificate=true");

            return new TeachingEvaluationSystemDB(optionsBuilder.Options);
        }
    }
}
