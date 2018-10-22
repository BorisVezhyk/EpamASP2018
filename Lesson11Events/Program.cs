using System;

namespace Lesson11FireServise
{
	class Program
	{
		static void Main(string[] args)
		{
			City rim=new City(100);
			FireServise fs=new FireServise();
			rim.CityLive();

			Console.ReadLine();
		}
	}
}
