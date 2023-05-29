using WolfAndSheeps;

var field = new Field(3);

var wolf = new Agent(new Position(0, 0), field, Kind.Wolf);

var sheep = new List<Agent>
{
    new Agent(new Position(0, 1), field, Kind.Sheep),
    new Agent(new Position(1, 1), field, Kind.Sheep),
    new Agent(new Position(1, 0), field, Kind.Sheep),
};

wolf.Run();
sheep.ForEach(it => it.Run());

Thread.Sleep(10000);