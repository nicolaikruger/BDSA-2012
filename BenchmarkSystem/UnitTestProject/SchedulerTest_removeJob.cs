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
		public void removeJob_removeFromShortQueue()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.shortJobQueue.Count);
		}

		[TestMethod]
		public void removeJob_removeFromShortRunningList()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.shortRunningJobs.Add(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.shortRunningJobs.Count);
		}

		[TestMethod]
		public void removeJob_removeFromLongQueue()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30001, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.longJobQueue.Count);
		}

		[TestMethod]
		public void removeJob_removeFromLongRunningList()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30001, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.longRunningJobs.Add(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.longRunningJobs.Count);
		}

		[TestMethod]
		public void removeJob_removeFromVeryLongQueue()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 120001, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.veryLongJobQueue.Count);
		}

		[TestMethod]
		public void removeJob_removeFromVeryLongRunningList()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 120001, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.veryLongRunningJobs.Add(job);
			sh.removeJob(job);

			Assert.AreEqual(0, sh.veryLongJobQueue.Count);
		}
	}
}
