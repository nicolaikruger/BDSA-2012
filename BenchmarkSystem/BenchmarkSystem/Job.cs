﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jobs
{

	public enum JobState { Waiting, Queued, Running, Done, Failed, Cancelled }

	public class Job
	{

		private Func<string, string> p { get; set; }

		public int NumberOfCPU { get; private set; }

		public int ExpRuntime { get; private set; }

		public JobState State { get; set; }

		public Owner Owner { get; private set; }

		public DateTime timeStamp { get; set; }

		public event EventHandler JobDone;

		public Job(int CPUNum, int runtime, Owner owner, Func<string, string> p)
		{
			NumberOfCPU = CPUNum;
			ExpRuntime = runtime;
			Owner = owner;

			this.p = p;

			State = JobState.Waiting;
		}


		public string procces(string s)
		{
			string returnMsg = p(s);

			if (JobDone != null)
				JobDone(this, EventArgs.Empty);

			return returnMsg;
		}
	}
}