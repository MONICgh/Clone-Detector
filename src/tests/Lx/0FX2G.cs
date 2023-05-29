using System;
using System.Collections;
using task1;

namespace Application
{
    class Task1
    {
        static void simpleExample()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            d.Add("one", 1);
            d.Add("two", 2);
            d.Add("three", 3);
            d.Add("four", 4);

            var hashTable = new HashTable<int>(d);
            Console.WriteLine("one {0}", hashTable["one"]);
            Console.WriteLine("two {0}", hashTable["two"]);
            Console.WriteLine("three {0}", hashTable["three"]);
            Console.WriteLine("four {0}", hashTable["four"]);
            hashTable.Add("five", 5);
            hashTable["six"] = 6;
            Console.WriteLine("five contains {0}", hashTable.ContainsKey("five"));
            Console.WriteLine("five {0}", hashTable["five"]);
            Console.WriteLine("six contains {0}", hashTable.ContainsKey("six"));
            Console.WriteLine("six {0}", hashTable["six"]);
            Console.WriteLine("six removed {0}", hashTable.Remove("six"));
            Console.WriteLine("six contains {0}", hashTable.ContainsKey("six"));
            Console.WriteLine("six {0}", hashTable["six"]);
            Console.WriteLine("six removed again {0}", hashTable.Remove("six"));

            hashTable["many"] = 999;
            Console.WriteLine("many {0}", hashTable["many"]);
            hashTable["many"] = 9999;
            Console.WriteLine("many again {0}", hashTable["many"]);
            hashTable.Add("many", 99999);
            Console.WriteLine("and many again {0}", hashTable["many"]);
        }

        static void sameHashCodeExample()
        {
            var hashTable = new HashTable<int>();
            var one = new DummyObject("one");
            var one2 = new DummyObject("one");
            Console.WriteLine("one value {0}", one.Value());
            var two = new DummyObject("two");
            var three = new DummyObject("three");
            var four = new DummyObject("three");

            hashTable[one] = 1;
            hashTable[two] = 2;
            hashTable.Add(three, 3);
            Console.WriteLine("one {0}", hashTable[one]);
            Console.WriteLine("two {0}", hashTable[two]);
            Console.WriteLine("three {0}", hashTable[three]);
            Console.WriteLine("four contains {0}", hashTable.ContainsKey(four));
            Console.WriteLine("four {0}", hashTable[four]);
            Console.WriteLine("one contains {0}", hashTable.ContainsKey(one));
            Console.WriteLine("one removed {0}", hashTable.Remove(one));
            Console.WriteLine("one contains {0}", hashTable.ContainsKey(one));
            Console.WriteLine("one removed again {0}", hashTable.Remove(one));
            Console.WriteLine("one {0}", hashTable[one]);
            hashTable[two] = 22;
            Console.WriteLine("two {0}", hashTable[two]);
        }

        static int Main()
        {
            simpleExample();
            Console.Write("\n\n\n");
            sameHashCodeExample();
            return 0;
        }
    }
}
