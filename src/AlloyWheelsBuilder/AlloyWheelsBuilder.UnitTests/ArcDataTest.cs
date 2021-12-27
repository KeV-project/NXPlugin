using NUnit.Framework;
using NXOpen;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
    [TestFixture]
    public class ArcDataTest
    {
        private const double X = 0.0;
        private const double Y = 5.1;
        private const double Z = -9.0;

        public Point3d Point => new Point3d(X, Y, Z);

        public ArcData ArcData => new ArcData(Point, Point, Point);


        [TestCase(TestName = "Позитивный тест геттера StartPoint")]
        public void TestStartPointGet_CorrectValue()
        {
            // setup
            Point3d expectedPoint = Point;
            ArcData arcData = ArcData;

            // act
            Point3d actualPoint = arcData.StartPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Геттер StartPoint " 
                + "возвращает неверне значение");
        }

        [TestCase(TestName = "Позитивный тест сеттера StartPoint")]
        public void TestStartPointSet_CorrectValue()
        {
            // setup
            ArcData arcData = ArcData;
            const double newZ = 10.0;
            Point3d expectedPoint = new Point3d(X, Y, newZ);
            arcData.StartPoint = expectedPoint;

            // act
            Point3d actualPoint = arcData.StartPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Сеттер StartPoint " 
                + "неверно устанавливает значение");
        }

        [TestCase(TestName = "Позитичный тест геттера PointOn")]
        public void TestPointOnGet_CorrectValue()
        {
            // setup
            Point3d expectedPoint = Point;
            ArcData arcData = ArcData;

            // act
            Point3d actualPoint = arcData.PointOn;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Геттер PointOn "
                + "возвращает неверне значение");
        }

        [TestCase(TestName = "Позитивный тест сеттера PointOn")]
        public void TestPointOnSet_CorrectValue()
        {
            // setup
            ArcData arcData = ArcData;
            const double newZ = 10.0;
            Point3d expectedPoint = new Point3d(Z, Y, newZ);
            arcData.PointOn = expectedPoint;

            // act
            Point3d actualPoint = arcData.PointOn;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Сеттер PointOn "
                + "неверно устанавливает значение");
        }

        [TestCase(TestName = "Позитичный тест геттера EndPoint")]
        public void TestEndPointGet_CorrectValue()
        {
            // setup
            Point3d expectedPoint = Point;
            ArcData arcData = ArcData;

            // act
            Point3d actualPoint = arcData.EndPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Геттер EndPoint "
                + "возвращает неверне значение");
        }

        [TestCase(TestName = "Позитивный тест сеттера EndPoint")]
        public void TestEndPointSet_CorrectValue()
        {
            // setup
            ArcData arcData = ArcData;
            const double newZ = 10.0;
            Point3d expectedPoint = new Point3d(Z, Y, newZ);
            arcData.EndPoint = expectedPoint;

            // act
            Point3d actualPoint = arcData.EndPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Сеттер EndPoint "
                + "неверно устанавливает значение");
        }

        [TestCase(TestName = "Позитивный тест конструктора")]
        public void TestConstructor_CorrectValue()
        {
            // act
            ArcData arcData = ArcData;
            Point3d actualStartPoint = arcData.StartPoint;
            Point3d actualPointOn = arcData.PointOn;
            Point3d actualEndPoint = arcData.EndPoint;

            // assert
            Assert.AreEqual(Point, actualStartPoint, 
                "Конструктор неверно инициализирует свойство StartPoint");
            Assert.AreEqual(Point, actualPointOn, 
                "Конструктор неверно инициализирует свойство PointOn");
            Assert.AreEqual(Point, actualEndPoint, 
                "Конструктор неверно инициализирует свойство EndPoint");
        }

        [TestCase(TestName = "Позитивный тест метода CompareTo")]
        public void TestCompareTo_CorrectValue()
        {
            // setup
            ArcData arcData = ArcData;
            ArcData comparedArcData = ArcData;
            const int expectedResult = 1;

            // act
            int actualResult = arcData.CompareTo(comparedArcData);

            // assert
            Assert.AreEqual(expectedResult, actualResult, 
                "Метод CompareTo некорректно сравнивает идентичные объекты");
        }

        [TestCase(TestName = "Негативный тест метода CompareTo")]
        public void TestCompareTo_IncorrectValue()
		{
            // setup
            ArcData arcData = ArcData;
            Point3d newEndPoint = new Point3d(Z, X, Y);
            ArcData comparedArcData = new ArcData(arcData.StartPoint,
                arcData.PointOn, newEndPoint);
            const int expectedResult = 0;

            // act
            int actualResult = arcData.CompareTo(comparedArcData);

            // assert
            Assert.AreEqual(expectedResult, actualResult,
                "Метод CompareTo некорректно сравнивает разные объекты");
        }
    }
}
