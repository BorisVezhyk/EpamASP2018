using System;
using System.Linq;
using System.Text;

namespace Less8TaskSyllabes
{
	class Syllabe
	{
		private char[] _vowels =
			{'ё', 'Ё', 'у', 'У', 'е', 'Е', 'ы', 'Ы', 'а', 'А', 'о', 'О', 'э', 'Э', 'я', 'Я', 'и', 'И', 'ю', 'Ю'};

		private char[] _excTraditionalStudy = {'й', 'ъ', 'ь'};

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
			for (int i = 0; i < word.Length; i++)
			{
				if (_vowels.Contains(word[i]) && countVolwels>1)
					{
						if ((i+1)<word.Length && _excTraditionalStudy.Contains(word[i+1]))
						{
							result.Append(word.Substring(i,2)+"-");
							i++;
							countVolwels--;
							continue;
						}
						if((i+2)<word.Length && _excTraditionalStudy.Contains(word[i + 2]))
						{
							result.Append(word.Substring(i, 3) + "-");
							i += 2;
							countVolwels--;
							continue;
						}
						
						result.Append(word[i] + "-");
						countVolwels--;
						continue;
					}

				result.Append(word[i]);
			}

			return result.ToString();
		}

		private int GetCountVolwels(string word)
		{
			return word.Split(_vowels).Length - 1;
		}
	}
}
