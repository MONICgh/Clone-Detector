namespace Task3;

public class Racing
{
    public String GoToGoal(int goal)
    {
        Queue<CommandsVariant> variants = new Queue<CommandsVariant>();
        variants.Enqueue(new CommandsVariant("", new Car(0, 1)));
        while (true)
        {
            var current = variants.Dequeue();
            if (current.Car.Position == goal)
            {
                return current.Commands;
            }
            variants.Enqueue(current.A());
            variants.Enqueue(current.R());
        }
    }
}