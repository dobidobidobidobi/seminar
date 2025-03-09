namespace knapsack_backtrack
{
    internal class Program
    {
        private static int[] weights;
        private static int[] values;
        private static int capacity;
        private static int bestValue = 0;
        private static List<int> bestCombination = new List<int>();

        static void Main(string[] args)
        {
            weights = Console.ReadLine().Split().Select(int.Parse).ToArray();
            values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            capacity = int.Parse(Console.ReadLine());
            List<int> combination = new List<int>();

            Backtrack(0,0,0, combination);

            Console.WriteLine(bestValue);
            Console.WriteLine(string.Join(" ", bestCombination));
        }

        static void Backtrack(int weight, int value, int start, List<int> combination)
        {
            
            for (int i = start; i < weights.Length; i++)
            {
                if (weights[i] <= capacity - weight)
                {
                    combination.Add(i+1);
                    value += values[i];
                    weight += weights[i];
                    
                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestCombination = new List<int>(combination);
                    }

                    Backtrack(weight, value, i+1, combination);
                    combination.RemoveAt(combination.Count - 1);
                    value -= values[i];
                    weight -= weights[i];
                }
            }
        }
    }
}
