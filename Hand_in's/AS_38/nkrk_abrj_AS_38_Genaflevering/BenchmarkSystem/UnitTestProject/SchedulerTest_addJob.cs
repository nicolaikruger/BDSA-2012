using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jobs;
using BenchmarkSystem;

namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_addJob
	{
		[TestMethod]
		public void addJob()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);

			Assert.AreEqual(1, sh.JobQueue.Count);
		}
	}
}
