﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;
using BenchmarkSystem.DB;

namespace BenchmarkSystem
{
	class BenchmarkSystem
	{
#if DEBUG
		public Scheduler scheduler = new Scheduler();
#else
        Scheduler scheduler = new Scheduler();
#endif

        public event EventHandler<JobEventArgs> JobSubmitted, JobCancelled, JobRunning, JobTerminated, JobFailed;

		static void Main(string[] args) 
		{
			BenchmarkSystem bs = new BenchmarkSystem();
			Logger.Logger logger = new Logger.Logger(bs);

			Owner ow = new Owner("Nicolai");

			Job j = new Job(1, 2, ow, s => "Hello world");
			Console.WriteLine("Job: " + j.id);

			bs.submit(j);
			bs.executeAll();

			Console.Out.WriteLine("done");

			Console.ReadLine();
		}

		public BenchmarkSystem()
		{
			subscribe(scheduler);
		}

		/// <summary>
		/// Submist a job to the system
		/// </summary>
		/// <param name="job">The job to add</param>
        public void submit(Job job) 
		{
			Console.WriteLine("System -> Jobid = " + job.id);
			job.State = JobState.Queued;
			OnJobSubmitted(job, new JobEventArgs(job.id, job.State));
			scheduler.addJob(job);
		}

		/// <summary>
		/// Cancel a job, and removes it from the system
		/// </summary>
		/// <param name="job">The job to remove</param>
        public void cancel(Job job) 
		{
			job.State = JobState.Cancelled;
			OnJobCancelled(job, new JobEventArgs(job.id, job.State));
			scheduler.removeJob(job);
		}

		/// <summary>
		/// Prints out a nice status message about the system
		/// </summary>
        public void status() 
		{
			scheduler.status();
		}

		/// <summary>
		/// Execute all of the queued jobs in the scheduler
		/// </summary>
        public void executeAll() 
		{
			scheduler.executeAll();
		}


		  //////////////////////////////////////////////////
		 // (Un)subscribes to the event from a scheduler //
		//////////////////////////////////////////////////

		private void subscribe(Scheduler s)
		{
			s.JobRunning += OnJobRunning;
			s.JobDone += OnJobTerminated;
		}

		private void unsubscribe(Scheduler s)
		{
			s.JobRunning -= OnJobRunning;
			s.JobDone -= OnJobTerminated;
		}


          ///////////////////////////////////////////////////
         // The methods below raises the different events //
        ///////////////////////////////////////////////////

		private void OnJobSubmitted(Object o, JobEventArgs e) 
        {
			if(JobSubmitted != null)
				JobSubmitted(o, e);
        }

		private void OnJobCancelled(Object o, JobEventArgs e) 
        {
			if (JobCancelled != null)
				JobCancelled(o, e);
        }

		private void OnJobRunning(Object o, JobEventArgs e) 
        {
			if(JobRunning != null)
	            JobRunning(o, e);
        }

		private void OnJobTerminated(Object o, JobEventArgs e) 
        {
			if(JobTerminated != null)
				JobTerminated(o, e);
        }

		private void OnJobFailed(Object o, JobEventArgs e) 
        {
			if(JobFailed != null)
				JobFailed(o, e);
        }
	}
}
