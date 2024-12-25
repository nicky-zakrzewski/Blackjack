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

        private const int blackjack = 21;
        private const double startBalance = 500, betButton1Value =20, betButton2Value = 50, betButton3Value = 100, betButton4Value = 200;
        public MainWindow()
        {
            InitializeComponent();
            EnableAllButtons(false);
            bankroll = new Bankroll(startBalance);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            int difficulty = Convert.ToInt32(difficultySlider.Value);
            switch (difficulty)
            {
                case 1:
                    difficulty = 1;
                    break;  
                case 2:
                    difficulty = 2;
                    break;
                case 3:
                    difficulty+=1;
                    break;
                default:
                    difficulty = 1;
                    break;
            }
            card.Difficulty = difficulty;
            difficultySlider.IsEnabled = false;
            EnableBetButtons(true);
            ResetScores();
            card.ClearUsedCards();
            UpdateUI();
        }

        private void hitButton_Click(object sender, RoutedEventArgs e)
        {
            card.CreateCard();
            CheckIfCardIsAceAndSelectValue();
            playerScore += card.Value;
            playerCardsListBox.Items.Add(card.ToString());
            UpdateUI();
            CheckGameStatus();
        }

        private void standButton_Click(object sender, RoutedEventArgs e)
        {
            hitButton.IsEnabled = false;
            while (dealerScore < 17)
            {
                card.CreateCard();
                CheckIfCardIsAceAndSelectValue();
                dealerScore += card.Value;
                dealerCardsListBox.Items.Add(card.ToString());
                UpdateUI();
            }
            UpdateUI();
            CheckGameStatus();
            CheckEndGameBankroll();
        }

        private void twentyButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfBankrollIsSufficient(betButton1Value);

        }

        private void fiftyButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfBankrollIsSufficient(betButton2Value);
        }

        private void hundredButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfBankrollIsSufficient(betButton3Value);
        }

        private void twoHundredButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfBankrollIsSufficient(betButton4Value);
        }

        private void placeCustomBetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = customBetAmountTextBox.Text;
                if (string.IsNullOrEmpty(input))
                {
                    if(pool.Amount != 0)
                    {
                        UpdateUI();
                        EnableHitAndStandButtons(true);
                        EnableBetButtons(false);
                    }
                    else
                    {
                        MessageBox.Show("You need to place a bet before playing!", "No bet placed", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    double amount = Convert.ToDouble(input);
                    if (amount <= 0)
                    {
                        MessageBox.Show("The bet must be more than 0!", "Incorrect bet", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (amount <= bankroll.Balance)
                        {
                            EnableHitAndStandButtons(true);
                            EnableBetButtons(false);
                        }
                        CheckIfBankrollIsSufficient(amount);
                    }
                    
                }
                customBetAmountTextBox.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter an amount!", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            bankroll.Balance = startBalance;
            pool.Amount = 0;
            ResetScores();
            UpdateUI();
            difficultySlider.IsEnabled = true;
            startButton.IsEnabled = true;
            EnableAllButtons(false);
        }
        private void difficultySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        //functions
        private void CheckEndGameBankroll()
        {
            if (bankroll.Balance == 0)
            {
                MessageBox.Show("You do not have enough credit to continue playing. \nThe game will be reset", "Not enough credit", MessageBoxButton.OK, MessageBoxImage.Warning);
                bankroll.Balance = startBalance;
                pool.Amount = 0;
                difficultySlider.IsEnabled = true;
            }
        }
        private void EnableHitAndStandButtons(bool trueOrFalse)
        {
            if (trueOrFalse)
            {
                hitButton.IsEnabled = true;
                standButton.IsEnabled = true;
            }
            else
            {
                hitButton.IsEnabled = false;
                standButton.IsEnabled = false;
            }
        }
        private void UpdateUI()
        {
            bankrollTextBox.Text = bankroll.ToString();
            poolAmountTextBox.Text = pool.ToString();
            playerScoreLabel.Content = playerScore;
            dealerScorelabel.Content = dealerScore;
        }
        private void EnableAllButtons(bool yesOrNo)
        {
            if (yesOrNo)
            {
                EnableBetButtons(true);
                EnableHitAndStandButtons(true);
            }
            else
            {
                EnableBetButtons(false);
                EnableHitAndStandButtons(false);
            }
        }
        public void EnableBetButtons(bool trueOrFalse)
        {
            if (trueOrFalse)
            {
                twentyButton.IsEnabled = true;
                fiftyButton.IsEnabled = true;
                hundredButton.IsEnabled = true;
                twoHundredButton.IsEnabled = true;
                placeCustomBetButton.IsEnabled = true;
                customBetAmountTextBox.IsEnabled = true;
            }
            else
            {
                twentyButton.IsEnabled = false;
                fiftyButton.IsEnabled = false;
                hundredButton.IsEnabled = false;
                twoHundredButton.IsEnabled = false;
                placeCustomBetButton.IsEnabled = false;
                customBetAmountTextBox.IsEnabled = false;
            }
        }
        public void ResetScores()
        {
            playerCardsListBox.Items.Clear();
            dealerCardsListBox.Items.Clear();
            gameResultTextBlock.Text = string.Empty;
            playerScore = 0;
            dealerScore = 0;
        }
        private void CheckIfCardIsAceAndSelectValue()
        {
            if (card.Value == 11)
            {
                if (playerScore + 11 > blackjack)
                {
                    card.Value = 1;
                }
            }
        }
        private void CheckGameStatus()
        {
            if(dealerScore == 0)
            {
                if(playerScore>blackjack)
                {
                    EnableHitAndStandButtons(false);
                    startButton.IsEnabled = true;
                    gameResultTextBlock.Text = "YOU LOST";
                    pool.Amount = 0;
                    UpdateUI();
                    CheckEndGameBankroll();
                }
            }
            else if (dealerScore <= 21 && dealerScore > playerScore)
            {
                EnableHitAndStandButtons(false);
                startButton.IsEnabled = true;
                gameResultTextBlock.Text = "YOU LOST";
                pool.Amount = 0;
                UpdateUI();
            }
            else if (dealerScore > blackjack || dealerScore < playerScore)
            {
                double wonAmount = pool.Amount;
                if (playerScore == blackjack)
                {
                    gameResultTextBlock.Text = "BLACKJACK!";
                    bankroll.AddToBalance(wonAmount * 2.5);
                }
                else
                {
                    gameResultTextBlock.Text = "YOU WIN!";
                    bankroll.AddToBalance(wonAmount * 2);
                }
                pool.Amount = 0;
                EnableHitAndStandButtons(false);
                startButton.IsEnabled = true;
                UpdateUI();
            }
            else if (playerScore == dealerScore)
            {
                EnableHitAndStandButtons(false);
                startButton.IsEnabled = true;
                gameResultTextBlock.Text = "TIE";
                UpdateUI();
            }
        }
        private void CheckIfBankrollIsSufficient(double amount)
        {
            if(bankroll.Balance - amount < 0)
            {
                MessageBox.Show("You have insufficient credits in your bankroll!", "Insufficient bankroll", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                bankroll.RemoveFromBalance(amount);
                pool.AddToBalance(amount);
                UpdateUI();
            }
        }
    }
}