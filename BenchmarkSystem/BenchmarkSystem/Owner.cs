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
			id = 0;
			this.name = name;
			Console.WriteLine(DatabaseModule.addOwner(this));
		}
	}
}
