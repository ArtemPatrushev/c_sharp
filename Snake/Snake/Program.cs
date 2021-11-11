using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            //отрисовка рамки
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            upLine.Draw();
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            downLine.Draw();
            VerticalLine leftLine = new VerticalLine(24, 0, 0, '+');
            leftLine.Draw();
            VerticalLine RightLine = new VerticalLine(24, 0, 78, '+');
            RightLine.Draw();

            //отрисовка точек - начало хвоста змейки
            Point p = new Point(4, 5, '*');
            //рисуем змейку
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            //snake.Move();

            while (true)
            {
                //определеляем была ли нажата клавиша
                if (Console.KeyAvailable)
                {
                    //определяем, какая клавиша была нажата
                    ConsoleKeyInfo key = Console.ReadKey();
                    //вызываем функцию из snake, которая определит направление движения в зивисимости от надатой клавиши
                    snake.HandleKey(key.Key);
                }
                //после того, как направление змейке определилось, задержка на 100 млсек
                System.Threading.Thread.Sleep(100);
                //смена направления движения
                snake.Move();
            }

            //Console.ReadLine();
        }
    }
}
