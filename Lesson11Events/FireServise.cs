using System;

namespace Lesson11FireServise
{
	class FireServise
	{
		CarFireEngine _car1=new CarFireEngine();
		CarFireEngine _car2 = new CarFireEngine();

		public FireServise() => Home.Signalization += FireServise_Signalization;

		private void FireServise_Signalization(object sender, FireEventArg e)
		{
			switch (e.SizeFire)
			{
				case SizeFire.Large:
					SendTwoCarsOnLargeFire(e.SizeFire);
					break;
				case SizeFire.Small:
					CarWentOnSmalFire(!_car1.IsBusy ? _car1 : _car2, e.SizeFire);
					break;
			}
			
		}

		private void SendTwoCarsOnLargeFire(SizeFire fire)
		{
			Console.WriteLine($"Fire is {fire.ToString()}\n {_car1} and {_car2} went on fire.\nFire finished\n");
		}

		private void CarWentOnSmalFire(CarFireEngine car,SizeFire fire)
		{
			if (car==null)
			{
				Console.WriteLine("The house borned down");
			}

			Console.WriteLine($"Fire is {fire.ToString()}");
			car.IsBusy = true;
			Console.WriteLine($"{car} went on fire\nFire finished\n");
		}
	}
}