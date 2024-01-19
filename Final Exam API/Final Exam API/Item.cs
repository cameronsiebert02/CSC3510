namespace FinalExamInventory {
    public class Item {
        public int id;
        public string name;
        public decimal cost;
        public int numberAvail;
        public String errorMsg;
        public int errorCode;

        public Item(int id, string name, decimal cost, int numberAvail) {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.numberAvail = numberAvail;
            this.errorMsg = "";
            this.errorCode = 0;
        } 
        public Item() {
            this.cost = 0;
        }
    }
}
