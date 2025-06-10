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
    }
}
