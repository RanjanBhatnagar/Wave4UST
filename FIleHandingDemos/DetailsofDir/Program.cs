namespace DetailsofDir
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
                Console.WriteLine("--> {0} ", s);
            //Set current directory to a specified folder.

            Directory.SetCurrentDirectory(@"d:\data2025");

            Console.WriteLine("Press Enter name to delete directories");
            string dname = Console.ReadLine();
            try
            {
                Directory.Delete(dname);
               
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
