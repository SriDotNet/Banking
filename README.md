
Task:

Write an object-oriented program, preferably using C#, adhering to the simple requirements listed below. This program should require no input to run and 
should not have a user interface. To demonstrate the functionality of your application, please write test classes that invoke a deposit, 
a withdrawal, and a transfer. 

Requirement: This is a simple bank program. 
A bank has a name. 
A bank also has several accounts. 
An account has an owner and a balance. 
Account types include: Checking, Investment. 
There are two types of Investment accounts: Individual, Corporate. 
Individual accounts have a withdrawal limit of 500 dollars. 
Transactions are made on accounts. 
Transaction types include: Deposit, Withdraw, and Transfer 


Solution:

This solution consists of two Projects .

1.BankEntities is a ClassLibrary consists of basic Classes 
   Bank Class (Properties:BankName and Accounts
   Methods:CreateAccount,ProcessTransaction,GetAccountById)
   EnumerationTypes:PrimaryAccountType,SecondaryAccountType,TransactionType)
   Account Class :(Properties:AccountId,Owner,Balance,PrimaryAccountType,SecondaryAccountType 
   Methods: DepositAmount,WithdrawlAmount,TransferAmount)
   Transaction Class:(Properties:TransactionType,Amount,ToDestinationAccount)
   Three EnumerationTypes created to hold PrimaryAccountType,SecondaryAccountType,TransactionTypes.
   
   
2.BankTest Consists of unitTests written to validate the functionality for the BankEntites class Library.
 Consists of 15 TestMethods :
 
 CreateBank --> Verifies BankCreation with the Provided Name
 CreateCheckingAccount. --> Verifies Valid Checking Account Creation
 CreateInvestmentAccount --> Verifies Valid Investment Account Creation
 GetAccountbyId. --> Verifies the search of Account by AccountId
 ProcessValidDepositTransaction --> Verifies Valid Deposit
 ProcessInvalidDepositTransaction -->Verifies negative or 0 deosit balance
 ProcessValidCheckingWithdrawl --> Verifies valid amount withdrawl from checking account
 ProcessExceedBalanceWithdrawl --> Verifies not enough in the balance withdrawl case
 ProcessValidIndividualWithdrawl --> Verifies valid amount withdrawl from Investment ,Individual  account
 ProcessInValidIndividualWithdrawl --> Verifies Invalid amount withdrawl from Investment ,Individual  account(>500)
 ProcessValidCorporateInvestmentWithdrawl-->Verifies valid amount withdrawl from Investment ,Corporate  account(>500)
 ProcessInValidCorporateInvestmentWithdrawl-->Verifies not enough in the balance withdrawl case
 ProcessValidTransfer. -->Verifies valid amount transfer from source to destination accounts
 ProcessInValidTransferInsufficientBalance --> Verifies not enough balance to transfer case
 ProcessInValidTransferDestNotFound. --> Verifies the destination account not found.


Note:
UserInterface,Input Constraints and Unique Account Id Creation,Exception logging or handling are out of scope.

