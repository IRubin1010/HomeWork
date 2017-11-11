using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class Game
    {
        private CardStock stock ;
        private Player pl1 = new Player();
        private Player pl2 = new Player();
        // begin game - mix the stock and distribute the cards
        public void BeginGame(string fName, string sName)
        {
            stock = new CardStock();
            stock.Mix();
            stock.distribute(pl1, pl2);
            pl1.Name = fName;
            pl2.Name = sName;
        }
        // retrun the winer - the second player have no cards
        public string Winer()
        {
            if(pl1.lose())
            {
                return pl2.Name;
            }
            else if(pl2.lose())
            {
                return pl1.Name;
            }
            // there is no winer - both have cards
            else
            {
                return "no one win yet";
            }
        }
        // check if finish the game - there is winer
        public bool FinishGame()
        {
            if(Winer() == "no one win yet")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // override ToString
        public override string ToString()
        {
            string str = pl1.Name + " number of cards: " + pl1.NumberOfCards + ",  " + pl2.Name + " number of cards: " + pl2.NumberOfCards;
            return str;
        }
        // make a move on the game
        public void Move()
        {
            if (FinishGame()) return; // if finish the game
            Card firstCard = pl1.PopCard();
            Card SecondCard = pl2.PopCard();
            // check whose ticket is bigger
            if (firstCard.Number > SecondCard.Number) 
            {
                pl1.AddCard(firstCard, SecondCard);
            }
            else if(firstCard.Number < SecondCard.Number)
            {
                pl2.AddCard(firstCard, SecondCard);
            }
            // both tickets the same
            else
            {
                // get 2 more cards end check beteen them
                // the biggest take all 4 cards
                Card[] cards = new Card[4];
                cards[0] = firstCard;
                cards[1] = SecondCard;
                cards[2] = pl1.PopCard();
                cards[3] = pl2.PopCard();
                if(cards[2].Number > cards[3].Number)
                {
                    pl1.AddCard(cards);
                }
                else
                {
                    pl2.AddCard(cards);
                }
            }
        }
    }
}
