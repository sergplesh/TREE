using GeometrucShapeCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TREE
{
    /// <summary>
    /// Элемент дерева
    /// </summary>
    /// <typeparam name="T">Обобщённый тип данных</typeparam>
    public class Point<T> where T: IComparable
    {
        /// <summary>
        /// Информационное поле
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        /// Ссылка на левое поддерево
        /// </summary>
        public Point<T>? Left { get; set; }
        /// <summary>
        /// Ссылка на правое поддерево
        /// </summary>
        public Point<T>? Right { get; set; }

        /// <summary>
        /// Конструктор элемента дерева (без параметров)
        /// </summary>
        public Point()
        {
            Data = default(T); // инфополе отсутствует
            Left = null;
            Right = null;
        }
        /// <summary>
        /// Конструктор элемента дерева (с параметрами)
        /// </summary>
        /// <param name="data">заданное инфополе</param>
        public Point(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Печать элемента дерева
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Data == null ? "" : Data.ToString(); // если элемента нет - ничего не выводим, пустая строка
        }

        /// <summary>
        /// Сравнение элементов дерева между собой
        /// </summary>
        /// <param name="other">сторонний элемент дерева</param>
        /// <returns></returns>
        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data); // сравниваем инфополя элементов
        }
    }
}
