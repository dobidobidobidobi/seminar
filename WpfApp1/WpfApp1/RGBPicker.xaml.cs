using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RGBPicker.xaml
    /// </summary>
    public partial class RGBPicker : Window
    {
        public RGBPicker()
        {
            InitializeComponent();
        }
        private string RgbToHex(int r, int g, int b)
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        private void DrawColor()
        {
            if (RedSlider == null || GreenSlider == null || BlueSlider == null)
            {
                return;
            }
            int r = (int)(RedSlider.Value);
            int g = (int)(GreenSlider.Value);
            int b = (int)(BlueSlider.Value);
            string hex = RgbToHex(r, g, b);
            if (HexTextBlock != null) { HexTextBlock.Text = hex; }
            Result.Fill = (Brush)(new BrushConverter().ConvertFromString(hex));
            

        }

        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RedBox.Text = RedSlider.Value.ToString();
            DrawColor();

        }

        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GreenBox.Text = GreenSlider.Value.ToString();
            DrawColor();
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BlueBox.Text = BlueSlider.Value.ToString();
            DrawColor();
        }

        private void RedBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RedBox.Text != "")
            {
                int value = int.Parse(RedBox.Text);
                value = ChangeToLegalValue(value);
                RedBox.Text = value.ToString();
                if (RedSlider != null) { RedSlider.Value = value; }
            }
        }

        private void GreenBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GreenBox.Text != "")
            {
                int value = int.Parse(GreenBox.Text);
                value = ChangeToLegalValue(value);
                GreenBox.Text = value.ToString();
                if (GreenSlider != null) { GreenSlider.Value = value; }
            }
        }

        private void BlueBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BlueBox.Text != "")
            {
                int value = int.Parse(BlueBox.Text);
                value = ChangeToLegalValue(value);
                BlueBox.Text = value.ToString();
                if (BlueSlider != null) { BlueSlider.Value = value; }
            }
        }

        private int ChangeToLegalValue(int value)
        {
            if (value <= 0) return 0;
            if (value > 255) return 255;
            return value;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("Zadávejte pouze hodnoty 0-255");
            }
        }
    }
}
