using System;
using System.Runtime.InteropServices;

namespace Lesson9MyLinkedList
{
	class Program
	{
		static void Main(string[] args)
		{
			MyList<int> list =new MyList<int>();
			list.Add(50);
			list.Add(5);
			list.Add(10);
			list.Add(30);
			list.Add(2);
			PrintList(list);

			Console.WriteLine("Insert on position 4 value 999");
			list.Insert(4, 999);
			PrintList(list);

			try
			{
				Console.WriteLine("Try insert more than Limit of the list");
				list.Insert(5,1000);

			}
			catch (LimitOfListException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex);
			}

			Console.WriteLine("Replace position 3 on value 666");
			list.Replace(3, 666);
			PrintList(list);

			Console.WriteLine("Delete 50 position");
			list.Delete(50);
			PrintList(list);

			Console.ReadLine();
		}

		private static void PrintList(MyList<int> list)
		{
			foreach (var i in list)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
		}
	}
}
