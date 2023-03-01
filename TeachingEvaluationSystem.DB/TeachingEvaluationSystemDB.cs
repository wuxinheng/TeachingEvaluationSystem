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
               
            }
            if (Menus.Count()==0)
            {
                var menus = new List<Menu>
                {
                    new() { Name = "主页", Route = @$"" },
                    new() { Name = "登录", Route = @$"login" },
                    new() { Name = "用户", Route = @$"user/index" },
                    new() { Name = "菜单", Route = @$"role/index" },
                    new() { Name = "角色", Route = @$"menu/index" },
                };
                Menus.AddRange(menus);
            }
            this.SaveChanges();
            
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
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeachingEvaluationSystemDB;User ID=sa;Password=123456;TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeachingEvaluationSystemDB;Integrated Security=True;TrustServerCertificate=true");

            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().Navigation(e => e.Menus).AutoInclude(); ;
        }

    }
}