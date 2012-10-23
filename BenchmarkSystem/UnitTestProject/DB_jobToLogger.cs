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
			BenchmarkDBEntities dbContent = new BenchmarkDBEntities();
			

				Job testJob = new Job(1, 10, new Owner("TestOwner"), s => "Hello world");
				int jobId = testJob.id;

				var result = from job in dbContent.DB_JobLogSet
							 where job.job_jobId == jobId
							 select job.DB_JobSet;

                DB_JobSet resultJob = result.First();

				Assert.AreEqual(jobId, resultJob.jobId);
			
        }

        [TestMethod]
        public void checkStateChange()
        {
            BenchmarkDBEntities dbContent = new BenchmarkDBEntities();

            Job testJob = new Job(1, 10, new Owner("TestOwner"), s => "Hello world");
            int jobId = testJob.id;

			BenchmarkSystem.BenchmarkSystem bs = new BenchmarkSystem.BenchmarkSystem();
			bs.submit(testJob);
            bs.executeAll();

           
            var result = from job in dbContent.DB_JobLogSet
                         where job.job_jobId == jobId
                         select job.DB_JobSet;
            
             DB_JobSet resultJob = result.First();

			 Assert.AreEqual("DONE", resultJob.status);
        }
    }
}
