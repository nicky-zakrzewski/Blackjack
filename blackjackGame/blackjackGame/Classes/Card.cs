using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjackGame.Classes
{
    class Card
    {
        private string suit;
        private int value;
        private string name;
        private List<String> usedCards = new List<string>();

        public Card()
        {

        }

        public string Suit
        {
            get { return suit; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public string Name 
        { 
            get { return name; } 
        }

        public void CreateCard()
        {
            Random random = new Random();
            int cardSuit = random.Next(1, 5);
            switch (cardSuit)
            {
                case 1:
                    suit = "Hearts";
                    break;
                case 2:
                    suit = "Spades";
                    break;
                case 3:
                    suit = "Clubs";
                    break;
                case 4:
                    suit = "Diamonds";
                    break;
            }

            int cardValue = random.Next(1, 14);
            switch (cardValue)
            {
                case 1:
                    value = 11;
                    name = "Ace";
                    break;
                case 11:
                    value = 10;
                    name = "Jack";
                    break;
                case 12:
                    value = 10;
                    name = "Queen";
                    break;
                case 13:
                    value = 10;
                    name = "King";
                    break;
                default:
                    value = cardValue;
                    name = Convert.ToString(cardValue);
                    break;
            }
            if(CheckAvailability($"{Name} of {Suit}") == false)
            {
                CreateCard();
            }
        }
        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }

        public void ClearUsedCards()
        {
            usedCards.Clear();
        }

        private bool CheckAvailability(string card)
        {
            if (usedCards.Contains(card))
            {
                return false;
            }
            else
            {
                usedCards.Add(card);
                return true;
            }
        }
    }
}
