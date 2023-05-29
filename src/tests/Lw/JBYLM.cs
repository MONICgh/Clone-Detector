using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using static Lab15.MergeSort;

namespace Lab15
{
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }

    [TestClass]
    public class MergeSortTest
    {
        public static bool Sorted(int[] array) 
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                if (array[i] > array[i + 1])
                    return false;
            }
            return true;
        }
        
        [TestMethod]
        public void TestGetMinFromOffsets()
        {
            List<Bound> bounds = new List<Bound>();
            for (int i = 0; i < 10; ++i)
            {
                bounds.Add(new Bound());
                bounds[i].begin = i * 100;
                bounds[i].end = bounds[i].begin + 100;
            }
            for (int i = 0; i < 1000; ++i)
            {
                int[] array = Enumerable.Range(1, 1000).ToArray();
                Random random = new Random();

                var min = GetMinFromOffsets(array, bounds);

                foreach(var b in bounds)
                {
                    Assert.IsTrue(array[min.begin] <= array[b.begin]);
                }
            }
        }

        [TestMethod]
        public void TestInsert()
        {
            Bound bound = new Bound();
            bound.begin = 0;
            bound.end = bound.begin + 9;

            int[] array = new int[] { 4, 5, 6, 8, 12, 14, 16, 18, 20 };
            int[] array1 = new int[] { 1, 2, 3, 9, 10, 11, 13, 15, 17, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int i = 4;
            Insert(array1, array, bound, ref i);

            foreach (int a in array1)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine("");
        }

        [TestMethod]
        public void TestRandomNoIntermediate()
        {
            const int repeats = 1;
            const int size = 100000;
            const int threads = 10;
            const int batch_size = size / threads;

            int[] example = Enumerable.Range(1, size).ToArray();
            for (int i = 0; i < repeats; ++i)
            {
                int[] array = new int[size];
                example.CopyTo(array, 0);
                Random random = new Random();
                random.Shuffle(array);

                Mergesort(array, threads, false);
                
                //Console.WriteLine("");
                //int k = 0;
                //foreach (int a in array)
                //{
                //    Console.Write($"{a} ");
                //    if (++k >= batch_size)
                //    {
                //        Console.WriteLine();
                //        k = 0;
                //    }
                //}
                //Console.WriteLine("");

                Assert.IsTrue(Sorted(array));
                CollectionAssert.AreEqual(example, array);
            }
        }
        [TestMethod]
        public void TestRandomIntermediate()
        {
            const int repeats = 1;
            const int size = 100000;
            const int threads = 10;
            const int batch_size = size / threads;

            int[] example = Enumerable.Range(1, size).ToArray();

            for (int i = 0; i < repeats; ++i)
            {
                int[] array = new int[size];
                example.CopyTo(array, 0);
                Random random = new Random();
                random.Shuffle(array);

                Mergesort(array, threads, true);
                Assert.IsTrue(Sorted(array));

                CollectionAssert.AreEqual(example, array);
            }
        }
    }

    [TestClass]
    public class BarberTest
    {
        [TestMethod]
        public void TestCasual()
        {
            Barbershop shop = new Barbershop(3);

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; ++i)
            {
                Thread t = new Thread(shop.Customer);
                t.Name = $"Customer {i}";
                threads.Add(t);

                t.Start();
                Thread.Sleep(1000);
            }

            foreach (var thr in threads)
                thr.Join();
        }
        [TestMethod]
        public void TestRushed()
        {
            Barbershop shop = new Barbershop(3);

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; ++i)
            {
                Thread t = new Thread(shop.Customer);
                t.Name = $"Customer {i}";
                threads.Add(t);

                t.Start();
                Thread.Sleep(100);
            }

            foreach (var thr in threads)
                thr.Join();
        }
        [TestMethod]
        public void TestRandomised()
        {
            Barbershop shop = new Barbershop(3);

            Random random = new Random();

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; ++i)
            {
                Thread t = new Thread(shop.Customer);
                int time = random.Next(100, 400);
                t.Name = $"Customer {i} [{time}]";
                threads.Add(t);

                t.Start();
                Thread.Sleep(time);
            }

            foreach (var thr in threads)
                thr.Join();
        }
    }
    [TestClass]
    public class BearTest
    {
        [TestMethod]
        public void Test()
        {
            BearBees.BearAndBees(5, 10);
        }
    }
}
