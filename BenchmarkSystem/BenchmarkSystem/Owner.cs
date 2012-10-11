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

		/// <summary>
		/// Creates a new owner. When created it ads itself to the database, and assign itself with a ID.
		/// </summary>
		/// <param name="name">The name of the owner</param>
		public Owner(string name)
		{
			this.id = 0;
			this.name = name;
			this.id = DatabaseManager.addOwner(this);
		}

		/// <summary>
		/// Create a new owner with a specified ID. This does NOT add the owner to the database and should only be used by the DatabaseManager.
		/// </summary>
		/// <param name="id">Id of the owner</param>
		/// <param name="name">Name of the owner</param>
		public Owner(int id, string name)
		{
			this.id = id;
			this.name = name;
		}
	}
}
