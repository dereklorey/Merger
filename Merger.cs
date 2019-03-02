using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            string contin = "y";
            string first;
            string firstfile;
            while (contin == "y" || contin == "Y")
            {
                Console.WriteLine("Document Merger\n");

                Console.WriteLine("What's the name of the first text file? ");
                first = Console.ReadLine();
                firstfile = @"c:\users\dlore\git\Merger\" + first + ".txt";

                while (File.Exists(firstfile) != true)
                {
                    Console.WriteLine("File does not exist. please re-enter the first file name: ");
                    first = Console.ReadLine();
                    firstfile = @"c:\users\dlore\git\Merger\" + first + ".txt";
                }

                string second;
                string secondfile;
                Console.WriteLine("What's the name of the second text file? ");
                second = Console.ReadLine();

                secondfile = @"c:\users\dlore\git\Merger\" + second + ".txt";

                while (File.Exists(secondfile) != true || secondfile == firstfile)
                {
                    Console.WriteLine("File does not exist or is in use. please re-enter the second file name: ");
                    second = Console.ReadLine();
                    secondfile = @"c:\users\dlore\git\Merger\" + second + ".txt";
                }

                string thirdfile = @"c:\users\dlore\git\Merger\" + first + second + ".txt.";
                string file1, file2, file3;
                try
                {
                    StreamReader fr = new StreamReader(firstfile);
                    file1 = fr.ReadLine();
                    file3 = file1;
                    while (file1 != null)
                    {
                        file1 = fr.ReadLine();
                        file3 += file1;
                    }
                    fr.Close();

                    StreamReader sr = new StreamReader(secondfile);
                    file2 = sr.ReadLine();
                    file3 += file2;
                    while (file2 != null)
                    {
                        file2 = sr.ReadLine();
                        file3 += file2;
                        sr.Close();
                        StreamWriter sw = new StreamWriter(thirdfile);
                        sw.WriteLine(file3);
                        sw.Close();
                        Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", thirdfile, file3.Length);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not read one or more of the files: " + e.Message);
                }
                Console.WriteLine("Would you like to merge two more files? (y/n): ");
                contin = Console.ReadLine();
            }
        }
    }
}
