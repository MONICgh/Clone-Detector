namespace Join
{
    public class Program
    {
        public static void Main()
        {
            string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string[] fileA = File.ReadAllLines(Path.Combine(workingDirectory, "A.txt"));
            string[] fileB = File.ReadAllLines(Path.Combine(workingDirectory, "B.txt"));
            DataBase A = new(fileA);
            DataBase B = new(fileB);
            DataBase C = A.Join(B);

            File.WriteAllText(Path.Combine(workingDirectory, "result.txt"), C.ToString());
        }
    }
}
