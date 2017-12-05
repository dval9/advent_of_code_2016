using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1(@"../../problem1.txt");
            Console.ReadLine();
        }

        /* Day 1
         * 
         */
        static void Problem1(string __input)
        {
            var directions = System.IO.File.ReadAllText(__input);
            int facing = 0; //0=north, 1=east, 2=south, 3=west
            int x_pos = 0;
            int y_pos = 0;
            char[] delims = { ' ', ',' };
            string[] dirs = directions.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> places = new Dictionary<string, string>();
            places.Add("0,0", null);
            for (int i = 0; i < dirs.Length; i++)
            {
                if (dirs[i].ElementAt(0).Equals('L'))
                {
                    facing = (((facing - 1) % 4) + 4) % 4;
                }
                else
                {
                    facing = (((facing + 1) % 4) + 4) % 4;
                }
                int dist = Int32.Parse(dirs[i].Substring(1));
                switch (facing)
                {
                    case 0:
                        for (int j = 0; j < dist; j++)
                        {
                            y_pos += 1;
                        }
                        break;
                    case 1:
                        for (int j = 0; j < dist; j++)
                        {
                            x_pos += 1;
                        }
                        break;
                    case 2:
                        for (int j = 0; j < dist; j++)
                        {
                            y_pos -= 1;
                        }
                        break;
                    case 3:
                        for (int j = 0; j < dist; j++)
                        {
                            x_pos -= 1;
                        }
                        break;
                }

            }
            int final = Math.Abs(x_pos) + Math.Abs(y_pos);
            places.Clear();
            x_pos = y_pos = 0;
            places.Add("0,0", null);
            for (int i = 0; i < dirs.Length; i++)
            {
                if (dirs[i].ElementAt(0).Equals('L'))
                {
                    facing = (((facing - 1) % 4) + 4) % 4;
                }
                else
                {
                    facing = (((facing + 1) % 4) + 4) % 4;
                }
                int dist = Int32.Parse(dirs[i].Substring(1));
                switch (facing)
                {
                    case 0:
                        for (int j = 0; j < dist; j++)
                        {
                            y_pos += 1;
                            if (places.ContainsKey(x_pos.ToString() + "," + y_pos.ToString()))
                            {
                                i = dirs.Count();
                                break;
                            }
                            else
                                places.Add(x_pos.ToString() + "," + y_pos.ToString(), null);
                        }
                        break;
                    case 1:
                        for (int j = 0; j < dist; j++)
                        {
                            x_pos += 1;
                            if (places.ContainsKey(x_pos.ToString() + "," + y_pos.ToString()))
                            {
                                i = dirs.Count();
                                break;
                            }
                            else
                                places.Add(x_pos.ToString() + "," + y_pos.ToString(), null);
                        }
                        break;
                    case 2:
                        for (int j = 0; j < dist; j++)
                        {
                            y_pos -= 1;
                            if (places.ContainsKey(x_pos.ToString() + "," + y_pos.ToString()))
                            {
                                i = dirs.Count();
                                break;
                            }
                            else
                                places.Add(x_pos.ToString() + "," + y_pos.ToString(), null);
                        }
                        break;
                    case 3:
                        for (int j = 0; j < dist; j++)
                        {
                            x_pos -= 1;
                            if (places.ContainsKey(x_pos.ToString() + "," + y_pos.ToString()))
                            {
                                i = dirs.Count();
                                break;
                            }
                            else
                                places.Add(x_pos.ToString() + "," + y_pos.ToString(), null);
                        }
                        break;
                }

            }
            int final2 = Math.Abs(x_pos) + Math.Abs(y_pos);
            Console.WriteLine("Day 1, Problem 1: " + final);
            Console.WriteLine("Day 1, Problem 2: " + final2);
        }
    }
}
