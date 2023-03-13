using LinkedLists;

namespace LinkedListsTests
{
    public class LinkedListTests
    {
        [SetUp]
        public void CreateCharList()
        {
            list = new CustomLinkedList<char>();
            list.AddToEnd('a');
            list.AddToEnd('b');
            list.AddToEnd('c');
        }

        private CustomLinkedList<char>? list;

        [Test]
        public void AddFirst()
        {
            var numberList = new CustomLinkedList<int>();
            numberList.AddFirst(24);
            numberList.AddFirst(2);
            Assert.That(numberList.Head.Data, Is.EqualTo(2));
            Assert.That(numberList.Head.Next.Data, Is.EqualTo(24));
        }

        [Test]
        public void AddEnd()
        {
            Assert.That(list!.Head.Next.Data, Is.EqualTo('b'));
            Assert.That(list.Head.Data, Is.EqualTo('a'));
            Assert.That(list.Head.Next.Next.Data, Is.EqualTo('c'));
        }

        [Test]
        public void MiddleOfLinkedListShouldBeValid() =>
            Assert.That(list!.GetMid().Data, Is.EqualTo('b'));

        [Test]
        public void MiddleOfLinkedListShouldBeValidForEvenList()
        {
            list!.AddToEnd('d');
            Assert.That(list.GetMid().Data, Is.EqualTo('c'));
        }

        [Test]
        public void GetElementAt() => Assert.That(list!.GetAt(1).Data, Is.EqualTo('b'));

        [Test]
        public void RemoveElementAt()
        {
            list!.RemoveAt(1);
            Assert.That(list!.Head.Next.Data, Is.EqualTo('c'));
        }

        [Test]
        public void AddElementAt()
        {
            list!.AddAt(1, 'd');
            Assert.That(list!.Head.Next.Data, Is.EqualTo('d'));
        }

        [Test]
        public void AddElementAtZero()
        {
            list!.AddAt(0, 'd');
            Assert.That(list!.Head.Data, Is.EqualTo('d'));
        }

        [Test]
        public void AddElementAtTwo()
        {
            list!.AddToEnd('d');
            list.AddAt(2, 'e');
            Assert.That(list!.Head.Next.Next.Next.Data, Is.EqualTo('e'));
        }

        [Test]
        public void AddElementAtEnd()
        {
            list!.AddAt(3, 'e');
            Assert.That(list!.Head.Next.Next.Next.Data, Is.EqualTo('e'));
        }

        [Test]
        public void NonExistentIndexShouldThrowError() =>
            Assert.That(() => list!.AddAt(10, 'r'),
                Throws.InstanceOf<IndexOutOfRangeException>()!);
    }
}