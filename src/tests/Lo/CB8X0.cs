using PrintFirstSecondThird;

var foo = new Foo();
bool firstLock, secondLock;

void A()
{
    foo.First();
    firstLock = false;
}

void B()
{
    while (firstLock) {}
    foo.Second();
    secondLock = false;
}

void C()
{
    while (secondLock) {}
    foo.Third();
}

void Try(int[] order)
{
    firstLock = true;
    secondLock = true;
    var threads = new Thread[3];
    threads[0] = new Thread(A);
    threads[1] = new Thread(B);
    threads[2] = new Thread(C);
    foreach (var i in order)
    {
        threads[i - 1].Start();
    }

    foreach (var i in order)
    {
        threads[i - 1].Join();
    }
    Console.WriteLine();
}

Try(new int[] {1, 2, 3});
Try(new int[] {1, 3, 2});
Try(new int[] {2, 1, 3});
Try(new int[] {2, 3, 1});
Try(new int[] {3, 1, 2});
Try(new int[] {3, 2, 1});