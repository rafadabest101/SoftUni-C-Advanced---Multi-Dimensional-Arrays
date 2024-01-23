namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = sizes[0];
            int m = sizes[1];

            char[,] lair = new char[n, m];
            int playerRow = 0;
            int playerCol = 0;
            for(int i = 0; i < lair.GetLength(0); i++)
            {
                string row = Console.ReadLine();
                for(int j = 0; j < row.Length; j++)
                {
                    lair[i, j] = row[j];
                    if(lair[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            string str = Console.ReadLine();
            Queue<char> commands = new Queue<char>();
            foreach(char ch in str) commands.Enqueue(ch);

            bool playerIsDead = false;
            bool playerEscaped = false;
            while(commands.Count > 0)
            {
                lair[playerRow, playerCol] = '.';

                switch(commands.Peek())
                {
                    case 'R':
                        if(playerCol < lair.GetLength(1) - 1) playerCol++;
                        else if(!playerIsDead) playerEscaped = true;
                        break;
                    case 'L':
                        if(playerCol > 0) playerCol--;
                        else if(!playerIsDead) playerEscaped = true;
                        break;
                    case 'D':
                        if(playerRow < lair.GetLength(0) - 1) playerRow++;
                        else if(!playerIsDead) playerEscaped = true;
                        break;
                    case 'U':
                        if(playerRow > 0) playerRow--;
                        else if(!playerIsDead) playerEscaped = true;
                        break;
                }
                if(lair[playerRow, playerCol] == 'B' && !playerEscaped) playerIsDead = true;

                Queue<int[]> bunnyLocations = new Queue<int[]>(); 
                for(int i = 0; i < lair.GetLength(0); i++)
                {
                    for(int j = 0; j < lair.GetLength(1); j++)
                    {
                        if(lair[i, j] == 'B') bunnyLocations.Enqueue(new int[] { i, j });
                    }
                }

                while(bunnyLocations.Count > 0)
                {
                    int bunnyRow = bunnyLocations.Peek()[0];
                    int bunnyCol = bunnyLocations.Peek()[1];
                    if(bunnyRow < lair.GetLength(0) - 1)
                    {
                        if(bunnyRow + 1 == playerRow && bunnyCol == playerCol && !playerEscaped) playerIsDead = true;
                        lair[bunnyRow + 1, bunnyCol] = 'B';
                    }
                    if(bunnyRow > 0)
                    {
                        if(bunnyRow - 1 == playerRow && bunnyCol == playerCol && !playerEscaped) playerIsDead = true;
                        lair[bunnyRow - 1, bunnyCol] = 'B';
                    }
                    if(bunnyCol < lair.GetLength(1) - 1)
                    {
                        if(bunnyRow == playerRow && bunnyCol + 1 == playerCol && !playerEscaped) playerIsDead = true;
                        lair[bunnyRow, bunnyCol + 1] = 'B';
                    }
                    if(bunnyCol > 0)
                    {
                        if(bunnyRow == playerRow && bunnyCol - 1 == playerCol && !playerEscaped) playerIsDead = true;
                        lair[bunnyRow, bunnyCol - 1] = 'B';
                    }

                    bunnyLocations.Dequeue();
                }

                if(playerEscaped || playerIsDead)
                {
                    for(int i = 0; i < lair.GetLength(0); i++)
                    {
                        for(int j = 0; j < lair.GetLength(1); j++)
                        {
                            Console.Write(lair[i, j]);
                        }
                        Console.WriteLine();
                    }

                    if(playerEscaped) Console.WriteLine($"won: {playerRow} {playerCol}");
                    if(playerIsDead) Console.WriteLine($"dead: {playerRow} {playerCol}");

                    return;
                }

                commands.Dequeue();
            }
        }
    }
}