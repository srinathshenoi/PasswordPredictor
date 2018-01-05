using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            //Randomgeneration(input);
            var output = Check(input);
            Console.WriteLine(output);

        }

        //private static string Check(string input)
        //{
        //    var libraryStringSet = "asiowertyupdfghjklcvbnmxqz";
        //    var random = new Random();
        //    var num = 0;
        //    var count = 0;
        //    var outputString = new StringBuilder();
        //    for (int indexOfInput = 0; indexOfInput < input.Length; indexOfInput++)
        //    {
        //        var list = new List<int>();
        //        var inputchar = input[indexOfInput];
        //        do
        //        {
        //            count++;
        //            num = random.Next(1, 26);
        //            Console.WriteLine(count);
        //            if (inputchar.Equals(libraryStringSet[num]))
        //            {
        //                outputString.Append(libraryStringSet[num]);
        //                break;
        //            }

        //        }
        //        while (!list.Contains(num));
        //        list.Add(num);
        //    }
        //    return outputString.ToString();

        //}

        private static string Check(string input)
        {
            var outputString = new StringBuilder();
            var count = 0;
            var libraryStringSet = "asiowertyupdfghjklcvbnmxqz";
            var librarySpecialSet = " .!*@&#$%^+";
            var librarySpecialSetLength = librarySpecialSet.Length;
            var libraryStringsetLength = libraryStringSet.Length;

            for (int indexOfInput = 0; indexOfInput < input.Length; indexOfInput++)
            {
                var inputchar = input[indexOfInput];
                if (libraryStringSet.Contains(char.ToLower(inputchar)))
                {
                    for (int index = 0; index < libraryStringsetLength; index++)
                    {
                        count++;
                        if (inputchar.Equals(libraryStringSet[index]))
                        {
                            outputString.Append(libraryStringSet[index]);
                            break;
                        }
                        else if (inputchar.Equals(char.ToUpper(libraryStringSet[index])))
                        {
                            outputString.Append(char.ToUpper(libraryStringSet[index]));
                            break;
                        }
                        Console.WriteLine(count);
                    }
                }
                else
                {
                    for (int index = 0; index < librarySpecialSetLength; index++)
                    {
                        count++;
                        if (inputchar.Equals(librarySpecialSet[index]))
                        {
                            outputString.Append(librarySpecialSet[index]);
                            break;
                        }
                        Console.WriteLine(count);
                    }
                }
            }
            return outputString.ToString();
        }


    }
}
