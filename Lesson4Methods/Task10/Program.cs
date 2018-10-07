using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Principal;

namespace Task10
{
	class Program
	{
		private const int MaxRangeFactorial = 100;
		private const int MaxSizeArray = 1000;
		private const int LimitOfCell = 9;

		static void Main(string[] args)
		{
			int[] arrayFactorial = new int[MaxSizeArray];
			arrayFactorial[MaxSizeArray-1] = 1;
			for (int i = 1; i <= MaxRangeFactorial; i++)
			{
				arrayFactorial= GetArrayFact(arrayFactorial,i);
			}
			PrintArrayFactorial(arrayFactorial);
			Console.ReadLine();
		}

		static int[] GetArrayFact(int[] sourceArr, int factorial)
		{
			int[] arrayResultFact = sourceArr;
			int multiplier = factorial;
			int remainder = 0;

			for (int i = arrayResultFact.Length-1; i >=0; i--)
			{
				int total = arrayResultFact[i] * multiplier+remainder;
				remainder = 0;
				if (total > LimitOfCell)
				{
					arrayResultFact[i] = total % 10;
					remainder = total / 10;
				}
				else
				{
					arrayResultFact[i] = total;
				}
			}

			return arrayResultFact;
		}

		static void PrintArrayFactorial(int[] arrayFactorial)
		{
			bool isFirstZeros = true;
			for (int i = 0; i < arrayFactorial.Length; i++)
			{
				if (isFirstZeros && arrayFactorial[i]==0)
				{
					continue;
				}

				isFirstZeros = false;
				Console.Write(arrayFactorial[i]);
			}

			Console.WriteLine();
		}
	}

	
}
