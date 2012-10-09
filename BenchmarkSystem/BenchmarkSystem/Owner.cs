using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystem.DB;

namespace Jobs
{
	public struct Owner
	{
		public readonly int id;
		public readonly string name;

		public Owner(string name)
		{
			this.id = 0;
			this.name = name;
			this.id = DatabaseManager.addOwner(this);
		}

		public Owner(int id, string name)
		{
			this.id = id;
			this.name = name;
		}
	}
}
