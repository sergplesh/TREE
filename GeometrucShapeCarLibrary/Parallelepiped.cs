using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrucShapeCarLibrary
{
    public class Parallelepiped : Rectangle
    {
        // высота параллепипеда
        protected double height;

        // свойство для высоты
        public double Height
        {
            get { return height; }
            set
            {
                if (value >= 0)
                    height = value;
                else
                {
                    height = 1;
                }
            }
        }

        // конструктор без параметров
        public Parallelepiped() : base()
        {
            Height = 1;
        }

        // конструктор с параметрами
        public Parallelepiped(string name, int number, double length, double width, double height) : base(name, number, length, width)
        {
            Height = height;
        }

        // конструктор клонирования
        public Parallelepiped(Parallelepiped s) : base(s)
        {
            Height = s.Height;
        }

        // переопределяем метод Init для наследника от Shape
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите высоту параллелепипеда");
            Height = EnterNumber.EnterDoubleNumber();
        }

        // переопределяем метод RandomInit для наследника от Shape
        public override void RandomInit()
        {
            base.RandomInit();
            Height = rnd.Next(0, 1000);
        }

        // переопределение для преобразования объекта в строку
        public override string ToString()
        {
            return base.ToString() + $", высота {Height}";
        }

        // переопределение Equals
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Parallelepiped? p = obj as Parallelepiped;
            return this.Height == p.Height;
        }

        // обычная функция для просмотра элементов данного класса-наследника (используется явное сокрытие имён с помощью new)
        public new void Show()
        {
            base.Show();
            Console.Write($", высота {Height}");
        }

        // virtual функция для просмотра элементов данного класса-наследника
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.Write($", высота {Height}");
        }

        // интерфейс IClonable
        public override object Clone()
        {
            return new Parallelepiped(Name, id.Number, Length, Width, Height);
        }
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        // хэш-код
        public override int GetHashCode()
        {
            int hashcode = base.GetHashCode();
            hashcode = 31 * hashcode + Height.GetHashCode();
            return hashcode;
        }

        // переопределение метода CompareTo
        public override int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj is not Parallelepiped) return -1;
            Parallelepiped? s = obj as Parallelepiped;
            if (s == null) return -1;
            if (base.CompareTo(obj) == -1)
            {
                return String.Compare(this.Height.ToString(), s.Height.ToString());
            }
            else return base.CompareTo(obj);
        }
    }
}
