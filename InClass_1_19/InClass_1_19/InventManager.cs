using System;
namespace InClass_1_19
{
	public class InventManager
	{
        public string inFile;
        public string[] rows;
        public List<Inventory> inventory = new List<Inventory>();

        public InventManager(string inFile)
        {
            this.inFile = inFile;
        }

        public void setDataFromFile()
        {
            string[] rows = new string[0];
            try
            {
                rows = File.ReadAllLines(inFile);
                setRows(rows);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on file open!");
                Console.WriteLine(e.Message);
            }
        }

        public void setRows(string[] rows)
        {
            this.rows = rows;
        }

        public void parseRows()
        {
            foreach(string row in rows)
            {
                string[] toks = row.Split(',');
                string item;
                int count;
                decimal price;
                try
                {
                    item = toks[0];
                    count = int.Parse(toks[1]);
                }catch(Exception e)
                {
                    throw new ArgumentException("Item not right");
                }
                try
                { 
                    count = int.Parse(toks[1]);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Count not right");
                }
                try
                {
                    price = decimal.Parse(toks[2]);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Price not right");
                }
                inventory.Add(new Inventory(item, count, price));
            }
        }
	}
}

