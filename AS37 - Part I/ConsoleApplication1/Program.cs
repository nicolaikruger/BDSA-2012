using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace BDSA12
{
	class Program
	{
		private static string urlRegEx = @"(http://|www|http://www)[\.\w\d-_]*\.\w*[^\s]*";
		private static string dateRegEx = @"(?<=Posted: )\w+, \d+ \w+ \d+";

		private static string txt = "";
		private static string Txt
		{
			get { return txt; }
			set	{ if(txt.Equals("")) txt = value; }
		}

		static void Main(string[] args)
		{
			Txt = TextFileReader.ReadFile("../../testFile.txt");
			search("String that cant be found in the txt!");
			while (true)
			{
				string input = Console.ReadLine();
				Console.Clear();
				if (input.Length > 0)
					search(input);
				else 
					search("String that cant be found in the txt!");
			}
		}

		static void search(string keyword)
		{
			string expression = removePluses(keyword);

			Console.Out.WriteLine("You searched for: \"" + expression + "\"\n");

			List<Tuple<int, int>> matchesIndexes = getIndexes(Txt, expression);

			createStringParts(matchesIndexes);
		}

		static List<Tuple<int, int>> getIndexes(string txt, string expression)
		{
			List<Tuple<int, int>> returnList = new List<Tuple<int, int>>();

			Regex reg = new Regex(expression);
			MatchCollection matches = reg.Matches(txt);

			foreach (Match match in matches)
			{
				int startIndex = match.Index;
				int length = match.Length;
				returnList.Add(new Tuple<int, int>(startIndex, startIndex + length));
			}

			return returnList;
		}

		static void createStringParts(List<Tuple<int, int>> list)
		{
			int normalStartIndex = 0;
			List<StringPart> stringParts = new List<StringPart>();

			foreach (Tuple<int, int> t in list)
			{
				if (t.Item1 != normalStartIndex) {
					string normalTxt = Txt.Substring(normalStartIndex, (t.Item1 - normalStartIndex));
					if (Regex.IsMatch(normalTxt, urlRegEx))
						stringParts.AddRange(findURL(normalTxt, normalStartIndex));
					else if(Regex.IsMatch(normalTxt, dateRegEx))
						stringParts.AddRange(findDates(normalTxt, normalStartIndex));
					else
						stringParts.Add(new StringPart(normalTxt, ConsoleColor.Black));
				}

				int length = t.Item2 - t.Item1;
				string keyWordTxt = Txt.Substring(t.Item1, length);
				stringParts.Add(new StringPart(keyWordTxt, ConsoleColor.Yellow));
				normalStartIndex = t.Item2;
			}

			if (normalStartIndex != Txt.Length - 1) {
				int length = (Txt.Length - 1) - normalStartIndex;
				string normalTxt = Txt.Substring(normalStartIndex, length);
				if (Regex.IsMatch(normalTxt, urlRegEx))
					stringParts.AddRange(findURL(normalTxt, normalStartIndex));
				else if (Regex.IsMatch(normalTxt, dateRegEx))
					stringParts.AddRange(findDates(normalTxt, normalStartIndex));
				else
					stringParts.Add(new StringPart(normalTxt, ConsoleColor.Black));
			}

			print(stringParts.ToArray());
		}

		static List<StringPart> findURL(string txt, int startIndex)
		{
			int normalStartIndex = 0;
			List<StringPart> returnList = new List<StringPart>();
			List<Tuple<int, int>> indexList = getIndexes(txt, urlRegEx);

			foreach (Tuple<int, int> t in indexList)
			{
				if (t.Item1 != normalStartIndex)
				{
					string normalTxt = txt.Substring(normalStartIndex, (t.Item1 - normalStartIndex));
					if (Regex.IsMatch(normalTxt, dateRegEx))
						returnList.AddRange(findDates(normalTxt, normalStartIndex + startIndex));
					else
						returnList.Add(new StringPart(normalTxt, ConsoleColor.Black));
				}

				int length = t.Item2 - t.Item1;
				string keyWordTxt = txt.Substring(t.Item1, length);
				returnList.Add(new StringPart(keyWordTxt, ConsoleColor.Blue));
				normalStartIndex = t.Item2;
			}

			if (normalStartIndex != Txt.Length - 1)
			{
				int length = txt.Length - normalStartIndex;
				string normalTxt = txt.Substring(normalStartIndex, length);
				if (Regex.IsMatch(normalTxt, dateRegEx))
					returnList.AddRange(findDates(normalTxt, normalStartIndex));
				else
					returnList.Add(new StringPart(normalTxt, ConsoleColor.Black));
			}

			return returnList;
		}

		static List<StringPart> findDates(string txt, int startIndex)
		{
			int normalStartIndex = 0;
			List<StringPart> returnList = new List<StringPart>();
			List<Tuple<int, int>> indexList = getIndexes(txt, dateRegEx);

			foreach (Tuple<int, int> t in indexList)
			{
				if (t.Item1 != normalStartIndex)
				{
					string normalTxt = txt.Substring(normalStartIndex, (t.Item1 - normalStartIndex));
					returnList.Add(new StringPart(normalTxt, ConsoleColor.Black));
				}

				int length = t.Item2 - t.Item1;
				string keyWordTxt = txt.Substring(t.Item1, length);
				returnList.Add(new StringPart(keyWordTxt, ConsoleColor.Red));
				normalStartIndex = t.Item2;
			}

			if (normalStartIndex != Txt.Length - 1)
			{
				int length = txt.Length - normalStartIndex;
				string normalTxt = txt.Substring(normalStartIndex, length);
				returnList.Add(new StringPart(normalTxt, ConsoleColor.Black));
			}

			return returnList;
		}

		static void print(params StringPart[] stringParts)
		{
			Console.ForegroundColor = ConsoleColor.Gray;
			foreach (StringPart stringPart in stringParts)
			{
				Console.BackgroundColor = stringPart.color;
				Console.Out.Write(stringPart.txt);
			}

			Console.BackgroundColor = ConsoleColor.Black;
		}

		static string removePluses(string s)
		{
			Regex reg = new Regex(@"\s*\+\s*");
			return removeStars(reg.Replace(s, @"\s"));
		}

		static string removeStars(string s)
		{
			Regex reg = new Regex(@"\*");
			return @"[^\d\w]" + reg.Replace(s, @"(\d|\w)*") + @"[^\d\w]";
		}

	}
}
