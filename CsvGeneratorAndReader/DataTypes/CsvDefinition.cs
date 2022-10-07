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
    public class CsvDefinition
    {
        public string Header { get; set; }
        public char FieldSeparator { get; set; }
        public char TextQualifier { get; set; }
        public IEnumerable<String> Columns { get; set; }
        public string EndOfLine { get; set; }

        public CsvDefinition()
        {
            if (CsvFile.DefaultCsvDefinition != null)
            {
                FieldSeparator = CsvFile.DefaultCsvDefinition.FieldSeparator;
                TextQualifier = CsvFile.DefaultCsvDefinition.TextQualifier;
                EndOfLine = CsvFile.DefaultCsvDefinition.EndOfLine;
            }
        }
    }
}
