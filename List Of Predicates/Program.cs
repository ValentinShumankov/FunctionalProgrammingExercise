using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main( string [ ] args )
        {

            List<string> people = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine( )) != "Party!")
            {
                Func<List<string>,List<string>> filterFunc = FilterFunc(command);
                people = filterFunc(people);
            }

            if (people.Any( ))
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            static Func<List<string>, List<string>> FilterFunc( string inputCommand )
            {
                Func<List<string>, List<string>> filterFunc = null;
                switch (inputCommand.Split(" ") [ 0 ])
                {
                    case "Double":
                        switch (inputCommand.Split(" ") [ 1 ])
                        {
                            case "StartsWith":
                                filterFunc = new Func<List<string>, List<string>>(( x ) =>
                                {
                                    List<string> copyList = new List<string>(x);
                                    for (int i = 0; i < x.Count; i++)
                                    {
                                        if (x [ i ].StartsWith(inputCommand.Split(" ") [ 2 ]))
                                        {
                                            copyList.Insert(x.IndexOf(x [ i ]), x [ i ]);
                                        }
                                    }
                                    return copyList;
                                });
                                break;
                            case "EndsWith":
                                filterFunc = new Func<List<string>, List<string>>(( x ) =>
                                {
                                    List<string> copyList = new List<string>(x);

                                    for (int i = 0; i < x.Count; i++)
                                    {
                                        if (x [ i ].EndsWith(inputCommand.Split(" ") [ 2 ]))
                                        {
                                            copyList.Insert(x.IndexOf(x [ i ]), x [ i ]);
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
                                        if (x [ i ].Length == int.Parse(inputCommand.Split(" ") [ 2 ]))
                                        {
                                            copyList.Insert(copyList.IndexOf(x [ i ]), x [ i ]);
                                        }
                                    }
                                    return copyList;
                                });
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Remove":
                        switch (inputCommand.Split(" ") [ 1 ])
                        {
                            case "StartsWith":
                                filterFunc = new Func<List<string>, List<string>>(( x ) =>
                                {
                                    List<string> copyList = new List<string>(x);

                                    for (int i = 0; i < x.Count; i++)
                                    {
                                        if (x [ i ].StartsWith(inputCommand.Split(" ") [ 2 ]))
                                        {
                                            copyList.Remove(x [ i ]);
                                        }
                                    }
                                    return copyList;
                                });
                                break;
                            case "EndsWith":
                                filterFunc = new Func<List<string>, List<string>>(( x ) =>
                                {
                                    List<string> copyList = new List<string>(x);

                                    for (int i = 0; i < x.Count; i++)
                                    {
                                        if (x [ i ].EndsWith(inputCommand.Split(" ") [ 2 ]))
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
                                        if (x [ i ].Length == int.Parse(inputCommand.Split(" ") [ 2 ]))
                                        {
                                            copyList.Remove(x [ i ]);
                                        }
                                    }
                                    return copyList;
                                });
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                return filterFunc;
            }
        }
    }
}
