
using System;

namespace task1
{
    static class MyFactory
    {
        private enum _models {Ford, Mazda, Renault, Volvo, Ferrari}
        private enum _colors {Red, Green, Yellow, Blue, Black}

        private static Random _random = new Random();
        private static readonly _models[] _modelsValues = Enum.GetValues(typeof(_models)).Cast<_models>().ToArray();
        private static readonly _colors[] _colorsValues = Enum.GetValues(typeof(_colors)).Cast<_colors>().ToArray();

        private static long _uniqueNumber = 0;

        private static Engine _engine = new Engine(136, new List<Cylinder>() { new Cylinder("steel", 70) });
        private static Chassis _chassis = new Chassis("frame");
        private static Transmission _transmission = new Transmission("friction");
        private static Stereosystem _stereosystem = new Stereosystem("Kenwood Excelon", 140);

        public static Car CreateCar<T> () where T : Car
        {
            _models model = _modelsValues[_random.Next(_modelsValues.Length)];
            _colors color = _colorsValues[_random.Next(_colorsValues.Length)];

            _uniqueNumber++;

            CarBody body;
            Dashboard dashboard;
            Car car;

            if (typeof(T).IsAssignableFrom(typeof(PassengerCar)))
            {
                body = new CarBody(_uniqueNumber, "open");
                dashboard = new Dashboard("electronic");
                car = PassengerCar.Create().SetModel(model.ToString()).SetColor(color.ToString()).SetBody(body).SetChassis(_chassis).
                                            SetDashboard(dashboard).SetEngine(_engine).SetStereosystem(_stereosystem).SetTransmission(_transmission);
              
            }
            else
            {
                body = new CarBody(_uniqueNumber, "closed");
                dashboard = new Dashboard("analogue");
                car = Truck.Create().SetModel(model.ToString()).SetColor(color.ToString()).SetBody(body).SetChassis(_chassis).
                                     SetDashboard(dashboard).SetEngine(_engine).SetStereosystem(_stereosystem).SetTransmission(_transmission);
            }


            return car;
            
           
           


        }

    }
}
