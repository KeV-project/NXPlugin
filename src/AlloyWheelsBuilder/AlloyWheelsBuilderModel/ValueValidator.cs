using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlloyWheelsBuilderModel
{
	public static class ValueValidator
	{
		private static bool IsNumberInRange(double number,
			double minLimit, double maxLimit)
		{
			return minLimit <= number && maxLimit >= number;
		}

		private static bool IsNumberPositive(double number)
		{
			return false;
		}


		public static void AssertNumberInRange(double number, 
			double minLimit, double maxLimit, string context)
		{
			if (!IsNumberInRange(number, minLimit, maxLimit))
			{
				throw new ArgumentException("Число " + number 
					+ " не входит в допустимый дипапазон ["
					+ minLimit + ", " + maxLimit + "]"
					+ "\nи не может определять " + context);
			}
		}

		public static void AssertNumberIsPositive(double number, 
			string context)
		{

		}
	}
}
