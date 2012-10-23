using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;
using BenchmarkSystem.DB;
using System.Threading;

namespace BenchmarkSystem
{
	public class BenchmarkSystem
	{
#if DEBUG
		public Scheduler scheduler = new Scheduler();
		public Logger.Logger logger = null;
#else
        private Scheduler scheduler = new Scheduler();
#endif

        public event EventHandler<JobEventArgs> JobSubmitted, JobCancelled, JobRunning, JobTerminated, JobFailed;
        public static readonly int NumberOfCPU = 30;
        public static int AvailableCPU { get; set; }

		static void Main(string[] args) 
		{

			BenchmarkSystem bs = new BenchmarkSystem();
           
            //Creates a clientThread
            ClientSimulation cs = new ClientSimulation(bs);
            Thread clientThread = new Thread(() => cs.createRandomJob());
			
            Owner ow = new Owner("Nicolai");

			Job j = new Job(1, 2, ow, s => "Hello world");
			Console.WriteLine("Job: " + j.id);

			bs.submit(j);
			bs.executeAll();
            
			Console.Out.WriteLine("done");

			Console.ReadLine();
		}

        //TODO : Should be made as a singleton
		public BenchmarkSystem()
		{
            AvailableCPU = NumberOfCPU;
			subscribe(scheduler);
			logger = new Logger.Logger(this);
		}

		/// <summary>
		/// Submist a job to the system
		/// </summary>
		/// <param name="job">The job to add</param>
        public void submit(Job job) 
		{
			Console.WriteLine("System -> Jobid = " + job.id);
			job.State = JobState.QUEUED;
			OnJobSubmitted(job, new JobEventArgs(job.id, job.State));
			scheduler.addJob(job);
		}

		/// <summary>
		/// Cancel a job, and removes it from the system
		/// </summary>
		/// <param name="job">The job to remove</param>
        public void cancel(Job job) 
		{
			job.State = JobState.CANCELLED;
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
