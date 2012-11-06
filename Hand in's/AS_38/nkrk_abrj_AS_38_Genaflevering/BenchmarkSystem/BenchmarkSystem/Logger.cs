using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;
using BenchmarkSystem.DB;

namespace Logger
{
	public class Logger
	{
        public Logger(BenchmarkSystem.BenchmarkSystem system)
        {
            subscribe(system);
        }

		/// <summary>
		/// Starts listens to events
		/// </summary>
		/// <param name="system">The system to "listen" to</param>
        public void subscribe(BenchmarkSystem.BenchmarkSystem system)
        {
            system.JobSubmitted		+= onJobSubmit;
            system.JobCancelled		+= onJobCancel;
            system.JobRunning		+= onJobRun;
            system.JobTerminated	+= onJobTerminate;
            system.JobFailed		+= onJobFail;
        }

		/// <summary>
		/// Stop listens to event
		/// </summary>
		/// <param name="system">The system to stop "listen" to</param>
        public void onSubscribe(BenchmarkSystem.BenchmarkSystem system)
        {
            system.JobSubmitted		-= onJobSubmit;
            system.JobCancelled		-= onJobCancel;
            system.JobRunning		-= onJobRun;
            system.JobTerminated	-= onJobTerminate;
            system.JobFailed		-= onJobFail;
        }

		//////////////////////////////////////////////////////////////////////////
		// Prints out a nice little comment to the console, about a given event //
		//////////////////////////////////////////////////////////////////////////

		private void onJobSubmit(Object sender, JobEventArgs e)
        {
            Console.Out.WriteLine("{0} JobID: {1}:\t Job has been submitted.", DateTime.Now, e.JobId);
			DatabaseManager.updateJob(e.JobId, e.JobState);
        }

		private void onJobCancel(Object sender, JobEventArgs e)
        {
			Console.Out.WriteLine("{0} JobID: {1}:\t Job has been cancelled.", DateTime.Now, e.JobId);
			DatabaseManager.updateJob(e.JobId, e.JobState);
        }

		private void onJobRun(Object sender, JobEventArgs e)
        {
			Console.Out.WriteLine("{0} JobID: {1}:\t Job is runnig.", DateTime.Now, e.JobId);
			DatabaseManager.updateJob(e.JobId, e.JobState);
        }

		private void onJobTerminate(Object sender, JobEventArgs e)
        {
			Console.Out.WriteLine("{0} JobID: {1}:\t Job has teminated.", DateTime.Now, e.JobId);
			DatabaseManager.updateJob(e.JobId, e.JobState);
        }

		private void onJobFail(Object sender, JobEventArgs e)
        {
			Console.Out.WriteLine("{0} JobID: {1}:\t Job has failed.", DateTime.Now, e.JobId);
			DatabaseManager.updateJob(e.JobId, e.JobState);
        }
	}
}
