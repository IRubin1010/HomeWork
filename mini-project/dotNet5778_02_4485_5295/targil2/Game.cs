using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class Game
    {
        private CardStock stock;
        private Player pl1 = new Player();
        private Player pl2 = new Player();
        // begin game - mix the stock and distribute the cards
        public void BeginGame(string fName, string sName)
        {
            pl1.Name = fName;
            pl2.Name = sName;
            stock = new CardStock();
            stock.Mix();
            stock.distribute(pl1, pl2);
            Console.WriteLine(pl1.ToString());
            Console.WriteLine(pl2.ToString());
        }
        // retrun the winer - the second player have no cards
        public string Winer()
        {
            if (pl1.lose())
            {
                return pl2.Name;
            }
            else if (pl2.lose())
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
            if (Winer() == "no one win yet")
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
            string str = pl1.Name + " number of cards: " + pl1.NumberOfCards + '\n' + pl2.Name + " number of cards: " + pl2.NumberOfCards;
            return str;
        }
        // make a move on the game
        // we use a list instead of array becouse if in the second move
        // the cards are stil the same, we want to to make a third move and etc.
        // and for each move we need to add the cards to the array, and this is much easier
        // to this with a list.
        public string Move()
        {
            bool isMove = false;
            Card firstCard;
            Card SecondCard;
            List<Card> cards = new List<Card>();
            string moveCards = "";
            // iterate the move as long as the cards are the same
            do
            {
                if (FinishGame()) return "no body has cards"; // if finish the game
                firstCard = pl1.PopCard();
                SecondCard = pl2.PopCard();
                // add to the list
                moveCards += pl1.Name + ": " + firstCard.ToString() + "  " + pl2.Name + ": " + SecondCard.ToString() + '\n';
                // check whose ticket is bigger
                if (firstCard.Number > SecondCard.Number)
                {
                    cards.Add(firstCard);
                    cards.Add(SecondCard);
                    pl1.AddCard(cards.ToArray());
                    isMove = true;
                }
                else if (firstCard.Number < SecondCard.Number)
                {
                    cards.Add(SecondCard);
                    cards.Add(firstCard);
                    pl2.AddCard(cards.ToArray());
                    isMove = true;
                }
                else
                {
                    cards.Add(firstCard);
                    cards.Add(SecondCard);
                }
                // if the cerds the same make another move
            } while (!isMove);
            return moveCards;
        }
    }
}
