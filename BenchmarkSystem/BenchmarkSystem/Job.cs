﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystem.DB;

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

		public event EventHandler<JobEventArgs> JobDone;

		public readonly int id;

		public Job(int CPUNum, int runtime, Owner owner, Func<string, string> p)
		{
			id = 0;
			NumberOfCPU = CPUNum;
			ExpRuntime = runtime;
			Owner = owner;

			this.p = p;

			State = JobState.Waiting;

			this.id = DatabaseManager.addJob(this);
		}


		public string procces(string s)
		{
			string returnMsg = p(s);

			if (JobDone != null)
				JobDone(this, new JobEventArgs(this.id, this.State));

			return returnMsg;
		}
	}
}