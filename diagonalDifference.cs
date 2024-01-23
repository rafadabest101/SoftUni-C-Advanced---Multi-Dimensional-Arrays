namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] arr = new int[size, size];
            int primDiagSum = 0;
            int secDiagSum = 0;

            for(int rows = 0; rows < arr.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for(int cols = 0; cols < arr.GetLength(1); cols++) arr[rows, cols] = nums[cols];
            }
            for(int cols = 0; cols < arr.GetLength(1); cols++)
            {
                for(int rows = 0; rows < arr.GetLength(0); rows++)
                {
                    if(rows == cols) primDiagSum += arr[rows, cols];
                    if(cols == size - 1 - rows) secDiagSum += arr[rows, cols];
                }
            }

            Console.WriteLine(Math.Abs(primDiagSum - secDiagSum));
        }
    }
}