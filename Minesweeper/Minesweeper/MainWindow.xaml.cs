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
        
        private Viewbox[,] viewboxes;

        private TextBlock[] nearbyNumbers;
        private bool isDragging = false;
        private Point initialMousePosition;
        private double InitialCanvasRight;
        private double InitialCanvasBottom;
        public MainWindow()
        {
            InitializeComponent();
            CreateGrid(MineField.Rows, MineField.Columns);
            InitializeMineField();
            CreateNearbyNumbers();
            viewboxes[0, 12].Child = nearbyNumbers[0];

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
            
            viewboxes = new Viewbox[MineField.Rows, MineField.Columns];
            for (int i = 0; i < MineField.Rows; i++)
            {
                for (int j = 0; j < MineField.Columns; j++)
                {
                    Viewbox viewbox = new Viewbox();
                    Border border = new Border
                    {
                        Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#3b3b3b")), 
                        BorderBrush = Brushes.Black,
                        Margin = new Thickness(0.5),
                        BorderThickness = new Thickness(0),
                        Child = viewbox
                    };
                    viewboxes[i, j] = viewbox;


                    MineField.Children.Add(border);
                }
            }
        }

        private void CreateNearbyNumbers()
        {
            nearbyNumbers = new TextBlock[9];
            for (var i = 0; i < 9 ;i++)
            {
                TextBlock JoeBiden = new TextBlock
                {
                    Text = Convert.ToString(i + 1),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009200")),
                    FontFamily = new FontFamily("Tahoma"),
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };
                nearbyNumbers[i] = JoeBiden;
            }
        }

        private void MineField_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            MineField.ReleaseMouseCapture();
        }

        private void MineField_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            initialMousePosition = e.GetPosition(this);
            isDragging = true;
            InitialCanvasBottom = Canvas.GetBottom(MineField);
            InitialCanvasRight = Canvas.GetRight(MineField);
            MineField.CaptureMouse();
        }

        private void MineField_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.GetPosition(this);
                double offsetX = currentMousePosition.X - initialMousePosition.X;
                double offsetY = currentMousePosition.Y - initialMousePosition.Y;

                Canvas.SetRight(MineField, offsetX/2 + InitialCanvasRight);
                Canvas.SetBottom(MineField, offsetY/2 + InitialCanvasBottom);
            }
        }
    }
}