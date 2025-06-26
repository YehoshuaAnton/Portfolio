namespace Bank_Library {
    public enum AccountType {
        Savings,
        Checking
    }

    public abstract class Account {
        public string Name { get; init; }
        public string ID { get; init; }
        public decimal Balance { get; init; }

        // Constructor for Account class
        public Account(string name) {
            Name = name;
            ID = GenerateAccountID();
        }

        protected Account() { } // Serialization requires a parameterless constructor

        // Make RNG for Account ID
        private readonly Random random = new();
        // Make a List<long> of all the used IDs
        private static readonly List<long> usedID = [];
        public string GenerateAccountID() {
            long i;
            do {        // Pick a number from 10,000,000,000 to 100,000,000,000 exclusive
                i = random.NextInt64(10_000_000_000, 100_000_000_000);
            } while (usedID.Contains(i)); // As long as it isn't already in the list
            return i.ToString();        // Convert to string for ease of use
        }

        // Create a List of Transactions
        public List<Transaction> transactions = []; // Would use a stack, but can't serialize a public stack

        // Create a method to deposit money into an account
        public virtual bool Deposit(string description, decimal amount, DateTime dateTime) {
            if (amount > 0) {
                amount = Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
                Balance += amount;
                transactions.Insert(0, new Transaction(description, amount, dateTime));
                return true;
            }
            return false;
        }

        // Create a method to withdraw money from an account
        public virtual bool Withdraw(string description, decimal amount, DateTime dateTime) {
            if (amount <= Balance && amount > 0) {
                amount = Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
                Balance -= amount;
                transactions.Insert(0, new Transaction(description, amount * -1, dateTime));
                return true;
            }
            return false;
        }
    }
}
