using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BSDA2012
{
    class Program
    {
        private static int counter = 0;
        private static bool allowedInput;
        private static Dictionary<int, long> graphList;
        private static int numberOfElements;
        private static Random random;
        private static List<int> randomList;
        
        static void Main(string[] args)
        {
            allowedInput = true;
            counter = 10000000;
            numberOfElements = counter/10;
            random = new Random();
            makeRandomList();
            testA();
            testB();
            testC();
            
           TestContains test = new TestContains(counter);
        }

        /*
         * This method is used to generate a list of random ints, which is then inserted in every testet list.
         */
        private static void makeRandomList()
        {
            randomList = new List<int>();
            for (int i = 0; i > counter; i++)
            {
                randomList.Add(random.Next(1, counter));
            }
        }
       
        
        /*
         *  First test method, which tests the Lists Add methods and times it for every 10th element that is checked.
         */ 

        private static void testA()
        {
            List<int> list = new List<int>();
            Stopwatch timer = new Stopwatch();
            graphList = new Dictionary<int, long>();
            int i;
            timer.Start();
            for (i = 0; i < counter; i++)
            {
                try
                {
                    list.Add(i);
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
            timer.Reset();
            Console.Out.WriteLine("Done with testA");
            list = null;
            Writer.write(graphList, "A", "ExcelGraph");
            graphList = null;
            Console.Out.WriteLine("Type Enter to perform next test");
            Console.ReadLine();
        }

       
        /*
         * Second test method. This method test the Add() for Dictionary and times it. It save the recorded times in graphlist and sends
         * that list to write in Writer.
         */
        private static void testB()
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
                    list.Add(i, i);
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
            Console.Out.WriteLine("done with testB");
            list = null;
            timer.Stop();
            timer.Reset();
            Writer.write(graphList, "B", "ExcelGraph");
            graphList = null;
            Console.Out.WriteLine("Type Enter to exit");
            Console.ReadLine();
        }

        /*
         * Third test method. It tests the Add() for SortedDictionary and like the two previos methods, times it and saves the 
         * the times in graphlist. 
         */
        private static void testC()
        {
            SortedDictionary<int, int> list = new SortedDictionary<int, int>();
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
                        list.Add(i,i);
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
                Console.Out.WriteLine("Done with testC");
                list = null;
                timer.Stop();
                timer.Reset();
                Writer.write(graphList, "C", "ExcelGraph");
                graphList = null;
                Console.Out.WriteLine("Type Enter to perform next test");
                Console.ReadLine();
            
        }
    }
}
  

