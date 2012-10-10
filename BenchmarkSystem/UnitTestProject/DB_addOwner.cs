using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem.DB;
using Jobs;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class DB_addOwner
    {
        [TestMethod]
        public void addOwner()
        {
            BenchmarkSystemModelContainer dbContent = new BenchmarkSystemModelContainer();

            Owner ow = new Owner("TestOwner");
            int owId = ow.id;

            var result = from user in dbContent.DB_userSet
                         where dbContent.DB_userSet.userid == owId
                         select user;
            
            DB_user resultUser = result;
            Assert.AreEqual(resultUser.userId, owId);
        }

        [TestMethod]
        public void checkOwnerInfo()
        {
            BenchmarkSystemModelContainer dbContent = new BenchmarkSystemModelContainer();

            Owner ow = new Owner("testOwner");
            int owId = ow.id;

            var result = from user in dbContent.DB_userSet
                         where dbContent.DB_userSet.userid == owId
                         select user;

            DB_user resultUser = result;
            Assert.AreEqual(resultUser.name, "testOwner");
        }
    }
}
