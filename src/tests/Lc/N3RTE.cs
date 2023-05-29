using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Lab13
{
    public class SudokuChecker
    {
        string[,] grid;
        bool is_checked = false;
        bool is_correct = true; // until first check lol

        private static ManualResetEvent mre = new ManualResetEvent(true);

        public static int ToDigit(string symbol)
        {
            if (symbol == ".")
                return 0;
            return Convert.ToInt32(symbol);
        }

        public SudokuChecker(string[,] grid)
        {
            this.grid = grid;
        }
        public void CheckRow(object i_)
        {
            int i = (int)i_;
            int appeared = 0;
            for (int k = 0; k < 9; ++k)
            {
                int digit = ToDigit(grid[i, k]);
                if (digit == 0)
                    continue;
                digit -= 1;
                if ((1 << digit & appeared) != 0)
                {
                    is_correct = false;
                    return;
                }
                else
                    appeared |= 1 << digit;
                mre.WaitOne();
            }
        }
        public void CheckColumn(object i_)
        {
            int i = (int)i_;
            int appeared = 0;
            for (int k = 0; k < 9; ++k)
            {
                int digit = ToDigit(grid[k, i]);
                if (digit == 0)
                    continue;
                digit -= 1;
                if ((1 << digit & appeared) != 0)
                {
                    is_correct = false;
                    return;
                }
                else
                    appeared |= 1 << digit;
                mre.WaitOne();
            }
        }
        public void CheckBox(object i_)
        {
            // 0 1 2 
            // 3 4 5
            // 6 7 8
            int i = (int)i_;
            int r = (i / 3) * 3;
            int c = (i % 3) * 3;
            int[] row = new int[9] { r,     r,     r, 
                                     r + 1, r + 1, r + 1,
                                     r + 2, r + 2, r + 2 };
            int[] column = new int[9] { c, c + 1, c + 2,
                                        c, c + 1, c + 2,
                                        c, c + 1, c + 2 };

            int appeared = 0;
            for (int k = 0; k < 9; ++k)
            {
                int digit = ToDigit(grid[row[k], column[k]]);
                if (digit == 0)
                    continue;
                digit -= 1;
                if ((1 << digit & appeared) != 0)
                {
                    is_correct = false;
                    return;
                }
                else
                    appeared |= 1 << digit;
                mre.WaitOne();
            }
        }

        public bool Check()
        {
            if (is_checked)
                return is_correct;

            List<Thread> threads = new List<Thread>();
            
            for (int i = 0; i < 9; ++i)
            {
                threads.Add(new Thread(new ParameterizedThreadStart(CheckRow)));
                threads.Add(new Thread(new ParameterizedThreadStart(CheckColumn)));
                threads.Add(new Thread(new ParameterizedThreadStart(CheckBox)));

                int len = threads.Count;
                threads[len-3].Start(i);
                threads[len-2].Start(i);
                threads[len-1].Start(i);
            }

            while(threads.Count > 0)
            {
                threads.RemoveAll(t => !t.IsAlive);
                if (!is_correct)
                    break;
            }
            foreach(var t in threads)
            {
                mre.Close();
            }

            is_checked = true;
            return is_correct;
        }
    }
}
