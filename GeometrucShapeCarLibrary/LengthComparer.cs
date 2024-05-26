using System;
using System.Collections; // УБИРАЕМ Generic
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrucShapeCarLibrary
{
    public class LengthComparer: IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            // проверяем, не имеют ли объекты нулевые ссылки
            if (obj1 == null & obj2 == null) return 0;
            if (obj1 == null & obj2 != null) return -1;
            if (obj1 != null & obj2 == null) return 1;
            //if (obj1 is not Rectangle || obj2 is not Rectangle) return -1; // данное условие автоматически выполняет ? после Rectangle в следующих двух строчках
            // приведение к типу Rectangle
            Rectangle? s1 = obj1 as Rectangle;
            Rectangle? s2 = obj2 as Rectangle;
            // проверим все случаи неудачного преобразования одного из объектов или обоих к типу Rectangle
            if (s1 == null & s2 == null) return 0;
            if (s1 == null & s2 != null) return -1;
            if (s1 != null & s2 == null) return 1;
            // сравниваем длину, если оба объекта получилось преобразовать к Rectangle
            if (s1.Length < s2.Length) return -1;
            else if (s1.Length == s2.Length) return 0;
            else return 1;
        }
    }
}
