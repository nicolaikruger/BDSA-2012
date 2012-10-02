using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BSDA2012
{

    /*
     * This class as well have been duplicated from the Program class, due to sickness in the group. In this class we only have
     * one test method, which uses a sorted list to test BinarySearch().
     */
    class TestSort
    {
        private int elements, counter, numberOfElements;
        private List<int> randomList;
        private List<int> list;
        private Dictionary<int, int> dlist;
        private Dictionary<int, long> graphList;
        private SortedDictionary<int, int> slist;
        public TestSort(int elements, List<int> randomList)
        {
            this.elements = elements;
            counter = elements;
            numberOfElements = counter / 10;
            this.randomList = randomList;
            testG();
            testH();
            
        }


        private void testG()
        {
            List<int> list = new List<int>();
            Stopwatch timer = new Stopwatch();
            graphList = new Dictionary<int, long>();

            foreach (int k in randomList)
            {
                list.Add(k);
            }
            list.Sort();        //The sorted List
            int i;
            timer.Start();
            for (i = 0; i < counter; i++)
            {
                try
                {
                    list.BinarySearch(i);      //Tests BinarySearch.
                    if (i % numberOfElements == 0 && i != 0)
                    {
                        graphList.Add(i, timer.ElapsedMilliseconds);
                    }

                }
                catch (OutOfMemoryException)
                {
                    list = null;
                    Console.Out.WriteLine("Out Of Memory. For loop stopped!");
                    break;
                }

            }
            timer.Stop();
            Console.Out.WriteLine("Done with testG");
            list = null;
            Writer.write(graphList, "G", "ExcelGraphSorted");
            graphList = null;
            Console.Out.WriteLine("Type Enter to perform next test");
            Console.ReadLine();
        }

        private void testH()
        {
           
       
        }
     
    }
}
