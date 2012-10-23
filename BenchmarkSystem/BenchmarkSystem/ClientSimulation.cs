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
