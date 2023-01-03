namespace KasboekEngineBackend
{
    public interface ITransaction
    {
        decimal Amount { get; }
        DateOnly Date { get; }
        string Description { get; }
        bool IsSpendingMoney { get; set; }

        decimal CheckAmount(decimal amount);
    }
}