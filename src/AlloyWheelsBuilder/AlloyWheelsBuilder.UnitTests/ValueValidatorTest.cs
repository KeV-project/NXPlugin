using System;
using NUnit.Framework;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
	[TestFixture]
	public class ValueValidatorTest
	{
		[TestCase(TestName = "Позитивный тест метода AssertNumberInRange")]
		public void TestAssertNumberInRange_СorrectValue()
		{
			// setup
			const double diameter = 440;
			const double minDiameter = 101.6;
			const double maxDiameter = 1117.2;
			const string context = "диаметр диска";

			// act
			ValueValidator.AssertNumberInRange(diameter, minDiameter,
			  maxDiameter, context);
		}

		[TestCase(TestName = "Негативный тест метода AssertNumberInRange")]
		public void TestAssertNumberInRange_IncorrectValue()
		{
			// setup
			const double wrongDiameter = 440;
			const double minDiameter = 666.6;
			const double maxDiameter = 1117.2;
			const string context = "диаметр диска";

			// assert
			Assert.Throws<ArgumentException>(() =>
			{
				ValueValidator.AssertNumberInRange(wrongDiameter, minDiameter,
					maxDiameter, context);
			}, "Должно возникать искючение, " +
			"если проверяемое число не входит в допустимый диапазон");
		}
	}
}
