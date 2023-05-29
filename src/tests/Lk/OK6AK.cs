using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hamster
{
    class Hamster : IComparable
    {
        private Random rand = new Random();
        public enum Color
        {
            standart, pearl, sapphire, mandarin
        }

        private Color get_Random_Color()
        {
            int color = rand.Next(0, 4);
            switch (color)
            {
                case 0:
                    return Color.standart;
                case 1:
                    return Color.pearl;
                case 2:
                    return Color.sapphire;
                case 3:
                    return Color.mandarin;
                default:
                    return Color.standart;
            }
        }
        private int num_of_color(Color c)
        {
            switch (c)
            {
                case Color.standart:
                    return 0;
                case Color.pearl:
                    return 1;
                case Color.sapphire:
                    return 2;
                case Color.mandarin:
                    return 3;
                default:
                    return -1;
            }
        }

        
        public enum Wool
        {
            shorthaired, longhaired, atlas
        }

        private Wool get_Random_Wool()
        {
            int color = rand.Next(0, 3);
            switch (color)
            {
                case 0:
                    return Wool.atlas;
                case 1:
                    return Wool.longhaired;
                case 2:
                    return Wool.shorthaired;
                default:
                    return Wool.atlas;
            }
        }
        private int num_of_wool(Wool w)
        {
            switch (w)
            {
                case Wool.atlas:
                    return 0;
                case Wool.longhaired:
                    return 1;
                case Wool.shorthaired:
                    return 2;
                default:
                    return -1;
            }
        }
        private Color color; private Wool wool;

        int weight, height, age;

        public Hamster(Color color, Wool wool, int weight, int height, int age)
        {
            this.color = color;
            this.wool = wool;
            this.weight = weight;
            this.height = height;
            this.age = age;
        }

        public Hamster()
        {
            color = get_Random_Color();
            wool = get_Random_Wool();
            weight = rand.Next(25, 65);
            height = rand.Next(5, 12);
            age = rand.Next(0, 30);
        }

        public int CompareTo(object o)
        {
            Hamster h = o as Hamster;
            if (h == null)
                throw new Exception("Uncomparable objects");

            if (num_of_color(color) > num_of_color(h.color))
                return 1;
            if (num_of_color(color) < num_of_color(h.color))
                return -1;

            if (num_of_wool(wool) > num_of_wool(h.wool))
                return 1;
            if (num_of_wool(wool) < num_of_wool(h.wool))
                return -1;

            if (weight > h.weight)
                return 1;
            if (weight < h.weight)
                return -1;

            if (height > h.height)
                return 1;
            if (height < h.height)
                return -1;

            if (age > h.age)
                return 1;
            if (age < h.age)
                return -1;


            return 0;
        }

        public override string ToString()
        {
            return $"Hamster color is {color}, type of wool is {wool}, weight = {weight}, height = {height}, age = {age}"; //как сделать запись похожей на табличную, я так и не понял.
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var hamsterlist = new List<Hamster>();
            for (int i = 0; i < 36; i++)
            {
                hamsterlist.Add(new Hamster());
            }
            hamsterlist.Sort();
            foreach (var h in hamsterlist)
                Console.WriteLine(h);
        }
    }
}