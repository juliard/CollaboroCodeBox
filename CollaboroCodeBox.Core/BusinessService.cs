using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboroCodeBox.Core
{
    public class BusinessService : IBusinessService
    {
        public BusinessService()
        {
        }

        public string DecipherCode(string codeBox, string codeToDecipher)
        {
            var response = string.Empty;

            // Format code box to dictionary here
            var codeBoxDictionary = new Dictionary<string, string>();
            var codeBoxArray = codeBox.Split("),");
            foreach (string codeBoxItem in codeBoxArray)
            {
                var formattedCodeBoxItem = codeBoxItem.Replace("(", string.Empty).Replace(")", string.Empty);
                var codeBoxKeyValuePair = formattedCodeBoxItem.Split(",");

                if (!codeBoxDictionary.ContainsKey(codeBoxKeyValuePair[0].Trim()))
                {
                    codeBoxDictionary.Add(codeBoxKeyValuePair[0].Trim(), codeBoxKeyValuePair[1]);
                }
                else
                {
                    return $"Error in processing: code box key ({codeBoxKeyValuePair[0]}) is repeated";
                }
            }

            Console.WriteLine("\n\nCode box contents");
            foreach (KeyValuePair<string, string> kvp in codeBoxDictionary)
            {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
            }

            var codeToDecipherList = codeToDecipher.Split(",");
            foreach (string code in codeToDecipherList)
            {
                if (codeBoxDictionary.ContainsKey(code.Trim()))
                {
                    response += codeBoxDictionary[code.Trim()];
                }
                else
                {
                    return $"Error in processing: code cannot be deciphered because ({code.Trim()}) is missing from the code box";
                }
            }

            return $"Code successfully deciphered: {response}";
        }
    }
}
