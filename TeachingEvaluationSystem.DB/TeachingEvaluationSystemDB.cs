using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging;

using TeachingEvaluationSystem.DB.Entitys;
using System.Security.Cryptography;
using System.Text;

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

        private static readonly byte[] Salt = Encoding.ASCII.GetBytes("my salt");
        private static readonly byte[] AesKey = new byte[32];
        private static readonly byte[] AesIV = new byte[16];

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


            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasConversion(
                    v => EncryptString(v),
                    v => DecryptString(v));
        }
        private static string EncryptString(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = AesKey;
                aes.IV = AesIV;

                var pbkdf2 = new Rfc2898DeriveBytes(plainText, Salt, 10000);
                var key = pbkdf2.GetBytes(32);

                using (var encryptor = aes.CreateEncryptor(key, aes.IV))
                using (var ms = new System.IO.MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var sw = new System.IO.StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    var encrypted = ms.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
        }

        private static string DecryptString(string encryptedText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = AesKey;
                aes.IV = AesIV;

                var pbkdf2 = new Rfc2898DeriveBytes(encryptedText, Salt, 10000);
                var key = pbkdf2.GetBytes(32);

                using (var decryptor = aes.CreateDecryptor(key, aes.IV))
                using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(encryptedText)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new System.IO.StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
