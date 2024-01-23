namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string str = Console.ReadLine();

            char[,] path = new char[sizes[0], sizes[1]];
            Queue<char> letters = new Queue<char>();
            foreach(char letter in str) letters.Enqueue(letter);

            for(int rows = 0; rows < path.GetLength(0); rows++)
            {
                if(rows % 2 == 0)
                {
                    for(int cols = 0; cols < path.GetLength(1); cols++)
                    {
                        path[rows, cols] = letters.Peek();
                        letters.Enqueue(letters.Dequeue());
                    }
                }
                else
                {
                    for(int cols = path.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        path[rows, cols] = letters.Peek();
                        letters.Enqueue(letters.Dequeue());
                    }
                }
            }

            for(int rows = 0; rows < path.GetLength(0); rows++)
            {
                for(int cols = 0; cols < path.GetLength(1); cols++)
                {
                    Console.Write(path[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}