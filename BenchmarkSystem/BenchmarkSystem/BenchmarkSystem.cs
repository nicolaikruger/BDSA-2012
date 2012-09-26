using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;

namespace BenchmarkSystem
{
	class BenchmarkSystem
	{
        Scheduler scheduler = new Scheduler();

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

        public void submit(Job job) 
		{
			job.State = JobState.Queued;
			OnJobSubmitted();
			scheduler.addJob(job);
		}

        public void cancel(Job job) 
		{
			job.State = JobState.Cancelled;
			OnJobCancelled();
			scheduler.removeJob(job);
		}

        public void status() 
		{
			scheduler.status();
		}

        public void executeAll() { }


        ///////////////////////////////////////////////////
        // The methods below raises the different events //
        ///////////////////////////////////////////////////

        private void OnJobSubmitted() 
        {
			if(JobSubmitted != null)
				JobSubmitted(this, EventArgs.Empty);
        }

        private void OnJobCancelled() 
        {
			if (JobCancelled != null)
				JobCancelled(this, EventArgs.Empty);
        }

        private void OnJobRunning() 
        {
			if(JobRunning != null)
	            JobRunning(this, EventArgs.Empty);
        }

        private void OnJobTerminated() 
        {
			if(JobTerminated != null)
				JobTerminated(this, EventArgs.Empty);
        }

        private void OnJobFailed() 
        {
			if(JobFailed != null)
				JobFailed(this, EventArgs.Empty);
        }
	}
}
