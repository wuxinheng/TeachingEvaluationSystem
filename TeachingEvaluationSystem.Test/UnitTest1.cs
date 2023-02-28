namespace TeachingEvaluationSystem.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TeachingEvaluationSystem.DB.TeachingEvaluationSystemDB db = new DB.TeachingEvaluationSystemDB();
            db.Users.Add(new DB.Entitys.User()
            {
                Email = "123@123.com",
                Name = "admin",
                Password = "admin",
            });
            var count =db.SaveChanges();
            Assert.AreEqual(1, count);
        }
    }
}