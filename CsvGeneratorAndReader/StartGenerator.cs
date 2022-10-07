using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;


#if !NET_3_5
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics;
#endif

namespace CSV_Generator
{
 
    public class StartGenerator
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("How many Datasets should be created?");
            var datasetCount =  int.Parse(Console.In.ReadLine());

            Console.WriteLine("Please give a file name ex test.csv");
            var filename = Console.In.ReadLine();
            if (filename.EndsWith(".csv")) {
                Console.WriteLine("Current Filename: " + filename);
            } else { filename = filename + ".csv";
                Console.WriteLine("Current Filename: " + filename);
            }

            var s1 = Stopwatch.StartNew();
            //Random random = new Random();
            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //var stringChars = new char[6];
            //Archiving.ArchiveProgram.Main();

            using (var csvFile = new CsvFile<Data>(@""+Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Desktop" + @"\" + filename))
            {
                Console.WriteLine("Write KSC File....");
                var count = datasetCount;
                var sysmodTime = DateTime.Now.TimeOfDay.ToString("hhmmss");
                var importTimestamp = "21.03.2017" + sysmodTime;
                
                //string Uppecharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                //string Lowercharacter = "abcdefghijklmnopqrstuvwxyz";
                //int len = 5;
                //int upp = 1;
                
                var random = new Random();

                for (int i = 0; i < count; i++)
                {
                    //StringBuilder b = new StringBuilder(len);
                    //StringBuilder u = new StringBuilder(upp);

                    //for (int c = 0; c < len; c++)
                    //{
                    //    b.Append(Lowercharacter[random.Next(Lowercharacter.Length)]);
                    //}
                    //string Lowercharacters = b.ToString();

                    //for (int l = 0; l < upp; l++)
                    //{
                    //    u.Append(Uppecharacter[random.Next(Uppecharacter.Length)]);
                    //}
                    //string Uppecharacters = u.ToString();

                    //string firstName = Uppecharacters + Lowercharacters;
                    var zreq = random.Next(1, 99999);
                    var tel = "41" + random.Next(1000000, 9999999);
                    var geburtstag = random.Next(01, 31) + "." + random.Next(1, 12) + "." + random.Next(1920, 1999);
                    var contractID = random.Next(10000, 99999) + "-" + random.Next(1000, 9999);
                    var bcn = random.Next(10000, 99999);
                    var plz = random.Next(1000, 9999);
                    var strNum = random.Next(1, 9999);
                    
                    var data = new Data()
                    {
                        ZREG = zreq.ToString(),
                        NAME = GenerateName(5),
                        TELEFON = tel.ToString(),
                        BCN = bcn.ToString(),
                        GEBURTSTAG = geburtstag.ToString(),

                    };
                    csvFile.Append(data);
                    //Console.WriteLine("Row" + i + " added...");
                }
                s1.Stop();
                Console.WriteLine(((double)(s1.Elapsed.TotalSeconds)).ToString("write " + count + " Lines to File in 0.00 seconds"));
                Console.WriteLine("Write File to " + Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Desktop" + @"\" +  filename);
            }
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

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
            System.Threading.Thread.Sleep(5);
            return Name;
        }
    }  
}