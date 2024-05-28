using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFWebApi.Data;

namespace FTWebApiDB.Tests
{
    public class BankAccauntTests
    {
        [Fact]
        public void Deposit_GivenPositiveAmount_IncreaseBalance()
        {
            BankAccount account = new BankAccount();

            var initialBalance = account.Balance;

            account.Deposit(100);

            Assert.Equal(initialBalance + 100, account.Balance);
        }

        [Fact]
        public void Widthdraw_WhenSufficientFunds_DecreasesBalance()
        {
            BankAccount account = new BankAccount();
            account.Deposit(100);

            var initialBalance = account.Balance;

            account.Withdraw(50);

            Assert.Equal(initialBalance - 50, account.Balance);
        }

        [Fact]
        public void Widthdraw_WhenInufficientFunds_ThrowsException()
        {
            //Arrange
            BankAccount account = new BankAccount();
            account.Deposit(100);

            //Act&Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
        }
    }
}
