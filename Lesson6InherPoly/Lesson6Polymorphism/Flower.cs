using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lesson6Polymorphism
{
	abstract class Flower
	{
		public int Cost { get; set; }
		public int Count { get; set; }
		public string Color { get; set; }	

		public Flower(int cost,int count,string color)
		{
			Cost = cost;
			Count = count;
			Color = color;
		}

		public virtual int GetAmount()
		{
			return Count * Cost;
		}

		
	}
}
