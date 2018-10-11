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
			int result= base.GetAmount() * MULTILIER_CARNATION;
			Console.WriteLine("Carnation count {0} costs {1}", Count, result);
			return result;
		}
	}

	class NordCarnation :Flower
	{
		public NordCarnation(int cost, int count, string color) : base(cost, count, color)
		{
		}

		public override int GetAmount()
		{
			int result= base.GetAmount();
			Console.WriteLine("NordCarnation is {0} count {1}. It costs {2}",Color,Count,result);
			return result;
		}
	}
}
