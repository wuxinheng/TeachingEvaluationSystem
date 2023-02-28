using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging;

using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.DB
{
    public class TeachingEvaluationSystemDB : Microsoft.EntityFrameworkCore.DbContext
    {
        public static readonly LoggerFactory LoggerFactory =
       new LoggerFactory(new[] { new DebugLoggerProvider() });
        public TeachingEvaluationSystemDB()
        {
            if (Users.Count()==0)
            {
                Users.Add(new User()
                {
                    Name="admin",
                    Email="123@qq.com",
                    Password="admin"
                });
                this.SaveChanges();
            }
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OptionBank> OptionBanks { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeachingEvaluationSystemDB;User ID=sa;Password=123456;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeachingEvaluationSystemDB;Integrated Security=True;TrustServerCertificate=true");

            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        
    }
}