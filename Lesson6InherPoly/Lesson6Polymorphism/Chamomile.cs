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

	}
}
