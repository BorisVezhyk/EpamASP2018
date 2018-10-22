namespace Lesson11FireServise
{
	class CarFireEngine
	{
		public bool IsBusy { get; set; }

		public string NameCar { get; set; }

		private static int _counterCar = 1;

		public CarFireEngine()
		{
			NameCar = "Car" + _counterCar;
			_counterCar++;
			IsBusy = false;
		}

		public override string ToString()
		{
			return NameCar;
		}
	}
}