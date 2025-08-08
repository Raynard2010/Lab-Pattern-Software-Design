using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ProjectLab.Handlers;
using ProjectLab.Models;

namespace ProjectLab.Controllers
{
    public class CardController
    {
        public static Response<Card> AddCard(string name, string price, string description, string type, string foil)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(foil))
            {
                return new Response<Card> { Success = false, Message = "All fields required" };
            }

            if (name.Length < 5 || name.Length > 50)
            {
                return new Response<Card> { Success = false, Message = "Name must be between 5 and 50 characters" };
            }

            if (!IsValidName(name))
            {
                return new Response<Card> { Success = false, Message = "Name must be alphabet with space only" };
            }

            if (!IsValidPrice(price))
            {
                return new Response<Card> { Success = false, Message = "Price must be number" };
            }

            if(double.Parse(price) < 10000)
            {
                return new Response<Card> { Success = false, Message = "Price must be greater or equal than 10000" };
            }

            return CardHandler.AddCard(name, double.Parse(price), description, type, foil);
        }

        public static Response<Card> EditCard(string oldName, string name, string price, string description, string type, string foil)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(foil))
            {
                return new Response<Card> { Success = false, Message = "All fields required" };
            }

            if (name.Length < 5 || name.Length > 50)
            {
                return new Response<Card> { Success = false, Message = "Name must be between 5 and 50 characters" };
            }

            if (!IsValidName(name))
            {
                return new Response<Card> { Success = false, Message = "Name must be alphabet with space only" };
            }

            if (!IsValidPrice(price))
            {
                return new Response<Card> { Success = false, Message = "Price must be number" };
            }

            if (double.Parse(price) < 10000)
            {
                return new Response<Card> { Success = false, Message = "Price must be greater or equal than 10000" };
            }
            return CardHandler.EditCard(oldName, name, double.Parse(price), description, type, foil);
        }

        private static bool IsValidName(string name)
        {
            bool isLetterOrWhiteSpace = true;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    isLetterOrWhiteSpace = false;
                }
            }

            return isLetterOrWhiteSpace;

        }

        private static bool IsValidPrice(string price) {
            foreach (char c in price)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

    }
}