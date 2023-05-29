namespace task4
{
    class Program
    {
        public static double[,] MultiplyMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            int resultMatrixRows = firstMatrix.GetLength(0);
            int resultMatrixColumns = secondMatrix.GetLength(1);
            double[,] resultMatrix = new double[resultMatrixRows, resultMatrixColumns];

            Parallel.For(0, resultMatrixRows, i =>
            {
                Parallel.For(0, resultMatrixColumns, j =>
                {
                    resultMatrix[i, j] = 0.0;
                    for (int n = 0; n < firstMatrix.GetLength(1); n++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, n] * secondMatrix[n, j];
                        
                    }
                    Thread.Sleep(50);
                });
                Thread.Sleep(50);
            });
            return resultMatrix;
        }

        public static void FillMatrix(ref double[,] matrix, int rows, int cols)
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(50);
                   
                }
            }
        }
        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            Console.Write("m: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine();

            double[,] matrixFirst = new double[m, n];
            FillMatrix(ref matrixFirst, m, n);
            double[,] matrixSecond = new double[n, k];
            FillMatrix(ref matrixSecond, n, k);
       
            Console.WriteLine("First matrix:");
            PrintMatrix(matrixFirst);
            Console.WriteLine();
            Console.WriteLine("Second matrix:");
            PrintMatrix(matrixSecond);
            Console.WriteLine();
            double[,] resultMatrix = MultiplyMatrix(matrixFirst, matrixSecond);
            Console.WriteLine("Result matrix: ");
            PrintMatrix(resultMatrix);

            /*
             * m: 3
               n: 3
               k: 3

               First matrix:
               0 8 7
               18 34 36
               49 35 9

               Second matrix:
               11 23 23
               13 32 1
               26 18 36


               Result matrix:
               286 382 260
               1576 2150 1744
               1228 2409 1486
             */
        }
    }
}
