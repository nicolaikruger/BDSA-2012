using System;
using System.Collections.Generic;
using System.Linq;
using Jobs;


namespace BenchmarkSystem
{
#if DEBUG
	public class Scheduler
#else
	internal class Scheduler
#endif
	{
#if DEBUG
		public List<Job> JobQueue = new List<Job>();
		public HashSet<Job> RunningJobs = new HashSet<Job>();
		private int shortRunningJobs, longRunningJobs, veryLongRunningJobs;

#else
		private LinkedList<Job> shortJobQueue = new LinkedList<Job>();
		private LinkedList<Job> longJobQueue = new LinkedList<Job>();
		private LinkedList<Job> veryLongJobQueue = new LinkedList<Job>();

		private HashSet<Job> shortRunningJobs = new HashSet<Job>();
		private HashSet<Job> longRunningJobs = new HashSet<Job>();
		private HashSet<Job> veryLongRunningJobs = new HashSet<Job>();
#endif
		internal event EventHandler<JobEventArgs> JobDone, JobRunning;

		/// <summary>
		/// Prints out a nice status message about the system
		/// </summary>
		internal void status()
		{
			int totalQueued = JobQueue.Count;
			int totalRunning = RunningJobs.Count;

			int shortJobsQueued = 0;
			int longJobsQueued = 0;
			int verylongJobsQueued = 0;
			for (int i = 0; i < JobQueue.Count; i++)
			{
				Job tmp = JobQueue.ElementAt(i);

				if (tmp.type == JobType.SHORT)
					shortJobsQueued++;
				else if (tmp.type == JobType.LONG)
					longJobsQueued++;
				else if (tmp.type == JobType.VERY_LONG)
					verylongJobsQueued++;

			}

			Console.Out.WriteLine("\n+-----------------------------------------------+");
			Console.Out.WriteLine("|                    STATUS:                    |");
			Console.Out.WriteLine("| Total queued short jobs:\t\t" + shortJobsQueued + "\t|");
			Console.Out.WriteLine("| Total queued long jobs:\t\t" + longJobsQueued + "\t|");
			Console.Out.WriteLine("| Total queued very long jobs:\t\t" + verylongJobsQueued + "\t|");
			Console.Out.WriteLine("| Total queued jobs:\t\t\t" + totalQueued + "\t|");
			Console.Out.WriteLine("|\t\t\t\t\t\t|");
			Console.Out.WriteLine("| Total running short jobs:\t\t" + shortRunningJobs + "\t|");
			Console.Out.WriteLine("| Total running long jobs:\t\t" + longRunningJobs + "\t|");
			Console.Out.WriteLine("| Total running very long jobs:\t\t" + veryLongRunningJobs + "\t|");
			Console.Out.WriteLine("| Total running jobs:\t\t\t" + totalRunning + "\t|");
			Console.Out.WriteLine("|\t\t\t\t\t\t|");
			Console.Out.WriteLine("| Total number of jobs:\t\t\t" + (totalQueued + totalRunning) + "\t|");
			Console.Out.WriteLine("+-----------------------------------------------+\n");
		}

		/// <summary>
		/// Execute all of the queued jobs
		/// </summary>
#if DEBUG
		public void executeAll()
#else
		internal void executeAll() 
#endif
		{
			while (JobQueue.Count() > 0)
			{
				Job tmp = findNextJobToRun();
				JobQueue.Remove(tmp);
				RunningJobs.Add(tmp);
				incrementRunningJobs(tmp);
				tmp.JobDone += onJobDone;
				JobEventArgs e = new JobEventArgs(tmp.id, tmp.State);
				OnJobRunning(tmp, e);
				tmp.procces("");
			}
		}

#if DEBUG
		public void incrementRunningJobs(Job job)
#else 
		private void incrementRunningJobs(Job job)
#endif
		{
			JobType type = job.type;
			if (type == JobType.SHORT) shortRunningJobs++;
			else if (type == JobType.LONG) longRunningJobs++;
			else if (type == JobType.VERY_LONG) veryLongRunningJobs++;
		}

		private void OnJobRunning(Job job, JobEventArgs e)
		{
			if (JobRunning != null)
				JobRunning(job, e);
		}

		/// <summary>
		/// Eventhandler for notifying the system that a job has completed.
		/// Also removes the completed job from the running sets.
		/// </summary>
		private void onJobDone(Object o, JobEventArgs e)
		{
			Job job = (Job)o;
			decrementRunningJobs(job);
			job.JobDone -= onJobDone;
			removeJob(job);
			JobEventArgs newE = new JobEventArgs(job.id, job.State);

			if (JobDone != null)
				JobDone(o, newE);
		}

#if DEBUG
		public void decrementRunningJobs(Job job)
#else 
		private void incrementRunningJobs(Job job)
#endif
		{
			JobType type = job.type;
			if (type == JobType.SHORT) shortRunningJobs--;
			else if (type == JobType.LONG) longRunningJobs--;
			else if (type == JobType.VERY_LONG) veryLongRunningJobs--;
		}

		/// <summary>
		/// Removes a job from the scheduler.
		/// </summary>
		/// <param name="job">The job to remove</param>
#if DEBUG
		public void removeJob(Job job)
#else
		internal void removeJob(Job job)
#endif
		{
			JobQueue.Remove(job);
		}

		/// <summary>
		/// Adds a job to the scheduler. The job is automaticly placed in the right queue.
		/// </summary>
		/// <param name="job">The job to add</param>
#if DEBUG
		public void addJob(Job job)
#else
		internal void addJob(Job job)
#endif
		{
			job.timeStamp = DateTime.Now;
			JobQueue.Add(job);
		}

		/// <summary>
		/// Returns the job that was added to the scheduler first.
		/// </summary>
		/// <returns>The job that was added last</returns>
#if DEBUG
		public Job PopJob()
#else	
		internal Job PopJob()
#endif
		{
			return JobQueue.First();

		}


		private Job findNextJobToRun()
		{
			for (int i = 0; i > JobQueue.Count(); i++)
			{
				Job job = JobQueue.ElementAt(i);

				if (job.type == JobType.SHORT)
					return findJob(job, shortRunningJobs);

				if (job.type == JobType.LONG)
					return findJob(job, longRunningJobs);

				if (job.type == JobType.VERY_LONG)
					return findJob(job, veryLongRunningJobs);
			}
			System.Threading.Thread.Sleep(100);
			return findNextJobToRun();

		}

		private Job findJob(Job job, int runningJobs)
		{
			if (runningJobs < 20 && job.NumberOfCPU < BenchmarkSystem.AvailableCPU)
			{
				return job;
			}
			else if (job.numberOfDelays == 2)
			{
				System.Threading.Thread.Sleep(100);
				return findNextJobToRun();
			}
			else
			{
				job.numberOfDelays++;
				return findNextJobToRun();
			}
		}

	}
}
