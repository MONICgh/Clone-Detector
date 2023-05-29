using System;
using System.Threading;

namespace Lab16
{
    public class CMyBarrier : IDisposable
    {
        int participants;
        AutoResetEvent resetEvent = new AutoResetEvent(true);

        public CMyBarrier(int participantCount)
        {
            participants = participantCount;
        }

        public bool SignalAndWait(TimeSpan timeout)
        {
            bool timePassed = false;
            Timer timer = new Timer((object obj) => { timePassed = true; }, timePassed, 0, timeout.Milliseconds);
            lock(resetEvent)
            {
                participants--;
                resetEvent.Set();
                while(participants > 0 && !timePassed) 
                {
                    resetEvent.WaitOne();
                }
                if (participants < 0)
                {
                    throw new InvalidOperationException("");
                }
            }
            return !timePassed;
        }
        public void Dispose()
        {
            resetEvent.Dispose();
        }
    }
}
