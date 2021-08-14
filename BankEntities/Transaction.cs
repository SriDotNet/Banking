using System;
using System.Collections.Generic;
using System.Linq;

namespace BankEntities
{   public class Transaction{

        private TransactionType _tType;
        private double _amount;
        private string _toAccountId=null;
        public TransactionType TType
        {
            get =>_tType;
            set=>_tType=value;
        }
        public double Amount
        {
            get =>_amount;
            set=>_amount=value;
        }
        public string ToAccountId
        {
            get =>_toAccountId;
            set=>_toAccountId=value;
        }
        public Transaction(TransactionType tType,double amount,string toAccountId)
        {
            TType=tType;
            Amount=amount;
            ToAccountId=toAccountId;
        }
         public Transaction(TransactionType tType,double amount)
        {
            TType=tType;
            Amount=amount;
         
        }
    }
   
    

     
    
}
