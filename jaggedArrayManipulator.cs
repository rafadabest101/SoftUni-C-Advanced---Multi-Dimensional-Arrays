namespace SU_MultiDimArrsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[n][];

            for(int i = 0; i < n; i++)
            {
                jaggedArr[i] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }

            for(int i = 0; i < jaggedArr.Length - 1; i++)
            {
                double multiplier = 2;

                if(jaggedArr[i].Length != jaggedArr[i + 1].Length) multiplier = 0.5;

                for(int j = 0; j < jaggedArr[i].Length; j++)
                {
                    jaggedArr[i][j] *= multiplier;
                }
                for(int j = 0; j < jaggedArr[i + 1].Length; j++)
                {
                    jaggedArr[i + 1][j] *= multiplier;
                }
            }

            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] commandParts = command.Split().ToArray();

                switch(commandParts[0])
                {
                    case "Add":
                        int addRow = int.Parse(commandParts[1]);
                        int addCol = int.Parse(commandParts[2]);
                        double addValue = double.Parse(commandParts[3]);

                        if(addRow >= 0 && addCol >= 0 && addRow < jaggedArr.Length && addCol < jaggedArr[addRow].Length)
                        {
                            jaggedArr[addRow][addCol] += addValue;
                        }
                        break;
                    case "Subtract":
                        int subtractRow = int.Parse(commandParts[1]);
                        int subtractCol = int.Parse(commandParts[2]);
                        double subtractValue = double.Parse(commandParts[3]);

                        if(subtractRow >= 0 && subtractCol >= 0 && 
                            subtractRow < jaggedArr.Length && subtractCol < jaggedArr[subtractRow].Length)
                        {
                            jaggedArr[subtractRow][subtractCol] -= subtractValue;
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            for(int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i]));
            }
        }
    }
}