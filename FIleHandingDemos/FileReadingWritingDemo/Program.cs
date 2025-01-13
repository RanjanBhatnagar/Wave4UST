namespace FileReadingWritingDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            // Write out Text to file on E drive.
            
            File.WriteAllText(@"d:\data2025\quote.txt", "Live and Let Live");

            // Read it all back and print.
            string quote = File.ReadAllText(@"d:\data2025\quote.txt");
            Console.WriteLine("Quote: {0}", quote);

            string text = File.ReadAllText(@"d:\data2025\test.txt");
            Console.WriteLine("Test Text: {0}", text);

        }
    }
}
