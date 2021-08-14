using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankEntities;

namespace BankingTest
{
    [TestClass]
    public class BankTests
    {

            //setup Test Variables for Account Creations
            // bankName,accountId,owner,accountId,ownerName,balance,primaryType,subType
            string[] accountId={"100001","100002","100003","100004","100005"};
            string[] owner={"Samantha","Jack","Horace","Shelly","Thomas"};
            double[] balance={1000,2000,3000,4000,5000};
            PrimaryAccountType[] primAccType={PrimaryAccountType.Investment,PrimaryAccountType.Checking,PrimaryAccountType.Investment,PrimaryAccountType.Checking,PrimaryAccountType.Investment};
            string bankName="ABC Blobal Bank";
            SubAccountType subType1=SubAccountType.Individual;
            SubAccountType subType2=SubAccountType.Corporate; 
        private Bank InitializeBankTestData()
        {
           
            Bank bank=new Bank(bankName);
            for (int i=0;i<5;i++){
                if(i<3)
                bank.CreateAccount(accountId[i],owner[i],balance[i], primAccType[i],subType1);
                else
                bank.CreateAccount(accountId[i],owner[i],balance[i], primAccType[i],subType2);

            }
            return bank;
        }
        [TestMethod]
        public void CreateBank()
        {
            //setup Test Variable for Bank Name.
            var bankName="ABC Blobal Bank";
            Bank bank=new Bank(bankName);

            //performTest
            Assert.AreEqual(bank.Name,bankName);

        }
        [TestMethod]
        public void CreateCheckingAccount()
        {
            //setup Test Variable for Account Creation
            // bankName,accountId,owner,accountId,ownerName,balance,primaryType,subType
            var bankName="ABC Blobal Bank";
            var owner="Sri T";
            var balance=1000;
            var primAccType=PrimaryAccountType.Checking;
            var accountId="100001";
            var subType=SubAccountType.Individual;

            Bank bank=new Bank(bankName);
            bank.CreateAccount(accountId,owner,balance, primAccType,subType);
            int count=bank.Accounts.Count;

            //performTest
            Assert.AreEqual(1,count);
            Assert.AreEqual(owner,bank.Accounts[0].OwnerName);
            Assert.AreEqual(accountId,bank.Accounts[0].AccountId);
            Assert.AreEqual(balance,bank.Accounts[0].Balance);
            Assert.AreEqual(primAccType,bank.Accounts[0].PrimaryAccType);
            Assert.AreNotEqual(subType,bank.Accounts[0].SubAccType);

        
      

        }

         [TestMethod]
         public void CreateInvestmentAccount()
        {
            //setup Test Variable for Account Creation
            // bankName,accountId,owner,accountId,ownerName,balance,primaryType,subType
            var bankName="ABC Blobal Bank";
            var owner="Ram T";
            var balance=5000;
            var primAccType=PrimaryAccountType.Investment;
            var accountId="100002";
            var subType=SubAccountType.Individual;

            Bank bank=new Bank(bankName);
            bank.CreateAccount(accountId,owner,balance, primAccType,subType);
            int count=bank.Accounts.Count;

            //performTest
            Assert.AreEqual(1,count);
            Assert.AreEqual(owner,bank.Accounts[0].OwnerName);
            Assert.AreEqual(accountId,bank.Accounts[0].AccountId);
            Assert.AreEqual(balance,bank.Accounts[0].Balance);
            Assert.AreEqual(primAccType,bank.Accounts[0].PrimaryAccType);
            Assert.AreEqual(subType,bank.Accounts[0].SubAccType);

        }
        [TestMethod]
         public void GetAccountbyId()
        {
           
            Bank bank=InitializeBankTestData();
    
            
            int count=bank.Accounts.Count;

            //performTest
            Account testacc=bank.GetAccountbyId(accountId[1]);
            Assert.AreEqual(owner[1],testacc.OwnerName);
            Assert.AreEqual(accountId[1],testacc.AccountId);
            Assert.AreEqual(balance[1],testacc.Balance);
            Assert.AreEqual(primAccType[1],testacc.PrimaryAccType);
           
        }
        [TestMethod]
         public void ProcessValidDepositTransaction()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Deposit;
            double depositAmt=500;
            Transaction testTrans=new Transaction(trantype,depositAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[0]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[0],testTrans);
            
           

            //PerformTest
             Assert.IsTrue(statusInfo.Success);
             Assert.AreEqual(1500,testacc.Balance);
    
            
           
        }
        [TestMethod]
         public void ProcessInvalidDepositTransaction()
        {
           //Test against negative values or zero
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Deposit;
            double depositAmt=0;
            Transaction testTrans=new Transaction(trantype,depositAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[0]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[0],testTrans);
            
        

            //PerformTest
             Assert.IsFalse(statusInfo.Success);
             //Assert.AreEqual(1500,testacc.Balance);
    
            
           
        }
        /* Withdraw Test Cases */
         [TestMethod]
         public void ProcessValidCheckingWithdrawl()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Withdrawl;
            double withAmt=500;
            Transaction testTrans=new Transaction(trantype,withAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[1]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[1],testTrans);
            
           

            //PerformTest
             Assert.IsTrue(statusInfo.Success);
             Assert.AreEqual(1500,testacc.Balance);
           
    
            
           
        }

        [TestMethod]
         public void ProcessExceedBalanceWithdrawl()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Withdrawl;
            double withAmt=1000;
            Transaction testTrans=new Transaction(trantype,withAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[0]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[0],testTrans);
            
        

            //PerformTest
             Assert.IsFalse(statusInfo.Success);
             Assert.AreEqual(1000,testacc.Balance);
    
            
           
        }
        [TestMethod]
         public void ProcessValidIndividualWithdrawl()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Withdrawl;
            double withAmt=100;
            Transaction testTrans=new Transaction(trantype,withAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[0]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[0],testTrans);
            
           

            //PerformTest
             Assert.IsTrue(statusInfo.Success);
             Assert.AreEqual(900,testacc.Balance);
           
    
            
           
        }
        [TestMethod]
         public void ProcessInValidIndividualWithdrawl()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Withdrawl;
            double withAmt=600;
            Transaction testTrans=new Transaction(trantype,withAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[0]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[0],testTrans);
            
           

            //PerformTest
             Assert.IsFalse(statusInfo.Success);
             Assert.AreEqual(1000,testacc.Balance);           

            
           
        }
        [TestMethod]
         public void ProcessValidCorporateInvestmentWithdrawl()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Withdrawl;
            double withAmt=1000;
            Transaction testTrans=new Transaction(trantype,withAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[4]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[4],testTrans);
            
           

            //PerformTest
             Assert.IsTrue(statusInfo.Success);
             Assert.AreEqual(4000,testacc.Balance);
           
    
            
           
        }
        [TestMethod]
         public void ProcessInValidCorporateInvestmentWithdrawl()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Withdrawl;
            double withAmt=5000;
            Transaction testTrans=new Transaction(trantype,withAmt);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[4]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[4],testTrans);
            
           

            //PerformTest
             Assert.IsFalse(statusInfo.Success);
             Assert.AreEqual(5000,testacc.Balance);           

            
           
        }
        [TestMethod]
         public void ProcessValidTransfer()
        {
           //Transfer 1000 from Account[3] with balance 4000 to Account[4] with balance 5000 
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Transfer;
            double transferAmt=1000;
          
            Transaction testTrans=new Transaction(trantype,transferAmt,accountId[4]);

            Bank bank=InitializeBankTestData();
             
            Account srcAcc=bank.GetAccountbyId(accountId[3]);
            Account destAcc=bank.GetAccountbyId(accountId[4]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[3],testTrans);
            
           

            //PerformTest
             Assert.IsTrue(statusInfo.Success);
             Assert.AreEqual(3000,srcAcc.Balance);
             Assert.AreEqual(6000,destAcc.Balance);
           
    
            
           
        }
        [TestMethod]
         public void ProcessInValidTransferInsufficientBalance()
        {
            //Transfer 2000 from Account[0] with balance 1000 to Account[1] with balance 2000 
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Transfer;
            double transferAmt=2000;
              
            Transaction testTrans=new Transaction(trantype,transferAmt,accountId[1]);

            Bank bank=InitializeBankTestData();
             
            Account srcAcc=bank.GetAccountbyId(accountId[0]);
            Account destAcc=bank.GetAccountbyId(accountId[1]);


            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[0],testTrans);
            
           

            //PerformTest
             Assert.IsFalse(statusInfo.Success);
             Assert.AreEqual(1000,srcAcc.Balance);     
             Assert.AreEqual(2000,destAcc.Balance);        

            
           
        }
        [TestMethod]
         public void ProcessInValidTransferDestNotFound()
        {
           
           //Setup Transaction Test Data.
            TransactionType trantype=TransactionType.Transfer;
            double transferAmt=4000;
            string toaccountId="1000034";
            Transaction testTrans=new Transaction(trantype,transferAmt,toaccountId);

            Bank bank=InitializeBankTestData();
             
            Account testacc=bank.GetAccountbyId(accountId[4]);

            //Initiate Transaction
            TransctionStatus statusInfo= bank.ProcessTransaction(accountId[4],testTrans);
            
           

            //PerformTest
             Assert.IsFalse(statusInfo.Success);
             Assert.AreEqual(5000,testacc.Balance);           

            
           
        }
        

    }
}
