using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jobs;
using BenchmarkSystem;

namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_executeAll
	{
		[TestMethod]
		public void executeAll()
		{
			Owner ow = new Owner("Nicolai");
			Scheduler sh = new Scheduler();

			for(int i = 0; i < 30; i++)
			{
				sh.addJob(new Job(1, 2+i, ow, s => "Hello world"));
			}

			for(int i = 0; i < 30; i++)
			{
				sh.addJob(new Job(1, 30001+i, ow, s => "Hello world"));
			}

			for (int i = 0; i < 30; i++)
			{
				sh.addJob(new Job(1, 120001 + i, ow, s => "Hello world"));
			}

			sh.executeAll();

			// Sleeps for a second to make sure that all Jobs gets done
			System.Threading.Thread.Sleep(1000);

			Assert.AreEqual(0, sh.JobQueue.Count);

			Assert.AreEqual(0, sh.shortRunningJobs);
			Assert.AreEqual(0, sh.longRunningJobs);
			Assert.AreEqual(0, sh.veryLongRunningJobs);
		}
	}
}
