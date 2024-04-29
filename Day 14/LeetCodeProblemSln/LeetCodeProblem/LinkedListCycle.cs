using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblem
{
    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    class LinkedList
    {
        public Node head;
        public void Insert(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        public void CreateLoop(int position)
        {
            if (position == -1 || head == null)
                return;
            Node current = head;
            Node loopNode = null;
            int count = 1;
            while (current.Next != null)
            {
                if (count == position)
                {
                    loopNode = current;
                    break;
                }
                current = current.Next;
                count++;
            }
            if (loopNode != null)
                current.Next = loopNode;
        }
    }
    public class LinkedListCycle
    {
        
        public static bool HasLoop(Node h)
        {
            HashSet<Node> s = new HashSet<Node>();
            while (h != null)
            {
                if (s.Contains(h))
                    return true;
                s.Add(h);
                h = h.Next;
            }

            return false;
        }
        public static async Task FindLLCycle()
        {
            while (true)
            {
                Console.WriteLine("Enter space separated numbers:");
                string input = await Console.In.ReadLineAsync();
                string[] numbers = input.Split(' ');
                LinkedList list = new LinkedList();
                foreach (string number in numbers)
                {
                    int value = int.Parse(number);
                    list.Insert(value);
                }
                Console.WriteLine("Enter the position to create a loop:");
                int position = int.Parse(await Console.In.ReadLineAsync());
                list.CreateLoop(position);
                Console.WriteLine($"The given Linked List {(HasLoop(list.head) ? "has" : "doesn't have")} Loop");
            }
        }
    }
}
