using Bank_Library;
using System.Text;

namespace Banking_App {
    public partial class BankForm : Form {
        private static BankForm? bankForm;
        private NewClientForm? newClientForm;
        private NewAccountForm? newAccountForm;
        private TransactionForm? transactionForm;
        private Client? currentClient;
        private Account? currentAccount;

        //
        private BankForm() => InitializeComponent();

        //
        public static BankForm? GetBankForm() {
            bankForm ??= new BankForm();
            return bankForm;
        }

        //
        private void AddClientButton_Click(object? sender, EventArgs e) {

        }

        //
        private void AddNewClient(object? sender, EventArgs e) {

        }

        //
        private void ClientSelected_ValueChanged(object? sender, EventArgs e) {

        }
        
        //
        private void AddAccountButton_Click(object? sender, EventArgs e) {

        }

        //
        private void AddNewAccount(object? sender, EventArgs e) {

        }

        //
        private void AccountSelected_ValueChanged(object? sender, EventArgs e) {

        }

        //
        private string PrintTransactionList() {
            StringBuilder transactionList = new();
            return transactionList.ToString();
        }

        //
        private void DepositButton_Click(object sender, EventArgs e) {

        }

        //
        private void WithdrawButton_Click(object? sender, EventArgs e) {

        }

        //
        private void AddNewTransaction(object? sender, EventArgs e) {

        }

        //
        private void SaveButton_Click(object? sender, EventArgs e) {

        }

        //
        private void LoadButton_Click(object? sender, EventArgs e) {

        }
    }
}
