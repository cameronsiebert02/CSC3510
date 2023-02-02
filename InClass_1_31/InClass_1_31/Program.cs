// See https://aka.ms/new-console-template for more information
using InClass_1_31;

DBConnectMysql dbc = new DBConnectMysql();
dbc.OpenConnection();
List<Candy> candyList = dbc.Select();
foreach(Candy candy in candyList)
{
    Console.WriteLine("ID: {0} Item: {1}", candy.id, candy.item);
}
dbc.Insert("KitKat", 20, 2.99m);
dbc.Update("Chocolate Sundae", 22, 22.22m, " id='359' ");
Console.WriteLine("Ok so far!");
Console.ReadLine();