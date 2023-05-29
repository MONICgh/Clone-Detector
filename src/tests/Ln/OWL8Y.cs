using System;
using System.Collections.Generic;
using System.Numerics;

namespace Application
{
    interface IInheritance
    {
        void metod1();

        int metod2();
    }

    struct SomeStruct1 : IInheritance
    {
        public void metod1()
        {
            Console.WriteLine("SomeStruct1.metod1");
        }

        public int metod2()
        {
            Console.WriteLine("SomeStruct1.metod2");
            return 0;
        }

        private string metod3()
        {
            Console.WriteLine("SomeStruct1.metod3");
            return "";
        }
    }

    struct SomeStruct2 : IInheritance
    {
        public void metod1()
        {
            Console.WriteLine("SomeStruct2.metod1");
        }

        public int metod2()
        {
            Console.WriteLine("SomeStruct2.metod2");
            return 0;
        }

        private string metod3()
        {
            Console.WriteLine("SomeStruct2.metod3");
            return "";
        }
    }

    struct SomeStructInherit<T> : IInheritance where T : IInheritance, new()
    {
        private T t = new T();

        public SomeStructInherit() {}

        public void metod1() => t.metod1();

        public int metod2() => t.metod2();
    }

    class Task1
    {
        static int Main()
        {
            var structInherit1 = new SomeStructInherit<SomeStruct1>();
            structInherit1.metod1();
            structInherit1.metod2();
            var structInherit2 = new SomeStructInherit<SomeStruct2>();
            structInherit2.metod1();
            structInherit2.metod2();
            return 0;
        }
    }
}
