using System;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main( string [ ] args )
        {
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> sirStatusDelegate = x => Console.WriteLine(string.Join("\n",x.Select(x => "Sir " + x)));

            sirStatusDelegate(names);
        }
    }
}
