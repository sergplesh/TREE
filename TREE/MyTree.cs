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
        public Point<T>? root = null;

        /// <summary>
        /// число записей
        /// </summary>
        int count = 0;

        /// <summary>
        /// число записей
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Конструктор для сбалансированного дерева без параметров
        /// </summary>
        public MyTree()
        {
            count = 0;
            root = null;
        }

        /// <summary>
        /// Конструктор для сбалансированного дерева с параметром (количество элементов в дереве)
        /// </summary>
        /// <param name="lenght">заданное число элементов в создаваемом дереве</param>
        public MyTree(int lenght)
        {
            count = lenght;
            root = MakeTree(lenght, root); // создаём сбалансированное дерево с корнем root
        }

        /// <summary>
        /// Конструктор для сбалансированного дерева (заполненное элементами массива)
        /// </summary>
        /// <param name="array">массив с элементами</param>
        public MyTree(T[] array)
        {
            count = array.Length;
            int current = 0; // номер элемента из массива
            root = MakeTree(array.Length, root, array, ref current); // создаём сбалансированное дерево с корнем root
        }

        /// <summary>
        /// Создание сбаланисированного дерева вручную с помощью массива
        /// </summary>
        /// <param name="lenght">количество элементов в дереве/поддереве</param>
        /// <param name="root">корень дерева/поддерева</param>
        /// <param name="array">массив из элементов</param>
        /// <returns></returns>
        Point<T>? MakeTree(int lenght, Point<T> root, T[] array, ref int current)
        {
            // если число записей в дереве 0 -> возвращаем null-ссылку
            if (lenght == 0)
                return null;

            // создаём информационное поле
            T data = (T)array[current].Clone();
            // создаём элемент дерева с созданным инфо полем
            Point<T> newItem = new(data);
            current++;

            // для сбалансированного дерева поровну распределяем элементы в правое и левое поддеревья
            int left = lenght / 2;
            int right = lenght - left - 1;

            // создаём (тоже сбалансированные) левое и правое поддеревья
            newItem.Left = MakeTree(left, newItem.Left, array, ref current);
            newItem.Right = MakeTree(right, newItem.Right, array, ref current);
            return newItem; // возвращаем корень дерева/поддерева
        }

        /// <summary>
        /// Создание сбаланисированного дерево с рандомными значениями
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
        public bool AddPoint(T item)
        {
            T data = (T)item.Clone(); // выделяем память под элемент

            // с помощью данных двух переменных найдём место в дереве поиска для добавляемого элемента
            Point<T>? point = root;
            Point<T>? current = null;

            if (point == null) // дерево пустое
            {
                Point<T> newPoint = new Point<T>(data); // создаём элемент с заданным инфополем
                root = newPoint; // ставим в корень
                count++; // увеличиваем количество элементов, находящихся в дереве
                return true; // добавление произошло
            }

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
                    if (point.Data.CompareTo(data) > 0) // меньшие - в левое поддерево
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
                Point<T> newPoint = new Point<T>(data); // создаём элемент с заданным инфополем
                // присоединяем к найденному листу current с правильной стороны
                if (current.Data.CompareTo(data) > 0) // если меньше - элемент идёт в левое поддерево
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
                //ОБХОД СВЕРХУ ВНИЗ (ТО ЕСТЬ СНАЧАЛА ЗАПИСЫВАЕМ В МАССИВ КОРЕНЬ, ПОТОМ: ЛЕВОЕ ДЕРЕВО - ПРАВОЕ ДЕРЕВО)
                array[current] = point.Data; // записываем в массив элемент
                current++; // считаем занесённый в массив элемент
                // забрасываем в массив элементы с левого поддерева
                TransformToArray(point.Left, array, ref current);
                // забрасываем в массив элементы с правого поддерева
                TransformToArray(point.Right, array, ref current);
            }
        }

        /// <summary>
        /// Преобразование идеально сбалансированного дерева в дерево поиска
        /// </summary>
        public MyTree<T> TransformToFindTree()
        {
            if (root != null) // если дерево не пустое
            {
                // Собираем все элементы в массив
                T[] array = new T[count]; // в массиве столько элементов, сколько в дереве
                int current = 0;
                TransformToArray(root, array, ref current);

                T[] rootSearchTree = [array[0]]; // это будет корень дерева
                MyTree<T> searchTree = new MyTree<T>(rootSearchTree); // создадим пустое дерево, которое заполним элементами
                                                         // исходного ИСД только уже так, чтобы это было деревом поиска

                // на основе элементов в массиве создаём дерево поиска (добавляя элементы)
                for (int i = 1; i < array.Length; i++)
                {
                    searchTree.AddPoint(array[i]); //добавляем элементы как в дерево поиска
                }
                // возвращаем дерево поиска
                return searchTree;
            }
            else return new MyTree<T>();
        }

        /// <summary>
        /// Удаление элемента из дерева
        /// </summary>
        /// <param name="searched">заданный элемент для удаления</param>
        public bool Remove(T searched)
        {
            if (root == null) // Проверяем, пустое ли дерево
                return false;

            // Ищем элемент для удаления
            Point<T>? parent = null; // элемент перед искомым
            Point<T>? current = root; // эта переменная предназначена для удаляемого элемента 
            // ищем и закончим, когда либо не найдем, дойдя до листа, либо найдём
            while (current != null && !current.Data.Equals(searched))
            {
                parent = current; // запоминаем предыдущий элемент
                if (current.Data.CompareTo(searched) > 0) // если текущий элемент меньше удаляемого
                    current = current.Left; // то идём влево
                else
                    current = current.Right; // иначе - вправо
            }

            // Случай 1: Элемент отсутствует
            if (current == null) // Элемент не найден
                return false;

            // Случай 2: Элемент - лист
            if (current.Left == null && current.Right == null)
            {
                if (parent == null) // Это корень дерева и лист -> единственный элемент в дереве
                    root = null; // обнуляем корень
                else if (parent.Left == current) // если это лист слева от предыдущего
                    parent.Left = null; // то обнуляем левую ссылку предыдущего
                else
                    parent.Right = null; // иначе - правую
            }
            // Случай 3: Элемент имеет только одного ребенка
            else if (current.Left == null || current.Right == null)
            {
                Point<T>? child = current.Left != null ? current.Left : current.Right; // единственная ветвь найденного элемента
                if (parent == null) // если найденный элемент - корень
                    root = child; // то корнем становится его единственный ребёнок
                else if (parent.Left == current) // если искомый находился слева от предыдущего
                    parent.Left = child; // то ребёнка прикрепляем в левую ссылку
                else
                    parent.Right = child; // иначе - в правую
            }
            // Случай 4: Элемент имеет двух детей
            else
            {
                Point<T>? successorParent = current; // элемент перед преемником
                Point<T>? successor = current.Right; // преемник, который встанет на место удаляемого элемента
                while (successor.Left != null) // пока не дойдём до "самого левого"(самого маленького) элемента в правом поддереве от удаляемого
                {
                    successorParent = successor; // элемент перед преемником
                    successor = successor.Left; // преемник
                }
                // Если преемник - не правый ребенок текущего элемента
                if (successorParent != current)
                {
                    successorParent.Left = successor.Right; // преемник может иметь правого ребенка,
                                                            // поэтому мы присваиваем правого ребенка преемника левой ветке предыдущего
                    successor.Right = current.Right; // затем присваиваем правому поддереву преемника правого ребенка удаляемого узла
                }
                // замещение удаляемого узла преемником
                // присоединяем к преемнику левое поддерево
                successor.Left = current.Left;
                // обновление родителя удаляемого узла
                if (parent == null) // если искомый элемент оказался корнем
                    root = successor; // преемник становится корнем
                else if (parent.Left == current) // если найденный элемент находился слева от предыдущего
                    parent.Left = successor; // то меняем левую ссылку у предыдущего
                else
                    parent.Right = successor; // иначе - правую
            }
            count--; // удалили элемент - уменьшили количество записей
            return true; // удаление произошло
        }

        /// <summary>
        /// Удаление дерева
        /// </summary>
        public void Clear()
        {
            root = null; // обнуляем корень
            count = 0; // обнуляем количество записей
        }

        /// <summary>
        /// Метод для подсчета количества листьев в дереве
        /// </summary>
        /// <returns>Количество листьев</returns>
        public int CountLeaves()
        {
            return CountLeaves(root); // вызываем рекурсивый метод для подсчёта листьев во всём дереве
        }

        /// <summary>
        /// Рекурсивный метод для подсчета количества листьев в дереве/поддереве
        /// </summary>
        /// <param name="point">Текущий узел дерева</param>
        /// <returns>Количество листьев</returns>
        private int CountLeaves(Point<T>? point)
        {
            if (point == null) // если дошли до пустого элемента
            {
                return 0; // возвращаем ноль
            }
            if (point.Left == null && point.Right == null) // наткнулись на лист
            {
                return 1; // посчитали
            }
            return CountLeaves(point.Left) + CountLeaves(point.Right); // складываем результаты вызовов рекурсивного метода
        }
    }
}
