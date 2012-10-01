using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;

namespace BenchmarkSystem
{
	class BenchmarkSystem
	{
#if DEBUG
		public Scheduler scheduler = new Scheduler();
#else
        Scheduler scheduler = new Scheduler();
#endif

        public event EventHandler JobSubmitted, JobCancelled, JobRunning, JobTerminated, JobFailed;

		static void Main(string[] args) 
		{
			BenchmarkSystem bs = new BenchmarkSystem();
			Logger.Logger logger = new Logger.Logger(bs);

			bs.status();
			Owner kruger = new Owner(@"Nicolai Krüger");
			Owner anders = new Owner("Anders");
			Owner dario = new Owner("Dario");
			Job j1 = new Job(2, 10000, kruger, s => "Krugers job kører!");
			Job j2 = new Job(5, 31000, anders, s => "Anders' job kører!");
			Job j3 = new Job(10, 7200001, dario, s => "Darios job is running!");

			bs.submit(j1);
			bs.submit(j2);
			bs.submit(j3);

			bs.status();

			bs.cancel(j2);
			bs.cancel(j3);

			bs.status();

			bs.cancel(j1);

			bs.status();

			Console.ReadLine();
		}

		/// <summary>
		/// Submist a job to the system
		/// </summary>
		/// <param name="job">The job to add</param>
        public void submit(Job job) 
		{
			job.State = JobState.Queued;
			OnJobSubmitted(job, EventArgs.Empty);
			scheduler.addJob(job);
		}

		/// <summary>
		/// Cancel a job, and removes it from the system
		/// </summary>
		/// <param name="job">The job to remove</param>
        public void cancel(Job job) 
		{
			job.State = JobState.Cancelled;
			OnJobCancelled(job, EventArgs.Empty);
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

		private void OnJobSubmitted(Object o, EventArgs e) 
        {
			if(JobSubmitted != null)
				JobSubmitted(o, e);
        }

		private void OnJobCancelled(Object o, EventArgs e) 
        {
			if (JobCancelled != null)
				JobCancelled(o, e);
        }

		private void OnJobRunning(Object o, EventArgs e) 
        {
			if(JobRunning != null)
	            JobRunning(o, e);
        }

		private void OnJobTerminated(Object o, EventArgs e) 
        {
			if(JobTerminated != null)
				JobTerminated(o, e);
        }

		private void OnJobFailed(Object o, EventArgs e) 
        {
			if(JobFailed != null)
				JobFailed(o, e);
        }
	}
}
