using System.Collections;

namespace Common.Lib
{
    public class Node<T>: IEnumerable
    {
        public Node<T> Next { get; set; }
        public T ValueItem { get; set; }

        public Node(T valueItem)
        {
            ValueItem = valueItem;
        }

        public Node(T valueItem, Node<T> next)
        {
            ValueItem = valueItem;
            Next = next;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }


        public NodeEnumerator<T> GetEnumerator()
        {
            return new NodeEnumerator<T>(this);
        }      
    }


    public class NodeEnumerator<T> : IEnumerator
    {
        private Node<T> _currentNode;
        private Node<T> _firstNode;        

        public NodeEnumerator(Node<T> node)
        {
            _firstNode = node;
        }


        public Node<T> Current => _currentNode;
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }


        public bool MoveNext()
        {
            if (_currentNode == null)
            {
                _currentNode = _firstNode;
                return true;
            }
            else if (_currentNode.Next != null)
            {
                _currentNode = _currentNode.Next;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _currentNode = null;
        }
    }
}
