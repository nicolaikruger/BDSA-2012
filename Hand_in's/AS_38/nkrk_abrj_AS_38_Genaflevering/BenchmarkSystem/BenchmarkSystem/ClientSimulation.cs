using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;
using System.Threading;

namespace BenchmarkSystem
{
    class ClientSimulation
    {
        private BenchmarkSystem bs;
        public ClientSimulation(BenchmarkSystem bs)
        {
            this.bs = bs;
            
        }

        /// <summary>
        /// A method that simulates a user, that adds randomjobs whenever AvailabeCPU = 30
        /// or when there is only queued a small number of jobs.
        /// If these conditions are not met, the thread sleeps and tries again afterwards.
        /// </summary>
        public void createRandomJob()
        {
            Random rand = new Random();
            while (bs.scheduler.JobQueue.Count < 4 || BenchmarkSystem.AvailableCPU == 30)
            {
                int time = rand.Next(50, 5000);
                int cpu = rand.Next(1, 10);
                Job job = new Job(cpu, time, new Owner("Client"), s => "Hello world");
            }

            Thread.Sleep(100);
            createRandomJob();
        }
    }
}
