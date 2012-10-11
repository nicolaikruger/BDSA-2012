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

            var result = from job in dbContent.DB_JobSet
                         where dbContent.DB_JobSet.userId = jobId
                         select job;
            DB_Job resultJob = result;
            //Convert resultJob to Job so its possible to cancel the job and then
            //check the status of the job
            
        }
    }
}
