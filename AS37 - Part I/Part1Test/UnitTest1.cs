using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDSA12;

namespace Part1Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestRemovePluses_noPluses()
		{
			string input = @"Hello World";
			string answer = Program.removePluses(input);

			Assert.AreEqual(@"[^\d\w]" + input + @"[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemovePluses_mulitplePluses()
		{
			string input = @"Hello + World + My Name +Is++Foo";
			string answer = Program.removePluses(input);

			Assert.AreEqual(@"[^\d\w]Hello World My Name Is Foo[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemovePluses_onePlus()
		{
			string input = @"Hello + World";
			string answer = Program.removePluses(input);

			Assert.AreEqual(@"[^\d\w]Hello World[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemovePluses_plusAtStart()
		{
			string input = @"+Hello World";
			string answer = Program.removePluses(input);

			Assert.AreEqual(@"[^\d\w]Hello World[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemovePluses_plusAtEnd()
		{
			string input = @"Hello World+";
			string answer = Program.removePluses(input);

			Assert.AreEqual(@"[^\d\w]Hello World[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemoveStars_noStars()
		{
			string input = @"Hello World";
			string answer = Program.removeStars(input);

			Assert.AreEqual(@"[^\d\w]" + input + @"[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemoveStars_mulitplStars()
		{
			string input = @"*ll* Wor*My Nam**";
			string answer = Program.removeStars(input);

			Assert.AreEqual(@"[^\d\w](\d|\w)*ll(\d|\w)* Wor(\d|\w)*My Nam(\d|\w)*(\d|\w)*[^\d\w]", answer);
		}

		[TestMethod]
		public void TestRemoveStars_oneStar()
		{
			string input = @"*llo World";
			string answer = Program.removeStars(input);

			Assert.AreEqual(@"[^\d\w](\d|\w)*llo World[^\d\w]", answer);
		}

		[TestMethod]
	}
}
