
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystem.DB;
using System.Threading.Tasks;

namespace Jobs
{
	public class Job
	{
		private readonly int minCPU = 1, maxCPU = 10;
		private int numberOfCPU;


		private Func<string, string> p { get; set; }

		public int NumberOfCPU 
		{ 
			get {return numberOfCPU; }
			private set
			{
				if (value >= minCPU && value <= maxCPU)
					numberOfCPU = value;
				else
					throw new ArgumentException("The number of CPU must be between 1 and 10, including");
			} 
		}

		public int ExpRuntime { get; private set; }

		public JobState State { get; set; }

		public Owner Owner { get; private set; }

		public DateTime timeStamp { get; set; }

		public event EventHandler<JobEventArgs> JobDone;

		public readonly int id;

		public readonly JobType type;

		public short numberOfDelays = 0;

		/// <summary>
		/// Creates a new job and adds it to the database. After adding to the database, it assigns a ID to itself.
		/// </summary>
		/// <param name="CPUNum"></param>
		/// <param name="runtime"></param>
		/// <param name="owner"></param>
		/// <param name="p"></param>
		public Job(int CPUNum, int runtime, Owner owner, Func<string, string> p)
		{
			id = 0;
			NumberOfCPU = CPUNum;
			ExpRuntime = runtime;
			Owner = owner;

			this.p = p;

			State = JobState.WAITING;

			this.id = DatabaseManager.addJob(this);

			if(runtime >= 100 && runtime <= 500)
			{ 
				this.type = JobType.SHORT;
			} 
			else if (runtime >= 600 && runtime <= 2000)
			{ 
				this.type = JobType.LONG;
			} 
			else if (runtime >= 2100 && runtime <= 5000)
			{ 
				this.type = JobType.VERY_LONG;
			}
		}


		// TODO Add some kind of exception handling, to check if the process fail.
		public string procces(string s)
		{
			this.State = JobState.RUNNING;
			Task<string> task = Task<string>.Factory.StartNew(() => p(s));
			string returnMsg = task.Result;

			// Simulates a runtime for the function
			System.Threading.Thread.Sleep(ExpRuntime);

			this.State = JobState.DONE;
			if (JobDone != null)
				JobDone(this, new JobEventArgs(this.id, this.State));

			return returnMsg;
		}
	}
}