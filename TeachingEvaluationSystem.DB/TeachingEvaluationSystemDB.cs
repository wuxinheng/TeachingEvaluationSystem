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

        private static string key = "12345678"; // 8位秘钥

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
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
        }
        // DES加密
        private static string Encrypt(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = keyBytes; // DES算法的向量参数需要和秘钥相同

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = keyBytes;
                des.IV = iv;

                using (ICryptoTransform encryptor = des.CreateEncryptor())
                {
                    byte[] resultBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(resultBytes);
                }
            }
        }

        // DES解密
        private static string Decrypt(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = keyBytes;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = keyBytes;
                des.IV = iv;

                using (ICryptoTransform decryptor = des.CreateDecryptor())
                {
                    byte[] resultBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Encoding.UTF8.GetString(resultBytes);
                }
            }
        }
    }
}
