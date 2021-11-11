using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();

            for (int i = 0; i < length; i++) 
            {
                //берем точку хвоста
                Point p = new Point(tail);
                //перемещаем ее на i единиц по направлению direction
                p.Move(i, direction);
                //добавляем точку, чтобы отрисовать
                pList.Add(p);
            }
        }
        internal void Move()
        {
            //First - возвращает первый элемент списка
            Point tail = pList.First();
            pList.Remove(tail);
            //после работы GetNextPoint в head записываются новые координаты головы змейки
            Point head = GetNextPoint();
            //добавляем в список
            pList.Add(head);

            //зачищаем консоль, чтобы отобразить актуальное положение змейки (метод вызывается для хвостовой точки)
            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            //получаем текущее положение головы змейки
            Point head = pList.Last();
            //создаем копию этой точки
            Point nextPoint = new Point(head);
            //сдвигаем эту копию по направлению direction
            nextPoint.Move(1, direction);
            //записываем в head значние nextPoint
            return nextPoint;
        }

        public void HandleKey (ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow) direction = Direction.LEFT;
            if (key == ConsoleKey.RightArrow) direction = Direction.RIGHT;
            if (key == ConsoleKey.DownArrow) direction = Direction.DOWN;
            if (key == ConsoleKey.UpArrow) direction = Direction.UP;
        }
    }
}
