using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Less8TaskSyllabes
{
	class Syllabe
	{
		private char[] vowels =
			{'ё', 'Ё', 'у', 'У', 'е', 'Е', 'ы', 'Ы', 'а', 'А', 'о', 'О', 'э', 'Э', 'я', 'Я', 'и', 'И', 'ю', 'Ю'};

		private char[] excTraditionalStudy = {'й', 'ъ', 'ь'};

		public string[] GetArrayWords(string text)
		{
			return text.Split(new []{" ","\r\n"},StringSplitOptions.None);
		}

		public string CompileText(string[] words)
		{
			return string.Join(" ", words);
		}

		public void ConverWordsInSyllabes(string[] words)
		{
			for (int i = 0; i < words.Length; i++)
			{
				int countVolwels = GetCountVolwels(words[i]);
				if (countVolwels==1 && words[i].Length==1)
				{
					continue;
				}

				words[i] = GetStringWithSyllabes(words[i],countVolwels);
			}
		}

		private string GetStringWithSyllabes(string word, int countVolwels)
		{
			StringBuilder result = new StringBuilder();
			bool neededAppend = false;
			bool isThereExcpt = CheckOnTraditionalStudy(word);
			for (int i = 0; i < word.Length; i++)
			{
				neededAppend = true;
				for (int j = 0; j < vowels.Length; j++)
				{
					if (word[i]==vowels[j] && countVolwels>1)
					{
						if ((i+1)<word.Length && excTraditionalStudy.Contains(word[i+1]))
						{
							result.Append(word.Substring(i,2)+"-");
							i++;
							neededAppend = false;
							countVolwels--;
							continue;
						}
						if((i+2)<word.Length && excTraditionalStudy.Contains(word[i + 2]))
						{
							result.Append(word.Substring(i, 3) + "-");
							i += 2;
							neededAppend = false;
							countVolwels--;
							continue;
						}
						else
						{
							result.Append(word[i] + "-");
							neededAppend = false;
							countVolwels--;
							continue;
						}
					}
				}

				if (neededAppend)
				{
					result.Append(word[i]);
				}
			}

			return result.ToString();
		}

		private int GetCountVolwels(string word)
		{
			return word.Split(vowels).Length - 1;
		}

		private bool CheckOnTraditionalStudy(string word)
		{
			return word.IndexOfAny(excTraditionalStudy) > 0;
		}


	}
}
