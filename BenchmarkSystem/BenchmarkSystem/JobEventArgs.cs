using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jobs
{
	public class JobEventArgs : EventArgs
	{
		public readonly int JobId;
		public readonly JobState JobState;

		public JobEventArgs(int jobId, JobState jobState)
		{
			this.JobId = jobId;
			this.JobState = jobState;
		}
	}
}
