using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDSA12
{
	public struct StringPart
	{
		/// <summary>
		/// The text this string part consists of
		/// </summary>
		public readonly String txt;

		/// <summary>
		/// The color of this string part
		/// </summary>
		public readonly ConsoleColor color;

		/// <summary>
		/// Creates a instance of a StringPart
		/// </summary>
		/// <param name="txt">The text this stringPart consists of</param>
		/// <param name="c">The color of this stringPart</param>
		public StringPart(String txt, ConsoleColor c)
		{
			this.txt = txt;
			color = c;
		}
	}
}
