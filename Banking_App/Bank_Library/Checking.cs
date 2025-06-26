namespace Bank_Library {
    public class Checking : Account {
        public Checking(string name) : base(name) { }

        private Checking() { }

        public override void EndOfMonth() { }

        public override string ToString() {
            return $"{Name} - {ID}";
        }
    }
}
