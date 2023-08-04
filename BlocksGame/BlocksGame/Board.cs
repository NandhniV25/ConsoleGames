using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlocksGame
{
    public class Board
    {
        //Board Property
        public int width, height, points;
        Random random = new Random();
        Block block;
        List<Block> blocks = new List<Block>();

        //Board Constructor
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.block = new Block(random.Next(width), 0, '*', ConsoleColor.DarkRed);
        }

        //Board Methods
        public void Read()
        {
            while (true)
            {
                var input = Console.ReadKey(true).Key;


                if (input == ConsoleKey.LeftArrow && block.x > 0)
                {
                    MoveBlockLR(-1, 0);
                }
                else if (input == ConsoleKey.RightArrow && block.x < width - 1)
                {
                    MoveBlockLR(1, 0);
                }
            }
        }

        public void MoveBlockLR(int x, int y)
        {
            block.Clear();
            block.x += x;
            block.y += y;
            block.Print();
        }

        public void Play()
        {
            block.Print();
            var isGameOver = false;

            while(!isGameOver)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, height + 2);
                Console.Write("Points = " + points);
                Console.ForegroundColor = ConsoleColor.White;
                //Block goes down until it touches the height or list of block touches 
                if ((block.y != height - 1) && !blocks.Any(item => item.x == block.x && item.y == block.y + 1))
                {
                    block.Clear();
                    block.MoveDown();
                    block.Print();
                }
                else
                {
                    //not possible to movedown and block creates on position 0
                    if (block.y == 0)
                    {
                        block.Print();
                        Console.SetCursorPosition(0, height + 4);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("GameOver");
                        Console.ForegroundColor = ConsoleColor.White;
                        isGameOver = true;
                        break;
                    }
                    block.ch = '@';
                    block.color = ConsoleColor.DarkGreen;
                    block.Print();
                    blocks.Add(block);
                    block = new Block(random.Next(width), 0, '*', ConsoleColor.DarkRed);
                    ClearRow();
                }
                Thread.Sleep(100);
            }
        }
        public void ClearRow()
        {
            for (int y = 0; y < height; y++)
            {
                var isRowFull = true;
                for (int x = 0; x < width; x++)
                {
                    if (!blocks.Any(item => item.x == x && item.y == y))
                    {
                        isRowFull = false;
                        break;
                    }
                }
                if(isRowFull)
                {
                    blocks.ForEach(item =>
                    {
                        if (item.y == y)
                        {
                            item.Clear();
                        }
                    });
                    blocks.RemoveAll(item => item.y == y);
                    blocks.ForEach(item =>
                    {
                        item.Clear();
                        item.y += 1;
                        item.Print();
                    });
                    points += 10;
                }
            }
        }
    }
}
