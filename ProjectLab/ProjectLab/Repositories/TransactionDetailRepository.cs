using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Repositories
{
    public class TransactionDetailRepository
    {
        private static DatabaseEntities1 db = new DatabaseEntities1();

        public static List<TransactionDetail> GetTransactionDetailsByTransactionId(int transactionId)
        {
            return db.TransactionDetails
                .Include("Card")
                .Where(td => td.TransactionID == transactionId)
                .ToList();
        }

        public static void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }
    }
}