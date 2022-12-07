namespace KasboekEngineBackend
{
    public class Account
    {
        private string _name;
        //TODO Readonly wel toepasselijk? Initial balance feb = initial balance jan + total income - total expense (mutatie vindt plaats)
        private readonly decimal _initialBalance;
        private List<Transaction> transactions;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Transaction> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }

        public decimal InitialBalance => _initialBalance;

        public Account(string name, decimal initialBalance)
        {
            _name = name;
            _initialBalance = initialBalance;
            transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            CheckForSpendingMoney(transaction);
        }

        private static void CheckForSpendingMoney(Transaction transaction)
        {
            if (transaction.TypeOfTransaction == TypeOfTransaction.Expense && transaction.IsSpendingMoney)
            {
                //TODO: remove transaction amount from remaining spending money 
            }
        }

        public decimal SumAllIncomes()
        {
            decimal sumIncome = 0;
            foreach (var transaction in Transactions)
            {
                if (transaction.TypeOfTransaction == TypeOfTransaction.Income)
                {
                    sumIncome += transaction.Amount;
                }
            }
            return sumIncome;
        }

        public decimal SumAllExpenses()
        {
            decimal sumExpense = 0;
            foreach (var transaction in Transactions)
            {
                if (transaction.TypeOfTransaction == TypeOfTransaction.Expense)
                {
                    sumExpense += transaction.Amount;
                }
            }
            return sumExpense;
        }

        public decimal SumNewBalance() => _initialBalance + SumAllIncomes() - SumAllExpenses();
    }
}
