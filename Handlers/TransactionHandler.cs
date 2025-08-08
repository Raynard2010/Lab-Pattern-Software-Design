using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;
using ProjectLab.Repositories;

namespace ProjectLab.Handlers
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionRepository.GetAllTransactions();
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            return TransactionRepository.GetTransactionsByUserId(userId);
        }

        public static TransactionHeader GetTransactionById(string transactionId)
        {
            if (int.TryParse(transactionId, out int id))
            {
                return TransactionRepository.GetTransactionById(id);
            }
            else
            {
                return null;
            }
        }
        public static List<TransactionDetail> GetTransactionDetails(int transactionId)
        {
            return TransactionRepository.GetTransactionDetails(transactionId);
        }

        public static List<Card> GetAllCards()
        {
            return CardRepository.getAllCards();
        }



    }
}