
namespace HeapSortDemo
{
    using System;
    using System.ComponentModel.Design.Serialization;
    using System.Numerics;
    using Windows.Graphics.Holographic;
    using System.Linq;

    public class Heaper<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node? left { get; set; }
            public Node? right { get; set; }
            public Node(T Value)
            {
                this.Value = Value;
            }
        }

        public void heapSort(T[] arr)
        {
            int size = arr.Length;
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                heapify(arr, size, i);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
         public void heapifyTree(Node root)
        {
            if (root.left == null && root.right == null)
            {
                return;
            }
            T[] values = new T[3];
            values[1] = root.Value;
            if (root.left != null)
            {
                values[0] = root.left.Value;
            }
            if (root.right != null)
            {
                values[2] = root.right.Value;
            }
            T maxValue = values.Max();
            if (maxValue.Equals(root.Value))
            {
                return;
            }
            else
            {
                if (maxValue.Equals(root.left.Value))
                {
                    T holder = root.left.Value;
                    root.left.Value = root.Value;
                    root.Value = holder;
                    heapifyTree(root.left);
                }
                else
                {
                    T holder = root.right.Value;
                    root.right.Value = root.Value;
                    root.Value = holder;
                    heapifyTree(root.right);
                }
            }
        }
            public Node breadthFirstBuild(T[] arr)
            {
                int size = arr.Length;
                Node root = null;
                Node[] nodes = new Node[size];
                for (int i = size - 1; i >= 0; i--)
                {
                    int left = 2 * i + 1;
                    int right = 2 * i + 2;
                    nodes[i] = new Node(arr[i]);
                    if (left < size)
                    {
                        nodes[i].left = nodes[left];
                    }
                    if (right < size)
                    {
                        nodes[i].right = nodes[right];
                    }
                    if (i == 0)
                    {
                        root = nodes[0];
                    }
                }
                return root;
            }

            public static void heapify(T[] arr, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n && arr[left].CompareTo(arr[largest]) > 0)
                {
                    largest = left;
                }
                if (right < n && arr[right].CompareTo(arr[largest]) > 0)
                {
                    largest = right;
                }
                if (largest != i)
                {
                    T holder = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = holder;
                    heapify(arr, n, largest);
                }
            }
        public void Inorder(Node root)
        {
            if(root == null)
            {
                return;
            }
            Inorder(root.left);
            Console.Write(root.Value + " ");
            Inorder(root.right);
        }
            
        }
    public class Program
    {
        public static void Main(string[] args)
        {
            Heaper<int> example = new Heaper<int>();
            int[] arr = { 55, 25, 89, 34, 12, 19, 78, 95, 1, 100 };
            int[] arr2 = { 55, 25, 89, 34, 12, 19, 78, 95, 1, 100 };
            int i;
            Console.WriteLine("Heap Sort");
            Console.Write("Initial array is: ");
            for (i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            example.heapSort(arr);
            Console.Write("\n");
            Console.Write("Sorted Array is: ");
            for (i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Heaper<int>.Node root = example.breadthFirstBuild(arr2);
            example.heapifyTree(root);
            example.Inorder(root);
        }
    }
}