namespace KasboekEngineBackend
{
    public class Transaction : ITransaction
    {
        public TypeOfTransaction TypeOfTransaction;
        public DateOnly Date { get; }
        public string Description { get; }
        public decimal Amount { get; private set; }
        public bool IsSpendingMoney { get; set; }

        public Transaction(TypeOfTransaction typeOfTransaction, DateOnly date, string description, decimal amount)
        {
            TypeOfTransaction = typeOfTransaction;
            Date = date;
            Description = description;
            CheckAmount(amount);
        }

        public decimal CheckAmount(decimal amount)
        {
            while (amount <= 0)
            {
                Console.WriteLine("Error! The amount cannot be 0 or a negative number! Please try again!");
                Console.Write("What is the amount of the transaction?: "); // Polly!
                _ = decimal.Parse(Console.ReadLine());
            }
            return Amount = amount;
        }
    }
}
