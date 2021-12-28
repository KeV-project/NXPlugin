using NUnit.Framework;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
    [TestFixture]
    public class CalculatorTest
    {
        /// <summary>
        /// Координата x центра оси, на которой располагаются окружности
        /// </summary>
        const double CENTER_X = 0.0;

        /// <summary>
        /// Координата y центра оси, на которой располагаются окружности
        /// </summary>
        const double CENTER_Y = 0.0;

        /// <summary>
        /// Радиус оси, на которой располагаются окружности
        /// </summary>
        const double RADIUS = 3.0;

        /// <summary>
        /// Радиус окружностей
        /// </summary>
        const double CIRCLES_RADIUS = 1.0;

        [TestCase(TestName = "Позитивный тест метода IsCirclesIntersect")]
        public void TestIsCirclesIntersect_CorrectValue()
        {
            // setup
            const int circlesCount = 4;

            const bool expectedResult = false;

            // act
            bool actualResult = Сalculator.IsCirclesIntersect(CENTER_X,
                CENTER_Y, RADIUS, CIRCLES_RADIUS, circlesCount);

            // assert
            Assert.AreEqual(expectedResult, actualResult, "Метод определил " 
                + "непересекающичеся окружности как пересекающиеся");
        }

        [TestCase(TestName = "Негативный тест метода IsCirclesIntersect")]
        public void TestIsCirclesIntersect_IncorrectValue()
		{
            // setup
            const int circlesCount = 12;

            const bool expectedResult = true;

            // act
            bool actualResult = Сalculator.IsCirclesIntersect(CENTER_X,
                CENTER_Y, RADIUS, CIRCLES_RADIUS, circlesCount);

            // assert
            Assert.AreEqual(expectedResult, actualResult, "Метод определил "
                + "пересекающиеся окружности как непересекающиеся");
        }
    }
}
