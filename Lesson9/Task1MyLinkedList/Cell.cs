using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson9MyLinkedList
{
	class Cell<T>
	{
		public Cell<T> Next { get; set; }

		public T Value { get; set; }

		public Cell(T value)
		{
			if (value==null)
			{
				throw new NullReferenceException();
			}
			Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
