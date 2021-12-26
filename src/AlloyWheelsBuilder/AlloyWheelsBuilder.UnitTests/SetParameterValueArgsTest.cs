using NUnit.Framework;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
	[TestFixture]
	class SetParameterValueArgsTest
	{
		[TestCase(TestName = "Позитивный тест сеттера ParameterName")]
		public void TestParameterNameSet_CorrectValue()
		{
			// setup
			const AlloyWheelsParameterName parameterName = 
				AlloyWheelsParameterName.Diameter;
			const string message = "";
			SetParameterValueArgs setParameterValueArgs = 
				new SetParameterValueArgs(parameterName, message);
			const AlloyWheelsParameterName expectedParameterName = 
				AlloyWheelsParameterName.OffSet;

			// act
			setParameterValueArgs.ParameterName = expectedParameterName;
			AlloyWheelsParameterName actualParameterName = 
				setParameterValueArgs.ParameterName;

			// assert
			Assert.AreEqual(expectedParameterName, actualParameterName, 
				"Сеттер ParameterName некорректно устанавливает значение");
		}

		[TestCase(TestName = "Позитивный тест сеттера Message")]
		public void TestMessageSet_CorrectValue()
		{
			// setup
			// setup
			const AlloyWheelsParameterName parameterName =
				AlloyWheelsParameterName.Diameter;
			const string message = "";
			SetParameterValueArgs setParameterValueArgs =
				new SetParameterValueArgs(parameterName, message);
			const string expectedMessage = "Ошибка";

			// act
			setParameterValueArgs.Message = expectedMessage;
			string actualMessage = setParameterValueArgs.Message;

			// assert
			Assert.AreEqual(expectedMessage, actualMessage, 
				"Сеттер Message некорректно устанавливает значение");
		}
	}
}
