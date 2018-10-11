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
			int result=base.GetAmount() * MULTILIER;
			return result;
		}
	}

	class AldaRose : Rose
	{
		public AldaRose(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			int result = base.GetAmount();
			Console.WriteLine("AldaRose is {2}, count {0}. It costs {1}", Count, result,Color);
			return result;
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
			int result =base.GetAmount() + RATIO;
			Console.WriteLine("RorlandRose is {2} count {0}. It costs {1}",Count, result,Color);
			return result;
		}
	}
}
