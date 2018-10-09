using System;

namespace MyBigInteger
{
	class Program
	{
		static void Main(string[] args)
		{
			BigIntList bi = "12312312312";
			bi.Addition(1111111);

			BigIntList bi2 = new BigIntList(135486);
			bi2.Multiply("123456789");

			BigIntList bi3 = new BigIntList(1000);
			bi3 = 123456789;
			bi3.Subtract(123456789);

			Console.WriteLine(bi);
			Console.WriteLine(bi2);
			Console.WriteLine(bi3);
			Console.ReadLine();
		}
	}
}
