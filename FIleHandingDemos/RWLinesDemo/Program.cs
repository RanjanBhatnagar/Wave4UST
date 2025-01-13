namespace RWLinesDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Write a string array to a file.
            string[] stringArray = new string[] { "C#", "ASP.NET", "VB.NET","Java" };
            File.WriteAllLines(@"d:\data2025\file.txt", stringArray);
            // Read in lines from file.
            foreach (string line in File.ReadAllLines(@"d:\data2025\file.txt"))
            {
                Console.WriteLine("{0}", line);
            }
        }
    }
}
