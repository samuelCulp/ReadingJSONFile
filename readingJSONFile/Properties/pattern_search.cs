using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using System.IO;

namespace readingJSONFile.Properties
{
    internal class pattern_search
    {



        public static string findPatternPrimary(string line)// this finds the quotations in a file line from json
        {
            string r = "";
            Regex find = new Regex("\".*?\":");// finds the "": which indicates the identifier
            var matches = find.Matches(line);
            if (matches.Count > 0) {
                r = matches[0].Value; }
            return r.ToString();
        }


        public static string findSecondaryPattern(string line)
        {


            string r = "";
            Regex find = new Regex("\".*?,");// finds the "", which indicates the identifier secondary
            var matches = find.Matches(line);
            if (matches.Count > 0) {
                r = matches[0].Value; }
            return r.ToString();
        }




        public static string[][] getMatchingLine(string line, string[] arr1, string[] arr2)
        {
            string[][] jagged = new string[arr1.Length][];
            int i = 0;int j = 0;
            for (i = 0; i < arr1.Length;i++)
            {
                for (j = 0; j < arr2.Length; j++)
                {
                    if (arr2.Contains(line))
                    {

                    }
                }
            }

            return null;

            

        }


        public static string getPattern(string data) {
            string s = "";

            int[]count = new int[data.Length];
            for (int i = 0; i < count.Length; i++)
                if (count[i] > 1)
                    s +=  ", " + "count = " + count[i];
            

           
            return s;
            int wordCount = 0, index = 0;
            string neww = "";
            Regex regex = new Regex(@"\b[ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\""{}[\]:;]\w+");
            MatchCollection matching = regex.Matches(data);
            string matchingstr = "";
            //matchingstr.ToList().ForEach(element => Match match in matching);
            foreach (Match match in matching)
            {
                matchingstr += match.Value + " ";
            }

            while (index < matchingstr.Length && char.IsWhiteSpace(matchingstr[index]))
                index++;

            while (index < matchingstr.Length)
            {
                while (index < matchingstr.Length && !char.IsWhiteSpace(matchingstr[index]))
                    index++;

                wordCount++;

                while (index < matchingstr.Length && char.IsWhiteSpace(matchingstr[index]))
                    index++;

            }

            for (int i = 0; i < matchingstr.Length; i++) { 
            neww += matchingstr[i]; 
        }

            //String.Concat(neww.Distinct());

            var result = string.Join(" ", neww.Split(' ').Distinct());
            
            return result; 
            //return neww.ToString();
            //turn wordCount.ToString();
            //return matchingstr.ToString();
        
        }
    }
}
