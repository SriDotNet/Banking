﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BankEntities
{
    #region ConfigurationTypes
    public enum PrimaryAccountType{
        /*Primary Account Types between 1 to 1000 */
        Checking=1,
        Investment= 2
    }
    public enum SubAccountType{
        /*Secondary Account Type classification between from 1000 to 5000 */
        Individual=1000,
        Corporate= 1001
    }
       public enum TransactionType{
        /*Transaction Type starts from 5000 */
        Deposit=5000,
        Transfer= 5001,
        Withdrawl=5002
    }

    #endregion

    /* A structure to hold a Transaction Status and Info about Transaction*/
    public struct TransctionStatus
    {
        public bool _success;
        public string _info;
        public bool Success {

           get =>_success;
           set=>_success=value;

       }
       public string Info {

           get =>_info;
           set=>_info=value;

       }
    }


    public class Bank
    {
       private string _name;
       private List<Account> _accounts=new List<Account>();
       public string Name {

           get =>_name;
           set=>_name=value;

       }
       public List<Account> Accounts{
           get=>_accounts;
           set=>_accounts=value;
       }
       public Bank(string name)
       {
           Name=name;
       }

       /*Method to create account
       Unique AccountId should be autogenerated by system. For this version user will provide accountId */
       public void CreateAccount(string accountId,string ownerName,double balance, PrimaryAccountType primaryType,SubAccountType subType){
        if(primaryType==PrimaryAccountType.Investment){
        Account acc=new Account(accountId,ownerName,balance,primaryType,subType);
        Accounts.Add(acc);
        }
        else{
            Account acc=new Account(accountId,ownerName,balance,primaryType);
            Accounts.Add(acc);
        }
        
       }

       public Account GetAccountbyId(string accountId){
         Account acc=Accounts.FirstOrDefault(o => o.AccountId == accountId);
         return acc;
       }

       /* Method to Verify the Transaction Type,Triggers the respective Transaction and returns the Transcation Status .*/
       public TransctionStatus ProcessTransaction(string accountId,Transaction transaction){
         TransctionStatus ts=new TransctionStatus();
         Account acc=GetAccountbyId(accountId);
         switch (transaction.TType)
         {
             case TransactionType.Deposit:
             return DepositAmount(acc,transaction);
        
             case TransactionType.Withdrawl:
              return WithdrawlAmount(acc,transaction);
             case TransactionType.Transfer:
              return Transfer(acc,transaction);
             default:
             ts.Info="Invalid Transaction Type.";
             ts.Success=false;
             return ts;
         }
        
         }
         /*Method to Deposit */
       public TransctionStatus DepositAmount(Account account,Transaction taction){
            //keeps track of Transaction status and return to the calling method
           TransctionStatus ts=new TransctionStatus();
           if(taction.Amount>0){
            account.Balance+=taction.Amount;
            ts.Info=$"Amount successfully Deposited  to the  Account {account.AccountId} and the current balance is : {account.Balance}";
            ts.Success=true;
            return ts;
       }else
       {
            ts.Info=$"Invalid Amount.";
            
            ts.Success=false;
            return ts;
       }
       }
       /*Method to withdraw*/
       public TransctionStatus WithdrawlAmount(Account account,Transaction taction){
           //keeps track of Transaction status and return to the calling method
            TransctionStatus ts=new TransctionStatus();
            if(haveEnoughFunds(account.Balance,taction.Amount)){

               //Verify the Account Type id Individual Checking Account
             if(account.PrimaryAccType==PrimaryAccountType.Investment && account.SubAccType==SubAccountType.Individual){

               if(taction.Amount<=500){
                 account.Balance-=taction.Amount;
                 ts.Info=$"Amount successfully Withdrawled from Account {account.AccountId} and the current balance is : {account.Balance}";
                 ts.Success=true;
                 return ts;
               }else{
                
                 ts.Info="The max Withdrawl amount is 500 only.";
                 ts.Success=false;

                 return ts;
                }
              }//If the Account is not Individual Account
              else
              {
           
                account.Balance-=taction.Amount;
                ts.Info=$"Amount successfully Withdrawed from Account {account.AccountId} and the current balance is : {account.Balance}";
                ts.Success=true;
                return ts;
             
             }
            }else{
            ts.Info="Insufficient Funds. ";
            ts.Success=false;
            return ts;
            }
           
           
           
        }
       
       /* Method to Transfer */
       public TransctionStatus Transfer(Account account,Transaction taction){

            //keeps track of Transaction status and return to the calling method
            TransctionStatus ts=new TransctionStatus();

            if(haveEnoughFunds(account.Balance,taction.Amount)){
            Account destAcc=GetAccountbyId(taction.ToAccountId);
            if(destAcc==null){
                ts.Info=$"Transaction failed becuase Destination Account with AccountId{account.AccountId} not found.";
                ts.Success=false;
                return ts;
            }else{
            account.Balance-=taction.Amount;
            destAcc.Balance+=taction.Amount;
            ts.Info=$"Amount {taction.Amount} successfully transfered from Account {account.AccountId} to Account : {destAcc.AccountId} ";
            ts.Success=true;

            return ts;
            }
            }
            else
            {
            ts.Info=$"Transaction failed becuase of insufficient Funda in the Account {account.AccountId}";
            ts.Success=false;

            return ts;
            }

           
       }
    
      private bool haveEnoughFunds(double accBalance,double amt){
           if(accBalance>amt) return true; else return false;

       }

    
    
}
}