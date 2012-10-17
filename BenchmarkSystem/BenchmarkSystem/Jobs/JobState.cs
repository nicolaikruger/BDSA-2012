using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jobs
{
	public enum JobState { WAITING, QUEUED, RUNNING, DONE, FAILED, CANCELLED }

	public static class JobStateExtensions
	{
		public JobState toJobState(this string state)
		{
			state = state.ToUpper();

			switch (state)
			{
				case "WAITING":
					return JobState.WAITING;
				case "QUEUED":
					return JobState.QUEUED;
				case "RUNNING":
					return JobState.RUNNING;
				case "DONE":
					return JobState.DONE;
				case "FAILED":
					return JobState.FAILED;
				case "CANCELLED":
					return JobState.CANCELLED;
				default:
					throw new NotImplementedException("No JobState with that name is specified!");
			}
		}
	}
}
