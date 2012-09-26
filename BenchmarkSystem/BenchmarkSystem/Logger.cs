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

        public void subscribe(BenchmarkSystem.BenchmarkSystem system)
        {
            system.JobSubmitted		+= onJobSubmit;
            system.JobCancelled		+= onJobCancel;
            system.JobRunning		+= onJobRun;
            system.JobTerminated	+= onJobTerminate;
            system.JobFailed		+= onJobFail;
        }

        public void onSubscribe(BenchmarkSystem.BenchmarkSystem system)
        {
            system.JobSubmitted		-= onJobSubmit;
            system.JobCancelled		-= onJobCancel;
            system.JobRunning		-= onJobRun;
            system.JobTerminated	-= onJobTerminate;
            system.JobFailed		-= onJobFail;
        }

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
