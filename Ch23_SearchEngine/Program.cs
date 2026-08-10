namespace Ch23_SearchEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SearchEngine searchEngine1 = new SearchEngine();
            SearchEngine searchEngine2 = new GoogleSearch();
            SearchEngine searchEngine3 = new RBsSearchEngine();

            //string[] defaultResults = searchEngine1.Search("hello");
            string[] googleResults = searchEngine2.Search("hello");
            string[] rbsResults = searchEngine3.Search("hello");

            //Console.WriteLine(string.Join(", ", defaultResults));
            Console.WriteLine(string.Join(", ", googleResults));
            Console.WriteLine(string.Join(", ", rbsResults));
        }
    }
}
