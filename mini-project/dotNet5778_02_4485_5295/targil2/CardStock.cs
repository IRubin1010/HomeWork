using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    // class for card stock, inherits from IEnumerable interfase
    class CardStock :IEnumerable
    {
        Random rand = new Random();
        // list for the cards
        private List<Card> Cards = new List<Card>();
        // cards property
        public List<Card> Cerds
        {
            get { return this.Cards; }
        }
        // constractor
        public CardStock()
        {
            // put 26 cards, 2 for each iteration 1 red and 1 black
            for (int i = 2; i <= 14; i++)
            {
                Cards.Add(new Card(E_Color.black, i));
                Cards.Add(new Card(E_Color.red, i));
            }
        }
        // mix the cards on the stock
        public void Mix()
        {
            // go over the list take 2 random cards and swap beteen them
            for (int i = 0; i <= 25; i++)
            {
                int RandA = rand.Next(0, 26);
                int RandB = rand.Next(0, 26);
                swap(RandA, RandB);
            }
        }
        // swap beteen 2 cards
        private void swap(int RandA, int RandB)
        {
            Card temp = Cards[RandA];
            Cards[RandA] = Cards[RandB];
            Cards[RandB] = temp;
        }
        // override ToString
        public override string ToString()
        {
            // go over the list and get all their names
            string list = Cards[0].ToString() + '\n';
            for (int i = 1; i < 26; i++)
            {
                list += Cards[i].ToString() + '\n';
            }
            return list;
        }
        // distribute the cards beteen the players
        public void distribute(params Player[] players) 
        {
            int cardsPerPlayer = Cards.Count / players.Length;
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = i*cardsPerPlayer; j < (i+1) * cardsPerPlayer; j++)
                {
                    players[i].AddCard(Cards[j]);
                }
            }
        }
        // override index operator
        public Card this[string index]
        {
            get
            {
                foreach(Card card in Cards)
                {
                    if (card.CardName == index) 
                    {
                        return card;
                    }
                }
                return null;
            }
        }
        // sort the card list
        public void SortCards()
        {
            Cards.Sort();
        }
        // implement IEnumerator
        public IEnumerator GetEnumerator()
        {
            return Cards.GetEnumerator();
        }
        // add card to the list
        public void addCard(Card card)
        {
            Cards.Add(card);
        }
        // remove card from the list
        public void reremoveCard(Card card)
        {
            Cards.Remove(card);
        }
    }
}
