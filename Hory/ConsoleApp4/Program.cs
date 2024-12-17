using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation;
            try
            {
                using (Data data = new Data("1.txt"))
                {
                    simulation = new Simulation(data);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

    }

    class Simulation
    {
        public Square[,] Squares { get; }
        public Move[] Moves { get; }
        int BoardSize { get; }
        private List<Square>? ShortestPath { get; set; }

        public Simulation(Data data)
        {
            Moves = data.Moves;
            BoardSize = data.BoardSize;
            Squares = new Square[BoardSize,BoardSize];

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Squares[row, col] = new Square(row, col, null);
                }
            }


            foreach (Square specialSquare in data.SpecialSquares)
            {
                Squares[specialSquare.X, specialSquare.Y] = specialSquare;
            }

            BFS();

            if (Squares[BoardSize-1, BoardSize-1].Path.Count() != 0)
            {
                ShortestPath = Squares[BoardSize-1, BoardSize-1].Path;
                ShortestPath.Add(Squares[BoardSize - 1, BoardSize - 1]);
                Console.WriteLine(ShortestPath.Count - 1);
                PrintPath();
            }
            else 
            { 
                ShortestPath = null;
                Console.WriteLine(-1);
            }

            

        }

        private void PrintPath()
        {
            string path = "";
            foreach (Square square in ShortestPath)
            {
                path += $"[{square.X},{square.Y}] ";
            }
            Console.WriteLine(path);
        }

        private void BFS()
        {
            Queue<Square> queue = new Queue<Square>();
            queue.Enqueue(Squares[0, 0]);
            Squares[0,0].Visited = true;

            while (queue.Count > 0)
            {
                Square currentSquare = queue.Dequeue();
                
                foreach (Move move in Moves)
                {
                    int row = move.VectorX + currentSquare.X; 
                    int col = move.VectorY + currentSquare.Y;
                    if ((row >= 0) && (col >= 0) && (row <= BoardSize -1) && (col <= BoardSize -1))
                    {

                        Square nextSquare = Squares[row, col];
                        if (!nextSquare.Visited)
                        {
                            if (CheckTraversibility(move, currentSquare))
                            {
                                nextSquare.Path = new List<Square> (currentSquare.Path);
                                nextSquare.Path.Add(currentSquare);
                                ShortestPath = nextSquare.Path;
                                nextSquare.Visited = true;
                                queue.Enqueue(nextSquare);
                            }
                           

                        }
                    }

                }
            }

        }

        private bool CheckTraversibility(Move move, Square currentSquare)
        {
            bool traversible = true;
            if (move.VectorY == move.VectorX)
            {
                for (int i = 1; i <= move.VectorX; i++)
                {
                    if (currentSquare.Path.Count() >= Squares[currentSquare.X + i, currentSquare.Y + i].TimeToBecomeUntraversable)
                    { traversible = false; break; }
                }
            }
            else if (move.VectorY == 0)
            {
                for (int i = 1; i <= move.VectorX; i++)
                {
                    if (currentSquare.Path.Count() >= Squares[currentSquare.X + i, currentSquare.Y].TimeToBecomeUntraversable)
                    { traversible = false; break; }
                }
            }
            else
            {
                for (int i = 1; i <= move.VectorY; i++)
                {
                    if (currentSquare.Path.Count() >= Squares[currentSquare.X, currentSquare.Y + i].TimeToBecomeUntraversable)
                    { traversible = false; break; }
                }
            }
            return traversible;
        }


    }

    class Square
    {
        public int X { get; }
        public int Y { get; }
        public int? TimeToBecomeUntraversable { get;  }
        
        public bool Visited { get; set; }

        public List<Square> Path { get; set; }

        public Square(int x, int y, int? timeToBecomeUntraversable)
        {
            X = x;
            Y = y;
            TimeToBecomeUntraversable = timeToBecomeUntraversable;
            Visited = false;
            Path = new List<Square>();
        }

    }

    class Move
    {
        public int VectorX { get; }
        public int VectorY { get; }
        public Move(int vectorX, int vectorY)
        {
            this.VectorX = vectorX;
            this.VectorY = vectorY;
        }
    }

    class Data : StreamReader
    {
        public int BoardSize { get; }
        public Move[] Moves { get; }
        public Square[] SpecialSquares { get; }

        public Data(string path) : base(path)
        {
            BoardSize = int.Parse(this.ReadLine());
            
            int numberOfSpecialSquares = int.Parse(this.ReadLine());
            SpecialSquares = new Square[numberOfSpecialSquares];

            for (int i = 0; i < numberOfSpecialSquares; i++)
            {
                int[] linedata = this.ReadLine().Split(' ').Select(int.Parse).ToArray();
                SpecialSquares[i] = new Square(linedata[0], linedata[1], linedata[2]);
            }

            int numberOfMoves= int.Parse(this.ReadLine());
            Moves = new Move[numberOfMoves];
            
            for (int i = 0; i < numberOfMoves; i++)
            {
                int[] linedata = this.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Moves[i] = new Move(linedata[0], linedata[1]);
            }
        }

    }
}
