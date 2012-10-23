using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem;
using Jobs;

namespace UnitTestProject
{
	[TestClass]
	public class SchedulerTest_findNextJobToRun
	{
		[TestMethod]
		public void findJob_findFirst()
		{
			Scheduler sch = new Scheduler();
			Job j1 = new Job(1, 300, new Owner("nicolai"), s => "Hello " + s);
			Job j2 = new Job(1, 700, new Owner("nicolai"), s => "Hello " + s);
			Job j3 = new Job(1, 3000, new Owner("nicolai"), s => "Hello " + s);

			Job nextJob = sch.findNextJobToRun();
		}
	}
}
