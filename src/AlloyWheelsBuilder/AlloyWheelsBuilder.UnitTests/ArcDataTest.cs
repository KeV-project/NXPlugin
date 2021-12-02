using NUnit.Framework;
using NXOpen;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
    [TestFixture]
    public class ArcDataTest
    {
        [Test(Description = "Позитивный тест геттера StartPoint")]
        public void TestStartPointGet_CorrectValue()
        {
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d expectedPoint = new Point3d(x, y, z);
            ArcData arcData = new ArcData(expectedPoint, 
                expectedPoint, expectedPoint);

            // act
            Point3d actualPoint = arcData.StartPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Геттер StartPoint " 
                + "возвращает неверне значение");
        }

        [Test(Description = "Позитивный тест сеттера StartPoint")]
        public void TestStartPointSet_CorrectValue()
		{
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d point = new Point3d(x, y, z);
            ArcData arcData = new ArcData(point, point, point);
            const double newZ = 10.0;
            Point3d expectedPoint = new Point3d(z, y, newZ);
            arcData.StartPoint = expectedPoint;

            // act
            Point3d actualPoint = arcData.StartPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Сеттер StartPoint " 
                + "неверно устанавливает значение");
        }

        [Test(Description = "Позитичный тест геттера PointOn")]
        public void TestPointOnGet_CorrectValue()
		{
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d expectedPoint = new Point3d(x, y, z);
            ArcData arcData = new ArcData(expectedPoint,
                expectedPoint, expectedPoint);

            // act
            Point3d actualPoint = arcData.PointOn;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Геттер PointOn "
                + "возвращает неверне значение");
        }

        [Test(Description = "Позитивный тест сеттера PointOn")]
        public void TestPointOnSet_CorrectValue()
		{
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d point = new Point3d(x, y, z);
            ArcData arcData = new ArcData(point, point, point);
            const double newZ = 10.0;
            Point3d expectedPoint = new Point3d(z, y, newZ);
            arcData.PointOn = expectedPoint;

            // act
            Point3d actualPoint = arcData.PointOn;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Сеттер PointOn "
                + "неверно устанавливает значение");
        }

        [Test(Description = "Позитичный тест геттера EndPoint")]
        public void TestEndPointGet_CorrectValue()
        {
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d expectedPoint = new Point3d(x, y, z);
            ArcData arcData = new ArcData(expectedPoint,
                expectedPoint, expectedPoint);

            // act
            Point3d actualPoint = arcData.EndPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Геттер EndPoint "
                + "возвращает неверне значение");
        }

        [Test(Description = "Позитивный тест сеттера EndPoint")]
        public void TestEndPointSet_CorrectValue()
        {
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d point = new Point3d(x, y, z);
            ArcData arcData = new ArcData(point, point, point);
            const double newZ = 10.0;
            Point3d expectedPoint = new Point3d(z, y, newZ);
            arcData.EndPoint = expectedPoint;

            // act
            Point3d actualPoint = arcData.EndPoint;

            // assert
            Assert.AreEqual(expectedPoint, actualPoint, "Сеттер EndPoint "
                + "неверно устанавливает значение");
        }

        [Test(Description = "Позитивный тест конструктора")]
        public void TestConstructor_CorrectValue()
        {
            // setup
            const double x = 0.0;
            const double y = 5.1;
            const double z = -9.0;
            Point3d expectedStartPoint = new Point3d(x, y, z);
            Point3d expectedPointOn = new Point3d(x, y, z);
            Point3d expectedEndPoint = new Point3d(x, y, z);

            // act
            ArcData arcData = new ArcData(expectedStartPoint, 
                expectedPointOn, expectedEndPoint);
            Point3d actualStartPoint = arcData.StartPoint;
            Point3d actualPointOn = arcData.PointOn;
            Point3d actualEndPoint = arcData.EndPoint;

            // assert
            Assert.AreEqual(expectedStartPoint, actualStartPoint, 
                "Конструктор неверно инициализирует свойство StartPoint");
            Assert.AreEqual(expectedPointOn, actualPointOn, 
                "Конструктор неверно инициализирует свойство PointOn");
            Assert.AreEqual(expectedEndPoint, actualEndPoint, 
                "Конструктор неверно инициализирует свойство EndPoint");
        }
    }
}
