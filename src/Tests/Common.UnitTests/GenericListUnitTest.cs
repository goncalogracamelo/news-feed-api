using Common.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common.UnitTests
{
    public class GenericListUnitTest
    {

        private Node<int> GetListOfInt()
        {
            Node<int> node10 = new Node<int>(10);
            Node<int> node9 = new Node<int>(9, node10);
            Node<int> node8 = new Node<int>(8, node9);
            Node<int> node7 = new Node<int>(7, node8);
            Node<int> node6 = new Node<int>(6, node7);
            Node<int> node5 = new Node<int>(5, node6);
            Node<int> node4 = new Node<int>(4, node5);
            Node<int> node3 = new Node<int>(3, node4);
            Node<int> node2 = new Node<int>(2, node3);
            Node<int> node1 = new Node<int>(1, node2);
            return node1;
        }

        [Fact]
        public void GenericListOfInt_ExplicitEnumeratorIteration_Success()
        {
            Node<int> list = GetListOfInt();

            var enumerator = list.GetEnumerator();

            int resultSumOfAllValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Sum();
            int listSum = 0;

            while (enumerator.MoveNext())
            {                
                listSum += enumerator.Current.ValueItem;
            }            

            Assert.Equal(resultSumOfAllValues, listSum);
        }


        [Fact]
        public void GenericListOfInt_ForEachEnumeratorIteration_Success()
        {
            Node<int> list = GetListOfInt();
            
            int resultSumOfAllValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Sum();
            int listSum = 0;

            foreach (var item in list)
            {
                listSum += item.ValueItem;
            }
            
            Assert.Equal(resultSumOfAllValues, listSum);
        }



    }
}
