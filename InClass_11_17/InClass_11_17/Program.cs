using InClass_11_17;

List<Book> books = getBooksFromUser();
Console.WriteLine("Size:{0}", books.Count);
foreach(Book book in books)
{
    Console.WriteLine("Title: {0} Pages: {1} Price: {2}, PricePerPage: {3}", book.title, book.pages, book.price, book.PricePerPage());
}
Console.Read();

List<Book> getBooksFromUser()
{
    List<Book> books = new List<Book>();
    books.Add(new Book("Good Grief", 100, 20m, 10));
    books.Add(new Book("Pizza is Good", 150, 10.5m, 10));
    books.Add(new Book("All About Nothing", 1000, 50.0m, 10));
    books.Add(new Book("Nothing to See", 100, 23.5m, 10));
    return books;
}