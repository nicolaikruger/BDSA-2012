using System;
using Jobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
	[TestClass]
	public class JobTest
	{
		[TestMethod]
		public void Equals_HashCode_right()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");
			Job j2 = new Job(1, 1, o, s => "Bring it!");

			bool result = j1.Equals(j2);
			int h1 = j1.GetHashCode();
			int h2 = j2.GetHashCode();

			Assert.AreEqual(h1, h2);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void Equals_HashCode_wrongDifferentOwner()
		{
			Owner o1 = new Owner("Nicolai");
			Owner o2 = new Owner("Anders");
			Job j1 = new Job(1, 1, o1, s => "Bring it!");
			Job j2 = new Job(1, 1, o2, s => "Bring it!");

			bool result = j1.Equals(j2);
			int h1 = j1.GetHashCode();
			int h2 = j2.GetHashCode();

			Assert.AreNotEqual(h1, h2);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Equals_HashCode_wrongDifferentCPU()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");
			Job j2 = new Job(2, 1, o, s => "Bring it!");

			bool result = j1.Equals(j2);
			int h1 = j1.GetHashCode();
			int h2 = j2.GetHashCode();

			Assert.AreNotEqual(h1, h2);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Equals_HashCode_wrongDifferentMinutes()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");
			Job j2 = new Job(1, 2, o, s => "Bring it!");

			bool result = j1.Equals(j2);
			int h1 = j1.GetHashCode();
			int h2 = j2.GetHashCode();

			Assert.AreNotEqual(h1, h2);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Equals_withNull()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");
			Job j2 = null;

			bool result = j1.Equals(j2);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Equals_withWrongObject()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");

			bool result = j1.Equals(o);
			
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Equals_HashCode_typesDifferentLamda()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");
			Job j2 = new Job(1, 1, o, s => "Brought it!");

			bool result = j1.Equals(j2);
			int h1 = j1.GetHashCode();
			int h2 = j2.GetHashCode();

			Assert.AreEqual(h1, h2);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void Equals_HashCode_typesDifferentState()
		{
			Owner o = new Owner("Nicolai");
			Job j1 = new Job(1, 1, o, s => "Bring it!");
			Job j2 = new Job(1, 1, o, s => "Brought it!");

			j1.State = JobState.Cancelled;

			bool result = j1.Equals(j2);
			int h1 = j1.GetHashCode();
			int h2 = j2.GetHashCode();

			Assert.AreEqual(h1, h2);
			Assert.AreEqual(true, result);
		}
	}
}
