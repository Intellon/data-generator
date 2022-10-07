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
    public class CsvDestination
    {
        public StreamWriter StreamWriter;

        public static implicit operator CsvDestination(string path)
        {
            return new CsvDestination(path);
        }
        private CsvDestination(StreamWriter streamWriter)
        {
            this.StreamWriter = streamWriter;
        }

        private CsvDestination(Stream stream)
        {
            this.StreamWriter = new StreamWriter(stream);
        }

        public CsvDestination(string fullName)
        {
            FixCsvFileName(ref fullName);
            this.StreamWriter = new StreamWriter(fullName);
        }

        private static void FixCsvFileName(ref string fullName)
        {
            fullName = Path.GetFullPath(fullName);
            var path = Path.GetDirectoryName(fullName);
            if (path != null && !Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!String.Equals(Path.GetExtension(fullName), ".csv"))
                fullName += ".csv";
        }
    }
}
