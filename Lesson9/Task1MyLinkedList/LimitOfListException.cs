using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson9MyLinkedList
{
	class LimitOfListException : Exception
	{
		public LimitOfListException(string message):base(message)
		{
			
		}
	}
}
