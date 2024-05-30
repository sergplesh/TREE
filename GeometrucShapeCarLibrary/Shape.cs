using System.Text.RegularExpressions;

namespace GeometrucShapeCarLibrary
{
    public class IdNumber
    {
        private int number; // id

        // свойство id
        public int Number
        {
            get { return number; }
            set
            {
                if (value >= 0)
                    number = value;
                else
                {
                    number = 0;
                }
            }
        }

        public IdNumber() // конструктор без параметров
        {
            Number = 0;
        }
        public IdNumber(int number) // конструктор с параметрами
        {
            Number = number;
        }

        // переопределение для преобразования объекта в строку
        public override string ToString()
        {
            return $"id {Number}: ";
        }

        // переопределение Equals
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            IdNumber? c = obj as IdNumber;
            if (c != null)
                return c.Number == this.Number;
            else
                return false;
        }
    }

    public class Shape : IInit, IComparable, ICloneable, INameEquatable
    {
        protected static Random rnd = new Random(); // рандом

        // id - ссылочное поле
        public IdNumber id;
        //назвавание фигуры
        protected string name;

        // массив для рандомного названия фигуры
        static string[] Names = { "ABCD", "ABC", "O", "HELP", "OPRST", "URL", "abcd", "BbCc", "bublic", "Buble", "Gogol", "Pushkin", "Tolstoi", "Chehov" };

        // свойство для названия фигуры
        public string Name
        {
            get { return name; }
            set
            {
                Regex pattern1 = new Regex(@"^[А-Яа-я]{1}[0-9А-Яа-я-]*$"); // название на русском
                Regex pattern2 = new Regex(@"^[A-Za-z]{1}[0-9A-Za-z-]*$"); // название на английском
                bool isMatch1 = pattern1.IsMatch(value);
                bool isMatch2 = pattern2.IsMatch(value);
                if (isMatch1 || isMatch2)
                {
                    name = value;
                }
                else
                {
                    name = "NoName";
                }
            }
        }

        // конструктор без параметра
        public Shape()
        {
            Name = "NoName";
            id = new IdNumber();
        }

        // конструктор с параметрами
        public Shape(string name, int number)
        {
            Name = name;
            id = new IdNumber(number);
        }

        // конструктор клонирования
        public Shape(Shape s)
        {
            Name = s.Name;
            id = new (s.id.Number);
        }

        // инициализация вручную (даём фигуре название)
        public virtual void Init()
        {
            Console.WriteLine("введите название геометрической фигуры");
            Name = Console.ReadLine();
            Console.WriteLine("введите номер id");
            id.Number = EnterNumber.EnterIntNumber();
        }

        // рандомное заполнение из массива с названиями
        public virtual void RandomInit()
        {
            Name = Names[rnd.Next(Names.Length)];
            id.Number = rnd.Next(0, 1000);
        }

        // переопределение для преобразования объекта в строку
        public override string ToString()
        {
            return $"{id}" + Name;
        }

        // переопределение Equals
        public override bool Equals(object? obj)
        {
            // AS ПРОХОДИТ ДЛЯ ПРОИЗВОДНЫХ, НАПРИМЕР (ID 2, N)(БАЗ) И (ID 2, N, 2, 2)(ПРОИЗВОД) - ЧТО НЕВЕРНО
            //if (obj == null) return false;
            //Shape? s = obj as Shape;
            //if (s != null) return this.Name == s.Name && this.id.Equals(s.id);
            //else return false;

            // TYPEOF (с переброской с производного equals на базовый) НЕ ПРОХОДИТ ДЛЯ ПРОИЗВОДНЫХ НИКОГДА
            //if (typeof(Shape) == obj?.GetType())
            //{
            //    Shape? s = obj as Shape;
            //    if (s != null) return this.Name == s.Name && this.id.Equals(s.id);
            //    else return false;
            //}
            //else return false;

            if (obj == null || GetType() != obj.GetType())
                return false;
            Shape? s = obj as Shape;
            return this.Name == s.Name && this.id.Equals(s.id);
        }

        // обычная функция для просмотра элементов данного базового класса Shape
        public void Show()
        {
            Console.Write($"{id}" + Name);
        }

        // virtual функция для просмотра элементов данного базового класса Shape
        public virtual void ShowVirtual()
        {
            Console.Write($"{id}" + Name);
        }

        // площадь фигуры (так как у класса Shape нет численных атрибутов для вычисления площади, то считаем её равной -1)
        public virtual double GetArea()
        {
            return -1.0;
        }

        // определение метода CompareTo
        public virtual int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj is not Shape) return -1;
            Shape? s = obj as Shape;
            if (s == null) return -1;
            //return String.Compare(this.Name, s.Name);
            if (this.id.Number != s.id.Number) return (this.id.Number).CompareTo(s.id.Number);
            //if (this.id.Number != s.id.Number) return String.Compare(this.id.Number.ToString(), s.id.Number.ToString());
            else if (this.Name != s.Name) return String.Compare(this.Name, s.Name);
            else return 0;
        }

        // интерфейс IClonable
        public virtual object Clone()
        {
            return new Shape(Name, id.Number);
        }
        public virtual object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        // хэш-код
        public override int GetHashCode()
        {
            int hashcode = id.Number.GetHashCode();
            hashcode = 31 * hashcode + Name.GetHashCode();
            return hashcode;
        }

        // Равенство объектов через название
        public bool NameEquals(object? obj)
        {
            if (obj == null) return false;
            Shape? s = obj as Shape;
            if (s != null) return this.Name == s.Name;
            else return false;
        }
    }
}