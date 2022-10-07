using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace CSV_Generator
{
/*    public class StartReader
    {
        private static string directoryPath = Properties.Settings.Default.sourcePath;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Read KSC File....");
            var s1 = Stopwatch.StartNew();
            
            //DirectoryInfo sourceDirectory = new DirectoryInfo(directoryPath);
            string pattern = "*.csv";
            var dataTable = new DataTable();
            var dirInfo = new DirectoryInfo(Properties.Settings.Default.sourcePath);

            var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).Last();
            string source = Properties.Settings.Default.sourcePath + file;
            //DataTable csvData = GetDataTabletFromCSVFile(source);

            foreach (var d in from data in CsvFile.Read<Data>(source)
                              //where data.name.StartsWith("J")
                              //where data.ACTIVE.Equals(true) 
                              //where source.Length < 0
                              select data)
            {
                //Console.WriteLine("Row" + d + " readed...");
            }
               
            s1.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalSeconds)).ToString("0.00 seconds"));  
            Console.ReadLine();
        }

        //private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        //{
        //    DataTable csvData = new DataTable();
        //    try
        //    {
        //        using(TextFieldParser csvReader = new TextFieldParser(csv_file_path))
        //        {
        //            csvReader.SetDelimiters(new string[] { "," });
        //            csvReader.HasFieldsEnclosedInQuotes = true;
        //            string[] colFields = csvReader.ReadFields();
        //            foreach (string column in colFields)
        //            {
        //                DataColumn datecolumn = new DataColumn(column);
        //                datecolumn.AllowDBNull = true;
        //                csvData.Columns.Add(datecolumn);
        //            }
        //            while (!csvReader.EndOfData)
        //            {
        //                string[] fieldData = csvReader.ReadFields();
        //                //Making empty value as null
        //                for (int i = 0; i < fieldData.Length; i++)
        //                {
        //                    if (fieldData[i] == "")
        //                    {
        //                        fieldData[i] = null;
        //                    }
        //                }
        //                csvData.Rows.Add(fieldData);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //    return csvData;
        //}
    }*/
}
