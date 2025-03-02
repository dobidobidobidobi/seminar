namespace mince
{
    internal class Program
    {
        private static int[] coinTypes;
        static void Main(string[] args)
        {
            coinTypes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int Sum = int.Parse(Console.ReadLine());



            List<int> combination = new List<int>();

            Backtrack(Sum, 0, combination);
        }


        static void Backtrack(int remaining, int start, List<int> combination)
        {
            if (remaining == 0)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }


            for (int i = start; i < coinTypes.Length; i++)
            {
                if (coinTypes[i] <= remaining)
                {
                    combination.Add(coinTypes[i]);
                    Backtrack(remaining - coinTypes[i], i, combination);
                    combination.RemoveAt(combination.Count - 1);
                }
            }
        }
    }
}
