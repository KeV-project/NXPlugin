using System;

namespace AlloyWheelsBuilderModel
{
	/// <summary>
	/// Класс <see cref="ValueValidator"/> предназначен для проверки 
	/// корректности пользовательских значений
	/// </summary>
	public static class ValueValidator
	{
		/// <summary>
		/// Проверяет вещественное число на вхождение в допустимый 
		/// диапазон значений
		/// </summary>
		/// <param name="number">Проверяемое число</param>
		/// <param name="minLimit">Минимальное допустимое значение</param>
		/// <param name="maxLimit">Максимальное допустимое значение</param>
		/// <returns>Возвращает true, если проверяемое число входит в 
		/// допутимый диапазон значение, иначе возвращает false</returns>
		private static bool IsNumberInRange(double number,
			double minLimit, double maxLimit)
		{
			return minLimit <= number && maxLimit >= number;
		}

		/// <summary>
		/// Проверяет вещественное число на вхождение в допустимый 
		/// диапазон значений 
		/// </summary>
		/// <param name="number">Проверяемое число</param>
		/// <param name="minLimit">Минимальное допустимое значение</param>
		/// <param name="maxLimit">Максимальное допустимое значение</param>
		/// <param name="context">Область использования проверяемого 
		/// значения</param>
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
	}
}
