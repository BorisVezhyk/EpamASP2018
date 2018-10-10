using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6Inheritance
{
	class Teacher : Man
	{
		private List<Student> _pupil=new List<Student>();

		public void AddPupil(params Student[] student)
		{
			for (int i = 0; i < student.Length; i++)
			{
			_pupil.Add(student[i]);

			}
		}

		public void RemovePupil(string name)
		{
			int index = _pupil.FindIndex(x => x.Name == name);

			_pupil.RemoveAt(index);
		}

		public Teacher(string name, bool mIsMan, int age, int weight) : base(name, mIsMan, age, weight)
		{
		}

		public void PrintAllPupil()
		{
			foreach (var student in _pupil)
			{
				Console.WriteLine("{0} is {1}.", student.Name, student.Age);
			}
		}

	}
}
