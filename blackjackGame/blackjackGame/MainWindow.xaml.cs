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
        private int playerScore = 0, dealerScore = 0;

        public MainWindow()
        {
            InitializeComponent();
            hitButton.IsEnabled = false;
            standButton.IsEnabled = false;

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            hitButton.IsEnabled = true;
            standButton.IsEnabled = true;
            startButton.IsEnabled = false;
            playerCardsListBox.Items.Clear();
            dealerCardsListBox.Items.Clear();
            playerScore = 0;
            dealerScore = 0;
            playerScoreLabel.Content = playerScore.ToString();
            dealerScorelabel.Content = dealerScore.ToString();
        }

        private void hitButton_Click(object sender, RoutedEventArgs e)
        {
            Card card = new Card();
            card.CreateCard();
            //Check if card is an ace
            if (card.Value == 0)
            {
                MessageBoxResult result = MessageBox.Show($"You have drawn an {card.ToString()}. " +
                    $"Do you want to set the ace value to 11?\n(If not, the value will be set to 1)",
                    "Ace value", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    card.Value = 11;
                }
                else
                {
                    card.Value = 1;
                }
            }
            playerScore += card.Value;
            playerScoreLabel.Content = Convert.ToString(playerScore);
            playerCardsListBox.Items.Add(card.ToString());
            CheckScore(playerScore);
        }

        private void CheckScore(int score)
        {
            if (score > 21)
            {
                gameResultTextBlock.Text = "YOU LOSE";
                hitButton.IsEnabled = false;
                standButton.IsEnabled = false;
                startButton.IsEnabled=true;
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}