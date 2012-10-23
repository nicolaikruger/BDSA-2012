using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem;
using Jobs;

namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_findNextJobToRun
	{
		BenchmarkSystem.BenchmarkSystem bs = new BenchmarkSystem.BenchmarkSystem();

		[TestMethod]
		public void findJob_findFirst()
		{
			Scheduler sch = new Scheduler();
			Job j1 = new Job(1, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			Job nextJob = sch.findNextJobToRun();
			Assert.AreEqual(j1, nextJob);
		}

		[TestMethod]
		public void findJob_toManyShortJobs()
		{
			Scheduler sch = new Scheduler();
			Job j1 = new Job(1, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			sch.shortRunningJobs = 40;
			Job nextJob = sch.findNextJobToRun();
			
			Assert.AreEqual(j2, nextJob);
		}

		[TestMethod]
		public void findJob_toManyShortAndLongJobs()
		{
			Scheduler sch = new Scheduler();
			Job j1 = new Job(1, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			sch.shortRunningJobs = sch.longRunningJobs = 40;
			Job nextJob = sch.findNextJobToRun();

			Assert.AreEqual(j3, nextJob);
		}

		[TestMethod]
		public void findJob_notEnoughCPU_delayFirstOnce()
		{
			Scheduler sch = new Scheduler();
			BenchmarkSystem.BenchmarkSystem.AvailableCPU = 28;
			Job j1 = new Job(3, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			sch.shortRunningJobs = 40;
			Job nextJob = sch.findNextJobToRun();

			Assert.AreEqual(j2, nextJob);
		}

		[TestMethod]
		public void findJob_notEnoughCPU_delayFirstTwice()
		{
			Scheduler sch = new Scheduler();
			BenchmarkSystem.BenchmarkSystem.AvailableCPU = 28;
			Job j1 = new Job(3, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			sch.shortRunningJobs = 40;
			sch.findNextJobToRun();
			Job nextJob = sch.findNextJobToRun();

			Assert.AreEqual(j2, nextJob);
		}

		[TestMethod]
		public void findJob_notEnoughCPU_delayFirstToMuch()
		{
			Scheduler sch = new Scheduler();
			BenchmarkSystem.BenchmarkSystem.AvailableCPU = 28;
			Job j1 = new Job(3, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			sch.shortRunningJobs = 40;
			sch.findNextJobToRun();
			sch.findNextJobToRun();

			BenchmarkSystem.BenchmarkSystem.AvailableCPU = 25;

			Job nextJob = sch.findNextJobToRun();

			Assert.AreEqual(j1, nextJob);
		}
	}
}
