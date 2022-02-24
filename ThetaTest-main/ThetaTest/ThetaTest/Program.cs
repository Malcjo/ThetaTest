using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;




namespace ThetaTest
{
    class Program
    {
        public Program()
        {
            //gets the current directory, which is the debug directory within the project
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"weather.txt");

            if (File.Exists(path))
            {
                List<string> lines = File.ReadLines(path).Skip(8).Take(30).ToList();
                List<Entry> EntryList = new List<Entry>();
                foreach (string line in lines)
                {
                    //Removing the spaces from each new line and sotring each string in an array (dealing with the *'s in the list and replacing with an empyty char)
                    string[] newLines = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Entry entry = new Entry(int.Parse(newLines[0]),
                                            int.Parse(newLines[1].Replace('*', ' ')),
                                            int.Parse(newLines[2].Replace('*', ' ')));
                    EntryList.Add(entry);

                }
                int smallestDiff = EntryList[0].getDifference();
                int smallestDay = 0;//for storing the index of the desired day

                //Going through the Entrylist and comparing the difference to the last lowest number
                for (int i = 0; i < EntryList.Count; i++)
                {
                    if (EntryList[i].getDifference() < smallestDiff)
                    {
                        smallestDiff = EntryList[i].getDifference();
                        smallestDay = i;
                    }
                }
                Console.WriteLine("Day number for smallest temperature difference is: " + EntryList[smallestDay].getDay());
            }
            else
            {
                Console.WriteLine("Not Exist");
            }
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            new Program();
        }
    }
}