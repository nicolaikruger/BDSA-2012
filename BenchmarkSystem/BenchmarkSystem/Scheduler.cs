using System;
using System.Collections.Generic;
using System.Linq;
using Jobs;

namespace BenchmarkSystem
{
	internal class Scheduler
	{
		private LinkedList<Job> shortJobQueue		= new LinkedList<Job>();
		private LinkedList<Job> longJobQueue		= new LinkedList<Job>();
		private LinkedList<Job> veryLongJobQueue	= new LinkedList<Job>();

		private HashSet<Job> shortRunningJobs		= new HashSet<Job>();
		private HashSet<Job> longRunningJobs		= new HashSet<Job>();
		private HashSet<Job> veryLongRunningJobs	= new HashSet<Job>();

		public void status()
		{
			int totalQueued = shortJobQueue.Count + longJobQueue.Count + veryLongJobQueue.Count;
			int totalRunning = shortRunningJobs.Count + longRunningJobs.Count + veryLongRunningJobs.Count;

			Console.Out.WriteLine("\n+-----------------------------------------------+");
			Console.Out.WriteLine("|                    STATUS:                    |");
			Console.Out.WriteLine("| Total queued short jobs:\t\t" + shortJobQueue.Count + "\t|");
			Console.Out.WriteLine("| Total queued long jobs:\t\t" + longJobQueue.Count + "\t|");
			Console.Out.WriteLine("| Total queued very long jobs:\t\t" + veryLongJobQueue.Count + "\t|");
			Console.Out.WriteLine("| Total queued jobs:\t\t\t" + totalQueued + "\t|");
			Console.Out.WriteLine("|\t\t\t\t\t\t|");
			Console.Out.WriteLine("| Total running short jobs:\t\t" + shortRunningJobs.Count + "\t|");
			Console.Out.WriteLine("| Total running long jobs:\t\t" + longRunningJobs.Count + "\t|");
			Console.Out.WriteLine("| Total running very long jobs:\t\t" + veryLongRunningJobs.Count + "\t|");
			Console.Out.WriteLine("| Total running jobs:\t\t\t" + totalRunning + "\t|");
			Console.Out.WriteLine("|\t\t\t\t\t\t|");
			Console.Out.WriteLine("| Total number of jobs:\t\t\t" + (totalQueued + totalRunning) + "\t|");
			Console.Out.WriteLine("+-----------------------------------------------+\n");
		}

        public void removeJob(Job job)
        {
			if (job.ExpRuntime <= 1000 * 30)
				removeJob(job, shortRunningJobs, shortJobQueue);
			else if (job.ExpRuntime <= 1000 * 60*2)
				removeJob(job, longRunningJobs, longJobQueue);
			else
				removeJob(job, veryLongRunningJobs, veryLongJobQueue);
        }

        public void addJob(Job job)
        {
            if(job.ExpRuntime <= 1000*30)
                shortJobQueue.AddLast(job);
            else if (job.ExpRuntime <= 1000*60*2)
                longJobQueue.AddLast(job);
            else
                veryLongJobQueue.AddLast(job);
        }

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

		private void removeJob(Job job, HashSet<Job> running, LinkedList<Job> queue) 
		{
			if (running.Remove(job))
				return;

			queue.Remove(job);
		}

		private Job checkFirst(HashSet<Job> runningCollection, LinkedList<Job> queue)
		{
			if (runningCollection.Count == 0 && queue.Count == 0)
				return null;
			if (runningCollection.Count == 0)
				return queue.First();
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
