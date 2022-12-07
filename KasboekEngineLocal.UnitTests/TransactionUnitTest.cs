using Shouldly;

namespace KasboekEngineBackend.UnitTests
{
    public class TransactionUnitTest
    {
        [Fact]
        public void AddIncome_ReceivesNewDateTimeDescriptionAndAmountOfMoney_ReturnsIncomeListOfTypeTransaction()
        {
            //Arrange
            Account account = new("Tim", 1000m);

            //Act
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Hema salaris", 20m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Levi's salaris", 100m));

            //Assert
            account.Transactions[0].Amount.ShouldBe(20m);
            account.Transactions[1].Amount.ShouldBe(100m);
            account.Transactions[0].Description.ShouldBe("Hema salaris");

        }

        [Fact]
        public void AddExpense_ReceivesNewDateTimeDescriptionAndAmountOfMoney_ReturnsExpensesListOfTypeTransaction()
        {
            //Arrange
            Account account = new("Tim", 1000m);

            //Act
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "McDonalds", 20m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "Broek", 100m));

            //Assert
            account.Transactions[0].Amount.ShouldBe(20m);
            account.Transactions[1].Amount.ShouldBe(100m);

        }

        [Fact]
        public void SumIncome_ReceivesListOfAllIncomeTransactions_ReturnsSumOfAllIncome()
        {
            //Arrange
            Account account = new("Tim", 1000m);

            //Act
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Hema salaris", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Terugboeking Levi's", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Verjaardag", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Only Fans", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "Vinted", 100m));

            var resultTotalIncome = account.SumAllIncomes();

            //Assert
            resultTotalIncome.ShouldBe(500m);
        }

        [Fact]
        public void SumExpense_ReceivesListOfAllExpenseTransactions_ReturnsSumOfAllExpensesInList()
        {
            //Arrange
            Account account = new("Tim", 1000m);

            //Act
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "Hema salaris", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "Terugboeking Levi's", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "Verjaardag", 100m));

            var resultTotalExpense = account.SumAllExpenses();

            //Assert
            resultTotalExpense.ShouldBe(300m);
        }

        [Fact]
        public void NewBalance_GetsInitialBalanceSumOfIncomeSumOfExpense_ReturnsNewBalance()
        {
            // Arrange
            Account account = new("Tim", 1000m);

            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "IncomeOne", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "IncomeTwo", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "IncomeThree", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "IncomeFour", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Income, new DateOnly(2022, 8, 31), "IncomeFive", 100m));

            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "ExpenseOne", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "ExpenseTwo", 100m));
            account.AddTransaction(new Transaction(TypeOfTransaction.Expense, new DateOnly(2022, 8, 31), "ExpenseThree", 100m));

            // Act
            var result = account.SumNewBalance();

            // Assert
            result.ShouldBe(1200m);
        }
    }
}