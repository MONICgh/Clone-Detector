using System;
using System.Collections.Generic;
using ConversionOperators;


namespace ConversionOperators
{
    public class TestsConversionOperators
    {
        public bool TestAll()
        {
            return HorseToCar() && CarToHorse();
        }
        
        private bool HorseToCar()
        {
            var car = new Car();
            car = new Horse("Pony", 5, 200, 1.1, true, 90, "brown");
            if (car.Type != "Passenger" || car.IsStudded != true || car.Colour != "brown")
            {
                return false;
            }
            
            car = new Horse("Boerperd", 5, 200, 1.1, true, 90, "brown");
            if (car.Type != "Boerperd" || car.Weight != 200)
            {
                return false;
            }
            
            car = (Horse)(new Horse("Belgian horse", 5, 200, 1.1, true, 90, "brown"));
            if (car.Type != "Cargo" || car.Height != 1.1)
            {
                return false;
            }

            return true;
        }

        private bool CarToHorse()
        {
            var horse = new Horse();

            horse = new Car("Cargo" , 10, 550, 1.5, true, 90, "blue");
            if (horse.Breed != "Belgian horse" || horse.Age != 10)
            {
                return false;
            }

            horse = new Car("Audi A4", 11, 999, 1.5, false, 90, "blue");
            if (horse.Breed != "Audi A4" || horse.Age != 11 || horse.IsShod)
            {
                return false;
            }
            
            horse = (Horse)(new Car("blablabla", 15, 887, 1.7, false, 42, "orange"));
            if (horse.Breed != "blablabla" || horse.Age != 15 || horse.IsShod)
            {
                return false;
            }
            
            return true;
        }

        private bool ComparisonOfHorses()
        {
            var horse1 = new Horse("Pony", 5, 200, 1.1, true, 90, "brown");
            var horse2 = new Horse("Boerperd", 6, 200, 1.1, true, 90, "brown");
            
            var horse3 = new Horse("Pony", 5, 200, 1.1, true, 90, "brown");
            var horse4 = new Horse("Boerperd", 5, 250, 1.1, true, 90, "brown");
            
            var horse5 = new Horse("Pony", 5, 200, 1.2, true, 90, "brown");
            var horse6 = new Horse("Boerperd", 5, 250, 1.1, true, 90, "brown");

            return horse1 < horse2 && horse3 <= horse4 && horse6 > horse5;
        }
    }
}