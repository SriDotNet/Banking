using System;
using System.Collections.Generic;

namespace BankEntities
{
   

    public class Account{
      private string _accountId;
      private string _ownerName;
      private double _balance;
      private PrimaryAccountType _primaryAccType;
      private SubAccountType _subAccType;
      
      
      public String AccountId{
          get=>_accountId;
          set=>_accountId=value;
      }

      public String OwnerName{
          get=>_ownerName;
          set=>_ownerName=value;
      }
      public double Balance{
          get =>_balance;
          set=>_balance=value;
      }
      public PrimaryAccountType PrimaryAccType{
          get=>_primaryAccType;
          set=>_primaryAccType=value;
      }
      public SubAccountType SubAccType{
          get=>_subAccType;
          set=>_subAccType=value;
      }
      public Account(string accountId,string ownerName,double balance,PrimaryAccountType primAccType,SubAccountType subAccType)
      {
          AccountId=accountId;
          OwnerName=ownerName;
          Balance=balance;
          PrimaryAccType=primAccType;
          SubAccType=subAccType;
      }
      public Account(string accountId,string ownerName,double balance,PrimaryAccountType primAccType)
      {
          AccountId=accountId;
          OwnerName=ownerName;
          Balance=balance;
          PrimaryAccType=primAccType;
         
      }
      /*Method to Deposit */
       public TransctionStatus DepositAmount(Transaction taction){
            //keeps track of Transaction status and return to the calling method
           TransctionStatus ts=new TransctionStatus();
           if(taction.Amount>0){
            Balance+=taction.Amount;
            ts.Info=$"Amount successfully Deposited  to the  Account {AccountId} and the current balance is : {Balance}";
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
       public TransctionStatus WithdrawlAmount(Transaction taction){
           //keeps track of Transaction status and return to the calling method
            TransctionStatus ts=new TransctionStatus();
            if(haveEnoughFunds(Balance,taction.Amount)){

               //Verify the Account Type id Individual Checking Account
             if(PrimaryAccType==PrimaryAccountType.Investment && SubAccType==SubAccountType.Individual){

               if(taction.Amount<=500){
                 Balance-=taction.Amount;
                 ts.Info=$"Amount successfully Withdrawled from Account {AccountId} and the current balance is : {Balance}";
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
           
                Balance-=taction.Amount;
                ts.Info=$"Amount successfully Withdrawed from Account {AccountId} and the current balance is : {Balance}";
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
       public TransctionStatus Transfer(Transaction taction,Account destAcc){

            //keeps track of Transaction status and return to the calling method
            TransctionStatus ts=new TransctionStatus();

            if(haveEnoughFunds(Balance,taction.Amount)){
            
            if(destAcc==null){
                ts.Info=$"Transaction failed becuase Destination Account with AccountId{AccountId} not found.";
                ts.Success=false;
                return ts;
            }else{
            Balance-=taction.Amount;
            destAcc.Balance+=taction.Amount;
            ts.Info=$"Amount {taction.Amount} successfully transfered from Account {AccountId} to Account : {destAcc.AccountId} ";
            ts.Success=true;

            return ts;
            }
            }
            else
            {
            ts.Info=$"Transaction failed becuase of insufficient Funda in the Account {AccountId}";
            ts.Success=false;

            return ts;
            }

           
       }
    
      private bool haveEnoughFunds(double accBalance,double amt){
           if(accBalance>amt) return true; else return false;

       }

      
}
}