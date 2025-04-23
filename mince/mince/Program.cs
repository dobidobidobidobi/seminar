namespace mince
{
    internal class Program
    {
        private static int[] coinTypes;
        static void Main(string[] args)
        {
            //prijamani inputu
            coinTypes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int Sum = int.Parse(Console.ReadLine());
            //list co bude ukladat kombinaci v danem momentu
            List<int> combination = new List<int>();

            Backtrack(Sum, 0, combination);
        }
        //funkce prijima tri argumenty - kolik nam toho jeste zbyva do kombinace, od jakeho cisla zaciname,
        //a z ceho je nase momentalni kombinace poskladana
        static void Backtrack(int remaining, int start, List<int> combination)
        {
            //pokud jsme presne na nule, znamena to, ze nas list obsahuje realnou kombinaci
            if (remaining == 0)
            {
                //tu serazenost posloupnosti splnujeme jelikoz zaciname rekurzi od nejvyssiho cisla
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            //zaciname od cisla, ktere je prave nejnizsi v kombinaci, aby byla splnena serazenost posloupnosti
            // a nedoslo k jakemukoliv opakovani
            for (int i = start; i < coinTypes.Length; i++)
            {
                //muzeme pokracovat v rekurzi pokud neprekrocime danou sumu
                if (coinTypes[i] <= remaining)
                {
                    //pridame dane cislo do kombinace
                    combination.Add(coinTypes[i]);
                    //rekurze
                    Backtrack(remaining - coinTypes[i], i, combination);
                    //odebereme pridane cislo, abychom mohli pokracovat s jinou rekurzi
                    combination.RemoveAt(combination.Count - 1);
                }
            }
        }
    }
}
