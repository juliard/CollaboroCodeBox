using System;
using CollaboroCodeBox.Core;

namespace CollaboroCodeBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the code box: ");
            var codeBoxString = Console.ReadLine();

            Console.Write("Enter the code to decipher: ");
            var stringToDecipher = Console.ReadLine();

            var businessService = new BusinessService();
            var output = businessService.DecipherCode(codeBoxString, stringToDecipher);

            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
