using System.Runtime.InteropServices;

namespace Application;

public class ZeroEvenOdd {
    class StateHolder
    {
        private volatile State state = State.Zero;
        private volatile bool isOdd = false; 

        public enum State
        {
            Zero,
            Even,
            Odd
        };
        
        public void next()
        {
            if (state == State.Zero)
            {
                if (isOdd)
                {
                    state = State.Even;
                }
                else
                {
                    state = State.Odd;
                }
                isOdd = !isOdd;
            }
            else
            {
                state = State.Zero;
            }
        }

        public void reset()
        {
            isOdd = false;
            state = State.Zero;
        }
        
        public State CurState
        {
            get => state;
        }
    }
    
    private int n;
    private volatile int nIter = 1;
    private readonly object obj = new object();
    private StateHolder sh = new StateHolder();
    
    private void action(Action<int> printNumber, bool zero = false)
    {
        lock (obj)
        {
            if (zero)
            {
                printNumber(0);
            }
            else
            {
                printNumber(nIter);
                nIter++;
            }
            Thread.Sleep(50);
            sh.next();
        }
    }

    public ZeroEvenOdd(int n) 
    {
        this.n = n; 
    }

    public void reset()
    {
        nIter = 1;
        sh.reset();
    }
    
    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber)
    {
        SpinWait spinWait = new SpinWait();
        while (nIter != n + 1)
        {
            if (sh.CurState == StateHolder.State.Zero)
            {
                action(printNumber, true);
            }
            spinWait.SpinOnce();            
        }
    }

    public void Even(Action<int> printNumber)
    {
        SpinWait spinWait = new SpinWait();
        while (nIter != n + 1)
        {
            if (sh.CurState == StateHolder.State.Even)
            {
                action(printNumber);
            }
            spinWait.SpinOnce();            
        }
    }

    public void Odd(Action<int> printNumber)
    {
        SpinWait spinWait = new SpinWait();
        while (nIter != n + 1)
        {
            if (sh.CurState == StateHolder.State.Odd)
            {
                action(printNumber);
            }
            spinWait.SpinOnce();            
        }
    } 
}
