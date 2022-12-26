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
            get => _name;
            set => _name = value;
        }

        public List<Transaction> Transactions
        {
            get => transactions;
            set => transactions = value;
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
            return transactions.Where(t => t.TypeOfTransaction == TypeOfTransaction.Income).Sum(t => t.Amount);
        }

        public decimal SumAllExpenses()
        {
            return transactions.Where(t => t.TypeOfTransaction == TypeOfTransaction.Expense).Sum(t => t.Amount);
        }

        public decimal SumNewBalance() => _initialBalance + SumAllIncomes() - SumAllExpenses();

        public void RemoveTransaction(Transaction transaction)
        {
            var transactionToRemove = transaction;
            transactions.Where(t => t.) // zoek transaction op in List<> en verwijder hem uit de list dmv Linq.
        }
    }
}
