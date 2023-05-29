using System;

namespace Sudoku
{
    public class TestsSheckSudoku
    {
        public void TestAll()
        {
            var result1 = Test1();
            var result2 = Test2();

            if (result1 && !result2)
            {
                Console.WriteLine("Testing checking sudoku : tests passed.");
            }
            else
            {
                Console.WriteLine("Testing checking sudoku : tests failed.");
            }
        }

        public bool Test1()
        {
            char[,] table = new char[,]
            {
                { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            var sudoku = new CheckSudoku(table);
            return sudoku.Check();
        }

        public bool Test2()
        {
            char[,] table = new char[,]
            {
                { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            
            var sudoku = new CheckSudoku(table);
            return sudoku.Check();
        }
    }
}