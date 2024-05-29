using GeometrucShapeCarLibrary;
using TREE;

namespace TestTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountLeaves_ReturnsCorrectNumberOfLeaves()
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
        public void RemoveElement_Leaf()
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
        public void RemoveElement_OneChild()
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
        public void RemoveElement_TwoChild()
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
        public void RemoveElement_TwoChild_SuccessorIsNotRightChild()
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 3));
            tree.AddPoint(new Shape("элемент", 8));
            tree.AddPoint(new Shape("элемент", 2));
            tree.AddPoint(new Shape("элемент", 4));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 9));
            //     5
            //    /  \
            //   3    8
            //  / \  / \
            // 2  4  7  9   
            //      /
            //     6       - 5 листов
            int expectedCount = 7;
            int expectedLeaves = 4;

            // Act
            bool removed = tree.Remove(new Shape("элемент", 8));
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
        public void RemoveElement_NotExistElement()
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
            bool removed = tree.Remove(new Shape("элемент", 10));
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
        public void ClearTree()
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
        public void AddSimilarElements()
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            int expectedCount = 3;

            // Act
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 5));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 7));
            tree.AddPoint(new Shape("элемент", 6));
            tree.AddPoint(new Shape("элемент", 6));
            //     5
            //    /  \
            //   6    7    - 2 листа

            // Assert
            Assert.AreEqual(expectedCount, tree.Count);
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
        public void Remove_EmptyTree()
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);

            // Act
            bool removed = tree.Remove(new Shape("элемент", 10));

            // Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void MakeTree_TransformToSearchTree()
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            Shape[] array = new Shape[3];
            int expectedLeaves = 2;

            // Act
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Shape("N", i+1);
            }
            tree = new MyTree<Shape>(array);
            MyTree<Shape> searchTree = tree.TransformToFindTree();

            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedLeaves, leafCount);
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