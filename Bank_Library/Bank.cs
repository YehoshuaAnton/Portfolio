using System.Xml.Serialization;

// Create the inner workings of the banking app
namespace Bank_Library {
    public class Bank {
        // Create an instance of the Bank class
        private static Bank? _instance;
        public List<Client?> clients;
        // Create a single Bank using the Singleton Pattern
        public static Bank CreateBankInstance() {
            _instance ??= new Bank();
            return _instance;
        }

        private Bank() {
            clients = [];
        }

        public void AddClient(string firstName, string lastName, AccountType accountType, string accountName) {
            clients.Add(new Client(firstName, lastName, accountType, accountName));
        }
    }
}
