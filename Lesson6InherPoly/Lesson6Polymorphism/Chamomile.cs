using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6Polymorphism
{
	class Chamomile :Flower
	{
		public Chamomile(int cost, int count, string color) : base(cost, count, color)
		{
		}
	}

	class FieldChamomile :Chamomile
	{
		public FieldChamomile(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			int result= base.GetAmount();
			Console.WriteLine("FieldChamomile is {0} count {1}. It costs {2}", Color, Count, result);
			return result;
		}
	}
}
