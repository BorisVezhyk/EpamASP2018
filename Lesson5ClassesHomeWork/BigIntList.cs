using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigInteger
{
	class BigIntList
	{
		private List<int> _bigInt = new List<int>();
		
		private const int LIMIT_OF_CELL = 9;

		public BigIntList()
		{
			_bigInt.Add(0);
		}

		public BigIntList(string numString)
		{
			_bigInt= ConverStringToBigInt(numString);
		}

		public BigIntList(long numLong)
		{
			string numStr = numLong.ToString();
			_bigInt = ConverStringToBigInt(numStr);
		}

		public BigIntList(int numInt) : this((long)numInt) { }

		public BigIntList(byte numByte):this((long)numByte) { }

		#region implicit
		public static implicit operator BigIntList(string numString)
		{
			return new BigIntList(numString);
		}

		public static implicit operator BigIntList(long numLong)
		{
			return new BigIntList(numLong);
		}

		public static implicit operator BigIntList(int numInt)
		{
			return new BigIntList(numInt);
		}

		public static implicit operator BigIntList(byte numByte)
		{
			return new BigIntList(numByte);
		}

		#endregion

		public void Subtract(string numSting)
		{
			List<int> rightBi; 
				rightBi= ConverStringToBigInt(numSting);
			List<int> leftBi=new List<int>(this._bigInt);
			int lenghtMax = Math.Max(leftBi.Count, rightBi.Count);
			int lengthLeft = lenghtMax - leftBi.Count;
			for (int j = 0; j <= lengthLeft; j++)
			{
				leftBi.Insert(0, 0);
			}

			int lenghtRight = lenghtMax - rightBi.Count;
			for (int i = 0; i <= lenghtRight; i++)
			{
				rightBi.Insert(0, 0);
			}

			int total = 0;
			int remainder = 0;
			for (int i = leftBi.Count-1; i >= 0; i--)
			{

				if ((leftBi[i] - remainder) < rightBi[i])
				{
					total = (leftBi[i] + 10) - rightBi[i] - remainder;
					remainder = 1;
					leftBi[i] = total;
				}
				else
				{
					total = leftBi[i] - rightBi[i] - remainder;
					remainder = 0;
					leftBi[i] = total;
				}
				
			}

				if (leftBi[0] == 0)
				{
					leftBi.RemoveAt(0);
				}
		
			

			_bigInt = leftBi;
		}


		public void Subtract(long numLong)
		{
			this.Subtract(numLong.ToString());
		}

		public void Addition(string numString)
		{
			List<int> rightBigInt = ConverStringToBigInt(numString);
			List<int> leftBigInt = _bigInt;
			
			AddCellForAddition(leftBigInt,rightBigInt);

			int remainder = 0;
			int total = 0;

			for (int i = leftBigInt.Count-1; i >= 0; i--)
			{
				total = leftBigInt[i] + rightBigInt[i] + remainder;
				remainder = 0;
				if (total > LIMIT_OF_CELL)
				{
					leftBigInt[i] = total % 10;
					remainder = total / 10;
				}
				else
				{
					leftBigInt[i] = total;
				}
			}

			if (leftBigInt[0]==0)
			{
				leftBigInt.RemoveAt(0);
			}
			_bigInt = leftBigInt;
		}

		private void AddCellForAddition(List<int> leftBigInt, List<int> rightBigInt)
		{
			
			int lenghtMax = Math.Max(leftBigInt.Count, rightBigInt.Count);
			int lengthLeft = lenghtMax - leftBigInt.Count;
			for (int j = 0; j <= lengthLeft; j++)
			{
				leftBigInt.Insert(0, 0);
			}

			int lenghtRight = lenghtMax - rightBigInt.Count;
			for (int i = 0; i <= lenghtRight; i++)
			{
				rightBigInt.Insert(0, 0);
			}
		}

		public void Addition(long numLong)
		{
			this.Addition(numLong.ToString());
		}

		public void Multiply(string numS)
		{
			long numl = Convert.ToInt64(numS);
			this.Multiply(numl);
		}

		public void Multiply(long mult)
		{
			int length = mult.ToString().Length;
			List<int> result = _bigInt;
			for (int i = 0; i < length; i++)
			{
				result.Insert(0, 0);
			}

			long multiplier = mult;
			int remainder = 0;

			for (int i = result.Count - 1; i >= 0; i--)
			{
				long total = result[i] * multiplier + remainder;
				remainder = 0;
				if (total > LIMIT_OF_CELL)
				{
					result[i] =(int) total % 10;
					remainder =(int) total / 10;
				}
				else
				{
					result[i] =(int) total;
				}
			}

			if (result[0] == 0)
			{
				result.RemoveAt(0);

			}

			_bigInt = result;
		}


		private List<int> ConverStringToBigInt(string numString)
		{
			List<int> result=new List<int>();
			int startIterator = 0;
			if (numString[0] == '-')
			{
				int negative = -(int)Char.GetNumericValue(numString[1]);
				result.Add(negative);
				startIterator = 2;
			}
			
			for (int i = startIterator; i < numString.Length; i++)
			{
					result.Add((int)Char.GetNumericValue(numString[i]));
			}

			return result;
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < _bigInt.Count; i++)
			{
				result.Append(_bigInt[i]);

			}
			return result.ToString();
		}

		private string PrintBig(List<int> list)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < _bigInt.Count; i++)
			{
				result.Append(_bigInt[i]);

			}

			return result.ToString();
			
		}
	}

}
