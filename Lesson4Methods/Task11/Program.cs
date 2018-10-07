using System;
using System.Text;

namespace TestRiht
{
	class Program
	{

		static void Main(string[] args)
		{
			int[] arrPoly = GetArrayForPolynomial();
			string polynomial= GetStringPolynomial(arrPoly);
			Console.WriteLine(polynomial);
			Console.ReadLine();
		}

		static string GetStringPolynomial(params int[] arrPoly)
		{
			StringBuilder result=new StringBuilder();
			for (int i = arrPoly.Length-1; i >=0; i--)
			{

				if (arrPoly[i] == 0) {continue;}
				if (FirstPart(arrPoly, i, result)) {continue;}
				NeedToAddPlus(arrPoly, i, result);
				if (PreLastPart(arrPoly, i, result)) {continue;}
				if (LastPart(arrPoly, i, result)) {continue;}
				result.Append(arrPoly[i]+"x^"+i);
				
			}

			return result.ToString();
		}

		private static void NeedToAddPlus(int[] arrPoly, int i, StringBuilder result)
		{
			if (arrPoly[i] > 0 && result.Length > 0)
			{
				result.Append("+");
			}
		}

		private static bool FirstPart(int[] arrPoly, int i, StringBuilder result)
		{
			if (i == arrPoly.Length - 1 && i > 1)
			{
				result.Append(GetFirstPartStringPoly(arrPoly, i, result.ToString()));
				return true;
			}

			return false;
		}

		private static bool LastPart(int[] arrPoly, int i, StringBuilder result)
		{
			if (i == 0)
			{
				result.Append(arrPoly[i]);
				return true;
			}

			return false;
		}

		private static bool PreLastPart(int[] arrPoly, int i, StringBuilder result)
		{
			if (i == 1)
			{
				if (arrPoly[i]==1)
				{
					result.Append("x");
					return true;
				}
				result.Append(arrPoly[i] + "x");
				return true;

			}

			return false;
		}

		private static string GetFirstPartStringPoly(int[] arrPoly, int i, string res)
		{
			string result = res;
			if (arrPoly[i] == 1)
			{
				result+="x^" + i;
			}
			else
			{
				result+=arrPoly[i] + "x^" + i;
			}

			return result;
		}


		static int[] GetArrayForPolynomial()
		{
			Console.WriteLine("Enter number for array length n>0");
			int lengthArray = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(string.Format("Enter {0} numbers",lengthArray));
			int[] arrayForPoly = new int[lengthArray];
			for (int i = 0; i < lengthArray; i++)
			{
				arrayForPoly[i] = Convert.ToInt32(Console.ReadLine());
			}

			return arrayForPoly;
		}
	}
}
