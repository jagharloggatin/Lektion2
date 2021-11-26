using System;
using Xunit;
using Lektion2;

namespace Lektion2.Tests
{
    public class UnitTest1 
    {
        public object Wallet { get; private set; }


        [Fact]
        public void Test_Transfer()
        {
            var kronor = new Kronor(11, 11);
            var account1 = new Account(kronor);
            var account2 = new Account();

            Account.Transfer(account1, account2, kronor);

            Assert.True(account1.amount.IsZero());
            Assert.True(account2.amount.IsPositive());
        }

        //testing account deposit
        [Fact]
        public void Test_Deposit()
        {
            var kronor = new Kronor(11,11);
            var account = new Account();

            account.Deposit(kronor);

            Assert.True(account.amount.IsPositive());
        }

        //testing account withdraw
        [Fact]
        public void Test_Withdraw()
        {
            var kronor = new Kronor(11, 11);
            var account = new Account();

            account.Deposit(kronor);
            account.Withdraw(kronor);

            Assert.True(account.amount.IsZero());
        }

        //Testing iszero kronor
        [Fact]
        public void Test_EmptyKronor()
        {
            var kronor = new Kronor();

            Assert.True(kronor.IsZero());
            Assert.False(kronor.isNegative());
            Assert.False(kronor.IsPositive());
        }

        //Testing if kronor is negative
        [Fact]
        public void Test_IsNegativeTrue()
        {
            var kronor = new Kronor(-10, -5);

            Assert.True(kronor.isNegative());

            /* Assert.False(kronor.isZero());
             Assert.True(kronor.isNegative());
             Assert.False(kronor.IsPositive()); */
        }

        //Testing if kronor is positive
        [Fact]
        public void Test_IsPositiveTrue()
        {
            var kronor = new Kronor(10, 5);

            Assert.True(kronor.IsPositive());
        }

        //Testing remove kronor
        [Fact]
        public void Test_Remove() 
        {
            var kronor = new Kronor(11, 11);
            var wallet = new Wallet(kronor);

            wallet.Remove(kronor);

            Assert.True(wallet.amount.IsZero());
        }

        //test removing all kronor
        [Fact]
        public void Test_RemoveAll() 
        {
            var kronor = new Kronor(11, 11);
            var kronor2 = new Kronor(20, 30);
            var wallet = new Wallet();

            wallet.Add(kronor);
            wallet.Add(kronor2);
            wallet.RemoveAll();

            Assert.True(kronor.IsZero());
        }

        [Fact]
        public void Test_AddToWallet() 
        {
            var kronor = new Kronor(11, 11);
            var wallet = new Wallet();

            wallet.Add(kronor);

            Assert.True(wallet.amount.IsPositive());
            Assert.False(wallet.amount.isNegative());
            Assert.False(wallet.amount.IsZero());
        }

        //Testing add kronor
        [Fact]
        public void Test_KronorAdd()
        {
            var kronorResult = new Kronor(10, 5);
            var kronorNum1 = new Kronor(5, 0);
            var kronorNum2 = new Kronor(5, 0);

            Assert.Equal(kronorResult.KronorPart(), kronorNum1.Add(kronorNum2).KronorPart());
        }

        //Testing kronor subtract
        [Fact]
        public void Test_KronorSubtract()
        {
            var kronorResult = new Kronor(0, 0);
            var kronorNum1 = new Kronor(5, 0);
            var kronorNum2 = new Kronor(5, 0);

            Assert.Equal(kronorResult.KronorPart(), kronorNum1.Subtract(kronorNum2).KronorPart());
        }

        [Fact]
        public void Test_ÖrenPart()
        {
            int amount = 100;
            var kronor = new Kronor(1000, amount);

            Assert.Equal(kronor.ÖrenPart(), amount);
        }

        [Fact]
        public void Test_KronorPart()
        {
            int amount = 10;
            var kronor = new Kronor(amount, 0);

            Assert.Equal(kronor.KronorPart(), amount);
        }
    }
}

//kronor.KronorPart(); //ska returnera kronor part
//kronor.ÖrenPart(); //ska returnera ören

// Action act = () => wallet.Remove(kronor);

//Assert.Throws<ArgumentException>(act);

/* [Fact]
public void Add_InputIsEqual()
{
    var kronor = new Kronor(11, 11);
    var wallet = new Wallet();
    //Action act = () => wallet.Add(kronor);
    wallet.Add(kronor);

    //Assert.Throws<ArgumentException>(act);
    Assert.Equal(11, 11);
    //Assert.NotNull(act); */
