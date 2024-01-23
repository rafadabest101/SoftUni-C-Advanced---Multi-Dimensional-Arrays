namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] arr = new char[sizes[0], sizes[1]];

            for(int rows = 0; rows < arr.GetLength(0); rows++)
            {
                char[] chars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for(int cols = 0; cols < arr.GetLength(1); cols++)
                {
                    arr[rows, cols] = chars[cols];
                }
            }

            int count = 0;

            for(int rows = 0; rows < arr.GetLength(0) - 1; rows++)
            {
                for(int cols = 0; cols < arr.GetLength(1) - 1; cols++)
                {
                    if(arr[rows, cols] == arr[rows, cols + 1] && arr[rows, cols + 1] == arr[rows + 1, cols] 
                        && arr[rows + 1, cols] == arr[rows + 1, cols + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}