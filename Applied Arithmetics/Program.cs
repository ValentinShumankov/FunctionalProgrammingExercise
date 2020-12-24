using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main( string [ ] args )
        {
            Action<int[]> print = (x) =>
            {
                Console.WriteLine(string.Join(" ",x));
            };
            int[] numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine())!=  "end")
            {
                if (input == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int[],int[]> processor = GetProcessor(input);
                    numbers = processor(numbers);
                }


            }

            static Func<int[], int[]> GetProcessor(string input )
            {
                Func<int[],int[]> processor = null;
                if (input == "add")
                {
                    processor = new Func<int [ ], int [ ]>((x) => 
                    {
                       return x.Select(x => x + 1).ToArray( );
                    } );
                }
                else if (input == "multiply")
                {
                    processor = new Func<int [ ], int [ ]>((x) => 
                    {
                       return x.Select(x => x * 2).ToArray( );
                    } );
                }
                else if (input == "subtract")
                {
                    processor = new Func<int [ ], int [ ]>((x) => 
                    {
                        return x.Select(x => x - 1).ToArray( );

                    } );
                }

                return processor;
            }
        }
    }
}

            //Func<string,int[]> toArray = (x) =>
            //{
            //    return  x.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //};
            //Func<int,int> addDeligate = x => x += 1;
            //Func<int,int> multiplyDeligate = x => x *= 2;
            //Func<int,int> subtractDeligate = x => x -= 1;
            //Action<int[]> printCollection = x =>Console.WriteLine(string.Join(" ", x));
            //int[] array = toArray(Console.ReadLine());
            //string input = string.Empty;
            //while ((input = Console.ReadLine( )) != "end")
            //{
            //    switch (input)
            //    {
            //        case "add":
            //           array = array.Select(addDeligate).ToArray();
            //            break;
            //        case "multiply":
            //           array = array.Select(multiplyDeligate).ToArray();
            //            break;
            //        case "subtract":
            //           array = array.Select(subtractDeligate).ToArray();
            //            break;
            //        case "print":
            //            printCollection(array);
            //            break;
            //    }
            //}