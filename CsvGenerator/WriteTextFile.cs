using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsvTest
{
    class WriteTextFile
    {
        
        static void Main()
        {
            Console.WriteLine("Write CsvData File....");
            var s1 = Stopwatch.StartNew();
            const int _max = 1000;            
            List<CsvData> datas = new List<CsvData>();
            for (int index = 0; index < _max; index++) {
                datas.Add(new CsvData {
                        FirstName = GenerateName(4),
                        LastName = GenerateName(5),
                        Email = "",
                        Street = "" ,
                        StreeNumber = 333,
                        Age = 35});
                
            }
            var csvContent = datas.AsCsv(true, ",", false);

            using (StreamWriter writer = new StreamWriter(@"C:\<USERHOME>>Extension.csv"))
            {
                writer.Write(csvContent);
            }
            s1.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000) / _max).ToString("0.00 ms"));
            Console.WriteLine("END");
            Thread.Sleep(3000);           
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            Thread.Sleep(5);
            return Name;
        }
    }
}