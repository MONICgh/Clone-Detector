// мда
// я, кажется, не совсем понял задание
// но кода я наклепал)
using System;
using System.Collections.Generic;

namespace Lab12
{
    public interface IMaintainable
    {
        // great method names here!
        bool isFine();

        /* 
        // would work for C# 8.0 or greater
        bool isInNeedOfMaintenance()
        {
            return not isFine();
        }
        */
    }

    public class Body { }

    public class Engine : IMaintainable 
    {
        Cylinder[] cylinders;
    }

    public class EightCubesEngine : Engine
    {

    }

    public class TwelveCubesEngine : Engine
    {

    }

    public class Cylinder { }

    public class Chassis : IMaintainable { }

    public class Transmission : IMaintainable { }

    public class Dashboard : IMaintainable { }

    public class Stereosystem : IMaintainable { }

    public abstract class Car
    {
        Body body;
        Engine engine;
        Chassis chassis;
        Transmission transmission;
        Dashboard dashboard;
        Stereosystem stereosystem;
        public int BodyNumber { get; private set; }
        public Car(Body body,
                   Engine engine,
                   Chassis chassis,
                   Transmission transmission,
                   Dashboard dashboard,
                   Stereosystem stereosystem,
                   int bodyNumber)
        {
            this.body = body;
            this.engine = engine;
            this.chassis = chassis;
            this.transmission = transmission;
            this.dashboard = dashboard;
            this.stereosystem = stereosystem;
            BodyNumber = bodyNumber;
        }
    }

    public class Model1 : Car
    {
        public Model1 (Body body,
                   Engine engine,
                   Chassis chassis,
                   Transmission transmission,
                   Dashboard dashboard,
                   Stereosystem stereosystem,
                   int bodyNumber) : base(body, engine, chassis, transmission, dashboard, stereosystem, bodyNumber) { }
    }

    public class Factory
    {
        List<Car> archives;
        public Model1 CreateModel1(Body body,
                   Engine engine,
                   Chassis chassis,
                   Transmission transmission,
                   Dashboard dashboard,
                   Stereosystem stereosystem)
        {
            Model1 model = new Model1(body, engine, chassis, transmission, dashboard, stereosystem, new Random().Next(100000, 999999));
            archives.Add(model);
            return model;
        }
    }
}
