using System;

namespace Lesson6Inheritance
{
	class Program
	{
		static void Main(string[] args)
		{
			Teacher teacher = new Teacher("Ivan", true, 40, 70);
			Student stud1 = new Student("Dima", true, 20, 60, 2);
			Student stud2 = new Student("Ula", false, 18, 60, 0);
			Student stud3 = new Student("Vanya", true, 21, 65, 2);
			Student stud4 = new Student("Kiril", true, 22, 60, 5);
			
			teacher.AddPupil(stud1,stud2,stud3,stud4);
			teacher.PrintAllPupil();
			Console.WriteLine("Need to remove one pupil with name Kiril");

			teacher.RemovePupil("Kiril");
			teacher.PrintAllPupil();
			
			
			Console.ReadLine();
		}
	}
}
