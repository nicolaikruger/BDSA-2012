using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDSA12
{
	struct StringPart
	{
		public readonly String txt;

		public readonly ConsoleColor color;

		public StringPart(String txt, ConsoleColor c)
		{
			this.txt = txt;
			color = c;
		}
	}
}
