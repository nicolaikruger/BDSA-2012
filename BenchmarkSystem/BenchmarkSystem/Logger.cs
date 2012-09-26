using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
	class Logger
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

        private void onJobSubmit(Object sender, EventArgs e)
        {
            Console.Out.WriteLine(DateTime.Now + ": A job has been submitted.");
        }

        private void onJobCancel(Object sender, EventArgs e)
        {
            Console.Out.WriteLine(DateTime.Now + ": A job has been cancelled.");
        }

        private void onJobRun(Object sender, EventArgs e)
        {
            Console.Out.WriteLine(DateTime.Now + ": A job is runnig.");
        }

        private void onJobTerminate(Object sender, EventArgs e)
        {
            Console.Out.WriteLine(DateTime.Now + ": A job has teminated.");
        }

        private void onJobFail(Object sender, EventArgs e)
        {
            Console.Out.WriteLine(DateTime.Now + ": A job has failed.");
        }
	}
}
