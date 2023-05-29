
namespace task1
{
    internal class Stereosystem
    {
        public string Model { get; private set; }

        public double MaxSoundLevel { get; private set; }

        public Stereosystem(string model, double maxSoundLevel)
        {
            Model = model;
            MaxSoundLevel = maxSoundLevel;
        }
        public override string ToString()
        {
            return $"model = {Model}, max sound level = {MaxSoundLevel}";
        }
    }
}
