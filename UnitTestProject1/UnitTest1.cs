using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPTest.Classes;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddSkillTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.AddSkill("Name", 1);

            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void RemoveSkillTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.RemoveSkill("Умение 3");

            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void AddSpecialtyTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.AddSpecializtion("Ababask", "0002", "Proger");

            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void DeleteSpecialtyTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.RemoveSpecializtion("0002");

            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void EditSpecialtyTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.EditSpecializtion("Лучезарики", "03.06.02");
            Assert.AreEqual(exp, actual);
        }
    }
}
