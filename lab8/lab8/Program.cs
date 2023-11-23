
using System.Text.RegularExpressions;

namespace lab8
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter text");
            string example = "";
            string temp;
            do{
                temp = Console.ReadLine();
                example += "\n"+temp;
            } while (temp != "");
            string pattern = @"Інформатика.+";
            int c = 0;
            foreach (Match match in Regex.Matches(example, pattern).Cast<Match>())
            {
                Console.WriteLine("Match at {0} contains: {1}",match.Index,match.Value);
                c++;
            }
            Console.WriteLine("The amount of matches is {0}",c);
        }
    }
}