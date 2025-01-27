using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Square[,] squares;
        private Image[,] textures;
        private Border[,] borders;


        public MainWindow()
        {
            InitializeComponent();
            CreateGrid(MineField.Rows, MineField.Columns);
            InitializeMineField();
        }

        private void CreateGrid(int rows, int columns)
        {
            squares = new Square[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Square square = new Square(i, j);
                    squares[i, j] = square;
                }
            }
        }

        private void InitializeMineField()
        {
            textures = new Image[MineField.Rows, MineField.Columns];
            borders = new Border[MineField.Rows, MineField.Columns];
            for (int i = 0; i < MineField.Rows; i++)
            {
                for (int j = 0; j < MineField.Columns; j++)
                {
                    Border border = new Border
                    {
                        Background = Brushes.LightGray, 
                        BorderBrush = Brushes.Black, 
                        BorderThickness = new Thickness(1) 
                    };
                    Image texture = new Image();
                    textures[i,j] = texture;
                    border.Child = texture;
                    borders[i, j] = border;


                    MineField.Children.Add(border);
                }
            }
        }

    }
}