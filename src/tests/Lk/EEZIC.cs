using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SortingHamsters
{
    public class Hamster
    {
        public int Age;
        public int Weight;
        public float Height;
        public string Colour;
        public string TypeOfFur;

        public Hamster(int age, int weight, float height, string colour, string typeOfFur)
        {
            Age = age;
            Weight = weight;
            Height = height;
            Colour = colour;
            TypeOfFur = typeOfFur;
        }

        public Hamster()
        {
            var rnd = new Random();
            Age = rnd.Next(0, 4);
            Weight = rnd.Next(25, 200); //gramme
            Height = rnd.Next(50, 150); //mm
            string[] colours = {"Pink", "Light pink", "Hot pink", "Piggy pink", "Pale pink", "Champagne pink", "Tango pink", "Mimi Pink"};
            Colour = colours[rnd.Next(0, colours.Length)];
            string[] typeOfFur = {"Rough", "Soft", "Fluffy"};
            TypeOfFur = typeOfFur[rnd.Next(0, typeOfFur.Length)];
        }

        public void Print()
        {
            Console.WriteLine("Age = " + Age + " Weight = " + Weight + " Height = " + Height + " Colour = " + Colour + " TypeOfFur = " + TypeOfFur);
        }
        
        // операторы сравнения сравнивают хомячков по ценности 

        public static bool operator <(Hamster h1, Hamster h2)
        {
            if (h1.Age != h2.Age) // более старший менее ценен
            {
                return h1.Age > h2.Age;
            }
            
            if (h1.Weight != h2.Weight) // более худой менее ценен 
            {
                return h1.Weight < h2.Weight;
            }
            
            if (h1.Height != h2.Height) // более низкий менее ценен 
            {
                return h1.Height < h2.Height;
            }

            if (h1.Colour.CompareTo(h2.Colour) != 0)
            {
                return h1.Colour.CompareTo(h2.Colour) == -1;
            }

            if (h1.TypeOfFur.CompareTo(h2.TypeOfFur) != 0)
            {
                return h1.TypeOfFur.CompareTo(h2.TypeOfFur) == -1;
            }

            return false;
        }
        
        public static bool operator >=(Hamster h1, Hamster h2)
        {
            return !(h1 < h2);
        }
        
        public static bool operator <=(Hamster h1, Hamster h2)
        {
            return h1 < h2 || h1.Age == h2.Age && h1.Weight == h2.Weight && h1.Height == h2.Height && 
                h1.Colour == h2.Colour && h1.TypeOfFur == h2.TypeOfFur;
        }
        
        public static bool operator >(Hamster h1, Hamster h2)
        {
            return !(h1 <= h2);
        }
        
        public static bool operator ==(Hamster h1, Hamster h2)
        {
            return h1 <= h2 && h1 >= h2;
        }
        
        public static bool operator !=(Hamster h1, Hamster h2)
        {
            return !(h1 == h2);
        }
    }
    
    public class HamsterComparer : IComparer<Hamster>
    {
        public int Compare(Hamster h1, Hamster h2)
        {
            if (h1 < h2)
            {
                return -1;
            }
            
            if (h1 > h2)
            {
                return 1;
            }
    
            return 0;
        }
    }
    
    public class SorterForHamsters
    {
        private Hamster[] Hamsters = new Hamster[20];

        public void Print()
        {
            for (int i = 0; i < Hamsters.Length; i++)
            {
                Hamsters[i].Print();
            }
        }

        public SorterForHamsters()
        {
            for (var i = 0; i < Hamsters.Length; i++)
            {
                Hamsters[i] = new Hamster();
            }
        }
        
        public void SortHamsters()
        {
            HamsterComparer hc = new HamsterComparer();
            Array.Sort(Hamsters, hc);
        }
    }
}