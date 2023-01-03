using Shouldly;

namespace KasboekEngineBackend.UnitTests
{
    public class AccountUnitTest
    {
        [Fact]
        public void Account_ReceivesNameUserAndInitialBalance_CreatesNewAccount()
        {
            //Arrange, Act
            Account account = new("Tim", 1000m);

            //Assert
            account.Name.ShouldBe("Tim");
            account.InitialBalance.ShouldBe(1000m);
        }

        [Fact]
        public void RemoveTransaction_ReceivesTheTransactionToBeRemoved_RemovesTransactionFromList()
        {
            //Arrange
            Account account = new("Tim", 1000m);

            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2021, 10, 4), "Test inkomen 1", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Test inkomen 2", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 1, 31), "Test inkomen 3", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2019, 5, 31), "Test uitgaven 1", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2020, 12, 31), "Test uitgaven 2", 100m));

            //Act
            //account.RemoveTransaction();

            //Assert
            //account.Transactions.Capacity
        }
    }
}
