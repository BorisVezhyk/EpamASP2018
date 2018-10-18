using System;

namespace Lesson9MySortedList
{
	class Program
	{
		static void Main(string[] args)
		{
			MySortedLinkedList<int> lst=new MySortedLinkedList<int>();
			lst.Add(123);
			lst.Add(5546);
			lst.Add(1233);
			lst.Add(-1);
			lst.Add(10);
			lst.Add(123);
			lst.Add(56);
			lst.Add(12999);
			lst.Add(-221);
			lst.Add(-1123457);
			Console.WriteLine();
			PrintList(lst);

			lst.Delete(123);
			lst.Delete(-1);
			Console.WriteLine();
			PrintList(lst);

			Console.ReadLine();
		}



		private static void PrintList(MySortedLinkedList<int> list)
		{
			foreach (var i in list)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
		}
	}


}
