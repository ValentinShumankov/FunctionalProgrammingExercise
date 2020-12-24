using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main( string [ ] args )
        {

        }


        static List<string> IfValid( List<string> word, int size )
        {
            return word.Where(x => x.Select(x => 
            {
                int cur = 0;
              cur = x.ToString( ).ToCharArray( ).Select(x => ( int ) x).ToArray( ).Sum( );
              
            });
        }
    }
}
