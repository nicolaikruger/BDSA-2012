using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;

namespace BenchmarkSystem
{
    public class LoggerEventArgs : EventArgs
    {
        public Job job { get; private set; }

        public LoggerEventArgs(Job job)
        {
            this.job = job;
        }
    }
}
