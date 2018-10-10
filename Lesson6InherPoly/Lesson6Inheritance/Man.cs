using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Lesson6Inheritance
{
	abstract class Man
	{
		private string _name;

		public string Name
		{
			get => _name;
			set
			{
				if (value.Length > 1)
				{
					_name = value;
				}
			}
		}

		public bool IsMan { get; set; }

		private int age;

		public int Age
		{
			get { return age; }
			set {
				if (value>=0)
				{
					age = value;	
				}
			}
		}

		private int weight;

		public int Weight
		{
			get { return weight; }
			set
			{
				if (value>0)
				{
					weight = value;
				}
			}
		}

		public Man(string name, bool mIsMan, int age, int weight)
		{
			Name = name;
			IsMan = mIsMan;
			Age = age;
			Weight = weight;
		}



	}
}
