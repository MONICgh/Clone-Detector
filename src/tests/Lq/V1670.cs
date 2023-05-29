using Task1.model;
using Task1.model.body;
using Task1.model.chassis;
using Task1.model.engine;
using Task1.model.gearbox;
using Task1.model.panel;
using Task1.model.stereo;

namespace Task1;

public class CarFactory
{
    private readonly ComponentFactory<AbstractBody> _bodyFactory = new();
    private readonly ComponentFactory<AbstractChassis> _chassisFactory = new();
    private readonly ComponentFactory<AbstractEngine> _engineFactory = new();
    private readonly ComponentFactory<AbstractGearbox> _gearboxFactory = new();
    private readonly ComponentFactory<AbstractPanel> _panelFactory = new();
    private readonly ComponentFactory<AbstractStereo> _stereoFactory = new();
    private readonly Random _random = new Random();

    private void SubfactoriesWorkday()
    {
        for (int i = 0; i < _random.Next() % 10; i++)
        {
            _bodyFactory.MakeNew(new Body(_random.Next()));
        }
        for (int i = 0; i < _random.Next() % 5; i++)
        {
            _chassisFactory.MakeNew(new Chassis());
        }
        for (int i = 0; i < _random.Next() % 5; i++)
        {
            _chassisFactory.MakeNew(new LongChassis());
        }
        for (int i = 0; i < _random.Next() % 5; i++)
        {
            _engineFactory.MakeNew(new Engine1(_random.Next() % 100));
        }
        for (int i = 0; i < _random.Next() % 5; i++)
        {
            _engineFactory.MakeNew(new Engine2());
        }
        for (int i = 0; i < _random.Next() % 10; i++)
        {
            _gearboxFactory.MakeNew(new Gearbox(_random.Next() % 5));
        }
        for (int i = 0; i < _random.Next() % 10; i++)
        {
            _panelFactory.MakeNew(new Panel());
        }
        for (int i = 0; i < _random.Next() % 10; i++)
        {
            _stereoFactory.MakeNew(new Stereo());
        }
    }
    
    public List<Car> Workday()
    {
        SubfactoriesWorkday();

        List<Car> newCars = new List<Car>();
        while (_bodyFactory.HaveAny() && _chassisFactory.HaveAny() && _engineFactory.HaveAny() &&
               _gearboxFactory.HaveAny() && _panelFactory.HaveAny() && _stereoFactory.HaveAny())
        {
            newCars.Add(
                new Car(
                    _bodyFactory.Take(),
                    _engineFactory.Take(),
                    _chassisFactory.Take(),
                    _gearboxFactory.Take(),
                    _panelFactory.Take(),
                    _stereoFactory.Take()));
        }

        return newCars;
    } 
}