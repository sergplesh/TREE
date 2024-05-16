using GeometrucShapeCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TREE
{
    /// <summary>
    /// сбалансированное дерево / дерево поиска
    /// </summary>
    /// <typeparam name="T">Обобщённый тип данных</typeparam>
    public class MyTree<T> where T : IInit, ICloneable, IComparable, new()
    {
        /// <summary>
        /// корень дерева
        /// </summary>
        Point<T>? root = null;

        /// <summary>
        /// число записей
        /// </summary>
        int count = 0;

        /// <summary>
        /// число записей
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Конструктор для сбалансированного дерева
        /// </summary>
        /// <param name="lenght">заданное число элементов в создаваемом дереве</param>
        public MyTree(int lenght)
        {
            count = lenght;
            root = MakeTree(lenght, root); // создаём сбалансированное дерево с корнем root
        }

        /// <summary>
        /// Создание сбаланисированного дерево
        /// </summary>
        /// <param name="lenght">количество элементов в дереве/поддереве</param>
        /// <param name="root">корень дерева/поддерева</param>
        /// <returns></returns>
        Point<T>? MakeTree(int lenght, Point<T> root)
        {
            // если число записей в дереве 0 -> возвращаем null-ссылку
            if (lenght == 0)
                return null;

            // создаём информационное поле
            T data = new T();
            data.RandomInit(); // инициализируем
            // создаём элемент дерева с созданным инфо полем
            Point<T> newItem = new(data);

            // для сбалансированного дерева поровну распределяем элементы в правое и левое поддеревья
            int left = lenght / 2;
            int right = lenght - left - 1;

            // создаём (тоже сбалансированные) левое и правое поддеревья
            newItem.Left = MakeTree(left, newItem.Left);
            newItem.Right = MakeTree(right, newItem.Right);
            return newItem; // возвращаем корень дерева/поддерева
        }

        /// <summary>
        /// Метод для выполнения печати (с проверкой на пустое дерево)
        /// </summary>
        public void ShowTree()
        {
            if (count == 0)
            {
                Console.WriteLine("Дерево пустое!");
            }
            else Show(root);
        }

        /// <summary>
        /// Вывод дерева на печать
        /// </summary>
        /// <param name="point">элемент дерева</param>
        /// <param name="spaces">отступы между уровнями дерева</param>
        void Show(Point<T>? point, int spaces = 5)
        {
            // если элемент существует - выводим
            if (point != null)
            {
                // сначала выводим левое поддерево
                Show(point.Left, spaces + 5);
                // делаем отступы
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                // выводим сам элемент(инфополе)
                Console.WriteLine(point.Data);
                // выводим правое поддерево
                Show(point.Right, spaces + 5);
            }
        }

        /// <summary>
        /// Добавление в дерево поиска
        /// </summary>
        /// <param name="data">добавляемое инфополе</param>
        public bool AddPoint(T data)
        {
            // с помощью данных двух переменных найдём место в дереве поиска для добавляемого элемента
            Point<T>? point = root;
            Point<T>? current = null;

            bool isExist = false; // с помощью данной переменной будем проверять, есть ли добавляемый элемент уже в дереве;
                                  // если уже есть - не добавляем

            // пока не дойдём до листа (и найдём место для добавляемого элемента)
            // или пока не найдём идентичный добавляемому элемент (и не будем добавлять)
            while (point != null && !isExist)
            {
                current = point;
                // если нашли такой же элемент в дереве
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else
                {
                    // движемся дальше по дереву
                    if (point.Data.CompareTo(data) < 0) // меньшие - в левое поддерево
                    {
                        point = point.Left;
                    }
                    else // бОльшие - в правое поддерево
                    {
                        point = point.Right;
                    }
                }
            }

            if (isExist) // Элемент уже есть в дереве - не добавляем
                return false; // добавление не произошло
            else // Добавляем элемент на своё место
            {
                Point<T> newPoint = new(data); // создаём элемент с заданным инфополем
                // присоединяем к найденному листу current с правильной стороны
                if (current.Data.CompareTo(data) < 0) // если меньше - элемент идёт в левое поддерево
                    current.Left = newPoint;
                else // если больше - в правое
                    current.Right = newPoint;
                count++; // увеличиваем количество элементов, находящихся в дереве
                return true; // добавление произошло
            }
        }

        /// <summary>
        /// Преобразование дерева в массив
        /// </summary>
        /// <param name="point">элемент дерева</param>
        /// <param name="array">массив для элементов дерева</param>
        /// <param name="current">счётчик элементов в дереве</param>
        void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null) // элемент существует
            {
                // забрасываем в массив элементы с левого поддерева
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data; // записываем в массив элемент
                current++; // считаем занесённый в массив элемент
                // забрасываем в массив элементы с правого поддерева
                TransformToArray(point.Right, array, ref current);
            }
        }

        /// <summary>
        /// Преобразование идеально сбалансированного дерева в дерево поиска
        /// </summary>
        public MyTree<T> TransformToFindTree()
        {
            // Собираем все элементы в массив
            T[] array = new T[count]; // в массиве столько элементов, сколько в дереве
            int current = 0;
            TransformToArray(root, array, ref current);

            MyTree<T> searchTree = new MyTree<T>(0); // создадим пустое дерево, которое заполним элементами
                                                     // исходного ИСД только уже так, чтобы это было деревом поиска

            // на основе элементов в массиве создаём дерево поиска (добавляя элементы)
            searchTree.root = new Point<T>(array[0]);
            searchTree.count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                searchTree.AddPoint(array[i]); //добавляем элементы как в дерево поиска
            }
            // возвращаем дерево поиска
            return searchTree;
        }

        /// <summary>
        /// Удаление элемента из дерева
        /// </summary>
        /// <param name="searched">заданный элемент для удаления</param>
        /// <returns></returns>
        public bool Remove(T searched)
        {
            if (root == null) // Проверяем, пустое ли дерево
                return false;

            // Ищем элемент для удаления
            Point<T>? parent = null;
            Point<T>? current = root;
            while (current != null && !current.Data.Equals(searched))
            {
                parent = current;
                if (current.Data.CompareTo(searched) < 0)
                    current = current.Right;
                else
                    current = current.Left;
            }

            // Случай 1: Элемент отсутствует
            if (current == null) // Элемент не найден
                return false;

            // Случай 2: Элемент - лист
            if (current.Left == null && current.Right == null)
            {
                if (parent == null) // Это корень дерева
                    root = null;
                else if (parent.Left == current)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            // Случай 3: Элемент имеет только одного ребенка
            else if (current.Left == null || current.Right == null)
            {
                Point<T>? child = current.Left != null ? current.Left : current.Right;
                if (parent == null)
                    root = child;
                else if (parent.Left == current)
                    parent.Left = child;
                else
                    parent.Right = child;
            }
            // Случай 4: Элемент имеет двух детей
            else
            {
                Point<T>? successorParent = current;
                Point<T>? successor = current.Right;
                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }

                // Если преемник - не правый ребенок текущего элемента
                if (successorParent != current)
                {
                    successorParent.Left = successor.Right;
                    successor.Right = current.Right;
                }

                successor.Left = current.Left;

                if (parent == null)
                    root = successor;
                else if (parent.Left == current)
                    parent.Left = successor;
                else
                    parent.Right = successor;
            }

            count--;
            return true;
        }





        //public int SearchLeaves()
        //{
        //    // с помощью данных двух переменных найдём место в дереве поиска для добавляемого элемента
        //    Point<T>? point = root;
        //    Point<T>? current = null;

        //    bool isExist = false; // с помощью данной переменной будем проверять, есть ли добавляемый элемент уже в дереве;
        //                          // если уже есть - не добавляем

        //    // пока не дойдём до листа (и найдём место для добавляемого элемента)
        //    // или пока не найдём идентичный добавляемому элемент (и не будем добавлять)
        //    while (point != null && !isExist)
        //    {
        //        current = point;
        //        // если нашли такой же элемент в дереве
        //        if (point.Data.CompareTo(data) == 0)
        //        {
        //            isExist = true;
        //        }
        //        else
        //        {
        //            // движемся дальше по дереву
        //            if (point.Data.CompareTo(data) < 0) // меньшие - в левое поддерево
        //            {
        //                point = point.Left;
        //            }
        //            else // бОльшие - в правое поддерево
        //            {
        //                point = point.Right;
        //            }
        //        }
        //    }
        //}
    }
}
