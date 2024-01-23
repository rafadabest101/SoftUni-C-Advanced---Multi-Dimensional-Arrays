namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];
            for(int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                row = row.Trim();
                for(int j = 0; j < row.Length; j++)
                {
                    board[i, j] = row[j];
                }
            }

            int knightsToRemove = 0;
            while(true)
            {
                int maxAttacks = 0;
                int removeRow = -1;
                int removeCol = -1;

                for(int rows = 0; rows < board.GetLength(0); rows++)
                {
                    for(int cols = 0; cols < board.GetLength(1); cols++)
                    {
                        if(board[rows, cols] == 'K')
                        {
                            int currentAttacks = CountAttacks(board, rows, cols);

                            if(currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                removeRow = rows;
                                removeCol = cols;
                            }
                        }
                    }
                }

                if(maxAttacks == 0) break;
                
                board[removeRow, removeCol] = '0';
                knightsToRemove++;
            }

            Console.WriteLine(knightsToRemove);
        }

        static int CountAttacks(char[,] board, int row, int col)
        {
            int attacks = 0;
            for(int i = -2; i <= 2; i++)
            {
                for(int j = -2; j <= 2; j++)
                {
                    if(Math.Abs(i) == Math.Abs(j) || i == 0 || j == 0 ||
                        row + i < 0 || col + j < 0 || row + i >= board.GetLength(0) ||
                        col + j >= board.GetLength(1))
                        continue;
                    else
                    {
                        if(board[row + i, col + j] == 'K')
                        {
                            attacks++;
                        }
                    }
                }
            }
            return attacks;
        }
    }
}