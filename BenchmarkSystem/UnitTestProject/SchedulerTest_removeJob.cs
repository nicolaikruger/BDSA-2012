using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jobs;
using BenchmarkSystem;


namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_removeJob
	{
		[TestMethod]
		public void removeJob_removeFromQueue()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.JobQueue.Count);
		}

		//TODO: Skal denne stadig bruges?
		[TestMethod]
		public void removeJob_removeFromRunningList()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.RunningJobs.Add(job);
			sh.removeJob(job);

			//Assert.AreEqual(0, sh.RunningJobs.Count);
		}
	}
}
