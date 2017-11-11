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
        private Queue<Card> PlayerCards = new Queue<Card>();
        // name property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // property to get player's number of ceards
        public int NumberOfCards
        {
            get
            {
                return PlayerCards.Count;
            }
        }
        // add cards to player queue
        public void AddCard(params Card[] cards)
        {
            foreach (Card card in cards)
            {
                PlayerCards.Enqueue(card);
            }
        }
        // override ToString
        public override string ToString()
        {
            string playerString = "name: " + name + ", number of cards: " + PlayerCards.Count + ", card names: ";
            foreach (Card card in PlayerCards)
            {
                playerString += card.ToString();
            }
            return playerString;
        }
        // retrun if a player lose - dom't have any cards
        public bool lose()
        {
            return (PlayerCards.Count == 0);
        }
        // take out player card 
        public Card PopCard()
        {
            if (PlayerCards.Count == 0) return null;
            Card card = PlayerCards.Dequeue();
            return card;
        }
    }
}
