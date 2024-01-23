namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int j = 0; j < nums.Length; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            string[] coordinates = Console.ReadLine().Split().ToArray();
            foreach(string coordinate in coordinates)
            {
                int[] rowAndCol = coordinate.Split(',').Select(int.Parse).ToArray();
                int row = rowAndCol[0];
                int col = rowAndCol[1];

                if(matrix[row, col] <= 0) continue;
                
                for(int i = -1; i <= 1; i++)
                {
                    for(int j = -1; j <= 1; j++)
                    {
                        if(row + i >= 0 && col + j >= 0 && row + i < matrix.GetLength(0) && col + j < matrix.GetLength(1))
                        {
                            if(matrix[row + i, col + j] > 0 && (i != 0 || j != 0))
                            {
                                matrix[row + i, col + j] -= matrix[row, col];
                            }
                        }
                    }
                }

                matrix[row, col] = 0;
            }

            int aliveCells = 0;
            int sum = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = new int[matrix.GetLength(0)];
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    nums[j] = matrix[i, j];
                }
                Console.WriteLine(string.Join(' ', nums));
            }
        }
    }
}
