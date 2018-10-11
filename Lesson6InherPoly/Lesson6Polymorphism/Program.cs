using System;
using System.Collections.Generic;

namespace Lesson6Polymorphism
{
	class Program
	{
		static void Main(string[] args)
		{
			RortlandRose s = new RortlandRose(2, 3, "red");
			HolandTulip holandTulip = new HolandTulip(3, 3, "Yellow");
			FieldChamomile f = new FieldChamomile(3, 4, "white");
			AldaRose alda = new AldaRose(5, 1, "red");
			NordCarnation nordf = new NordCarnation(6, 3, "Black");

			List<Flower> bouquet = new List<Flower>();
			bouquet.Add(s);
			bouquet.Add(holandTulip);
			bouquet.Add(f);
			bouquet.Add(alda);
			bouquet.Add(nordf);

			int sum = 0;
			foreach (var flower in bouquet)
			{
				sum += flower.GetAmount();
			}

			Console.WriteLine("Bouquet costs total: {0} $",sum);
			Console.ReadLine();
		}
	}
}
