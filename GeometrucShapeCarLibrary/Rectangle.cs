using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrucShapeCarLibrary
{
    public class Rectangle : Shape
    {
        // длина и ширина прямоугольника
        protected double length;
        protected double width;

        // свойство для длины
        public double Length
        {
            get { return length; }
            set
            {
                if (value >= 0)
                    length = value;
                else
                {
                    length = 1;
                }
            }
        }

        // свойство для ширины
        public double Width
        {
            get { return width; }
            set
            {
                if (value >= 0)
                    width = value;
                else
                {
                    width = 1;
                }
            }
        }

        public Shape GetBase
        {
            get => new Shape(this.Name, this.id.Number);//возвращает объект базового класса
        }

        // конструктор без параметров
        public Rectangle() : base()
        {
            Length = 1;
            Width = 1;
        }

        // конструктор с параметрами
        public Rectangle(string name, int number, double length, double width) : base(name, number)
        {
            Length = length;
            Width = width;
        }

        // конструктор клонирования
        public Rectangle(Rectangle s) : base(s)
        {
            Length = s.Length;
            Width = s.Width;
        }

        // переопределяем метод Init для наследника от Shape
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите длину прямоугольника");
            Length = EnterNumber.EnterDoubleNumber();
            Console.WriteLine("введите ширину прямоугольника");
            Width = EnterNumber.EnterDoubleNumber();
        }

        // переопределяем метод RandomInit для наследника от Shape
        public override void RandomInit()
        {
            base.RandomInit();
            Length = rnd.Next(0, 1000);
            Width = rnd.Next(0, 1000);
        }

        // переопределение для преобразования объекта в строку
        public override string ToString()
        {
            return base.ToString() + $", длина {Length}, ширина {Width}";
        }

        // переопределение Equals
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Rectangle? r = obj as Rectangle;
            return this.Length == r.Length && this.Width == r.Width;
        }

        // обычная функция для просмотра элементов данного класса-наследника (используется явное сокрытие имён с помощью new)
        public new void Show()
        {
            base.Show();
            Console.Write($", длина {Length}, ширина {Width}");
        }

        // virtual функция для просмотра элементов данного класса-наследника
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.Write($", длина {Length}, ширина {Width}");
        }

        // метод, вычисляющий площадь прямоугольника
        public override double GetArea()
        {
            return Length * Width;
        }

        // интерфейс IClonable
        public override object Clone()
        {
            return new Rectangle(Name, id.Number, Length, Width);
        }
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        // хэш-код
        public override int GetHashCode()
        {
            int hashcode = base.GetHashCode();
            hashcode = 31 * hashcode + Length.GetHashCode();
            hashcode = 31 * hashcode + Width.GetHashCode();
            return hashcode;
        }

        // переопределение метода CompareTo
        public override int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj is not Rectangle) return -1;
            Rectangle? s = obj as Rectangle;
            if (s == null) return -1;
            if (base.CompareTo(obj) == -1)
            {
                if (this.Length != s.Length) return String.Compare(this.Length.ToString(), s.Length.ToString());
                else if (this.Width != s.Width) return String.Compare(this.Width.ToString(), s.Width.ToString());
                else return -1;
            }
            else return base.CompareTo(obj);
        }
    }
}
