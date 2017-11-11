using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class Player
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Queue<Card> PlayerCards = new Queue<Card>();
        public int NumberOfCards
        {
            get
            {
                return PlayerCards.Count;
            }
        }
        public void AddCard(params Card[] cards)
        {
            foreach (Card card in cards)
            {
                PlayerCards.Enqueue(card);
            }
        }
        public override string ToString()
        {
            string playerString = "name: " + name + ", number of cards: " + PlayerCards.Count + ", card names: ";
            foreach (Card card in PlayerCards)
            {
                playerString += card.ToString();
            }
            return playerString;
        }
        public bool lose()
        {
            return (PlayerCards.Count == 0);
        }

        public Card PopCard()
        {
            if (PlayerCards.Count == 0) return null;
            Card card = PlayerCards.Dequeue();
            return card;
        }
    }
}
