using GeometrucShapeCarLibrary;
using TREE;

namespace TestTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountLeaves_ReturnsCorrectNumberOfLeaves() // подсчёт листьев в дереве
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedLeaves = 4;

            // Act
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_LeftLeaf() // удаление левого листа
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / 
            // 2  4  6      - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_RightLeaf() // удаление правого листа
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 6));
            //     5
            //    /  \
            //   3    7
            //  / \    \
            // 2  4     8    - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveLeftElement_OneLeftChild() // удаление узла (в левой ссылке) с одним потомком
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            //     5
            //    /  \
            //   3    7
            //  / \  / 
            // 2  4  6      - 3 листа
            int expectedCount = 5;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 7));
            //     5
            //    /  \
            //   3    6
            //  / \   
            // 2  4         - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveLeftElement_OneRightChild() // удаление узла (в левой ссылке) с одним потомком
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \    \
            // 2  4     8    - 3 листа
            int expectedCount = 5;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    8
            //  / \   
            // 2  4         - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRightElement_OneChild() // удаление узла (в правой ссылке) с одним потомком
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 8));
            tree.AddPoint(new Shape("элемент", 6));
            //     5
            //    /  \
            //   3    6
            //  /    / \
            // 2    7   8    - 3 листа
            int expectedCount = 5;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 3));
            //     5
            //    /  \
            //   2    6
            //       / \
            //      7   8    - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRootElement_OneChild() // удаление узла-корня с одним потомком
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 2));
            //     5
            //    /   
            //   3    
            //  /      
            // 2             - 1 лист
            int expectedCount = 2;
            int expectedLeaves = 1;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 5));
            //     3
            //    /  
            //   2           - 1 лист
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRightElement_TwoChild() // удаление элемента (в правой ссылке) с двумя потомками
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 7));
            //     5
            //    /  \
            //   3    6
            //  / \    \
            // 2  4     8    - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveLeftElement_TwoChild() // удаление элемента (в левой ссылке) с двумя потомками
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 3));
            //      5
            //    /   \
            //   2     7
            //    \   / \
            //     4 6   8    - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_TwoChild_SuccessorIsNotRightChild() // удаление элемента с двумя потомками, но наследник не правый элемент от удаляемого
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 9));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  9   
            //         /
            //        8       - 4 листА
            int expectedCount = 7;
            int expectedLeaves = 4;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 7));
            //     5
            //    /  \
            //   3    8
            //  / \  / \
            // 2  4  6  9   - 4 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_NotExistElement() // удаление не существующего
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 7;
            int expectedLeaves = 4;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 1));
            // дерево не изменится
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsFalse(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRootTwoChild() // удаление корня с двумя потомками
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 5));
            // дерево не изменится
            //     6
            //    /  \
            //   3    7
            //  / \    \
            // 2  4     8   - 3 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void ClearTree() // удаление дерева
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 листа
            int expectedCount = 0;

            // Act
            tree.Clear();

            // Assert
            Assert.AreEqual(expectedCount, tree.Count);
        }

        [TestMethod]
        public void AddSimilarElements() // добавление элемента, который уже есть в дереве
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            int expectedCount = 3;
            int expectedLeaves = 2;

            // Act
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 4));
            //     5
            //    /  \
            //   6    7    - 2 листа
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void MakeTree_CountLeafes() // проверка того, что создаётся СБАЛАНСИРОВАННОЕ дерево
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(7);
            int expectedLeaves = 4;

            // Act
            // в ИСД 7 элементов должны расположиться следующим образом
            //     *
            //    /  \
            //   *    *
            //  / \  / \
            // *  *  *  *
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void Remove_EmptyTree() // удаление в пустом дереве
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);

            // Act
            bool removed = tree.Remove(new Shape("элемент", 10));

            // Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void Remove_RootTreeToEmptyTree() // удаление корня в дереве из одного элемента
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 10));
            int expectedCount = 0;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 10));

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
        }

        [TestMethod]
        public void MakeTree_TransformToSearchTree() // трансформация ИСД в дерево поиска
        {
            // Arrange
            Shape[] array = new Shape[3];
            // элементы: 1, 2, 3
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Shape("элемент", i + 1);
            }
            int expectedLeaves = 1;
            MyTree<Shape> tree = new MyTree<Shape>(array);
            // в ИСД 3 элемента должны расположиться следующим образом:
            //     1      - высота дерева = 1
            //    /  \
            //   2    3   - 2 листа

            // Act
            MyTree<Shape> searchTree = tree.TransformToFindTree();
            //     1
            //    / 
            //   2    - высота дерева = 2
            //  / 
            // 3      - 1 лист

            int leafCount = searchTree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void MakeTree_TransformToSearchTree_EmptyTree() // трансформация пустого ИСД в дерево поиска
        {
            // Arrange
            int expectedCount = 0;
            MyTree<Shape> tree = new MyTree<Shape>();

            // Act
            MyTree<Shape> searchTree = tree.TransformToFindTree();

            // Assert
            Assert.AreEqual(expectedCount, searchTree.Count);
        }






        // Point
        [TestMethod]
        public void PointConstructor() // конструктор Point
        {
            // Arrange
            Point<Shape> point1 = new Point<Shape>();

            // Act
            Point<Shape> point2 = new Point<Shape>(null);

            // Assert
            Assert.AreEqual(point1.Left, point2.Left);
            Assert.AreEqual(point1.Data, point2.Data);
            Assert.AreEqual(point1.Right, point2.Right);
        }
        //[TestMethod]
        //public void NullPointToString() // null Point-строка
        //{
        //    // Arrange
        //    Point<Shape> point1 = new Point<Shape>();

        //    // Act
        //    string s = "";

        //    // Assert
        //    Assert.AreEqual(s, point1.ToString());
        //}
        [TestMethod]
        public void PointCompareTo() // Point-строка
        {
            // Arrange
            Shape seted = new Shape("элемент", 2);

            // Act
            Point<Shape> point1 = new Point<Shape>(seted);

            // Assert
            Assert.AreEqual(seted.CompareTo(new Shape("элемент", 2)), point1.CompareTo(new Point<Shape>(new Shape("элемент", 2))));
        }
        [TestMethod]
        public void PointToString() // Point-строка
        {
            // Arrange
            Shape seted = new Shape("элемент", 2);
            Point<Shape> point1 = new Point<Shape>(seted);

            // Act
            string s = "id 2: " + "элемент";

            // Assert
            Assert.AreEqual(s, point1.ToString());
        }
    }
}