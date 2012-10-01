using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jobs;
using BenchmarkSystem;


namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_popJob
	{
		[TestMethod]
		public void popJob_popShortJob()
		{
			Owner ow = new Owner("Nicolai");
			Job j1 = new Job(1, 30000, ow, s => "Hello world");
			Job j2 = new Job(1, 30002, ow, s => "Hello world");
			Job j3 = new Job(1, 3000000, ow, s => "Hello world");

			Scheduler sh = new Scheduler();

			sh.addJob(j1);
			sh.addJob(j2);
			sh.addJob(j3);

			Assert.AreEqual(j1, sh.PopJob());
		}

		[TestMethod]
		public void popJob_popLongJob()
		{
			Owner ow = new Owner("Nicolai");
			Job j1 = new Job(1, 30000, ow, s => "Hello world");
			Job j2 = new Job(1, 30002, ow, s => "Hello world");
			Job j3 = new Job(1, 3000000, ow, s => "Hello world");

			Scheduler sh = new Scheduler();

			sh.addJob(j2);
			sh.addJob(j1);
			sh.addJob(j3);

			Assert.AreEqual(j2, sh.PopJob());
		}

		[TestMethod]
		public void popJob_popVeryLongJob()
		{
			Owner ow = new Owner("Nicolai");
			Job j1 = new Job(1, 30000, ow, s => "Hello world");
			Job j2 = new Job(1, 30002, ow, s => "Hello world");
			Job j3 = new Job(1, 3000000, ow, s => "Hello world");

			Scheduler sh = new Scheduler();

			sh.addJob(j3);
			sh.addJob(j1);
			sh.addJob(j2);

			Assert.AreEqual(j3, sh.PopJob());
		}
	}
}
