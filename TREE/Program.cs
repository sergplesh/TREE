using GeometrucShapeCarLibrary;
using System;

namespace TREE
{
    internal class Program
    {
        // выбор фигуры для добавления/удаления/поиска
        public static void MenuChoise(ref Shape obj)
        {
            int answer;
            //do
            //{
            Console.WriteLine("1.Неопределённую фигуру");
            Console.WriteLine("2.Прямоугольник");
            Console.WriteLine("3.Параллелепипед");
            Console.WriteLine("4.Окружность");
            Console.WriteLine("0.Выбор сделан - закрыть меню");
            Console.WriteLine("Выберите фигуру");
            answer = EnterNumber.EnterIntNumber(); // выбираем действие
            switch (answer)
            {
                case 1: // первый выбор
                    {
                        obj = new Shape();
                        break;
                    }
                case 2: // второй выбор
                    {
                        obj = new Rectangle();
                        break;
                    }
                case 3: // третий выбор
                    {
                        obj = new Parallelepiped();
                        break;
                    }
                case 4: // третий выбор
                    {
                        obj = new Circle();
                        break;
                    }
                case 0: // программа продолжит работу
                    {
                        Console.WriteLine("Выбор закрыт");
                        break;
                    }
                default: // введённое число не подошло ни к одному пункту
                    {
                        Console.WriteLine("Неправильно задан пункт меню. По умолчанию выбрана неопределённая фигура.");
                        break;
                    }
            }
            //} while (answer != 0); // не закрываем запросы, пока не введём 0
        }
        static void Main(string[] args)
        {
            // --------------------------------------------------------------------------------------------------------
            //  MyTree
            // --------------------------------------------------------------------------------------------------------
            MyTree<Shape> tree = new MyTree<Shape>(0); // ИСД
            MyTree<Shape> searchTree = new MyTree<Shape>(0); // дерево поиска
            int answer;
            do
            {
                Console.WriteLine("1.Сформировать идеально сбалансированное бинарное дерево вручную");
                Console.WriteLine("2.Сформировать идеально сбалансированное бинарное дерево ДСЧ");
                Console.WriteLine("3.Распечатать дерево ИСД и дерево поиска");
                Console.WriteLine("4.Найти количество листьев в дереве");
                Console.WriteLine("5.Преобразовать идеально сбалансированное дерево в дерево поиска");
                Console.WriteLine("6.Удалить из дерева поиска элемент с заданным ключом");
                Console.WriteLine("7.Удалить дерево ИСД");
                Console.WriteLine("8.Удалить дерево поиска");
                Console.WriteLine("9.Сформировать дерево поиска вручную");
                Console.WriteLine("0.Закончить работу с деревом");
                //Console.WriteLine("Выберите пункт меню");
                answer = EnterNumber.EnterIntNumber("Выберите пункт меню", 0); // выбираем действие
                switch (answer)
                {
                    case 1: // первый выбор (Формирование вручную ИСД)
                        {
                            // количество элементов в формируемом дереве
                            //Console.WriteLine("Введите количество объектов");
                            int count = EnterNumber.EnterIntNumber("Введите количество объектов", 0); // вводим количество элементов, которыми будем заполнять дерево
                            // массив элементов
                            Shape[] array = new Shape[count]; // на основе данного массива затем создадим связанный список
                            Shape added = new Shape();
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine($"Ввод {i + 1} фигуры");
                                // выбираем фигуру для добавления
                                MenuChoise(ref added);
                                Console.WriteLine("Введите данные для объекта:");
                                added.Init(); // задаем параметры для элемента, который хотим добавить
                                array[i] = (Shape)added.Clone();
                            }
                            tree = new MyTree<Shape>(array); // создаём идеально сбалансированное дерево с введёнными элементами
                            Console.WriteLine("Сформированное идеально сбалансированное дерево:");
                            tree.ShowTree();
                            break;
                        }
                    case 2: // второй выбор (Формирование ДСЧ ИСД)
                        {
                            Console.WriteLine("Введите количество объектов");
                            int count = EnterNumber.EnterIntNumber("Введите количество объектов", 0); // вводим количество элементов, которыми будем заполнять дерево
                            tree = new MyTree<Shape>(count); // создаём идеально сбалансированное дерево с заданным числом элементов
                            Console.WriteLine("Сформированное идеально сбалансированное дерево:");
                            tree.ShowTree();
                            break;
                        }
                    case 3: // третий выбор (Печать)
                        {
                            Console.WriteLine("ИСД:");
                            tree.ShowTree();
                            Console.WriteLine("Дерево поиска:");
                            searchTree.ShowTree();
                            break;
                        }
                    case 4: // четвёртый выбор (Количество листьев)
                        {
                            Console.WriteLine($"В дереве ИСД: {tree.CountLeaves()} листьев");
                            Console.WriteLine($"В дереве поиска: {searchTree.CountLeaves()} листьев");
                            break;
                        }
                    case 5: // пятый выбор (ИСД -> дерево поиска)
                        {
                            searchTree = tree.TransformToFindTree();
                            Console.WriteLine("ИСД");
                            tree.ShowTree();
                            Console.WriteLine("Дерево поиска");
                            searchTree.ShowTree();
                            break;
                        }
                    case 6: // шестой выбор (Удаление элемента) ВЫПОЛНЯЕТСЯ С ДЕРЕВОМ ПОИСКА
                        {
                            if (searchTree.Count == 0) Console.WriteLine("Дерево поиска пустое, для удаления добавьте в него элементы");
                            else
                            {
                                // вводим удаляемый элемент
                                Console.WriteLine("Введите фигуру, которую хотите удалить");
                                Shape removedName = new Shape();
                                MenuChoise(ref removedName); // выбираем фигуру для удаления
                                Console.WriteLine("Введите данные для объекта:");
                                removedName.Init(); // задаем параметры для элемента, который хотим удалить
                                // удаляем
                                bool ok = searchTree.Remove(removedName);
                                if (!ok) Console.WriteLine("Элемент отсутствует в дереве поиска");
                                else Console.WriteLine("Элемент был удалён");
                                // печать результата
                                Console.WriteLine("Удаление завершено");
                                Console.WriteLine("Полученное дерево поиска:");
                                searchTree.ShowTree();
                            }
                            break;
                        }
                    case 7: // седьмой выбор (Удаление дерева ИСД)
                        {
                            tree.Clear();
                            Console.WriteLine("Удаление ИСД завершено");
                            break;
                        }
                    case 8: // восьмой выбор (Удаление дерева поиска)
                        {
                            searchTree.Clear();
                            Console.WriteLine("Удаление дерева поиска завершено");
                            break;
                        }
                    case 9: // девятый выбор (Формирование вручную дерева поиска)
                        {
                            searchTree.Clear(); // очищаем дерево поиска
                            // количество элементов в формируемом дереве
                            Console.WriteLine("Введите количество объектов");
                            int count = EnterNumber.EnterIntNumber("Введите количество объектов", 0); // вводим количество элементов, которыми будем заполнять дерево
                            Shape added = new Shape();
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine($"Ввод {i + 1} фигуры");
                                // выбираем фигуру для добавления
                                MenuChoise(ref added);
                                Console.WriteLine("Введите данные для объекта:");
                                added.Init(); // задаем параметры для элемента, который хотим добавить
                                searchTree.AddPoint(added);
                            }
                            Console.WriteLine("Сформированное дерево поиска:");
                            searchTree.ShowTree();
                            break;
                        }
                    case 0: // программа продолжит работу
                        {
                            Console.WriteLine("Выбор закрыт");
                            break;
                        }
                    default: // введённое число не подошло ни к одному пункту
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer != 0); // не закрываем запросы, пока не введём 0
        }
    }
}
