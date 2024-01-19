namespace FinalExamInventory {
    public class DBManager : IDBManager {
        // Note: This code simulates going to the database to get data
        //     DO NOT CHANGE THIS CODE. If you want to generate your own test 
        //     data consider other ways to realize the interface without changing this 
        //     file.
        public List<Item> getItems() {
            List<Item> items = new List<Item>();

            items.Add(new Item(1, "Furby", 12.00m, 100));
            items.Add(new Item(2, "Hot Wheels Set", 14.99m, 1100));
            items.Add(new Item(3, "Tamagothi", 11.99m, 32));
            items.Add(new Item(4, "Cabbage Patch Kids Set", 15.99m, 22));
            items.Add(new Item(5, "Rubik Cube", 3.99m, 12));
            items.Add(new Item(6, "Barbie", 9.99m, 10));
            items.Add(new Item(7, "My Little Pony Set", 11.99m, 112));
            items.Add(new Item(8, "XBox Bundle", 550.99m, 12));
            items.Add(new Item(9, "Easy Bake Oven", 22.99m, 12));
            items.Add(new Item(10, "Teddy Ruxpin", 25.99m, 122));
            items.Add(new Item(11, "Monopoly", 22.99m, 12));
            items.Add(new Item(12, "Nintendo", 299.99m, 12));
            return items;
        }
    }
}
