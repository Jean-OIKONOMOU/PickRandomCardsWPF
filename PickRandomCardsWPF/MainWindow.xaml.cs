using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PickRandomCardsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpCardPicker();
        }

        private void SetUpCardPicker()
        {
            mainGrid.Background = new SolidColorBrush(Colors.Black);
            ReadOnlyText.Background = new SolidColorBrush(Colors.Black);
            ReadOnlyText.Foreground = new SolidColorBrush(Colors.LawnGreen);
            UserInput.Background = new SolidColorBrush(Colors.Black);
            UserInput.Foreground = new SolidColorBrush(Colors.LawnGreen);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.Key == Key.Return)
            {
                ProcessCommand(textBox.Text);
            }
        }

        private void ProcessCommand(string text)
        {
            ReadOnlyText.Text = text;
        }
    }
}
