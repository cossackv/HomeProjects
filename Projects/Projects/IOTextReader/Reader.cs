﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projects.IOTextReader
{
    public class Reader
    {
        private static string _textFromFile;
        private static string _editString;
        private static string _cleanStr;
        private static string[] _cleanArray;
        private static Dictionary<string, int> _resultTable;

        public Reader()
        {
                _textFromFile = System.IO.File.ReadAllText(@"C:\Users\dmytr\source\repos\HomeProjects\Projects\Projects\IOTextReader\Example.txt");
        }

        #region CleanArrayFromFile
        /// <summary>
        /// Returns an array of words without extra characters
        /// </summary>
        public string[] GetCleanArrText()
        {
            Console.OutputEncoding = Encoding.UTF8;

            _editString = _textFromFile.Replace("\r", "").Replace("\n", "").ToLower();

            _cleanStr = _editString.Replace('.', ' ').Replace('?', ' ').Replace(',', ' ').Replace('!', ' ').Replace(' ', ' ');

           _cleanArray = _cleanStr.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            return _cleanArray;
        }
        #endregion

        #region SortAndAddToDict
        /// <summary>
        /// Returns a dictionary<key, value>, where values ​​is the number of elements by key
        /// </summary>
        public Dictionary<string, int> SortAnDictionaryInit()
        {
            _resultTable = new Dictionary<string, int>();
            foreach (string element in _cleanArray)
            {
                if (element.Length > 0)
                {
                    if (!_resultTable.ContainsKey(element))
                    {
                        _resultTable.Add(element, 1);
                    }
                    else
                    {
                        _resultTable[element] += 1;
                    }
                }
            }

            var orderByNumbers = _resultTable.OrderByDescending(x => x.Value);

            foreach (KeyValuePair<string, int> kv in orderByNumbers)
            {
                Console.WriteLine("\"{0}\" - {1}", kv.Key, kv.Value);
            }
            return _resultTable;
        }
        #endregion

        #region DictionaryToString
        /// <summary>
        /// Translation of the dictionary into a string for output
        /// </summary>
        public string DictToStr(Dictionary<string, int> resultTable)
        {
            StringBuilder keyValueBox = new StringBuilder();
            foreach (var keyValue in resultTable)
            {
                keyValueBox.Append(keyValue.Key).Append(":").Append(keyValue.Value).Append(',');
            }
            string result = keyValueBox.ToString();

            result = result.TrimEnd(',');
            return result;
        }

        #endregion

        #region ExportToFile
        /// <summary>
        /// Export string to Result.txt 
        /// </summary>
        public static async Task PrintToFile(string str)
        {
            await File.WriteAllTextAsync("Result1.txt", str);
        }
        #endregion

    }
}
