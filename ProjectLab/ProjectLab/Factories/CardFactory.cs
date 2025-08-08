using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Factories
{
    public class CardFactory
    {
        public static Card Create(string name, double price, string description, string type, string foil)
        {
            Card card = new Card();

            card.CardName = name;
            card.CardPrice = price;
            card.CardDesc = description;
            card.CardType = type;

            if(string.Equals(foil, "1"))
            {
                card.isFoil = new byte[]{ 1 };
            }
            else
            {
                card.isFoil = new byte[] { 0 };

            }

            return card;

        }
    }
}