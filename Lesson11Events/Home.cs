using System;

namespace Lesson11FireServise
{

	class Home
	{
		public delegate void FireSignalization(object sender, FireEventArg e);

		private static int _counterHomes;

		public int NumberHome { get; }

		public Home()
		{
			NumberHome = _counterHomes++;
		}

		public static event FireSignalization Signalization;

		public void OnSignaliation(SizeFire fire)
		{
			Signalization?.Invoke(this, new FireEventArg(fire));
		}

		public void StartFire(SizeFire fire)
		{
			Console.WriteLine($"Home number {NumberHome} begin FIRE!!!!!!");
			OnSignaliation(fire);
		}
	}
}