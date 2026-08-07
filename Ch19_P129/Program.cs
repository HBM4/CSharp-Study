namespace Ch19_P129
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");

            book.Title = "Harry Potter and Half-Blood Prince.";
            book.Pages = 607;
            book.Publisher = "Bloomsbury";

            book.AssignWordCountFromText("This is a sample text to count the number of words in the book.");

            Console.WriteLine(book.Title);
            Console.WriteLine(book.Author);
            Console.WriteLine(book.Pages);
            Console.WriteLine(book.WordCount);
            Console.WriteLine(book.Publisher);
        }
    }
}
