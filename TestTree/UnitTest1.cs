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

            // Act
            int leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(4, leafCount);
        }

        [TestMethod]
        public void AddPoint_AddsElementTree()
        {
            // Arrange
            MyTree<Shape> tree = new MyTree<Shape>(0);
            int expected = 3;

            // Act
            tree.AddPoint(new Shape("элемент1", 1));
            tree.AddPoint(new Shape("элемент2", 2));
            tree.AddPoint(new Shape("элемент3", 3));

            // Assert
            Assert.AreEqual(expected, tree.Count);
        }

        //[TestMethod]
        //public void Remove_RemovesElementFromTree()
        //{
        //    // Arrange
        //    MyTree<int> tree = new MyTree<int>(0);
        //    tree.AddPoint(5);
        //    tree.AddPoint(3);
        //    tree.AddPoint(7);

        //    // Act
        //    bool removed = tree.Remove(3);

        //    // Assert
        //    Assert.IsTrue(removed);
        //    Assert.AreEqual(2, tree.Count);
        //}

        //[TestMethod]
        //public void TransformToFindTree_TransformsTreeToSearchTree()
        //{
        //    // Arrange
        //    MyTree<int> tree = new MyTree<int>(0);
        //    tree.AddPoint(5);
        //    tree.AddPoint(3);
        //    tree.AddPoint(7);

        //    // Act
        //    MyTree<int> searchTree = tree.TransformToFindTree();

        //    // Assert
        //    Assert.AreEqual(3, searchTree.Count);
        //    Assert.IsTrue(searchTree.AddPoint(6)); // Verify it's a binary search tree
        //}
    }
}