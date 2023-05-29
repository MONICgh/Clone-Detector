var number = 0;

void IncrementThread(int t)
{
    for (int i = 0; i < t; i++) {
        number = number + 1;
    }
}

int n = 1000000;
var t1 = new Thread(() => IncrementThread(n));
var t2 = new Thread(() => IncrementThread(n));
t1.Start();
t2.Start();
t1.Join();
t2.Join();

Console.WriteLine("Expected answer: " + 2 * n);
Console.WriteLine("Real answer: " + number);