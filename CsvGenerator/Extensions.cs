using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest
{
    public static class ICsvExtensions
    {
    /// <summary>
    /// convert the objet list into a string in csv format
    /// – delimiter: comma
    /// – field quotes: quotes will be used
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static string AsCsv<T>(this IEnumerable<T> items)
    {
        return AsCsv(items, false, ",", true);
    }

    /// <summary>
    /// convert the objet list into a string in csv format
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <param name="withHeader"></param>
    /// <param name="delimiter"></param>
    /// <param name="useQuotesForFields"></param>
    /// <returns></returns>
    public static string AsCsv<T>(this IEnumerable<T> items, bool withHeader, string delimiter, bool useQuotesForFields)
    {
        var csvBuilder = new StringBuilder();
        var properties = typeof(T).GetProperties();

        if (withHeader)
        {
            csvBuilder.AppendLine(string.Join(delimiter, (from p in properties select p.Name).ToArray()));
        }

        foreach (T item in items)
        {
            var values = from p in properties
            select p.GetValue(item, null).ToCsvValue(useQuotesForFields);
            csvBuilder.AppendLine(string.Join(delimiter, values.ToArray()));
        }
        return csvBuilder.ToString();
    }

    /// <summary>
    /// convert a single item into a csv value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="useQuotesForFields"></param>
    /// <returns></returns>
    private static string ToCsvValue<T>(this T item, bool useQuotesForFields)
    {
        if (item is string)
        {
            if (useQuotesForFields == true)
            {
                return string.Format("\"{0}\"", item.ToString().Replace("\"", "\"\""));
            }
            else
            {
                return item.ToString();
            }         
        }

        if (item is DateTime)
        {
            return string.Format("{0:u}", item);    //format: 2013-01-20 12:49:56Z
        }

        double dummy;

        if (item == null)
            return "";

        if (double.TryParse(item.ToString(), out dummy))
            return string.Format("{0}", item);
            return string.Format("{0}", item);
        }
    }
}
