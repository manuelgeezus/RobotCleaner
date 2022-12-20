using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RobotCleaner.Interfaces;

namespace RobotCleaner
{
    public class Robot : iRobot
    {
        public string  currentDirection = robotDirections.right.ToString();
        public int currentN = 0;
        public int currentM = 0;
        public List<string> cleanedList = new List<string>();
        public char[][] Board { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Robot()
        {
        }
        public Robot(int columns, int rows, char[][] board)
        {
            Board = board;
            Rows = rows;
            Columns = columns;
        }
        public int clean()
        {
            bool finishClean = false;
            //Console.WriteLine("Columns: "+this.Columns +", Rows: " + this.Rows);

            while(!finishClean)
            {
                if(currentM >= this.Columns || currentN >= this.Rows || currentN < 0 || currentM < 0)
                {
                    //Console.WriteLine("OutOfBorder: "+ currentN+","+currentM);
                    turn();
                }
                //Console.WriteLine("Current Position: " + currentN+","+currentM+", Val: "+Board[currentN][currentM]);
                if(Board[currentN][currentM] == '.')
                {
                    cleanedList.Add(currentN+","+currentM);
                    move();
                }
                else
                {
                    turn();
                }

                if(cleanedList.Count() >= (this.Columns*this.Rows))
                {
                    finishClean = true;
                }
            }

            return (from x in cleanedList select x).Distinct().Count();
        }
        public void move()
        {
            switch(this.currentDirection)
            {
                case "right":
                    currentM++;
                    break;
                case "down":
                    currentN++;
                    break;
                case "left":
                    currentM--;
                    break;
                case "up":
                    currentN--;
                    break;
            }
        }
        public void turn()
        {
            switch(this.currentDirection)
            {
                case "right":
                    currentM--;
                    this.currentDirection = robotDirections.down.ToString();
                    break;
                case "down":
                    currentN--;
                    this.currentDirection = robotDirections.left.ToString();
                    break;
                case "left":
                    currentM++;
                    this.currentDirection = robotDirections.up.ToString();
                    break;
                case "up":
                    currentN++;
                    this.currentDirection = robotDirections.right.ToString();
                    break;
            }
        }
    }
    public enum robotDirections
    {
        up,
        down,
        left,
        right
    }
}
