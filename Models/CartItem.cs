using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLab.Models
{
    public class CartItem
    {
        public Card Card { get; set; }
        public int Quantity { get; set; }

        public int CardId
        {
            get { return Card?.CardId ?? 0; }
        }
    }
}