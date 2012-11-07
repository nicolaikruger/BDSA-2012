using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jobs;
using BenchmarkSystem;

namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_numberOfRunningJobs
	{
		[TestMethod]
		public void addShortJob()
		{
			Job job = new Job(1, 300, new Owner("nicolai"), s => "Hello " + s);
			Scheduler sch = new Scheduler();

			sch.incrementRunningJobs(job);

			Assert.AreEqual(1, sch.shortRunningJobs);
		}

		[TestMethod]
		public void addLongJob()
		{
			Job job = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Scheduler sch = new Scheduler();

			sch.incrementRunningJobs(job);

			Assert.AreEqual(1, sch.longRunningJobs);
		}

		[TestMethod]
		public void addVeryLongJob()
		{
			Job job = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);
			Scheduler sch = new Scheduler();

			sch.incrementRunningJobs(job);

			Assert.AreEqual(1, sch.veryLongRunningJobs);
		}

		[TestMethod]
		public void removeShortJob()
		{
			Job job = new Job(1, 300, new Owner("nicolai"), s => "Hello " + s);
			Scheduler sch = new Scheduler();

			sch.incrementRunningJobs(job);
			sch.decrementRunningJobs(job);

			Assert.AreEqual(0, sch.shortRunningJobs);
		}

		[TestMethod]
		public void removeLongJob()
		{
			Job job = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Scheduler sch = new Scheduler();

			sch.incrementRunningJobs(job);
			sch.decrementRunningJobs(job);

			Assert.AreEqual(0, sch.longRunningJobs);
		}

		[TestMethod]
		public void removeVeryLongJob()
		{
			Job job = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);
			Scheduler sch = new Scheduler();

			sch.incrementRunningJobs(job);
			sch.decrementRunningJobs(job);

			Assert.AreEqual(0, sch.veryLongRunningJobs);
		}
	}
}
