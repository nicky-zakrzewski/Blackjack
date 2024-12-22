using blackjackGame.Classes;
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

namespace blackjackGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Card card = new Card();
        private int playerScore = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            //card.CreateCard();
            //gameResultTextBlock.Text = card.ToString();
        }

        private void hitButton_Click(object sender, RoutedEventArgs e)
        {
            card.CreateCard();
            //if (card.Value == 0)
            //{
            //    MessageBoxOptions.
            //}
            playerScore += card.Value;
            playerScoreLabel.Content = Convert.ToString(playerScore);
            playerCardsListBox.Items.Add(card.ToString());
        }
    }
}