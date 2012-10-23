using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jobs
{
	public enum JobType { SHORT, LONG, VERY_LONG }

	public static class JobTypeExtentions
	{
		public static JobType toJobType(this string type)
		{
			type = type.ToUpper();

			switch (type)
			{
				case "SHORT":
					return JobType.SHORT;
				case "LONG":
					return JobType.LONG;
				case "VERY_LONG":
					return JobType.VERY_LONG;
				default:
					throw new NotImplementedException("No JobState with that name is specified!");
			}
		}
	}
}
