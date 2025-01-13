namespace StreamWriterReaderDemo
{
    public class Program
    {
        static string file = @"d:\data2025\poem2.txt";

        static void Main(string[] args)
        {
            Write();
            Read();
        }
        static void Write()
        {
            //StreamWriter fileStream = new StreamWriter(file);
            //fileStream.WriteLine("What is this life if, full of care,");
            //fileStream.WriteLine("We have no time to stand and stare");
            //fileStream.Close();

            using (StreamWriter fileStream = new StreamWriter(file))
            {
                fileStream.WriteLine("I made myself a snowball");
                fileStream.WriteLine("As perfect as could be.");
                fileStream.WriteLine("I thought I'd keep it as a pet");
                fileStream.WriteLine("And let it sleep with me.");
                fileStream.WriteLine("I made it some pajamas");
                fileStream.WriteLine("And a pillow for its head.");
                fileStream.WriteLine("Then last night it ran away,");
                fileStream.WriteLine("But first it wet the bed.");
            }
        }
        static void Read()
        {
            StreamReader fileStream = new StreamReader(file);
            string s = null;
            while ((s = fileStream.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            fileStream.Close();
        }

    }
}
