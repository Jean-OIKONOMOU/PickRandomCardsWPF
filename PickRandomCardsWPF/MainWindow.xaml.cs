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
            ReadOnlyText.Text = "Hello, master. How many cards would you like ? The maximum number of cards you can ask for is 52.";

            UserInput.Background = new SolidColorBrush(Colors.Black);
            UserInput.Foreground = new SolidColorBrush(Colors.LawnGreen);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.Key == Key.Return)
            {
                //ProcessCommand(textBox.Text);
                GenerateDeck(textBox.Text);
            }
        }

        private void GenerateDeck(string text)
        {
            ReadOnlyListBox.Items.Clear();
            if (text == null)
            {
                text = "1";
            }

            if (int.TryParse(text, out int id))
            {
                if (id <= 52)
                {
                string[] deck = CardPicker.PickSomeCards(id);
                foreach (var card in deck)
                {
                    ReadOnlyListBox.Items.Add(card);
                }
                ReadOnlyText.Text = $"Here is your {deck.Length} card deck, master. Write another digit if you want to generate another deck.";

                } else {
                    ReadOnlyText.Text = "Master, please input a digit equal, or smaller, than 52.";
                }
            } else {
                ReadOnlyText.Text = "Master, please input a digit equal, or smaller, than 52.";
            }
        }

        private void ReadOnlyText_RemovePlaceHolderText(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Write here")
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
