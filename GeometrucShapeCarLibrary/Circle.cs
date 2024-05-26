using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrucShapeCarLibrary
{
    public class Circle : Shape
    {
        // радиус окружности
        protected double radius;

        // свойство для радиуса
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                {
                    radius = 1;
                }
            }
        }

        // конструктор без параметра
        public Circle() : base()
        {
            Radius = 1;
        }

        // конструктор с параметрами
        public Circle(string name, int number, double radius) : base(name, number)
        {
            Radius = radius;
        }

        // конструктор клонирования
        public Circle(Circle s) : base(s)
        {
            Radius = s.Radius;
        }

        // переопределяем метод Init для наследника от Shape
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите радиус окружности");
            Radius = EnterNumber.EnterDoubleNumber();
        }

        // переопределяем метод RandomInit для наследника от Shape
        public override void RandomInit()
        {
            base.RandomInit();
            Radius = rnd.Next(0, 1000);
        }

        // метод, вычисляющий площадь окружности
        public override double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        // переопределение для преобразования объекта в строку
        public override string ToString()
        {
            return base.ToString() + $", радиус {Radius}";
        }

        // переопределение Equals
        public override bool Equals(object? obj)
        {
            // AS ПРОХОДИТ ДЛЯ ПРОИЗВОДНЫХ, НАПРИМЕР (ID 2, N)(БАЗ) И (ID 2, N, 2, 2)(ПРОИЗВОД) - ЧТО НЕВЕРНО
            //if (base.Equals(obj))
            //{
            //    Circle? c = obj as Circle;
            //    if (c != null) return c.Radius == this.Radius;
            //    else return false;
            //}
            //else return false;

            // TYPEOF (с переброской с производного equals на базовый) НЕ ПРОХОДИТ ДЛЯ ПРОИЗВОДНЫХ НИКОГДА
            //if (base.Equals(obj))
            //{
            //    if (typeof(Circle) == obj?.GetType())
            //    {
            //        Circle? c = obj as Circle;
            //        if (c != null) return c.Radius == this.Radius;
            //        else return false;
            //    }
            //    else return false;
            //}
            //else return false;

            if (obj == null || GetType() != obj.GetType())
                return false;
            Circle? c = obj as Circle;
            return c.Radius == this.Radius;
        }

        // обычная функция для просмотра элементов данного класса-наследника (используется явное сокрытие имён с помощью new)
        public new void Show()
        {
            base.Show();
            Console.Write($", радиус {Radius}");
        }

        // virtual функция для просмотра элементов данного класса-наследника
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.Write($", радиус {Radius}");
        }

        // интерфейс IClonable
        public override object Clone()
        {
            return new Circle(Name, id.Number, Radius);
        }
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        // хэш-код
        public override int GetHashCode()
        {
            int hashcode = base.GetHashCode();
            hashcode = 31 * hashcode + Radius.GetHashCode();
            return hashcode;
        }

        // переопределение метода CompareTo
        public override int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj is not Circle) return -1;
            Circle? s = obj as Circle;
            if (s == null) return -1;
            if (base.CompareTo(obj) == -1)
            {
                return String.Compare(this.Radius.ToString(), s.Radius.ToString());
            }
            else return base.CompareTo(obj);
        }
    }
}
