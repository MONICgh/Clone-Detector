namespace task1
{
    class CarMaker<T> where T :  Car, new()
    {
        private T _car;
        public CarMaker()
        {
            _car = new T();
        }
        public CarMaker<T> SetModel(string model)
        {
            _car.Model = model;
            return this;
        }

        public CarMaker<T> SetColor(string color)
        {
            _car.Color = color;
            return this;
        }
        public CarMaker<T> SetBody(CarBody body)
        {
            _car.Body = body;
            return this;
        }
        public CarMaker<T> SetChassis(Chassis chassis)
        {
            _car.Chassis = chassis;
            return this;
        }

        public CarMaker<T> SetDashboard(Dashboard dashboard)
        {
            _car.Dashboard = dashboard;
            return this;
        }

        public CarMaker<T> SetEngine(Engine engine)
        {
            _car.Engine = engine;
            return this;
        }
        public CarMaker<T> SetStereosystem(Stereosystem stereosystem)
        {
            _car.Stereosystem = stereosystem;
            return this;
        }

        public CarMaker<T> SetTransmission(Transmission transmission)
        {
            _car.Transmission = transmission;
            return this;
        }

        public static implicit operator T(CarMaker<T> maker)
        {
            return maker._car;
        }
    }
}
