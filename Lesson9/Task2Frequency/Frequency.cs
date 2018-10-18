using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson9Task2
{
	static class Frequency
	{
		static Dictionary<string, int> frequencyInts = new Dictionary<string, int>();

		private static string[] GetSplitText(string text)
		{
			text.Trim(' ');
			return text.Split(new char[] {' ', '.', ',', '?', '!'});
		}

		public static void PrintFrequencyWordInText(string text)
		{
			frequencyInts.Clear();
			string[] words = GetSplitText(text);
			foreach (var word in words)
			{
				SaveInDictionary(word.ToLower());
			}
			Print();
		}

		private static void SaveInDictionary(string word)
		{
			
			if (frequencyInts.ContainsKey(word))
			{
				frequencyInts[word] = frequencyInts[word] + 1;
			}
			else
			{
				frequencyInts.Add(word,1);
			}
		}

		private static void Print()
		{
			foreach (var word in frequencyInts)
			{
				Console.WriteLine("Frequency {0} ={1}",word.Key,word.Value);
			}
		}

	}
}
