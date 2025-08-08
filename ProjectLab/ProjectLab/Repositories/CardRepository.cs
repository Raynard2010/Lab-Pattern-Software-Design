using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Repositories
{
    public class CardRepository
    {
        private static DatabaseEntities1 db = new DatabaseEntities1();
        public static void AddCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
        }
        public static List<Card> getAllCards()
        {
            return db.Cards.ToList();
        }

        public static void deleteCard(string name)
        {
            Card deletedCard = getCardByName(name);
            db.Cards.Remove(deletedCard);
            db.SaveChanges();
        }

        public static Card getCardByName(string name)
        {
            return db.Cards.FirstOrDefault(u => u.CardName == name);
        }
        public static Card getCardById(int id)
        {
            return db.Cards.FirstOrDefault(c => c.CardId == id);
        }

        public static void EditCard(string originalName, string newName, double newPrice, string newDescription, string newType, string newFoil)
        {
            Card editedCard = getCardByName(originalName);
            Card card = db.Cards.Find(editedCard.CardId);
            card.CardName = newName;
            card.CardPrice = newPrice;
            card.CardDesc = newDescription;
            card.CardType = newType;

            if (string.Equals(newFoil, "1"))
            {
                card.isFoil = new byte[] { 1 };
            }
            else
            {
                card.isFoil = new byte[] { 0 };
            }
            db.SaveChanges();

        }

       

    }
}