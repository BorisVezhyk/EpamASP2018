using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6Inheritance
{
	class Student : Man
	{

		private int _studyYears;
		public int StudyYears
		{
			get => _studyYears;
			set
			{
				if (0<=value && value<=5)
				{
					_studyYears = value;
				}
			}

		}

		public Student(string name, bool mIsMan, int age, int weight,int studyYears) : base(name, mIsMan, age, weight)
		{
			StudyYears = studyYears;
		}


	}
}
