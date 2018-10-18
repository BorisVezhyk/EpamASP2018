using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson9MySortedList
{
	class MySortedLinkedList<T> : IEnumerable<T> where T : IComparable
	{
		private SortedCell<T> _first = null;
		private SortedCell<T> _last = null;

		public int Count { get; private set; }

		public void Add(T value)
		{
			if (value == null)
			{
				throw new NullReferenceException();
			}
			var next = new SortedCell<T>(value);

			if (_first == null)
			{
				_first = next;
				_last = next;
			}

			if ((_last.Value.CompareTo(next.Value))<0)
			{
				_last.Next = next;
				_last = next;
			}
			else
			{
				var current = _first;
				SortedCell<T> prev = null;
				while (current != null)
				{
					if ((current.Value.CompareTo(next.Value)) > 0)
					{
						if (prev == null)
						{
							next.Next = _first;
							_first = next;
						}
						else
						{
							next.Next = current;
							prev.Next = next;
						}
						break;
					}
					prev = current;
					current = current.Next;
				}
			}

			Count++;
		}

		public void Delete(T value)
		{
			if (value == null)
			{
				throw new NullReferenceException();
			}

			var current = _first;
			SortedCell<T> prevCell = null;
			while (current != null)
			{
				if (current.Value.Equals(value))
				{
					if (prevCell == null)
					{
						_first = _first.Next;
						if (_first == null)
						{
							_last = null;
						}

					}
					else
					{
						prevCell.Next = current.Next;
						if (current.Next == null)
						{
							_last = prevCell;
						}
					}

					Count--;
					break;
				}

				prevCell = current;
				current = current.Next;
			}

		}
		public IEnumerator<T> GetEnumerator()
		{
			var current = _first;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}

