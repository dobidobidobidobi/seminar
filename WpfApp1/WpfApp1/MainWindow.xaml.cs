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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing;
        private bool leftWhileDrawing;
        private Polyline currentLine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                isDrawing = true;
                currentLine = new Polyline
                {
                    Stroke = ButtonColor.Background,
                    StrokeThickness = (int)(BrushSize.Value)
                };
                drawingCanvas.Children.Add(currentLine);
                currentLine.Points.Add(e.GetPosition(drawingCanvas));
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                currentLine.Points.Add(e.GetPosition(drawingCanvas));
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
            }
        }

        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
            RGBPicker rgbPicker = new RGBPicker();
            rgbPicker.ShowDialog();
            ButtonColor.Background = rgbPicker.Result.Fill;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;
            }
        }

        private void Canvas_MouseEnter(object sender, MouseEventArgs e)
        {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    isDrawing = true;
                    currentLine = new Polyline
                    {
                        Stroke = ButtonColor.Background,
                        StrokeThickness = (int)(BrushSize.Value)
                    };
                    drawingCanvas.Children.Add(currentLine);
                    currentLine.Points.Add(e.GetPosition(drawingCanvas));
                }   
        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
    }
}