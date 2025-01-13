namespace DirInfoDemp
{
    public class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir1 = new DirectoryInfo(".");
            DirectoryInfo dir2 = new DirectoryInfo(@"d:\Data2025");
            DirectoryInfo dir3 = new DirectoryInfo(@"D:\Data2025\MyCode");
            dir3.Create();
            dir3.CreateSubdirectory(@"Data2025");


            Console.WriteLine("***** Directory Info *****\n");
            DirectoryInfo dir = new DirectoryInfo(@"d:\Dotnetdemos");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");

            

        }
    }
}
