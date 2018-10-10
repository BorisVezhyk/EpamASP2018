using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6Polymorphism
{
	class Rose : Flower
	{
		private const int MULTILIER = 2;
		public Rose(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			return base.GetAmount() * MULTILIER;
		}
	}

	class AldaRose : Rose
	{
		public AldaRose(int cost, int count, string color) : base(cost, count, color)
		{
		}
	}

	class RortlandRose: Rose
	{
		private const int RATIO = 100;
		public RortlandRose(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			return base.GetAmount() + RATIO;
		}
	}
}
