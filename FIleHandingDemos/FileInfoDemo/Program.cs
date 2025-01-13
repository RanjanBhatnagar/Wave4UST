namespace FileInfoDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //// Make a new file on the E drive.
            //FileInfo f = new FileInfo(@"d:\data2025\Test1.dat");
            //FileStream fs = f.Create();
            //// Use the FileStream object...
            //// Close down file stream.
            //fs.Close();

            //// Make a new file via FileInfo.Open().
            //FileInfo f2 = new FileInfo(@"d:\data2025\Test1.dat");
            //using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate,                    FileAccess.ReadWrite, FileShare.None))
            //{
            //    // Use the FileStream object...
            //}

            //Printing names of folders starting with 'win'
            String searchName = "oops";
            DirectoryInfo dir = new DirectoryInfo(@"d:\dotnetdemos");
            SearchDirectories(dir, searchName);
        }
        public static void SearchDirectories(DirectoryInfo dir, string searchString)
        {
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name.StartsWith(searchString))
                {
                    Console.WriteLine(file.Name);
                }
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in dirs)
            {
                SearchDirectories(subDir, searchString);
            }
        }
    }
}
