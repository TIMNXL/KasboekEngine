namespace KasboekEngineBackend
{
    public static class TransactionExtension
    {
        public static string GetStringIfCorrect(this Transaction transaction, TypeOfTransaction typeOfTransaction)
        {
            if (transaction.TypeOfTransaction == typeOfTransaction)
            {
                return transaction.Amount.ToString();
            }

            return string.Empty;
        }
    }
}
