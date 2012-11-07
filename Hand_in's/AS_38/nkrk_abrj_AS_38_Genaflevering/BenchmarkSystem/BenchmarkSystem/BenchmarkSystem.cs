﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;
using BenchmarkSystem.DB;
using BenchmarkSystem.Network;
using System.Threading;
using BenchmarkSystem.GUI;
using System.Windows.Forms;

namespace BenchmarkSystem
{
	public class BenchmarkSystem
	{
#if DEBUG
		public Scheduler scheduler = new Scheduler();
		public Logger.Logger logger = null;
#else
        private Scheduler scheduler = new Scheduler();
		private Logger.Logger logger = null;
#endif
		public TCPConnection conn = new TCPConnection(8080);
		public event EventHandler<JobEventArgs> JobSubmitted, JobCancelled, JobRunning, JobTerminated, JobFailed;
        public static readonly int NumberOfCPU = 30;
		private static int availableCPU = NumberOfCPU;
		public static int AvailableCPU
		{
			get
			{
				return availableCPU;
			}
			set
			{
				availableCPU = value;
			}
		}

		static void Main(string[] args) 
		{

			BenchmarkSystem bs = new BenchmarkSystem();
           
            //Creates a clientThread
            ClientSimulation cs = new ClientSimulation(bs);
            Thread clientThread = new Thread(() => cs.createRandomJob());
			
			Console.Out.WriteLine("done");

			Console.ReadLine();
		}

        //TODO : Should be made as a singleton
		public BenchmarkSystem()
		{
			subscribe(scheduler);
			logger = new Logger.Logger(this);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
			form1.form2.JobSubmittedClick += submit;
			Application.Run(form1);
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
