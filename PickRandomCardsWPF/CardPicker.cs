using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickRandomCardsWPF
{
    internal class CardPicker
    {
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = NewUniqueCard(RandomValue() + " " + RandomSuit(), pickedCards);
            }

            return pickedCards;
        }

        static Random Random = new Random();

        static string RandomValue()
        {
            int rand = Random.Next(0, 13);
            string[] cardValues = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                                   "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            return cardValues[rand];
        }
        static string RandomSuit()
        {
            int rand = Random.Next(0, 4);
            string[] cardSuits = { "of Spades", "of Clubs", "of Hearts", "of Diamonds" };
            return cardSuits[rand];
        }

        static string NewUniqueCard(string card, string[] cards)
        {
            if (cards.Contains(card))
            {
                return NewUniqueCard(RandomValue() + " " + RandomSuit(), cards);
            }
            else
            {
                return card;
            }
        }
    }
}
