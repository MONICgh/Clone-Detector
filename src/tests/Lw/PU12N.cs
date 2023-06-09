﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Barber
{
    class Barbershop : IDisposable
    {
        readonly int N;
        int curCnt = 0;
        Task order; 
        AutoResetEvent _notify = new AutoResetEvent(false);
        Mutex m = new Mutex();
        Mutex barber = new Mutex();
        Random rand = new Random();
        Task lastTask;

        public Barbershop(int N)
        {
            this.N = N;
            order = new Task(() => Sleep());
        }

        public void Run()
        {
            order.Start();
        }

        public bool Add()
        {
            m.WaitOne();
            Console.WriteLine("Try to add");
            if (curCnt >= N)
            {
                Console.WriteLine("Queue is full");
                return false;
            }
            curCnt++;
            lastTask = order.ContinueWith(t => Haircut());
            Console.WriteLine("Succesfully added");

            _notify.Set();
            m.ReleaseMutex();
            return true;
        }

        public void WaitLastHaircut()
        {
            lastTask.Wait();
        }

        public void Dispose()
        {
            order.Dispose();
            _notify.Dispose();
            m.Dispose();
            barber.Dispose();
            lastTask.Dispose();
        }

        private void Haircut()
        {
            barber.WaitOne();
            Console.WriteLine("Haircutting");
            Thread.Sleep(rand.Next(500, 1000));
            curCnt--;
            if (curCnt == 0)
            {
                _notify.Reset();
                lastTask = order.ContinueWith(t => Sleep(), TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            Console.WriteLine("Haircut ended");
            barber.ReleaseMutex();
        }

        private void Sleep()
        {
            barber.WaitOne();
            Console.WriteLine("Sleep");
            _notify.WaitOne();
            Console.WriteLine("Awake");
            barber.ReleaseMutex();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var barber = new Barbershop(3);
            barber.Add();
            barber.Run();
            barber.Add();
            Thread.Sleep(500);
            barber.Add();
            barber.Add();
            barber.Add();
            Thread.Sleep(3000);
            barber.Add();
            barber.Add();
            barber.WaitLastHaircut();
        }
    }
}