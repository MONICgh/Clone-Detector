using System.Reflection;

namespace Application
{
    abstract class Component
    {
        private string name;
        private string id;
        
        public string Name
        {
            get => name;
        }
        
        public string Id
        {
            get => id;
        }
        
        public Component(string name, string id)
        {
            this.name = name;
            this.id = id;
        }

        public override string ToString() => $"Component(Name={Name}, Id={Id})";
    }
    
    class Carcase: Component
    {
        private static int carcaseIdNew = 1;
        private int carcaseId;

        public Carcase(string name, string id) : base(name, id)
        {
            carcaseId = carcaseIdNew;
            carcaseIdNew++;
        }
        
        public override string ToString() => $"Carcase(Name={Name}, Id={Id}, carcaseId={carcaseId})";
    }
    
    class Cylinder: Component
    {
        public Cylinder(string name, string id) : base(name, id) {}
        
        public override string ToString() => $"Cylinder(Name={Name}, Id={Id})";
    }

    class Engine: Component
    {
        private Cylinder? cylinder;
        
        public Cylinder? Cylinder
        {
            get => cylinder;
        }

        public Engine(string name, string id, Cylinder? cylinder = null): base(name, id)
        {
            this.cylinder = cylinder;
        }

        public override string ToString() => $"Engine(Name={Name}, Id={Id}, Cylinder={Cylinder})";
    }

    class SmartEngine: Engine
    {
        public SmartEngine(string name, string id, Cylinder? cylinder = null): base(name, id, cylinder) {}
        
        public override string ToString() => $"SmartEngine(Name={Name}, Id={Id}, Cylinder={Cylinder})";
    }
    
    class Chassis: Component
    {
        public Chassis(string name, string id) : base(name, id) {}
        
        public override string ToString() => $"Chassis(Name={Name}, Id={Id})";
    }
    
    class BaseKitCreator: Component
    {
        public Func<Carcase> CarcaseCreator;
        public Func<Engine> EngineCreator;
        public Func<Chassis> ChassisCreator;
        
        public BaseKitCreator(string name, string id, Func<Carcase> carcaseCreator, Func<Engine> engineCreator, Func<Chassis> chassisCreator): base(name, id)
        {
            CarcaseCreator = carcaseCreator;
            EngineCreator = engineCreator;
            ChassisCreator = chassisCreator;
        }
    }
    
    abstract class Transmission: Component
    {
        public Transmission(string name, string id) : base(name, id) {}
    }

    class ManualTransmissions : Transmission
    {
        public ManualTransmissions(string name, string id) : base(name, id) {}
        
        public override string ToString() => $"ManualTransmissions(Name={Name}, Id={Id})";
    }
    
    class AutomaticTransmissions : Transmission
    {
        public AutomaticTransmissions(string name, string id) : base(name, id) {}
        
        public override string ToString() => $"AutomaticTransmissions(Name={Name}, Id={Id})";
    }
    
    class Dashboard: Component
    {
        public Dashboard(string name, string id) : base(name, id) {}
        
        public override string ToString() => $"Dashboard(Name={Name}, Id={Id})";
    }
    
    class StereoSystem: Component
    {
        public StereoSystem(string name, string id) : base(name, id) {}
        
        public override string ToString() => $"StereoSystem(Name={Name}, Id={Id})";
    }
    
    abstract class AnyCar: Component
    {
        public Carcase Carcase;
        public Engine Engine;
        public Chassis Chassis;
        public Transmission Transmission;
        public Dashboard Dashboard;
        public StereoSystem StereoSystem;

        public AnyCar(string name, string id, Carcase carcase, Engine engine, Chassis chassis, Transmission transmission, Dashboard dashboard, StereoSystem stereoSystem): base(name, id)
        {
            Carcase = carcase;
            Engine = engine;
            Chassis = chassis;
            Transmission = transmission;
            Dashboard = dashboard;
            StereoSystem = stereoSystem;
        }
    }
    
    class Car: AnyCar {
        public Car(string name, string id, Carcase carcase, Engine engine, Chassis chassis, Transmission transmission, Dashboard dashboard,
            StereoSystem stereoSystem) :
            base(name, id, carcase, engine, chassis, transmission, dashboard, stereoSystem) {}

        public override string ToString() => $"Car(Name={Name}, Id={Id}, Carcase={Carcase}, Engine={Engine}, Chassis={Chassis}, Transmission={Transmission}, Dashboard={Dashboard}, StereoSystem={StereoSystem})";
    }

    interface IFactory<T, C>
    {
        public T produce(string name, string id, List<C> components);
    }

    interface ICarFactory : IFactory<Car, Component>
    {
        public Car produce(string name, string id, List<Component> components);
    }
    
    class CarFactory : ICarFactory
    {
        public BaseKitCreator DefaultBaseKitCreator;
        public Func<Transmission> DefaultTransmissionCreator;
        public Func<Dashboard> DefaultDashboardCreator;
        public Func<StereoSystem> DefaultStereoSystemCreator;

        public CarFactory(BaseKitCreator defaultBaseKitCreator, Func<Transmission> defaultTransmissionCreator, Func<Dashboard> defaultDashboardCreator,
            Func<StereoSystem> defaultStereoSystemCreator)
        {
            DefaultBaseKitCreator = defaultBaseKitCreator;
            DefaultTransmissionCreator = defaultTransmissionCreator;
            DefaultDashboardCreator = defaultDashboardCreator;
            DefaultStereoSystemCreator = defaultStereoSystemCreator;
        }
        
        public Car produce(string name, string id, List<Component>? components = null)  // если несколько компонентов одного типа предполагается выбор одного из них на самой фабрике
        {
            Carcase carcase = null;
            Engine engine = null;
            Chassis chassis = null;
            Transmission transmission = null;
            Dashboard dashboard = null;
            StereoSystem stereoSystem = null;
            if (components != null)
            {
                foreach (var component in components)
                {
                    if (component is Carcase) carcase = component as Carcase;
                    else if (component is Engine) engine = component as Engine;
                    else if (component is Chassis) chassis = component as Chassis;
                    else if (component is Transmission) transmission = component as Transmission;
                    else if (component is Dashboard) dashboard = component as Dashboard;
                    else if (component is StereoSystem) stereoSystem = component as StereoSystem;
                }
            }
            carcase = carcase ?? DefaultBaseKitCreator.CarcaseCreator();
            engine = engine ?? DefaultBaseKitCreator.EngineCreator();
            chassis = chassis ?? DefaultBaseKitCreator.ChassisCreator();
            transmission = transmission ?? DefaultTransmissionCreator();
            dashboard = dashboard ?? DefaultDashboardCreator();
            stereoSystem = stereoSystem ?? DefaultStereoSystemCreator();            
            return new Car(name, id, carcase, engine, chassis, transmission, dashboard, stereoSystem);
        }
    }
    
    class Task1
    {
        static void Main()
        {
            BaseKitCreator baseKit = new BaseKitCreator("base kit", "1", () => new Carcase("default carcase", "1"),
                () => new SmartEngine("engine", "1"), () => new Chassis("chassis", "1"));
            Func<Transmission> transmission = () => new AutomaticTransmissions("automatic", "1");
            Func<Dashboard> dashboard = () => new Dashboard("dashboard", "1");
            Func<StereoSystem> stereoSystem = () => new StereoSystem("stereo", "1");
            CarFactory carFactory = new CarFactory(baseKit, transmission, dashboard, stereoSystem);
            var car = carFactory.produce("fast car", "2134");
            Console.WriteLine(car);
            var car2 = carFactory.produce("fast car2", "2135", new List<Component>() { new StereoSystem("newest stereo", "2") });
            Console.WriteLine(car2);
            carFactory.DefaultTransmissionCreator = () => new ManualTransmissions("manual", "2");
            carFactory.DefaultBaseKitCreator.CarcaseCreator = () => new Carcase("updated carcase", "2");
            var car3 = carFactory.produce("fast car3", "2136");
            Console.WriteLine(car3);
        }
    }
}
