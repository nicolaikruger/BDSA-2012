using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystem
{
	class Scheduler
	{
		private Queue<Job> shortJobQueue	= new Queue<Job>();
		private Queue<Job> longJobQueue		= new Queue<Job>();
		private Queue<Job> veryLongJobQueue = new Queue<Job>();

		private HashSet<Job> shortRunningJobs		= new HashSet<Job>();
		private HashSet<Job> longRunningJobs		= new HashSet<Job>();
		private HashSet<Job> veryLongRunningJobs	= new HashSet<Job>();

		public Job PopJob()
		{
			List<Job> jobs = new List<Job>(3);

			Job j1 = checkFirst(shortRunningJobs, shortJobQueue);
			Job j2 = checkFirst(longRunningJobs, longJobQueue);
			Job j3 = checkFirst(veryLongRunningJobs, veryLongJobQueue);

			if (j1 != null)
				jobs.Add(j1);

			if (j2 != null)
				jobs.Add(j2);

			if (j3 != null)
				jobs.Add(j3);

			if (jobs.Count == 0)
				return null;
			else
				return getFirst(jobs);
		}

		private Job checkFirst(HashSet<Job> runningCollection, Queue<Job> queue)
		{
			if (runningCollection.Count == 0 && queue.Count == 0)
				return null;
			if (runningCollection.Count == 0)
				return queue.Peek();
			else
				return getFirst(runningCollection);
		}

		private Job getFirst(IEnumerable<Job> jobSet)
		{
			jobSet.OrderBy(j => j.timeStamp);

			return jobSet.First();
		}
	}
}
