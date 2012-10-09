using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;

namespace BenchmarkSystem.DB
{
	class DatabaseManager
	{
		private static void init()
		{
			
		}

		public static int addOwner(Owner ow)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				DB_user user = new DB_user();
				user.name = ow.name;

				dbContent.DB_userSet.Add(user);
				dbContent.SaveChanges();

				return user.userId;
			}
		}

		public static int addJob(Job job)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				DB_Job dbJob = new DB_Job();
				dbJob.user_userId = job.Owner.id;
				dbJob.status = job.State.ToString();
				dbJob.submitDate = DateTime.Now;

				dbContent.DB_JobSet.Add(dbJob);
				dbContent.SaveChanges();

				return dbJob.jobId;
			}
		}

		public static ICollection<Owner> getOwners()
		{
			ICollection<Owner> returnCollection = new List<Owner>();

			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var result = from user in dbContent.DB_userSet
							 select user;

				foreach (DB_user user in result)
				{
					returnCollection.Add(new Owner(user.userId, user.name));
				}
			}

			return returnCollection;
		}

		public static ICollection<Job> getAllJobsFromUser(int userId)
		{
			throw new NotImplementedException("This method is comming in a later exercise");
			ICollection<Job> returnCollection = new List<Job>();

			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var result = from job in dbContent.DB_JobSet
							 where job.user_userId == userId
							 select job;

				foreach (DB_Job job in result)
				{
					// Insert black-magic here!
				}
			}

			return returnCollection;
		}

		public static ICollection<Job> getAllJobsFromUserWithPastXDays(int userId, int XDays)
		{
			throw new NotImplementedException("This method is comming in a later exercise");
		}

		public static ICollection<Job> getAllJobsFromUserWithinPeriod(int userId, DateTime start, DateTime end)
		{
			throw new NotImplementedException("This method is comming in a later exercise");
		}

		public static int jobsWithinPeriod(DateTime start, DateTime end)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var result = from job in dbContent.DB_JobSet
							 where start <= job.submitDate && job.submitDate <= end
							 orderby job.status
							 select job;

				return result.Count();
			}
		}

		public static int jobsWithinPeriodByUser(DateTime start, DateTime end, int userId)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var result = from job in dbContent.DB_JobSet
							 where job.user_userId == userId 
									&& start <= job.submitDate 
									&& job.submitDate <= end
							 orderby job.status
							 select job;

				return result.Count();
			}
		}

		public static void updateJob(int jobId, JobState jobState)
		{
			Console.WriteLine("DBM -> Jobid = " + jobId);

			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var result = from job in dbContent.DB_JobSet
							 where job.jobId == jobId
							 select job;
				
				DB_Job tmpJob = result.First();
				tmpJob.status = jobState.ToString();

					dbContent.SaveChanges();

				addJobLog(jobId, jobState);
			}
		}

		public static void addJobLog(int jobId, JobState jobstate)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				DB_JobLog joblog = new DB_JobLog();
				joblog.dateTime = DateTime.Now;
				joblog.job_jobId = jobId;
				joblog.status = jobstate.ToString();

				dbContent.DB_JobLogSet.Add(joblog);

				dbContent.SaveChanges();
			}
		}







		public static Owner getOwner(int id)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var dbUser = from user in dbContent.DB_userSet
							 where user.userId == id
							 select user;

				DB_user tmpUser = dbUser.First();
				
				return new Owner(tmpUser.userId, tmpUser.name); ;
			}
		}
	}
}
