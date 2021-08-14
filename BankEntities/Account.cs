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
      
}
}