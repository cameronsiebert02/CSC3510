// See https://aka.ms/new-console-template for more information
using InClass_1_31;

DBConnectMySql dbc = new DBConnectMySql();
dbc.OpenConnection();
List<Candy> candyList = dbc.Select();
foreach(Candy candy in candyList)
{
    Console.WriteLine("ID: {0} Item: {1}", candy.id, candy.item);
}
Console.WriteLine("Ok so far!");