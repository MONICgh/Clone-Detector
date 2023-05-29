namespace Application
{
    class Task4
    {
        private static readonly object blocker = new object();
        static bool correct;
        
        static void CorrectCells(List<string> cells)
        { 
            var nums = new List<bool>() { false, false, false, false, false, false, false, false, false };
            foreach (var cell in cells)
            {
                if (cell != ".")
                { 
                    var i = Int32.Parse(cell) - 1;
                    if (nums[i])
                    {
                        lock (blocker)
                        {
                            correct = false;
                        }
                        break;
                    }
                    nums[i] = true;
                }   
            }
        }
        
        static bool CorrectBoard(List<List<string>> board)
        {
            correct = true;
            var threads = new List<Thread>();
            for (int i = 0; i < 9; i++)
            {
                var cells = new List<string>() { };
                for (int j = 0; j < 9; j++)
                {
                    cells.Add(board[i][j]);
                }
                threads.Add(new Thread(() => CorrectCells(cells)));
                
                var cells2 = new List<string>() { };
                for (int j = 0; j < 9; j++)
                {
                    cells2.Add(board[j][i]);
                }
                threads.Add(new Thread(() => CorrectCells(cells2)));
                
                var cells3 = new List<string>() { };
                var row = (i % 3) * 3;
                var column = (i / 3) * 3;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        cells3.Add(board[row+j][column+k]);
                    }
                }
                threads.Add(new Thread(() => CorrectCells(cells3)));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return correct;
        } 

        static void Main()
        {
            var board = new List<List<string>>() {
                new List<string>() {"5","3",".",".","7",".",".",".","."},
                new List<string>() {"6",".",".","1","9","5",".",".","."},
                new List<string>() {".","9","8",".",".",".",".","6","."},
                new List<string>() {"8",".",".",".","6",".",".",".","3"},
                new List<string>() {"4",".",".","8",".","3",".",".","1"},
                new List<string>() {"7",".",".",".","2",".",".",".","6"},
                new List<string>() {".","6",".",".",".",".","2","8","."},
                new List<string>() {".",".",".","4","1","9",".",".","5"},
                new List<string>() {".",".",".",".","8",".",".","7","9"},
            };
            Console.WriteLine($"correct board: {CorrectBoard(board)}");
            board[0][0] = "8";
            Console.WriteLine($"correct board: {CorrectBoard(board)}");
        }
    }
}
