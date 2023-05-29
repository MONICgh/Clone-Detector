using CarManufacturing;

var factory = new Factory();
var ford = factory.MakeNewFord();
var mercedes = factory.MakeNewMercedes();
var landrover = factory.MakeNewLandRover();
Console.WriteLine(factory.Count);
ford.StartEngine();
ford.SecondGear();
ford.PlayRadio();
ford.TurnRight();
ford.TurnLeft();