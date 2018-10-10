using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6Polymorphism
{
	class Tulip : Flower
	{
		public Tulip(int cost, int count, string color) : base(cost, count, color)
		{
		}
	}

	class HolandTulip : Tulip
	{
		private const int ADDITOR = 10;

		public HolandTulip(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			return base.GetAmount() + ADDITOR;
		}
	}
}
