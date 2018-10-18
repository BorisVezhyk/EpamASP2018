using System;

namespace Lesson9Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			string text =
				"world wide web wide word big pig web hello world hi there next Level how are you you need to solve this task," +
				" world wiDE web wide word big pig web Hello WORLD how are you you need to solve this";

			Frequency.PrintFrequencyWordInText(text);

			Console.ReadLine();
		}
	}
}
