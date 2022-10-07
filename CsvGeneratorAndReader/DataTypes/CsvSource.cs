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
#endif

namespace CSV_Generator
{
    public class CsvSource
    {
        public readonly TextReader TextReader;

        public static implicit operator CsvSource(CsvFile csvFile)
        {
            return new CsvSource(csvFile);
        }

        public static implicit operator CsvSource(string path)
        {
            return new CsvSource(path);
        }

        public static implicit operator CsvSource(TextReader textReader)
        {
            return new CsvSource(textReader);
        }

        public CsvSource(TextReader textReader)
        {
            this.TextReader = textReader;
        }

        public CsvSource(Stream stream)
        {
            this.TextReader = new StreamReader(stream);
        }

        public CsvSource(string path)
        {
            this.TextReader = new StreamReader(path);
        }

        public CsvSource(CsvFile csvFile)
        {
            this.TextReader = new StreamReader(csvFile.BaseStream);
        }
    }
}
