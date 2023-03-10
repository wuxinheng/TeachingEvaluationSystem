using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging;

using TeachingEvaluationSystem.DB.Entitys;

namespace TeachingEvaluationSystem.DB
{
    public class TeachingEvaluationSystemDB : Microsoft.EntityFrameworkCore.DbContext
    {
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public TeachingEvaluationSystemDB(DbContextOptions<TeachingEvaluationSystemDB> options)
        : base(options)
        {
            DataInit();
        }

        public TeachingEvaluationSystemDB()
        {
            DataInit();
        }

        private void DataInit()
        {
            #region DataInit


            if (Roles.Count() == 0)
            {
                var roles = new List<Role>
                {
                    new (){Name = "管理员",Description = "系统管理员"},
                    new (){Name = "老师",Description = "被评价对象"},
                    new (){Name = "学生",Description = "评价主体"},
                };
                Roles.AddRange(roles);
            }
            if (Users.Count() == 0)
            {
                Users.Add(new User()
                {
                    Name = "admin",
                    Email = "123@qq.com",
                    Password = "admin",
                    RoleId = 1,
                });

            }
            if (Menus.Count() == 0)
            {
                var menus = new List<Menu>
                {
                    new() { Name = "主页", Route = @$"" },
                    new() { Name = "登录", Route = @$"login" },
                    new() { Name = "用户", Route = @$"user/index" },
                    new() { Name = "角色", Route = @$"role/index" },
                    new() { Name = "菜单", Route = @$"menu/index" },
                    new() { Name = "评价", Route = @$"evaluationpage/index" },
                    new() { Name = "班级", Route = @$"class/index" },
                    new() { Name = "学科", Route = @$"subjectpage/index" },
                    new() { Name = "题库", Route = @$"question/index" },
                    new() { Name = "题库类型", Route = @$"questiontype/index" }
                };
                Menus.AddRange(menus);
            }

            this.SaveChanges();
            #endregion
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<OptionBank> OptionBanks { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<UserAnswerDetail> UserAnswerDetails { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }

        public DbSet<QuestionBankSubject> BankSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeachingEvaluationSystemDB;Integrated Security=True;TrustServerCertificate=true");

            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Navigation(e => e.Role).AutoInclude();
            modelBuilder.Entity<Role>().Navigation(e => e.Menus).AutoInclude();
            modelBuilder.Entity<Class>().Navigation(e => e.Students).AutoInclude();
            modelBuilder.Entity<Class>().Navigation(e => e.Teachers).AutoInclude();
            modelBuilder.Entity<UserClass>().Navigation(e => e.User).AutoInclude();
            modelBuilder.Entity<UserClass>().Navigation(e => e.Classes).AutoInclude();
            modelBuilder.Entity<UserClass>().Navigation(e => e.Subjects).AutoInclude();
            modelBuilder.Entity<QuestionBank>().Navigation(e => e.OptionBanks).AutoInclude();
            modelBuilder.Entity<QuestionBank>().Navigation(e => e.QuestionType).AutoInclude();
            modelBuilder.Entity<QuestionBankSubject>().Navigation(e => e.QuestionBank).AutoInclude();
            modelBuilder.Entity<Subject>().Navigation(e => e.Questions).AutoInclude();
            modelBuilder.Entity<UserAnswer>().Navigation(e => e.AnswerDetails).AutoInclude();
        }

    }
}