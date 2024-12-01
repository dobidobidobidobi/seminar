namespace TextAnalyzer
{
    internal class Program
    {
        static void Output(string filepath)
        {
            using (TextAnalyzer txtAnal = new TextAnalyzer(filepath))
            {
                Console.WriteLine(txtAnal.WordCount);
                Console.WriteLine(txtAnal.CharactersNoSpacesCount);
                Console.WriteLine(txtAnal.CharactersCount);
                Console.WriteLine();
                txtAnal.VypisCetnostSlov();
                Console.WriteLine();
                Console.WriteLine(txtAnal.SlovaOddelenaMezerou());
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string[] soubory = {"0_vstup.txt", "1_vstup.txt",
                                "2_vstup.txt", "3_vstup.txt" };
            foreach (string filepath in soubory)
            {
                try
                {
                    Output(filepath);
                }
                catch (Exception ex)
                {
                    if (ex.ToString() == "FileNotFoundException")
                    {
                        Console.WriteLine("Soubor jménem " + filepath + " neexistuje");
                    }
                    else { Console.WriteLine("Input File Error"); }
                }
            }
        }

        class TextAnalyzer : StreamReader
        {
            private Dictionary<string, int> _words = new Dictionary<string, int>();
            public int WordCount { get; }
            public int CharactersNoSpacesCount { get; private set; }
            public int CharactersCount { get; private set; }

            private string SlovaOddelenaMezerouString { get; set; }


            public TextAnalyzer(string path) : base(path)
            {
                string text = this.ReadToEnd();
                string[] slova = text.Split(' ', '\t', '\n', '\r');
                
                
                foreach (string s in slova)
                {
                    if (s != "")
                    {
                        WordCount++;
                        if (_words.ContainsKey(s))
                        {
                            _words[s] += 1;
                        }
                        else
                        {
                            _words.Add(s, 1);
                        }
                    }
                }

                CharactersCount = text.Length;
                CharactersNoSpacesCount = new string(text.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).Length;

                SlovaOddelenaMezerouString = "";

                string[] slovaRadky = text.Split(' ', '\t');
                foreach (string s in slovaRadky) 
                {
                    if (s != "")
                    { 
                        if ((s[s.Length-1] == '\n') || (s[s.Length - 1] == '\r')) { SlovaOddelenaMezerouString += s; }
                        else { SlovaOddelenaMezerouString += s + ' '; }
                    }
                }
                if ((SlovaOddelenaMezerouString.Length > 0) &&
                   (SlovaOddelenaMezerouString[SlovaOddelenaMezerouString.Length - 1] == ' ' ))
                { 
                    SlovaOddelenaMezerouString.Remove(SlovaOddelenaMezerouString.Length - 1); 
                }
            }

            public string SlovaOddelenaMezerou()
            {
                return SlovaOddelenaMezerouString;
            }

            public void VypisCetnostSlov()
            {
                foreach (KeyValuePair<string, int> entry in _words)
                {
                    Console.WriteLine(entry.Key + ": " + entry.Value);
                }
            }
        }
    }
}
