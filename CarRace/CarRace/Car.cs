using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Car
    {
        //Car Property
        public int x, y;
        public char ch;
        public ConsoleColor color;

        //Car Constructor
        public Car(int x, int y, char ch, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.color = color;
        }

        //Car Methods
        public void MoveDown()
        {
            y = y + 1;
        } 

        public void Print()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(ch);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
