using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital2Hyphen
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.Directory.GetFiles(System.Environment.CurrentDirectory).ToList().ForEach((fileName) =>
            {
                string temp = System.IO.Path.GetFileName(fileName);
                if (containsCapital(temp))
                {
                    copyFile(temp, convertFileName(temp));
                }
            });
        }
        static bool containsCapital(string fileName)
        {
            return fileName.Any(c => System.Char.IsUpper(c));
        }
        static string removeWhiteSpace(string fileName)
        {
            return fileName.Aggregate(string.Empty, (accumulate, c) => { return System.Char.IsWhiteSpace(c) ? accumulate : accumulate + c; });
        }
        static string capital2Hyphen(string fileName)
        {
            return fileName.Aggregate(string.Empty, (accumulate, c) => { return System.Char.IsUpper(c) ? accumulate + '-' + System.Char.ToLower(c) : accumulate + c; });
        }
        static string removeHeadingDash(string fileName)
        {
            return fileName.TrimStart(new char[] { '-' });
        }
        static string convertFileName(string fileName)
        {
            return removeHeadingDash(capital2Hyphen(removeWhiteSpace(fileName)));
        }
        static void copyFile(string s, string d)
        {
            System.Console.WriteLine("From " + s + " to " + d);
            try
            {
                System.IO.File.Copy(s, d);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
