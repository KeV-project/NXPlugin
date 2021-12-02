using NUnit.Framework;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test(Description = "Позитивный тест метода IsCirclesIntersect")]
        public void TestIsCirclesIntersect_CorrectValue()
        {
            // setup
            const double centerX = 0.0;
            const double centerY = 0.0;
            const double radius = 3.0;
            const double circlesRadius = 1.0;
            const int circlesCount = 4;

            const bool expectedResult = false;

            // act
            bool actualResult = Сalculator.IsCirclesIntersect(centerX,
                centerY, radius, circlesRadius, circlesCount);

            // assert
            Assert.AreEqual(expectedResult, actualResult, "Метод определил " 
                + "непересекающичеся окружности как пересекающиеся");
        }

        [Test(Description = "Негативный тест метода IsCirclesIntersect")]
        public void TestIsCirclesIntersect_IncorrectValue()
		{
            // setup
            const double centerX = 0.0;
            const double centerY = 0.0;
            const double radius = 3.0;
            const double circlesRadius = 1.0;
            const int circlesCount = 12;

            const bool expectedResult = true;

            // act
            bool actualResult = Сalculator.IsCirclesIntersect(centerX,
                centerY, radius, circlesRadius, circlesCount);

            // assert
            Assert.AreEqual(expectedResult, actualResult, "Метод определил "
                + "пересекающиеся окружности как непересекающиеся");
        }
    }
}
