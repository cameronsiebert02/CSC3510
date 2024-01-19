namespace FinalExamInventory {
    public class Order {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public string OrderResponseMessage { get; set; }
        public int ErrorCode { get; set; }
    }
}
