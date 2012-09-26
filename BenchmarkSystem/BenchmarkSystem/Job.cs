using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jobs
{
	public enum JobState {	Waiting, Queued, Running, Done, Failed, Cancelled }

	public class Job
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

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			Job j = (Job)obj;

			return (NumberOfCPU == j.NumberOfCPU &&
					ExpRuntime == j.ExpRuntime &&
					Owner.Equals(j.Owner)) ? true : false;
		}

		public override int GetHashCode()
		{
			return NumberOfCPU ^ ExpRuntime ^ Owner.GetHashCode();
		}
	}
}
