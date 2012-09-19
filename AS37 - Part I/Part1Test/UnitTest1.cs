using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDSA12;
using System.Collections.Generic;

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
        public void TestGetIndexes_noMatch()
        {
            string input = @"is simply dummy text of the printing and typesetting industry.
                            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                            when an unknown printer took a galley of type and scrambled it to make a 
                            type specimen book. It has survived not only five centuries, but also 
                            the leap into electronic typesetting, remaining essentially unchanged. 
                            It was popularised in the 1960s with the release of Letraset sheets 
                            containing Lorem Ipsum passages, and more recently with desktop publishing 
                            software like Aldus PageMaker including versions of Lorem Ipsum";

            List<Tuple<int, int>> answer = Program.getIndexes(input, "Jens vejmand");

            bool isEmpty = answer.Count == 0;

            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void TestGetIndexes_match()
        {
            string input = @"is simply dummy text of the printing and typesetting industry.
                            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                            when an unknown printer took a galley of type and scrambled it to make a 
                            type specimen book. It has survived not only five centuries, but also 
                            the leap into electronic typesetting, remaining essentially unchanged. 
                            It was popularised in the 1960s with the release of Letraset sheets 
                            containing Lorem Ipsum passages, and more recently with desktop publishing 
                            software like Aldus PageMaker including versions of Lorem Ipsum";

            List<Tuple<int, int>> answer = Program.getIndexes(input, "Lorem");

            bool isEmpty = answer.Count == 0;

            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void TestGetIndexes_escapedChararters_noMatch()
        {
            string input = @"is simply dummy text of the printing and typesetting industry.
                            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                            when an unknown printer took a galley of type and scrambled it to make a 
                            type specimen book. It has survived not only five centuries, but also 
                            the leap into electronic typesetting, remaining essentially unchanged. 
                            It was popularised in the 1960s with the release of Letraset sheets 
                            containing Lorem Ipsum passages, and more recently with desktop publishing 
                            software like Aldus PageMaker including versions of Lorem Ipsum";

            List<Tuple<int, int>> answer = Program.getIndexes(input, @"Jens \s vejmand");

            bool isEmpty = answer.Count == 0;

            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void TestGetIndexes_escapedChararters_match()
        {
            string input = @"is simply dummy text of the printing and typesetting industry.
                            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                            when an unknown printer took a galley of type and scrambled it to make a 
                            type specimen book. It has survived not only five centuries, but also 
                            the leap into electronic typesetting, remaining essentially unchanged. 
                            It was popularised in the 1960s with the release of Letraset sheets 
                            containing Lorem Ipsum passages, and more recently with desktop publishing 
                            software like Aldus PageMaker including versions of Lorem Ipsum";

            List<Tuple<int, int>> answer = Program.getIndexes(input, @"Lorem\s");

            bool isEmpty = answer.Count == 0;

            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void TestFindURL_noURL()
        {
            string input = @"Hello Google, how are you today";

            List<StringPart> answer = Program.findURL(input, 0);

            bool onlyOne = answer.Count <= 1;

            Assert.IsTrue(onlyOne);
        }

        [TestMethod]
        public void TestFindURL_oneURL()
        {
            string input = @"Hello http://www.google.dk, how are you today";

            List<StringPart> answer = Program.findURL(input, 0);

            bool onlyOne = answer.Count <= 1;

            Assert.IsFalse(onlyOne);
        }

        [TestMethod]
        public void TestFindDates_noDates()
        {
            string input = @"Hello World, today is 19/9-2012";

            List<StringPart> answer = Program.findDates(input, 0);

            bool onlyOne = answer.Count <= 1;

            Assert.IsTrue(onlyOne);
        }

        [TestMethod]
        public void TestFindDates_oneDate()
        {
            string input = @"Hello World, today is Posted: wen, 19 sep 2012";

            List<StringPart> answer = Program.findDates(input, 0);

            bool onlyOne = answer.Count <= 1;

            Assert.IsFalse(onlyOne);
        }
	}
}
