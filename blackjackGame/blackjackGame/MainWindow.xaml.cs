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
        private Card card = new Card();
        private Bankroll bankroll;
        private Pool pool = new Pool();
        public MainWindow()
        {
            InitializeComponent();
            hitButton.IsEnabled = false;
            standButton.IsEnabled = false;
            twentyButton.IsEnabled = false;
            fiftyButton.IsEnabled = false;
            hundredButton.IsEnabled = false;
            twoHundredButton.IsEnabled = false;
            placeCustomBetButton.IsEnabled = false;

            bankroll = new Bankroll(500);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            standButton.IsEnabled = true;
            twentyButton.IsEnabled = true;
            fiftyButton.IsEnabled = true;
            hundredButton.IsEnabled = true;
            twoHundredButton.IsEnabled = true;
            placeCustomBetButton.IsEnabled = true;
            startButton.IsEnabled = false;

            playerCardsListBox.Items.Clear();
            dealerCardsListBox.Items.Clear();

            playerScore = 0;
            dealerScore = 0;

            playerScoreLabel.Content = playerScore.ToString();
            dealerScorelabel.Content = dealerScore.ToString();

            card.ClearUsedCards();

            bankrollTextBox.Text = bankroll.ToString();
            poolAmountTextBox.Text = pool.ToString();
        }

        private void hitButton_Click(object sender, RoutedEventArgs e)
        {
            twentyButton.IsEnabled = false;
            fiftyButton.IsEnabled = false;
            hundredButton.IsEnabled = false;
            twoHundredButton.IsEnabled = false;
            placeCustomBetButton.IsEnabled = false;

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
            if (IsScoreAbove21(playerScore))
            {
                PlayerLostGame();
            }
            
        }

        private bool IsScoreAbove21(int score)
        {
            if (score > 21)
            {
                return true;
            }
            else { return false; }
        }

        private void PlayerLostGame()
        {
            gameResultTextBlock.Text = "YOU LOSE...";
            pool.Amount = 0;
            hitButton.IsEnabled = false;
            standButton.IsEnabled = false;
            startButton.IsEnabled = true;
            UpdateUI();
            if (bankroll.Balance == 0)
            {
                MessageBox.Show("You do not have enough credit to continue playing. \nThe game will be reset", "Not enough credit", MessageBoxButton.OK, MessageBoxImage.Warning);
                bankroll.Balance = 500;
            }
        }

        private void PlayerWonGame()
        {
            double wonAmount = pool.Amount;
            if(playerScore == 21)
            {
                gameResultTextBlock.Text = "BLACKJACK!";
                bankroll.AddToBalance(wonAmount*2.5);
            }
            else
            {
                gameResultTextBlock.Text = "YOU WIN!";
                bankroll.AddToBalance(wonAmount * 2);
            }
            pool.Amount = 0;
            hitButton.IsEnabled = false;
            standButton.IsEnabled = false;
            startButton.IsEnabled = true;
            UpdateUI();
        }

        private void GameEndsInTie()
        {
            gameResultTextBlock.Text = "IT'S A TIE";
            hitButton.IsEnabled = false;
            standButton.IsEnabled = false;
            startButton.IsEnabled = true;
        }

        private void standButton_Click(object sender, RoutedEventArgs e)
        {
            hitButton.IsEnabled = false;

            while (dealerScore <17)
            {
                card.CreateCard();
                if (card.Value == 0)
                {
                    if(dealerScore + 11 <= 21)
                    {
                        card.Value = 11;
                    }
                    else
                    {
                        card.Value = 1;
                    }
                }
                dealerScore += card.Value;
                dealerScorelabel.Content = Convert.ToString(dealerScore);
                dealerCardsListBox.Items.Add(card.ToString());

            }
            if (IsScoreAbove21(dealerScore))
            {
                PlayerWonGame();
            }
            else if (dealerScore < playerScore)
            {
                PlayerWonGame();
            }
            else if (dealerScore == playerScore)
            {
                GameEndsInTie();
            }
            else
            {
                PlayerLostGame();
            }
        }

        private void twentyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfBankrollIsSufficient(20))
            {
                bankroll.RemoveFromBalance(20);
                pool.AddToBalance(20);
                UpdateUI();
                hitButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You have insufficient credits in your bankroll!", "Insufficient bankroll", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void fiftyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfBankrollIsSufficient(50))
            {
                bankroll.RemoveFromBalance(50);
                pool.AddToBalance(50);
                UpdateUI();
                hitButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You have insufficient credits in your bankroll!", "Insufficient bankroll", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void hundredButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfBankrollIsSufficient(100))
            {
                bankroll.RemoveFromBalance(100);
                pool.AddToBalance(100);
                UpdateUI();
                hitButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You have insufficient credits in your bankroll!", "Insufficient bankroll", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void twoHundredButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfBankrollIsSufficient(200))
            {
                bankroll.RemoveFromBalance(200);
                pool.AddToBalance(200);
                UpdateUI();
                hitButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You have insufficient credits in your bankroll!", "Insufficient bankroll", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void placeCustomBetButton_Click(object sender, RoutedEventArgs e)
        {
            double customAmount = Convert.ToDouble(customBetAmountTextBox.Text);
            if (CheckIfBankrollIsSufficient(customAmount))
            {
                bankroll.RemoveFromBalance(customAmount);
                pool.AddToBalance(customAmount);
                UpdateUI();
                hitButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You have insufficient credits in your bankroll!", "Insufficient bankroll", MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void UpdateUI()
        {
            bankrollTextBox.Text = bankroll.ToString();
            poolAmountTextBox.Text = pool.ToString();
            playerScoreLabel.Content = playerScore;
            dealerScorelabel.Content = dealerScore;
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            bankroll.Balance = 500;
            pool.Amount = 0;
            playerScore = 0;
            dealerScore = 0;
            dealerCardsListBox.Items.Clear();
            playerCardsListBox.Items.Clear();
            poolAmountTextBox.Text = string.Empty;
            gameResultTextBlock.Text = string.Empty;
            UpdateUI();
        }

        private bool CheckIfBankrollIsSufficient(double amount)
        {
            if(bankroll.Balance - amount < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}