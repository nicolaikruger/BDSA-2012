using System;
using System.Collections.Generic;
using System.Linq;
using Jobs;
using System.Threading;


namespace BenchmarkSystem
{
#if DEBUG
	public class Scheduler
#else
	internal class Scheduler
#endif
	{
#if DEBUG
		public LinkedList<Job> JobQueue	= new LinkedList<Job>();

		public HashSet<Job> RunningJobs	= new HashSet<Job>();
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

		/// <summary>
		/// Execute all of the queued jobs
		/// </summary>
#if DEBUG
		public void executeAll()
#else
		internal void executeAll() 
#endif
		{
			bool jobsWaiting = shortJobQueue.Count > 0 || longJobQueue.Count > 0 || veryLongJobQueue.Count > 0;

			while (jobsWaiting)
			{
				if (shortJobQueue.Count > 0 && shortRunningJobs.Count <= 20)
				{
					Job tmp = shortJobQueue.First();
					shortJobQueue.RemoveFirst();
					shortRunningJobs.Add(tmp);
					tmp.State = JobState.Running;
					tmp.JobDone += onJobDone;
					JobEventArgs e = new JobEventArgs(tmp.id, tmp.State);
					OnJobRunning(tmp, e);
					tmp.procces("");
				}

				if (longJobQueue.Count > 0 && longRunningJobs.Count <= 20)
				{
					Job tmp = longJobQueue.First();
					longJobQueue.RemoveFirst();
					longRunningJobs.Add(tmp);
					tmp.State = JobState.Running;
					tmp.JobDone += onJobDone;
					JobEventArgs e = new JobEventArgs(tmp.id, tmp.State);
					OnJobRunning(tmp, e);
					tmp.procces("");
				}

				if (veryLongJobQueue.Count > 0 && veryLongRunningJobs.Count <= 20)
				{
					Job tmp = veryLongJobQueue.First();
					veryLongJobQueue.RemoveFirst();
					veryLongRunningJobs.Add(tmp);
					tmp.State = JobState.Running;
					tmp.JobDone += onJobDone;
					JobEventArgs e = new JobEventArgs(tmp.id, tmp.State);
					OnJobRunning(tmp, e);
					tmp.procces("");
				}


				jobsWaiting = shortJobQueue.Count > 0 || longJobQueue.Count > 0 || veryLongJobQueue.Count > 0;
			}
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
			job.JobDone -= onJobDone;
			removeJob(job);
			job.State = JobState.Done;
			JobEventArgs newE = new JobEventArgs(job.id, job.State);

			if (JobDone != null)
				JobDone(o, newE);
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
			if (job.ExpRuntime <= 1000 * 30)
				removeJob(job, shortRunningJobs, shortJobQueue);
			else if (job.ExpRuntime <= 1000 * 60*2)
				removeJob(job, longRunningJobs, longJobQueue);
			else
				removeJob(job, veryLongRunningJobs, veryLongJobQueue);
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
			System.Threading.Thread.Sleep(1);
            if(job.ExpRuntime <= 1000*30)
                shortJobQueue.AddLast(job);
            else if (job.ExpRuntime <= 1000*60*2)
                longJobQueue.AddLast(job);
            else
                veryLongJobQueue.AddLast(job);
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
			List<Job> jobs = new List<Job>(3);

			Job j1 = shortJobQueue.First();//checkFirst(shortRunningJobs, shortJobQueue);
			Job j2 = longJobQueue.First();//checkFirst(longRunningJobs, longJobQueue);
			Job j3 = veryLongJobQueue.First();//checkFirst(veryLongRunningJobs, veryLongJobQueue);

			jobs.Add(j1);
			jobs.Add(j2);
			jobs.Add(j3);

			Job returnJob = getFirst(jobs);

			Console.Out.WriteLine();
			Console.Out.WriteLine(returnJob.timeStamp);

			if (returnJob == j1)
				shortJobQueue.RemoveFirst();
			else if (returnJob == j2)
				longJobQueue.RemoveFirst();
			else if (returnJob == j3)
				veryLongJobQueue.RemoveFirst();

			return returnJob;

		}

		/// <summary>
		/// Finds a job within either a hashset or a linkedlist, and removes it.
		/// </summary>
		/// <param name="job">The job to remove</param>
		/// <param name="running">A hashset where the job might be held</param>
		/// <param name="queue">A linkedlist where the job might be held</param>
		private void removeJob(Job job, HashSet<Job> running, LinkedList<Job> queue) 
		{
			if (running.Remove(job))
				return;

			queue.Remove(job);
		}

		/// <summary>
		/// Compares a hashset and a linkedlist to find the job that was added first.
		/// If both collections a empty, null is returned.
		/// If the hashset is empty, the job is beeing found within the linkedlist.
		/// If the neither of the collections are empty, the job is beeing found within the hashset.
		/// </summary>
		/// <param name="runningCollection">The hashset to look in</param>
		/// <param name="queue">The linkedlist to look in</param>
		/// <returns>The job that was first add to the schedular within the two lists</returns>
		private Job checkFirst(HashSet<Job> runningCollection, LinkedList<Job> queue)
		{
			if (runningCollection.Count == 0 && queue.Count == 0)
				return null;
			if (runningCollection.Count == 0)
				return queue.First();
			else
				return getFirst(runningCollection);
		}

		/// <summary>
		/// Finds the job with the earlist timestamp, within a collection
		/// </summary>
		/// <param name="jobSet">The collection to look in</param>
		/// <returns>The job with the earliste timestamp</returns>
		private Job getFirst(IEnumerable<Job> jobSet)
		{
			List<Job> jobs = jobSet.OrderBy(j => j.timeStamp).ToList();

			return jobs.First();
		}

        private Job findNextJobToRun(int index)
        {
            Job job = JobQueue.

                if(job.type == shortJobs)
                    if (shortJobs < 20 && job.NumberOfCPU < AvailableCPU)
                    {
                        return job;
                    }
                    else if (job.numberOfdelays = 2)
                    {
                        Thread.Sleep(20);
                        findNextJobToRun(index);
                    }
                    else
                    {
                        job.delayed();
                        findNextJobToRun(index++);
                    }   

               Job job = JobsQueued.get(index);

           
                if(job.type == LongJobs)
                    if (longJobs < 20 && job.NumberOfCPU < AvailableCPU)
                    {
                        return job;
                    }
                    else if (job.numberOfdelays = 2)
                    {
                        Thread.Sleep(20);
                        findNextJobToRun(index);
                    }
                    else
                    {
                        job.delayed();
                        findNextJobToRun(index++);
                    }   

            Job job = JobsQueued.get(index);

           
                if(job.type == VeryLongJob)
                    if (VeryLongJobs < 20 && job.NumberOfCPU < AvailableCPU)
                    {
                        return job;
                    }
                    else if (job.numberOfdelays = 2)
                    {
                        Thread.Sleep(20);
                        findNextJobToRun(index);
                    }
                    else
                    {
                        job.delayed();
                        findNextJobToRun(index++);
                    }   
            }
           
        }
	}
}
