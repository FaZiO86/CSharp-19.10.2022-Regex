using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Regex_n_LINQ {
    

    class ReadFile{
        
        public string readText(string text,ref string str) {
            
            StreamReader f = new StreamReader(text);
            while (!f.EndOfStream) {
                str = f.ReadLine();
                
            }
            f.Close();
            return str;

        }
        public string readPattern(string pattern, ref string str) {
            StreamReader f = new StreamReader(pattern);
            while (!f.EndOfStream) {
                str = f.ReadLine();

            }
            f.Close();
            return str;
            
        }
    }
    internal class Program
    {
        
        static MatchCollection myRegex(string input, string pattern, string replacement = "заменено")
        {
            // \d{4}[./]\d{1,2}[./]\d{1,2} - YYYY.MM.DD
            // \d{1,2}[./]\d{1,2}[./]\d{4} - DD.MM.YYYY
            // pattern001 = @"\d{4}[./]\d{1,2}[./]\d{1,2}";
            // pattern002 = @"\d{1,2}[./]\d{1,2}[./]\d{4}";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            Console.WriteLine(Regex.Replace(input, pattern, replacement));
            
            return matches;
        }
        static void PrintMatches(MatchCollection matches)
        {
            StreamWriter output = new StreamWriter("output.txt");
            
            
            foreach (var item in matches)
            {
                output.WriteLine(item.ToString());
                Console.WriteLine(item);
            }
            output.Close();
        }
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////
            string input = "";
            string myPattern = "";
            ReadFile read = new ReadFile();
            

            read.readText(args[0],ref input);
            //Console.WriteLine(input);
            read.readPattern(args[1],ref myPattern);
            //Console.WriteLine(myPattern);
            String[] words = myPattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            ////////////////////////////////////////////////////////////////
            string text, pattern001, pattern002 = "";
            try
            {
                text = input;
                pattern001 = words[0];
                try
                {
                    pattern002 = words[1];
                }
                catch
                {
                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Введите текст:");
                text = Console.ReadLine();
                Console.WriteLine("Введите шаблон поиска (RegEx):");
                pattern001 = Console.ReadLine();  
            }
            
            PrintMatches(myRegex(text, pattern001));
            if (pattern002 != "")
            {
                PrintMatches(myRegex(text, pattern002));
            }
            Console.ReadKey();
        }
    }
}
