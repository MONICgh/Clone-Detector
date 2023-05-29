using System.Collections;
using System.Collections.Generic;

namespace PersonSort
{
    public class ComparatorName : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            var lena = a.Name.Length;
            var lenb = b.Name.Length;
            if (lena < lenb)
            {
                return -1;
            }

            if (lena > lenb)
            {
                return 1;
            }

            var cha = a.Name[0];
            var chb = b.Name[0];
            if (cha < chb)
            {
                return -1;
            }

            if (cha > chb)
            {
                return 1;
            }

            return 0;
        }
    }
    
    public class ComparatorAge : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            var agea = a.Age;
            var ageb = b.Age;
            if (agea < ageb)
            {
                return -1;
            }

            if (agea > ageb)
            {
                return 1;
            }

            return 0;
        }
    }
}