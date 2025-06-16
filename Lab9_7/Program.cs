using System.Collections.Generic;
class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(5);
        list.AddLast(10);
        list.AddLast(15);
        list.AddLast(10);
        list.AddLast(20);
        int index = 1; 
        int removedIndex = -1;

        LinkedListNode<int> nodeToRemove = list.First;
        while (nodeToRemove != null)
        {
            if (nodeToRemove.Value == 10)
            {
                removedIndex = index;
                list.Remove(nodeToRemove);
                break; 
            }
            nodeToRemove = nodeToRemove.Next;
            index++;
        }
        if (removedIndex != -1)
        {
            Console.WriteLine("Удален элемент под номером: " + removedIndex);
        }
        else
        {
            Console.WriteLine("Элемент 10 не найден.");
        }
    }
}



