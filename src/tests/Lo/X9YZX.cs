using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.IO;

namespace Lab14
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
    public class PrintInOrderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Foo foo = new Foo();
            Thread a = new Thread(foo.first);
            Thread b = new Thread(foo.second);
            Thread c = new Thread(foo.third);

            a.Start();
            b.Start();
            c.Start();
            a.Join();
            b.Join();
            c.Join();
        }
        [TestMethod]
        public void TestMethod2()
        {
            Foo foo = new Foo();
            Thread a = new Thread(foo.first);
            Thread b = new Thread(foo.third);
            Thread c = new Thread(foo.second);

            a.Start();
            b.Start();
            c.Start();
            a.Join();
            b.Join();
            c.Join();
        }

        [TestMethod]
        public void TestMethod3()
        {
            for (int i = 0; i < 100; i++)
            {
                Foo foo = new Foo();
                Thread[] t = new Thread[3] { new Thread(foo.first), new Thread(foo.second), new Thread(foo.third) };
                
                var rng = new Random();
                rng.Shuffle(t);
                foreach (Thread k in t)
                {
                    k.Start();
                }
                foreach (Thread k in t)
                {
                    k.Join();
                }
                Console.WriteLine();
            }
        }
    }

    [TestClass]
    public class FileCalculatorTest
    {
        void GenerateFiles(string dir, bool with_random = false)
        {
            using (var sw = File.CreateText($"{dir}\\test1.txt"))
            {
                sw.WriteLine(1);
                sw.WriteLine("{0} {1}", 0.1, 0.2);
            }
            using (var sw = File.CreateText($"{dir}\\test2.txt"))
            {
                sw.WriteLine(2);
                sw.WriteLine("{0} {1}", 0.1, 0.2);
            }
            using (var sw = File.CreateText($"{dir}\\test3.txt"))
            {
                sw.WriteLine(3);
                sw.WriteLine("{0} {1}", 0.1, 0.2);
            }
            if (!with_random)
                return;

            for (int i = 0; i < 100; ++i)
            {
                using (var sw = File.CreateText($"{dir}\\{i}.txt"))
                {
                    Random rnd = new Random();
                    sw.WriteLine(rnd.Next(1, 3));
                    sw.WriteLine("{0} {1}", rnd.NextDouble(), rnd.NextDouble());
                }
            }
        }

        [TestMethod]
        public void CalculateFileTest()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string testsDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\Test files";
            if (!File.Exists($"{testsDirectory}\\test1.txt"))
                GenerateFiles(testsDirectory);

            float eps = 0.00001f;
            Assert.IsTrue(Math.Abs(FileCalculator.CalculateFile($"{testsDirectory}\\test1.txt") - 0.3) < eps);
            Assert.IsTrue(Math.Abs(FileCalculator.CalculateFile($"{testsDirectory}\\test2.txt") - 0.02) < eps);
            Assert.IsTrue(Math.Abs(FileCalculator.CalculateFile($"{testsDirectory}\\test3.txt") - 0.05) < eps);
        }
        [TestMethod]
        public void Calculate()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string testsDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\Test files";
            if (!File.Exists($"{testsDirectory}\\test1.txt"))
                GenerateFiles(testsDirectory);
            float res1 = FileCalculator.CalculateThreaded(1, testsDirectory);
            float res2 = FileCalculator.CalculateThreaded(2, testsDirectory);
            float res3 = FileCalculator.CalculateThreaded(3, testsDirectory);

            float eps = 0.00001f;
            Console.WriteLine($"{res1} {res2} {res3}");
            Assert.IsTrue(Math.Abs(res1 - 0.37) < eps);
            Assert.IsTrue(Math.Abs(res2 - 0.37) < eps);
            Assert.IsTrue(Math.Abs(res3 - 0.37) < eps);
        }
        [TestMethod]
        public void CalculateRandom()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string testsDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\Test files";
            if (!File.Exists($"{testsDirectory}\\0.txt"))
                GenerateFiles(testsDirectory, true);
            float res1 = FileCalculator.CalculateThreaded(1, testsDirectory);
            float res10 = FileCalculator.CalculateThreaded(10, testsDirectory);
            float eps = 0.00001f;
            Console.WriteLine($"{res1} {res10}");
            Assert.IsTrue(Math.Abs(res1 - res10) < eps);
        }
    }
}
