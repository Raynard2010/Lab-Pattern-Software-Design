using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Repositories
{
    public class TransactionRepository
    {
        private static DatabaseEntities1 db = new DatabaseEntities1();

        public static List<TransactionHeader> GetAllTransactions()
        {
            return db.TransactionHeaders.Include("User").ToList();
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            return db.TransactionHeaders.Include("User")
                .Where(th => th.User.UserID == userId).ToList();
        }

        public static TransactionHeader GetTransactionById(int transactionId)
        {
            return db.TransactionHeaders.Include("User")
                .FirstOrDefault(th => th.TransactionID == transactionId);
        }

        public static int CreateTransaction(TransactionHeader transaction)
        {
            try
            {
                db.TransactionHeaders.Add(transaction);
                db.SaveChanges();
                return transaction.TransactionID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static bool UpdateTransaction(TransactionHeader transaction)
        {
            try
            {
                var existingTransaction = db.TransactionHeaders.Find(transaction.TransactionID);
                if (existingTransaction != null)
                {
                    existingTransaction.Status = transaction.Status;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateTransactionStatus(int transactionId, string newStatus)
        {
            try
            {
                var transaction = db.TransactionHeaders.Find(transactionId);
                if (transaction != null)
                {
                    transaction.Status = newStatus;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public static List<TransactionDetail> GetTransactionDetails(int transactionId)
        {
            return db.TransactionDetails
                     .Include("Card") 
                     .Where(td => td.TransactionID == transactionId)
                     .ToList();
        }
    }
}
