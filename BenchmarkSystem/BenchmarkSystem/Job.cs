using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystem
{
	enum JobState {	Waiting, Queued, Running, Done, Failed, Cancelled }

	class Job
	{
		public Func<string, string> process { get; private set; }

		public int NumberOfCPU { get; private set; }

		public int ExpRuntime { get; private set; }

		public JobState State { get; set; }

		public Owner Owner { get; private set; }

		public DateTime timeStamp { get; set; }

		public Job(int CPUNum, int runtime, Owner owner, Func<string, string> p)
		{
			NumberOfCPU = CPUNum;
			ExpRuntime = runtime;
			Owner = owner;

			process = p;

			State = JobState.Waiting;
		}

		static void test()
		{
			Job j = new Job(1, 1, new Owner("Anders"), (s) => "Hello mr. " + s);
			j.State = JobState.Running;
			j.process("Anders");
			j.State = JobState.Done;
		}
	}
}
