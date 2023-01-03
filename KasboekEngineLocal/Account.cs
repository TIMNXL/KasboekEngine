namespace KasboekEngineBackend
{
    public class Account
    {
        public string Name { get; set; }
        public List<ITransaction> Transactions { get; set; }
        public decimal InitialBalance { get; }

        public Account(string name, decimal initialBalance)
        {
            Name = name;
            InitialBalance = initialBalance;
            Transactions = new List<ITransaction>();
        }

        public void AddTransaction(ITransaction transaction)
        {
            Transactions.Add(transaction);
            CheckForSpendingMoney(transaction);
        }

        private static void CheckForSpendingMoney(ITransaction transaction)
        {
            if (transaction.TypeOfTransaction == TypeOfTransaction.Expense
                && transaction.IsSpendingMoney)
            {
                //TODO: remove transactionToRemove amount from remaining spending money 
            }
        }

        public decimal SumAllIncomes()
        {
            return Transactions
                .Where(t => t.TypeOfTransaction == TypeOfTransaction.Income)
                .Sum(t => t.Amount);
        }

        public decimal SumAllExpenses()
        {
            return Transactions
                .Where(t => t.TypeOfTransaction == TypeOfTransaction.Expense)
                .Sum(t => t.Amount);
        }

        public decimal SumNewBalance() => InitialBalance + SumAllIncomes() - SumAllExpenses();

        public void RemoveTransaction(Transaction transactionToRemove)
        {
            Transactions.Remove(transactionToRemove);
        }
    }
}
