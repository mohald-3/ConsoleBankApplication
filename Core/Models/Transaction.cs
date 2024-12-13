public class Transaction
{
    public string TransactionId { get; private set; }
    public string AccountNumber { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public TransactionType Type { get; private set; }
    public string RelatedAccountNumber { get; set; }  // Add this for transfer transactions

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    public Transaction(string accountNumber, decimal amount, TransactionType transactionType)
    {
        TransactionId = Guid.NewGuid().ToString();
        AccountNumber = accountNumber;
        Amount = amount;
        Type = transactionType;
        TransactionDate = DateTime.Now;
    }

    public string GetTransactionDetails()
    {
        return $"{TransactionDate}: {Type} of {Amount:C} in account {AccountNumber}";
    }
}
