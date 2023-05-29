using System;

namespace Allergies
{
    public class EnumAllergen
    {
        private enum Allergen
        {
            Eggs = 1, 
            Peanut = 2,
            Shellfish = 4, 
            Strawberries = 8,
            Tomatoes = 16, 
            Chocolate = 32, 
            Pollen = 64, 
            Cats = 128
        }
        
        public string GetNameOfAllergen(int allergen)
        {
            foreach(Allergen value in Enum.GetValues(typeof(Allergen)))
            {
                if ((int)value == allergen)
                {
                    return value.ToString();
                }
            }
            
            throw new Exception("Error in GetNameOfAllergen: no allergen with score = " +  allergen);
        }

        public int GetScoreOfAllergen(string allergen)
        {
            //можно сократить вычисления ниже, используя встроенный метод: (Allergen)Enum.Parse(typeof(Allergen), allergen)
            foreach(Allergen value in Enum.GetValues(typeof(Allergen)))
            {
                string name = Enum.GetName(typeof(Allergen), value);
                if (name == allergen)
                {
                    return (int)value;
                }
            }

            throw new Exception("Error in GetScoreOfAllergen(): allergen " +  allergen + " do not exists");
        }
    }
}