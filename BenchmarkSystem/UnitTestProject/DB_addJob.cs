﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem.DB;
using Jobs;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class DB_addJob
    {
        [TestMethod]
        public void addJob()
        {
            BenchmarkSystemModelContainer dbContent = new BenchmarkSystemModelContainer();

            Job testJob = new Job(1, 10, new Owner("TestOwner"), s => "Hello world");
            int jobId = testJob.id;

            var result = from job in dbContent.DB_JobSet
							 where job.user_userId == jobId
							 select job;
            DB_Job resultJob = result;

            Assert.AreEqual(resultJob.jobId, jobId);
        }

        [TestMethod]
        public void checkJobInfo()
        {
            BenchmarkSystemModelContainer dbContent = new BenchmarkSystemModelContainer();

            Owner ow = new Owner("TestAnders");
            int owId = ow.id;

            Job testJob = new Job(1, 10, ow, s => "Hello world");
            int jobId = testJob.id;

            var result = from job in dbContent.DB_JobSet
                         where job.user_userId == jobId
                         select job;
            
            DB_Job resultJob = result;

            Assert.AreEqual(resultJob.status, "Queued");
            Assert.AreEqual(resultJob.user_userId, owId);
            Assert.AreEqual(resultJob.jobId, jobId);

        }
    }
}
