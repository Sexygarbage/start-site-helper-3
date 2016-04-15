using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplicationHelperStartHPI
{
    class Program
    {
        /*
         * Generate auto code 
         */ 
        static void Main(string[] args)
        {
            var enc1251 = Encoding.GetEncoding(1251);
            List<String> specsOut = new List<string>();
            string[] specs = File.ReadAllLines("specs.txt", enc1251);

            

            string[] strings = File.ReadAllLines("Part.txt", enc1251);

            foreach (var specOfItem in specs)
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings[i].Contains("[su_spoiler title="))
                    {

                        var stringVar = strings[i].Remove(strings[i].IndexOf('"') + 1);
                        stringVar += specOfItem.TrimEnd() + "\" style=\"fancy\"]";
                        strings[i] = stringVar;
                        //Console.WriteLine("•" + stringVar);
                    }
                }
                specsOut.AddRange(strings);
            }

            //foreach (var st in specsOut)
              //  Console.WriteLine(st);

            Write(specsOut, "outAll.txt");
        }

        public static void Write(List<string> strings, string outfile)
        {
            using (StreamWriter writer = System.IO.File.CreateText(outfile))
            {
                foreach (string string0 in strings)
                    writer.WriteLine(string0);

            }
        }
    }


}
