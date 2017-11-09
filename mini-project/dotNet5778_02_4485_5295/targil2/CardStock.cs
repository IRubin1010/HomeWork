using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class CardStock :IEnumerable
    {
        Random rand = new Random();
        private List<Card> Cards = new List<Card>();
        public List<Card> Cerds
        {
            get { return this.Cards; }
        }
        public CardStock()
        {
            for (int i = 2; i <= 14; i++)
            {
                Cards.Add(new Card(E_Color.blak, i));
                Cards.Add(new Card(E_Color.red, i));
            }
        }
        public void Mix()
        {
            for (int i = 0; i <= 25; i++)
            {
                int RandA = rand.Next(0, 26);
                int RandB = rand.Next(0, 26);
                swap(RandA, RandB);
            }
        }
        private void swap(int RandA, int RandB)
        {
            Card temp = Cards[RandA];
            Cards[RandA] = Cards[RandB];
            Cards[RandB] = temp;
        }
        public override string ToString()
        {
            string list = Cards[0].ToString();
            for (int i = 1; i < 26; i++)
            {
                list += ", " + Cards[i].ToString();
            }
            return list;
        }
        public void distribute(params Player[] players) // need to implement
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
        public void SortCards()
        {
            Cards.Sort();
        }

        public IEnumerator GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        public void addCard(Card card)
        {
            Cards.Add(card);
        }

        public void reremoveCard(Card card)
        {
            Cards.Remove(card);
        }
    }
}
