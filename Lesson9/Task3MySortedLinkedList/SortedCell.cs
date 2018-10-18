using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson9MySortedList
{
	class SortedCell<T> where T : IComparable
	{
		public SortedCell<T> Next { get; set; }

		public T Value { get; set; }

		public SortedCell(T value)
		{
			if (value == null)
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