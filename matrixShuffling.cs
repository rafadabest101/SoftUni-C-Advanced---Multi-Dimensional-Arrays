namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] arr = new string[sizes[0], sizes[1]];

            for(int rows = 0; rows < arr.GetLength(0); rows++)
            {
                string[] strs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for(int cols = 0; cols < arr.GetLength(1); cols++)
                {
                    arr[rows, cols] = strs[cols];
                }
            }

            string command = Console.ReadLine();
            while(command != "END")
            {
                if(!command.Contains("swap"))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                string[] commandParts = command.Split().ToArray();
                if(commandParts.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                int row1 = int.Parse(commandParts[1]);
                int col1 = int.Parse(commandParts[2]);
                int row2 = int.Parse(commandParts[3]);
                int col2 = int.Parse(commandParts[4]);

                if(row1 >= 0 && col1 >= 0 && row2 >= 0 && col2 >= 0 && row1 < arr.GetLength(0) && 
                    col1 < arr.GetLength(1) && row2 < arr.GetLength(0) && col2 < arr.GetLength(1))
                {
                    string temp = arr[row1, col1];
                    arr[row1, col1] = arr[row2, col2];
                    arr[row2, col2] = temp;

                    for(int rows = 0; rows < arr.GetLength(0); rows++)
                    {
                        for(int cols = 0; cols < arr.GetLength(1); cols++)
                        {
                            Console.Write(arr[rows, cols]);
                            if(cols < arr.GetLength(1) - 1) Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
                else Console.WriteLine("Invalid input!");

                command = Console.ReadLine();
            }
        }
    }
}