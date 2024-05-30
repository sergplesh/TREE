using GeometrucShapeCarLibrary;
using TREE;

namespace TestTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountLeaves_ReturnsCorrectNumberOfLeaves() // ������� ������� � ������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedLeaves = 4;

            // Act
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_LeftLeaf() // �������� ������ �����
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / 
            // 2  4  6      - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_RightLeaf() // �������� ������� �����
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 6));
            //     5
            //    /  \
            //   3    7
            //  / \    \
            // 2  4     8    - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveLeftElement_OneLeftChild() // �������� ���� (� ����� ������) � ����� ��������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            //     5
            //    /  \
            //   3    7
            //  / \  / 
            // 2  4  6      - 3 �����
            int expectedCount = 5;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 7));
            //     5
            //    /  \
            //   3    6
            //  / \   
            // 2  4         - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveLeftElement_OneRightChild() // �������� ���� (� ����� ������) � ����� ��������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \    \
            // 2  4     8    - 3 �����
            int expectedCount = 5;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    8
            //  / \   
            // 2  4         - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRightElement_OneChild() // �������� ���� (� ������ ������) � ����� ��������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 8));
            tree.AddPoint(new Shape("�������", 6));
            //     5
            //    /  \
            //   3    6
            //  /    / \
            // 2    7   8    - 3 �����
            int expectedCount = 5;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 3));
            //     5
            //    /  \
            //   2    6
            //       / \
            //      7   8    - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRootElement_OneChild() // �������� ����-����� � ����� ��������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 2));
            //     5
            //    /   
            //   3    
            //  /      
            // 2             - 1 ����
            int expectedCount = 2;
            int expectedLeaves = 1;

            // Act
            bool removed = tree.Remove(new Shape("�������", 5));
            //     3
            //    /  
            //   2           - 1 ����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRightElement_TwoChild() // �������� �������� (� ������ ������) � ����� ���������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 7));
            //     5
            //    /  \
            //   3    6
            //  / \    \
            // 2  4     8    - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveLeftElement_TwoChild() // �������� �������� (� ����� ������) � ����� ���������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 3));
            //      5
            //    /   \
            //   2     7
            //    \   / \
            //     4 6   8    - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_TwoChild_SuccessorIsNotRightChild() // �������� �������� � ����� ���������, �� ��������� �� ������ ������� �� ����������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 9));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  9   
            //         /
            //        8       - 4 �����
            int expectedCount = 7;
            int expectedLeaves = 4;

            // Act
            bool removed = tree.Remove(new Shape("�������", 7));
            //     5
            //    /  \
            //   3    8
            //  / \  / \
            // 2  4  6  9   - 4 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveElement_NotExistElement() // �������� �� �������������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 7;
            int expectedLeaves = 4;

            // Act
            bool removed = tree.Remove(new Shape("�������", 1));
            // ������ �� ���������
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsFalse(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void RemoveRootTwoChild() // �������� ����� � ����� ���������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 6;
            int expectedLeaves = 3;

            // Act
            bool removed = tree.Remove(new Shape("�������", 5));
            // ������ �� ���������
            //     6
            //    /  \
            //   3    7
            //  / \    \
            // 2  4     8   - 3 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void ClearTree() // �������� ������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 3));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 2));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 6));
            tree.AddPoint(new Shape("�������", 8));
            //     5
            //    /  \
            //   3    7
            //  / \  / \
            // 2  4  6  8   - 4 �����
            int expectedCount = 0;

            // Act
            tree.Clear();

            // Assert
            Assert.AreEqual(expectedCount, tree.Count);
        }

        [TestMethod]
        public void AddSimilarElements() // ���������� ��������, ������� ��� ���� � ������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            int expectedCount = 3;
            int expectedLeaves = 2;

            // Act
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 5));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 7));
            tree.AddPoint(new Shape("�������", 4));
            tree.AddPoint(new Shape("�������", 4));
            //     5
            //    /  \
            //   6    7    - 2 �����
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void MakeTree_CountLeafes() // �������� ����, ��� �������� ���������������� ������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(7);
            int expectedLeaves = 4;

            // Act
            // � ��� 7 ��������� ������ ������������� ��������� �������
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
        public void Remove_EmptyTree() // �������� � ������ ������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);

            // Act
            bool removed = tree.Remove(new Shape("�������", 10));

            // Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void Remove_RootTreeToEmptyTree() // �������� ����� � ������ �� ������ ��������
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            tree.AddPoint(new Shape("�������", 10));
            int expectedCount = 0;

            // Act
            bool removed = tree.Remove(new Shape("�������", 10));

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(expectedCount, tree.Count);
        }

        [TestMethod]
        public void MakeTree_TransformToSearchTree() // ������������� ��� � ������ ������
        {
            // Arrange
            Shape[] array = new Shape[3];
            // ��������: 1, 2, 3
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Shape("�������", i + 1);
            }
            int expectedLeaves = 1;
            MyTree<Shape> tree = new MyTree<Shape>(array);
            // � ��� 3 �������� ������ ������������� ��������� �������:
            //     1      - ������ ������ = 1
            //    /  \
            //   2    3   - 2 �����

            // Act
            MyTree<Shape> searchTree = tree.TransformToFindTree();
            //     1
            //    / 
            //   2    - ������ ������ = 2
            //  / 
            // 3      - 1 ����

            int leafCount = searchTree.CountLeaves();

            // Assert
            Assert.AreEqual(expectedLeaves, leafCount);
        }

        [TestMethod]
        public void MakeTree_TransformToSearchTree_EmptyTree() // ������������� ������� ��� � ������ ������
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
        public void PointConstructor() // ����������� Point
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
        //public void NullPointToString() // null Point-������
        //{
        //    // Arrange
        //    Point<Shape> point1 = new Point<Shape>();

        //    // Act
        //    string s = "";

        //    // Assert
        //    Assert.AreEqual(s, point1.ToString());
        //}
        [TestMethod]
        public void PointCompareTo() // Point-������
        {
            // Arrange
            Shape seted = new Shape("�������", 2);

            // Act
            Point<Shape> point1 = new Point<Shape>(seted);

            // Assert
            Assert.AreEqual(seted.CompareTo(new Shape("�������", 2)), point1.CompareTo(new Point<Shape>(new Shape("�������", 2))));
        }
        [TestMethod]
        public void PointToString() // Point-������
        {
            // Arrange
            Shape seted = new Shape("�������", 2);
            Point<Shape> point1 = new Point<Shape>(seted);

            // Act
            string s = "id 2: " + "�������";

            // Assert
            Assert.AreEqual(s, point1.ToString());
        }
    }
}