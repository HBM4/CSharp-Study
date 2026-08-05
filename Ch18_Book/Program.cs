namespace Ch18_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");

            book.SetTitle("Harry Potter and the Half-Blood Prince.");
            
            Console.WriteLine(book.GetTitle());
        }
    }
}
