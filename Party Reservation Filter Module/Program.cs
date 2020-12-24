using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main( string [ ] args )
        {

            List<string> people = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = string.Empty;
            List<String> filtersList = new List<string>();
            while ((command = Console.ReadLine( )) != "Print")
            {
                switch (command.Split(";") [ 0 ])
                {
                    case "Add filter":
                        filtersList.Add(command);
                        break;
                    case "Remove filter":
                        for (int i = 0; i < filtersList.Count; i++)
                        {
                            if (filtersList [ i ].EndsWith(command.Split(";") [ 2 ]))
                            {
                                filtersList.RemoveAt(i);
                                break;
                            }
                        }
                        break;
                }
            }
            for (int i = 0; i < filtersList.Count; i++)
            {
                Func<List<string>,List<string>> filterFunc = FilterFunc(filtersList[i]);
                people = filterFunc(people);

            }

            if (people.Any( ))
            {
                Console.WriteLine(string.Join(" ", people));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            static Func<List<string>, List<string>> FilterFunc( string inputCommand )
            {
                Func<List<string>, List<string>> filterFunc = null;

                switch (inputCommand.Split(";") [ 1 ])
                {
                    case "Starts with":
                        filterFunc = new Func<List<string>, List<string>>(( x ) =>
                        {
                            List<string> copyList = new List<string>(x);

                            for (int i = 0; i < x.Count; i++)
                            {
                                if (x [ i ].StartsWith(inputCommand.Split(";") [ 2 ]))
                                {
                                    copyList.Remove(x [ i ]);
                                }
                            }
                            return copyList;
                        });
                        break;
                    case "Ends with":
                        filterFunc = new Func<List<string>, List<string>>(( x ) =>
                        {
                            List<string> copyList = new List<string>(x);

                            for (int i = 0; i < x.Count; i++)
                            {
                                if (x [ i ].EndsWith(inputCommand.Split(";") [ 2 ]))
                                {
                                    copyList.Remove(x [ i ]);
                                }
                            }
                            return copyList;
                        });
                        break;
                    case "Length":
                        filterFunc = new Func<List<string>, List<string>>(( x ) =>
                        {
                            List<string> copyList = new List<string>(x);

                            for (int i = 0; i < x.Count; i++)
                            {
                                if (x [ i ].Length == int.Parse(inputCommand.Split(";") [ 2 ]))
                                {
                                    copyList.Remove(x [ i ]);
                                }
                            }
                            return copyList;
                        });
                        break;
                    case "Contains":
                        filterFunc = new Func<List<string>, List<string>>(( x ) =>
                        {
                            List<string> copyList = new List<string>(x);

                            for (int i = 0; i < x.Count; i++)
                            {
                                if (x [ i ].Contains(inputCommand.Split(";") [ 2 ]))
                                {
                                    copyList.Remove(x [ i ]);
                                }
                            }
                            return copyList;
                        });
                        break;
                }
                return filterFunc;
            }

        }
    }
}
