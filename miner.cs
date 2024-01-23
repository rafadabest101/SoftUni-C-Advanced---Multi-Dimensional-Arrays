namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            string[] words = Console.ReadLine().Split().ToArray();
            Queue<string> commands = new Queue<string>();
            foreach(string word in words) commands.Enqueue(word);

            int minerRow = 0;
            int minerCol = 0;
            int coals = 0;
            for(int i = 0; i < n; i++)
            {
                char[] tiles = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for(int j = 0; j < tiles.Length; j++)
                {
                    field[i, j] = tiles[j];
                    if(field[i, j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                    if(field[i, j] == 'c') coals++;
                }
            }

            int collectedCoals = 0;

            while(commands.Count > 0)
            {
                switch(commands.Peek())
                {
                    case "up":
                        if(minerRow > 0) minerRow--;
                        break;
                    case "down":
                        if(minerRow < field.GetLength(0) - 1) minerRow++;
                        break;
                    case "left":
                        if(minerCol > 0) minerCol--;
                        break;
                    case "right":
                        if(minerCol < field.GetLength(1) - 1) minerCol++;
                        break;
                }

                if(field[minerRow, minerCol] == 'c')
                {
                    collectedCoals++;
                    field[minerRow, minerCol] = '*';

                    if(collectedCoals == coals)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }

                if(field[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
                commands.Dequeue();
            }

            Console.WriteLine($"{coals - collectedCoals} coals left. ({minerRow}, {minerCol})");
        }
    }
}
