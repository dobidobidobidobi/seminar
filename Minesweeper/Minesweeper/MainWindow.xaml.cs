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
        private bool ZoomCreated = false;
        private TextBlock[] nearbyNumbers;
        private bool isDragging = false;
        private Point initialMousePosition;
        private double InitialCanvasRight;
        private double InitialCanvasBottom;
        private double zoomScale = 1.0;
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
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3b3b3b")),
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
            for (var i = 0; i < 9; i++)
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
                double offsetX = (currentMousePosition.X - initialMousePosition.X) / zoomScale;
                double offsetY = (currentMousePosition.Y - initialMousePosition.Y) / zoomScale;

                if ((-offsetX / 2 + InitialCanvasRight >= -MineField.Width * zoomScale + ActualWidth - 14) &&
                    (-offsetX / 2 + InitialCanvasRight <= 0))
                {
                    Canvas.SetRight(MineField, -offsetX / 2 + InitialCanvasRight);
                }
                if ((-offsetY / 2 + InitialCanvasBottom >= -MineField.Height * zoomScale + ActualHeight - 110) &&
                    (-offsetY / 2 + InitialCanvasBottom <= 0))
                {
                    Canvas.SetBottom(MineField, -offsetY / 2 + InitialCanvasBottom);
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double bottom = Canvas.GetBottom(MineField);
            double right = Canvas.GetRight(MineField);

            CalculateMinZoomScale();
            if (zoomScale < MinZoomScale)
            {
                zoomScale = MinZoomScale;
            }

            zoomScale = 1.0;
            ApplyZoom();

            if (bottom < -MineField.Height * zoomScale + ActualHeight - 110)
            {
                Canvas.SetBottom(MineField, -MineField.Height * zoomScale + ActualHeight - 110);
            }
            if (right < -MineField.Width * zoomScale + ActualWidth - 14)
            {
                Canvas.SetRight(MineField, -MineField.Width * zoomScale + ActualWidth - 14);
            }
            

        }
        
        private double MaxZoomScale = 2.0;
        private double MinZoomScale = 0.4;

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            CalculateMinZoomScale();

            if (e.Delta > 0 && zoomScale < MaxZoomScale)
            {
                zoomScale += (1 - MinZoomScale) / 8;
            }
            else if (e.Delta < 0 && zoomScale >= MinZoomScale + ((1 - MinZoomScale) / 8))
            {
            zoomScale -= (1 - MinZoomScale) / 8;
            }

            ApplyZoom();
        }

        private void ApplyZoom()
        {
            MineField.LayoutTransform = new ScaleTransform(zoomScale, zoomScale);

            double bottom = Canvas.GetBottom(MineField);
            double right = Canvas.GetRight(MineField);

            if (bottom < -MineField.Height * zoomScale + ActualHeight - 110)
            {
                Canvas.SetBottom(MineField, -MineField.Height * zoomScale + ActualHeight - 110);
            }
            if (right < -MineField.Width * zoomScale + ActualWidth - 14)
            {
                Canvas.SetRight(MineField, -MineField.Width * zoomScale + ActualWidth - 14);
            }
        }

        private void CalculateMinZoomScale()
        {
            double widthScale = (ActualWidth-14)  / MineField.Width;
            double heightScale = (ActualHeight -110) / MineField.Height;
            MinZoomScale = Math.Max(widthScale, heightScale);
            MaxZoomScale = MinZoomScale * 4;
        }
    }
}