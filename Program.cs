using System;
using System.Globalization;
using System.Linq;

namespace RobotCleaner
{
    class Program : Robot
    {
        static void Main(string[] args)
        {
            //6
            //string inputString = "...x..,....xx,..x...";
            //4
            //string inputString = "..x...,...xx.,.x..x.,.xx...,.xxx..,......";
            //24
            //string inputString = "......,x.x...,....x.,.x....,...x..,......";
            //string inputString = ".X.";
            string[] lines = System.IO.File.ReadAllLines(@"BoardsTesting.txt");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t" + line);
                string[] board = line.Split(',');
                Console.WriteLine("Cleaned Squares: " + solution(board));
            }
        }

        public static int solution(string[] R)
        {
            char[][] result = R.Select(item => item.ToArray()).ToArray();
            Robot rob = new Robot(R[0].Length, R.Count(), result);
            return rob.clean();
        }
    }
}