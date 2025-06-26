namespace Bank_Library {
    public class Savings : Account {
        private const decimal INTERESTRATE = .0435m;
        
        public Savings(string name) : base(name) { }

        private Savings() { }

        public override void EndOfMonth() {
            DateTime dateTime = new();
            decimal monthlyInterest = Math.Round((INTERESTRATE / 12) * Balance, 2, MidpointRounding.ToPositiveInfinity);
            Deposit("Monthly Interest", monthlyInterest, dateTime.Date);
        }

        public override string ToString() {
            return $"{Name} - {ID}";
        }
    }
}
