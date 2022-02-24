// See https://aka.ms/new-console-template for more information
using System;

namespace Assignment2 {
    class Program {
        public static int number_of_lines = 0;
        public static void Main(string[] args) {
            
            Console.Write("Enter a string which you want to find : ");
            string input_string = Console.ReadLine();

            //Path of the sample file
            string path = @"../../../Inputfile.txt";
            if (File.Exists(path))
            {
                //Display the Ocuurence of String
                int occurenece = LineNumberOfString(path, input_string);
                Console.WriteLine("Occuence of Input string is : {0}", occurenece);
                if (occurenece == 0)
                {
                    Console.WriteLine("The File {0} does not contain the string {1}, please try any other");
                }
                else
                {
                    //Take an integer from user
                    Console.WriteLine("Enter a value : ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n == 0)
                    {
                        Console.WriteLine("Enter input which is greater than 0");
                    }
                    else if (n > occurenece)
                    {
                        Console.WriteLine("Total occurence of {0} is {1}. So please choose a number less than or equal to this.", input_string, occurenece);
                    }
                    else
                    {
                        var o = LineNumberOfString(path, input_string, n);
                        Console.WriteLine("The Line number  is : {0} ", number_of_lines);
                    }

                }
            }
            else {
                Console.WriteLine("File does not exists");
            }


        }
        public static int LineNumberOfString(string path, string input_string, int n=0)
        {
            int line = 0, occ = 0;
            foreach (string lines in File.ReadLines(path).Where(line => line != ""))
            {
                line++;
                string[] array_of_data = lines.Split(" ");
                for (int i = 0; i < array_of_data.Length; i++)
                {
                    if (array_of_data[i] == input_string)
                    {
                        occ++;
                        if (occ == n)
                        {
                            number_of_lines = line;
                        }
                    }
                }

            }
            return occ;
        }

    }
}