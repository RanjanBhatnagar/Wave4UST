using System.Text;

namespace StreamReadingWritingDemo
{
    public class Program
    {
        static string file = @"d:\data2025\streamtest.txt";
        static void Main(string[] args)
        {
            Write();
            Read();
        }

        static void Write()
        {
            FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.Write);
            string content = @"What is this life if, full of care,
				We have no time to stand and stare";
            byte[] info = new UTF8Encoding(true).GetBytes(content);
            fileStream.Write(info, 0, content.Length);
            fileStream.Close();
        }

        static void Read()
        {
            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[1024];
            UTF8Encoding data = new UTF8Encoding(true);
            while (fileStream.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(data.GetString(b));
            }
        }
    }
}
