namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] arr = new int[sizes[0], sizes[1]];

            for(int rows = 0; rows < arr.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for(int cols = 0; cols < arr.GetLength(1); cols++)
                {
                    arr[rows, cols] = nums[cols];
                }
            }

            int maxSum = 0;
            int[,] biggestSquare = new int[3, 3];

            for(int rows = 0; rows < arr.GetLength(0) - 2; rows++)
            {
                for(int cols = 0; cols < arr.GetLength(1) - 2; cols++)
                {
                    int sum = 0;
                    for(int i = 0; i < 3; i++)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            sum += arr[rows + i, cols + j];
                        }
                    }

                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        for(int i = 0; i < 3; i++)
                        {
                            for(int j = 0; j < 3; j++)
                            {
                                biggestSquare[i, j] = arr[rows + i, cols + j];
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{biggestSquare[0, 0]} {biggestSquare[0, 1]} {biggestSquare[0, 2]}");
            Console.WriteLine($"{biggestSquare[1, 0]} {biggestSquare[1, 1]} {biggestSquare[1, 2]}");
            Console.WriteLine($"{biggestSquare[2, 0]} {biggestSquare[2, 1]} {biggestSquare[2, 2]}");
        }
    }
}