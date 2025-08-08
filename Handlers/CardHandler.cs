using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Factories;
using ProjectLab.Models;
using ProjectLab.Repositories;

namespace ProjectLab.Handlers
{
    public class CardHandler
    {
        public static Response<Card> AddCard(string name, double price, string description, string type, string foil)
        {
            Card card = CardFactory.Create(name, price, description, type, foil);
            CardRepository.AddCard(card);
            return new Response<Card> { Success = true, Message = " ", Payload = card };
        }

        public static List<Card> getAllCards()
        {
            return CardRepository.getAllCards();
        }
        public static Card GetCardById(int cardId)
        {
            return CardRepository.getCardById(cardId);
        }


        public static void deleteCard(string name)
        {
            CardRepository.deleteCard(name);
        }

        public static Response<Card> EditCard(string oldName, string name, double price, string description, string type, string foil)
        {
            CardRepository.EditCard(oldName, name, price, description, type, foil);
            return new Response<Card> { Success = true, Message = " " };
        }
    }
}