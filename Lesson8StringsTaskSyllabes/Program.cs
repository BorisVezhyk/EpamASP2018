using System;
using System.Text;

namespace Less8TaskSyllabes
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			string text =
				"Спайка Прощай зайка спайка \n" +
				" Семья Перья дарья момблан банька\n " +
				"Я сразу смазал карту будня,\n " +
				"плеснувши краску из стакана;\n " +
				"я показал на блюде студня\n" +
				" косые скулы океана.\n" +
				" На чешуе жестяной рыбы\n" +
				" прочёл я зовы новых губ.\n" +
				" А вы\n" +
				" ноктюрн сыграть\n" +
				" могли бы\n" +
				" на флейте водосточных труб?";
			Console.WriteLine(text);
			Syllabe syllabe=new Syllabe();
			string[] words = syllabe.GetArrayWords(text);
			syllabe.ConverWordsInSyllabes(words);
			//text = string.Join(" ", words);
			text = syllabe.CompileText(words);

			Console.WriteLine("\nРазделяем слова текста на слоги по технике Традиционная школа\n");
			Console.WriteLine(text);


			Console.ReadLine();
		}
	}
}
