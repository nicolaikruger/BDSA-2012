//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BenchmarkSystem.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DB_JobLogSet
    {
        public int logId { get; set; }
        public string status { get; set; }
        public System.DateTime dateTime { get; set; }
        public int job_jobId { get; set; }
    
        public virtual DB_JobSet DB_JobSet { get; set; }
    }
}
