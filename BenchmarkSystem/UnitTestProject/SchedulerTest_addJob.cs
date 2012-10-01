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
		public void addJob_shortJob()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);

			Assert.AreEqual(1, sh.shortJobQueue.Count);
		}

		[TestMethod]
		public void addJob_longJob_justOver30K()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 30001, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);

			Assert.AreEqual(1, sh.longJobQueue.Count);
		}

		[TestMethod]
		public void addJob_longJob_120K()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 120000, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);

			Assert.AreEqual(1, sh.longJobQueue.Count);
		}

		[TestMethod]
		public void addJob_veryLongJob_justOver120K()
		{
			Owner ow = new Owner("Nicolai");
			Job job = new Job(1, 120001, ow, s => "Hello world");
			Scheduler sh = new Scheduler();

			sh.addJob(job);

			Assert.AreEqual(1, sh.veryLongJobQueue.Count);
		}
	}
}
