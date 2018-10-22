using System;
using System.Collections.Generic;

namespace Lesson11FireServise
{
	class City
	{
		private List<Home> _homes=new List<Home>();
		private Random _random = new Random();
		private readonly int _maxHomes;
		private const int MAX_EVENT = 2;

		public City(int homes)
		{
			_maxHomes = homes;
			for (int i = 0; i < _maxHomes; i++)
			{
				_homes.Add(new Home());
			}
		}

		public void CityLive()
		{
			for (int i = 0; i < MAX_EVENT; i++)
			{
				int numHome = _random.Next(0,_maxHomes);
				SizeFire fire = (SizeFire) _random.Next(Enum.GetNames(typeof(SizeFire)).Length);
				
				foreach (var home in _homes)
				{
					if (home.NumberHome == numHome)
					{
						home.StartFire(fire);
					}
				}

			}
			
		}
	}
}