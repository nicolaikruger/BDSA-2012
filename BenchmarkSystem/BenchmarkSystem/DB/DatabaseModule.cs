using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobs;

namespace BenchmarkSystem.DB
{
	class DatabaseModule
	{
		public static int addOwner(Owner o)
		{
			using (var dbContent = new BenchmarkSystemModelContainer())
			{
				var nextId = from owner in dbContent.DB_userSet
							 orderby owner.userId descending
							 select owner.userId;

				return nextId.First();
			}
		}
	}
}
