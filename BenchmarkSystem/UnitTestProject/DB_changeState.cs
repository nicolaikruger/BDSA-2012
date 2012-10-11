using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem.DB;
using Jobs;
using System.Linq;
using BenchmarkSystem;
namespace UnitTestProject
{
    [TestClass]
    public class DB_changeState
    {
        [TestMethod]
        public void cancelJob()
        {
            BenchmarkSystemModelContainer dbContent = new BenchmarkSystemModelContainer();

            Job testJob = new Job(1, 10, new Owner("TestOwner"), s => "Hello world");
            int jobId = testJob.id;

			BenchmarkSystem.BenchmarkSystem bs = new BenchmarkSystem.BenchmarkSystem();

			bs.submit(testJob);
			bs.cancel(testJob);

            var result = from job in dbContent.DB_JobSet
                         where job.jobId == jobId
                         select job;
            DB_Job resultJob = result.First();

			Assert.AreEqual("Cancelled", resultJob.status);
        }
    }
}
