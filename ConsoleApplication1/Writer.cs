using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSDA2012
{
    class Writer
    {
        public static void write(Dictionary<int, long> result, String k, String name)
        {
            int[] time = result.Keys.ToArray();
            string[] stringtime = new string[time.Length];
            int counter = 0;
            //Converts the long elements in time[] to strings and inserts them in stringtime[]
            foreach (long l in time)
            {
                stringtime[counter] = l.ToString();
                counter++;
            }
            long[] elements = result.Values.ToArray();
            string[] stringelements = new string[elements.Length];
            counter = 0;
            //Converts the int elements in elements[] to strings and inserts them in stringelements[]
            foreach (int i in elements)
            {
                stringelements[counter] = i.ToString();
                counter++;
            }
            //Writes stringtime[] to textfile ExcelGraph
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(name+".txt", true))
            {
                file.WriteLine("####ELEMENTS#### - FOR TEST " + k);
                foreach (string s in stringtime)
                {
                    file.WriteLine(s);
                }
            }

            //Writes the stringelements[] to textfile ExcelGraph
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(name+".txt", true))
            {
                file.WriteLine("###TIME###");
                foreach (string s in stringelements)
                {
                    file.WriteLine(s);
                }
            }
        }
    }
}
