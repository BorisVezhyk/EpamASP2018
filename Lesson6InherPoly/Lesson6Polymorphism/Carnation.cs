using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6Polymorphism
{
	class Carnation : Flower
	{
		private const int MULTILIER_CARNATION = 4;

		public Carnation(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			return base.GetAmount() * MULTILIER_CARNATION;
		}
	}

	class NordCarnation :Flower
	{
		public NordCarnation(int cost, int count, string color) : base(cost, count, color)
		{
		}
	}
}
