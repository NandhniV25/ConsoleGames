using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Board
    {
        //Board Property
        public int width, height, points;
        Random random = new Random();
        Car UserCar;
        List<Car> EnemyCar=new List<Car>();

        //Board Constructor
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.UserCar = new Car(width / 2, height - 1, '*', ConsoleColor.DarkGreen);
        }

        //Board Methods
        public void Read()
        {
            while(true)
            {
                var input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.LeftArrow && UserCar.x>0)
                {
                    MoveCar(-1, 0);
                }
                else if (input == ConsoleKey.RightArrow && UserCar.x < width-1)
                {
                    MoveCar(1, 0);
                }
            }
        }

        public void MoveCar(int x, int y)
        {
            UserCar.Clear();
            UserCar.x += x;
            UserCar.x += y;
            UserCar.Print();
        }

        public void Play()
        {
            UserCar.Print();
            var isGameOver = false;
            while(!isGameOver)
            {
                Console.SetCursorPosition(0, height + 2);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Points = " + points);
                Console.ForegroundColor = ConsoleColor.White;

                EnemyCar.Add(new Car(random.Next(width),0,'#',ConsoleColor.DarkRed));

                foreach(var each in EnemyCar)
                {
                    each.Clear();
                    each.MoveDown();

                    if(each.y != height)
                    {
                        each.Print();
                    }
                    else
                    {
                        if(each.x == UserCar.x)
                        {
                            Console.SetCursorPosition(0, height + 4);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("GameOver");
                            Console.ForegroundColor = ConsoleColor.White;

                            isGameOver = true;
                            break;
                        }
                        else
                        {
                            points += 10;
                        }
                    }
                }
                EnemyCar.RemoveAll(item => item.y == height);
                Thread.Sleep(500);
            }
        }
    }
}
