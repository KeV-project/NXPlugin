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
			double minLimit, int maxLimit)
		{
			return false;
		}

		private static bool IsNumberPositive(double number)
		{
			return false;
		}


		public static void AssertNumberInRange(double number, 
			double minLimit, int maxLimit, string context)
		{

		}

		public static void AssertNumberIsPositive(double number, 
			string context)
		{

		}
	}
}
