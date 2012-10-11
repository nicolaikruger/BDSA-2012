using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem.DB;
using Jobs;
using System.Linq;
using BenchmarkSystem;

namespace UnitTestProject
{
    [TestClass]
    public class DB_jobToLogger
    {
        [TestMethod]
        public void addJob()
        {
			using (var dbContent = new BenchmarkSystemModelContainer())
			{

				Job testJob = new Job(1, 10, new Owner("TestOwner"), s => "Hello world");
				int jobId = testJob.id;

				var result = from job in dbContent.DB_JobLogSet
							 where job.job_jobId == jobId
							 select job;
				DB_JobLog resultJob = result.First();

				Assert.AreEqual(resultJob.jobId, jobId);
			}
        }

        [TestMethod]
        public void checkStateChange()
        {
            BenchmarkSystemModelContainer dbContent = new BenchmarkSystemModelContainer();

            Job testJob = new Job(1, 10, new Owner("TestOwner"), s => "Hello world");
            int jobId = testJob.id;

            Scheduler sc = new Scheduler();
            sc.executeAll();

            var result = from job in dbContent.DB_JobLogSet
                         where dbContent.DB_JobLogSet.job_jobId == jobId 
                         select job;
            DB_Job resultJob = result;

            Assert.AreEqual(resultJob.status, "Done");
        }
    }
}
