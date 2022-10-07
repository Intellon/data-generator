using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest
{
    /**class Program
    {

        /*
        Method 1: 
        Uses a foreach-loop that directly accesses the instance field _values.
         * 
        Method 2: 
        Stores the instance field into a local variable reference. Then it uses that local variable in the foreach-loop.
         * 
        Result: 
        Because the field's address is resolved each time it is accessed, Method1() is slower. It adds indirection.
        
        const int _max = 100000000;
        static void Main()
        {
            Program program = new Program();
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                program.Method1();
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                program.Method2();
            }
            s2.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000 * 1000) /
                _max).ToString("0.00 ns"));
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000 * 1000) /
                _max).ToString("0.00 ns"));
            Console.Read();
        }

        int[] _values = { 1, 2, 3 };

        int Method1()
        {
            // Access the field directly in the foreach expression.
            int result = 0;
            foreach (int value in this._values)
            {
                result += value;
            }
            return result;
        }

        int Method2()
        {
            // Store the field into a local variable and then iterate.
            int result = 0;
            var values = this._values;
            foreach (int value in values)
            {
                result += value;
            }
            return result;
        }
    }
*/
}