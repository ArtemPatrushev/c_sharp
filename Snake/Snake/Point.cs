using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        //конструктор, void здесь не указывается, потому что конструктор никогда ничего не возвращает
        public Point()
        {
        }

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        //конструктор, при помощи которого мы задаем точки при помощи другой точки
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        //метод для реализации движения
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT) x = x + offset;
            else if (direction == Direction.LEFT) x = x - offset;
            else if (direction == Direction.UP) y = y - offset;
            else if (direction == Direction.DOWN) y = y + offset;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
