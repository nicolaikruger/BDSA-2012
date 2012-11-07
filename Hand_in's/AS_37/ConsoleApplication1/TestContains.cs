using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BSDA2012
{

    /*
     * Because of sickness in the group all is this class have been duplicated from the Program class
     * and just modified to test Contains() insted of Add()
     */ 
    class TestContains
    {
        private int elements;
        private static int counter, numberOfElements;
        private static List<int> randomList;
        private Random random;
        private static Dictionary<int, long> graphList;
        private List<int> list;
        private Dictionary<int, int> dlist;
        private SortedDictionary<int, int> slist;
        public TestContains(int elements)
        {
            this.elements = elements;
            counter = elements;
            numberOfElements = counter / 10;
            
            random = new Random();
            makeRandomList();
            list = new List<int>();
            dlist = new Dictionary<int, int>();
            slist = new SortedDictionary<int, int>();
      
            testD();
            testE();
            testF();
           TestSort testsort = new TestSort(elements, randomList);
        }

        private void makeRandomList()
        {
            randomList = new List<int>();
            for(int i = 0; i>counter; i++)
            {
                randomList.Add(random.Next(1, counter));
            }
        }

        /*
         * Fourth test method. 
         */
        private static void testD()
        {
            List<int> list = new List<int>();
            Stopwatch timer = new Stopwatch();
            graphList = new Dictionary<int, long>();
            foreach (int k in randomList)
            {
                list.Add(k);
            }
            int i;
            timer.Start();
            for (i = 0; i < counter; i++)
            {
                try
                {
                    list.Contains(i); //Modified to test Contains()
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
            Console.Out.WriteLine("Done with testD");
            Writer.write(graphList, "D", "ExcelGraphContains");
            list = null;
            graphList = null;
            Console.Out.WriteLine("Type Enter to perform next test");
            Console.ReadLine();
        }


        /*
         * Fifth test method.
         */
        private static void testE()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            Stopwatch timer = new Stopwatch();
            graphList = new Dictionary<int, long>();
            int index = 0;
            foreach (int k in randomList)
            {
                list.Add(index, k);
                index++;
            }

            int i;
            timer.Start();
            for (i = 0; i < counter; i++)
            {
                try
                {
                    list.ContainsKey(i); //modified to test ContainsKey()
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
            Console.Out.WriteLine("done with testE");
            timer.Stop();
            Writer.write(graphList, "E", "ExcelGraphContains");
            list = null;
            graphList = null;
            Console.Out.WriteLine("Type Enter to exit");
            Console.ReadLine();
        }

        /*
         * Sixth test method.
         */
        private static void testF()
        {
            SortedDictionary<int, int> list = new SortedDictionary<int, int>();
            Stopwatch timer = new Stopwatch();
            graphList = new Dictionary<int, long>();
            int index = 0;
            foreach (int k in randomList)
            {
                list.Add(index, k);
            }

            int i;
            timer.Start();
            for (i = 0; i < counter; i++)
            {

                try
                {
                    list.ContainsKey(i); //Modified to test ContainsKey()
                    if (i % numberOfElements == 0 && i != 0)
                    {
                        graphList.Add(i, timer.ElapsedMilliseconds);
                    }

                }
                catch (OutOfMemoryException)
                {
                    list = null;
                    GC.Collect();
                    Console.Out.WriteLine("Out Of Memory. For loop stopped!");
                    break;
                }

            }
            Console.Out.WriteLine("Done with testF");
            list = null;
            timer.Stop();
            Writer.write(graphList, "F", "ExcelGraphContains");
            graphList = null;
            Console.Out.WriteLine("Type Enter to perform next test");
            Console.ReadLine();

        }
    }
}
