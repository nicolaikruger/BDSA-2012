using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystem
{
	enum JobState {	Waiting, Qued, Running, Done, Failed }

	class Job
	{
		private Func<string, string> f { get; set; }

		public int NumberOfCPU { get; private set; }

		public int ExpRuntime { get; private set; }

		public JobState State { get; private set; }

		public Owner Owner { get; private set; }

		public Job(int CPUNum, int runtime, Owner owner, Func<string, string> p)
		{
			NumberOfCPU = CPUNum;
			ExpRuntime = runtime;
			Owner = owner;

			f = p;

			State = JobState.Waiting;
		}

		public string process(string s)
		{
			State = JobState.Running;
			string returnVal = "";

			try {
				returnVal = f(s);
			} catch (Exception e) {
				State = JobState.Failed;
				throw e;
			}

			State = JobState.Done;
			return returnVal;
		}

		static void printJobName()
		{
			new Job(1, 30, new Owner("Anders"), (s) => "Job 1, you gave me: " + s);
		}

	}
}
