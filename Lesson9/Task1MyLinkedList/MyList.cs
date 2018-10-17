﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson9MyLinkedList
{
	class MyList<T>:IEnumerable<T>
	{
		private Cell<T> _head = null;
		private Cell<T> _end = null;
		private const int LIMIT_OF_LIST = 6;

		public int Count { get; private set; }

		public void Delete(T value)
		{
			if (value == null)
			{
				throw new NullReferenceException();
			}

			var current = _head;
			Cell<T> prevCell = null;
			while (current!=null)
			{
				if (current.Value.Equals(value))
				{
					if (prevCell==null)
					{
						_head = _head.Next;
						if (_head==null)
						{
							_end = null;
						}

					}
					else
					{
						prevCell.Next = current.Next;
						if (current.Next==null)
						{
							_end = prevCell;
						}
					}

					Count--;
					break;
				}

				prevCell = current;
				current = current.Next;
			}


		}

		public void Add(T value)
		{
			if (Count==LIMIT_OF_LIST)
			{
				throw new LimitOfListException("You have reached the limite of the list");
			}
			if (value==null)
			{
				throw new NullReferenceException();
			}
			var next = new Cell<T>(value);
			if (_head==null)
			{
				_head = next;
			}
			else
			{
				_end.Next = next;
			}

			_end = next;
			Count++;
		}

		public void Insert(int position, T value)
		{
			if (position>Count || (Count+1)>LIMIT_OF_LIST)
			{
				throw new LimitOfListException("ERROR!! LIMIT OF LIST");
			}
			if (value==null)
			{
				throw new NullReferenceException();
			}
			if (position==Count)
			{
				Add(value);
			}
			var newCell=new Cell<T>(value);

			var oldCell = GetCellFromPosition(position);
			newCell.Next = oldCell;
			if (position==0)
			{
				_head = newCell;
			}
			else
			{
				var prevOldCell = GetCellFromPosition(position - 1);
				prevOldCell.Next = newCell;
			}

			Count++;
		}

		public void Clear()
		{
			_head = null;
			_end = null;
			Count = 0;
		}

		private Cell<T> GetCellFromPosition(int position)
		{
			var current = _head;
			while (position > 0)
			{
				current = current.Next;
				position--;
			}

			return current;
		}

		public void Replace(int position, T value)
		{
			if (position > Count)
			{
				throw new LimitOfListException("Your position more list");
			}
			if (value == null)
			{
				throw new NullReferenceException();
			}

			var current = GetCellFromPosition(position);
			current.Value = value;
		}

		public IEnumerator<T> GetEnumerator()
		{
			var current = _head;
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
