using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;

namespace BenchmarkSystem.DB
{
	class DatabaseManager
	{

		/// <summary>
		/// Adds a owner to the database. When adding, the owner is given a ID.
		/// </summary>
		/// <param name="ow">The owner to add</param>
		/// <returns>Returns the ID the owner has been assigned with</returns>
		public static int addOwner(Owner ow)
		{
			using (var dbContent = new BenchmarkDBEntities())
			{
				DB_userSet user = new DB_userSet();
				user.name = ow.name;

				dbContent.DB_userSet.Add(user);
				dbContent.SaveChanges();

				return user.userId;
			}
		}

		/// <summary>
		/// Adds a job to the database. When adding, the job is given a ID.
		/// </summary>
		/// <param name="job">The job to add</param>
		/// <returns>Returns the ID the job has been assigned with</returns>
		public static int addJob(Job job)
		{
			using (var dbContent = new BenchmarkDBEntities())
			{
				DB_JobSet dbJob = new DB_JobSet();
				dbJob.user_userId = job.Owner.id;
				dbJob.status = job.State.ToString();
				dbJob.submitDate = DateTime.Now;
				dbJob.type = job.type.ToString();
				dbJob.numberOfDelays = job.numberOfDelays;
				

				dbContent.DB_JobSet.Add(dbJob);
				try
				{
					dbContent.SaveChanges();
				}
				catch (Exception e)
				{
					throw;
				}

				addJobLog(dbJob.jobId, job.State);

				return dbJob.jobId;
			}
		}

		/// <summary>
		/// Gets and returns a collection of all owners in the database
		/// </summary>
		/// <returns>A collection of all owners in the database</returns>
		public static ICollection<Owner> getOwners()
		{
			ICollection<Owner> returnCollection = new List<Owner>();

			using (var dbContent = new BenchmarkDBEntities())
			{
				var result = from user in dbContent.DB_userSet
							 select user;

				foreach (DB_userSet user in result)
				{
					returnCollection.Add(new Owner(user.userId, user.name));
				}
			}

			return returnCollection;
		}

		/// <summary>
		/// Gets and returns a collection of all jobs with a specified owner.
		/// </summary>
		/// <param name="userId">The id of the owner</param>
		/// <returns>A collection of jobs</returns>
		public static ICollection<Job> getAllJobsFromUser(int userId)
		{
			throw new NotImplementedException("This method is comming in a later exercise");
			ICollection<Job> returnCollection = new List<Job>();

			using (var dbContent = new BenchmarkDBEntities())
			{
				var result = from job in dbContent.DB_JobSet
							 where job.user_userId == userId
							 select job;

				foreach (DB_JobSet job in result)
				{
					// Insert black-magic here!
				}
			}

			return returnCollection;
		}

		/// <summary>
		/// Gets and returns a collection of all jobs with a specified owner created within the last X days.
		/// </summary>
		/// <param name="userId">The id of the owner</param>
		/// <param name="XDays">How many days back the search should go</param>
		/// <returns>A collection of jobs</returns>
		public static ICollection<Job> getAllJobsFromUserWithPastXDays(int userId, int XDays)
		{
			throw new NotImplementedException("This method is comming in a later exercise");
		}

		/// <summary>
		/// Gets and returns a collection of all jobs with a specified owner created within the given periode.
		/// </summary>
		/// <param name="userId">The id of the owner</param>
		/// <param name="start">The start date and time</param>
		/// <param name="end">The end data and time</param>
		/// <returns>A collection of jobs</returns>
		public static ICollection<Job> getAllJobsFromUserWithinPeriod(int userId, DateTime start, DateTime end)
		{
			throw new NotImplementedException("This method is comming in a later exercise");
		}

		/// <summary>
		/// Gets and returns a collection of all jobs created within the given periode.
		/// </summary>
		/// <param name="start">The start date and time</param>
		/// <param name="end">The end data and time</param>
		/// <returns>A collection of jobs</returns>
		public static int jobsWithinPeriod(DateTime start, DateTime end)
		{
			using (var dbContent = new BenchmarkDBEntities())
			{
				var result = from job in dbContent.DB_JobSet
							 where start <= job.submitDate && job.submitDate <= end
							 orderby job.status
							 select job;

				return result.Count();
			}
		}

		/// <summary>
		/// Returns the number of jobs "owned" by a user within the a specified periode of time.
		/// </summary>
		/// <param name="start">The start date and time</param>
		/// <param name="end">The end data and time</param>
		/// <param name="userId">The id of the owner</param>
		/// <returns>Number of jobs</returns>
		public static int jobsWithinPeriodByUser(DateTime start, DateTime end, int userId)
		{
			using (var dbContent = new BenchmarkDBEntities())
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

		/// <summary>
		/// Updates a given jobs state. After updating it calls the addJobLog method, with the same parameters.
		/// </summary>
		/// <param name="jobId">The ID og the job to update</param>
		/// <param name="jobState">The new state of the job</param>
		public static void updateJob(int jobId, JobState jobState)
		{
			Console.WriteLine("DBM -> Jobid = " + jobId);

			using (var dbContent = new BenchmarkDBEntities())
			{
				var result = from job in dbContent.DB_JobSet
							 where job.jobId == jobId
							 select job;
				
				DB_JobSet tmpJob = result.First();
				tmpJob.status = jobState.ToString();

					dbContent.SaveChanges();

				addJobLog(jobId, jobState);
			}
		}

		/// <summary>
		/// Logs a change about a jobs state.
		/// </summary>
		/// <param name="jobId">The ID of the job</param>
		/// <param name="jobstate">The new state of the job</param>
		public static void addJobLog(int jobId, JobState jobstate)
		{
			using (var dbContent = new BenchmarkDBEntities())
			{
				DB_JobLogSet joblog = new DB_JobLogSet();
				joblog.dateTime = DateTime.Now;
				joblog.job_jobId = jobId;
				joblog.status = jobstate.ToString();

				dbContent.DB_JobLogSet.Add(joblog);

				dbContent.SaveChanges();
			}
		}






		/// <summary>
		/// Returns the owner from the database with the specified ID
		/// </summary>
		/// <param name="id">The ID of the owner</param>
		/// <returns>A owner from the database</returns>
		public static Owner getOwner(int id)
		{
			using (var dbContent = new BenchmarkDBEntities())
			{
				var dbUser = from user in dbContent.DB_userSet
							 where user.userId == id
							 select user;

				DB_userSet tmpUser = dbUser.First();
				
				return new Owner(tmpUser.userId, tmpUser.name); ;
			}
		}
	}
}
