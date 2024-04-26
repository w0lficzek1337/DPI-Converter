using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace fortnite_sens_calc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void tbDPI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            if (!IsDecimalOrDigit(newText))
            {
                e.Handled = true;
            }
        }

        private bool IsDecimalOrDigit(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private void tbXY_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            if (!IsNumberOrComma(newText))
            {
                e.Handled = true;
            }
        }

        private bool IsNumberOrComma(string text)
        {
            bool commaFound = false;
            foreach (char c in text)
            {
                if (!char.IsDigit(c) && c != ',')
                {
                    return false;
                }
                else if (c == ',')
                {
                    if (commaFound)
                    {
                        return false;
                    }
                    commaFound = true;
                }
            }

            return true;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1a1a1a"));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF171717"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(tbDPIx.Text, out float DPIx) && DPIx >= 100 && DPIx <= 30000 &&
                float.TryParse(tbDPIy.Text, out float DPIy) && DPIy >= 100 && DPIy <= 30000 &&
                float.TryParse(tbX.Text, out float X) && X >= 1 && X <= 100 &&
                float.TryParse(tbY.Text, out float Y) && Y >= 1 && Y <= 100)
            {
                float obecna_sensX = X * DPIx;
                float newDPIx = obecna_sensX;
                float newX = obecna_sensX / newDPIx;

                float obecna_sensY = Y * DPIy;
                float newDPIy = obecna_sensY;
                float newY = obecna_sensY / newDPIy;

                int roundedDPIx = (int)Math.Round(newDPIx);
                int roundedDPIy = (int)Math.Round(newDPIy);
                int roundedX = (int)Math.Round(newX);
                int roundedY = (int)Math.Round(newY);

                lb_newDPIx.Content = roundedDPIx.ToString();
                lb_newDPIy.Content = roundedDPIy.ToString();
                lb_newX.Content = roundedX.ToString();
                lb_newY.Content = roundedY.ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }

        private void reset_bttn_Click(object sender, RoutedEventArgs e)
        {
            tbDPIx.Text = "";
            tbDPIy.Text = "";
            tbX.Text = "";
            tbY.Text = "";
            lb_newDPIx.Content = "";
            lb_newDPIy.Content = "";
            lb_newX.Content = "";
            lb_newY.Content = "";
        }
    }
}