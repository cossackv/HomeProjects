using System;
using System.Collections.Generic;
using System.IO;


namespace Projects.IOTextReader
{
    public static class RunApp
    {
        public static void RunIOTextReader()
        {
            Reader reader = new Reader();
            var text = reader.GetCleanArrText();
            Console.WriteLine();
            var dc = reader.SortAnDictionaryInit();
            var strResult = reader.DictToStr(dc);
            File.WriteAllText(@"C:\Users\dmytr\source\repos\HomeProjects\Projects\Projects\IOTextReader\Result.txt", strResult);
            


        }
    }
}
