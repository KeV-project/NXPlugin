using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NXOpen;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
    [TestFixture]
    public class AlloyWheelsDataTest
    {
        private List<ArcData> _sketchArcs = new List<ArcData>()
        {
            new ArcData(new Point3d(15.44323363559, 92.43285152947, 0.00000000000),
                new Point3d(17.60996477529, 92.55690331473, 0.00000000000),
                new Point3d(19.77669591499, 92.43285152947, 0.00000000000)),
            new ArcData(new Point3d(19.77669591499, 92.43285152947, 0.00000000000),
                new Point3d(23.55528849074, 90.67939696317, 0.00000000000),
                new Point3d(25.53823099100, 87.01602368023, 0.00000000000)),
            new ArcData(new Point3d(25.53823099100, 87.01602368023, 0.00000000000),
                new Point3d(27.17454523816, 83.85873231365, 0.00000000000),
                new Point3d(30.31488827624, 82.19012250545, 0.00000000000)),
            new ArcData(new Point3d(30.31488827624, 82.19012250545, 0.00000000000),
                new Point3d(33.56375925018, 82.10282645413, 0.00000000000),
                new Point3d(36.67623414550, 83.03839218236, 0.00000000000)),
            new ArcData(new Point3d(36.67623414550, 83.03839218236, 0.00000000000),
                new Point3d(38.33517611971, 83.18427403455, 0.00000000000),
                new Point3d(39.67122728857, 82.19012250545, 0.00000000000)),
            new ArcData(new Point3d(39.67122728857, 82.19012250545, 0.00000000000),
                new Point3d(40.56414904539, 80.83409095227, 0.00000000000),
                new Point3d(41.49719071266, 79.5053456478, 0.00000000000)),
            new ArcData(new Point3d(41.49719071266, 79.5053456478, 0.00000000000),
                new Point3d(42.78681697037, 78.45407714785, 0.00000000000),
                new Point3d(44.42818701799, 78.18166989701, 0.00000000000)),
            new ArcData(new Point3d(44.42818701799, 78.18166989701, 0.00000000000),
                new Point3d(53.58361096100, 77.98150676627, 0.00000000000),
                new Point3d(62.73903490401, 78.18166989701, 0.00000000000)),
            new ArcData(new Point3d(62.73903490401, 78.18166989701, 0.00000000000),
                new Point3d(73.66231678350, 79.36874173704, 0.00000000000),
                new Point3d(84.54816870285, 80.8605374879, 0.00000000000)),
            new ArcData(new Point3d(84.54816870285, 80.8605374879, 0.00000000000),
                new Point3d(85.52865954895, 81.11173765126, 0.00000000000),
                new Point3d(86.43913406113, 81.55389145261, 0.00000000000)),
            new ArcData(new Point3d(86.43913406113, 81.55389145261, 0.00000000000),
                new Point3d(87.21242782586, 82.12029624435, 0.00000000000),
                new Point3d(87.88635288200, 82.80192858907, 0.00000000000)),
            new ArcData(new Point3d(87.88635288200, 82.80192858907, 0.00000000000),
                new Point3d(89.14699645419, 83.38814382466, 0.00000000000),
                new Point3d(90.40764002637, 82.80192858907, 0.00000000000)),
            new ArcData(new Point3d(90.40764002637, 82.80192858907, 0.00000000000),
                new Point3d(91.00489456033, 82.34726834978, 0.00000000000),
                new Point3d(91.73887963860, 82.19012250545, 0.00000000000)),
            new ArcData(new Point3d(91.73887963860, 82.19012250545, 0.00000000000),
                new Point3d(93.92735687980, 82.19992512608, 0.00000000000),
                new Point3d(96.11583412100, 82.19012250544, 0.00000000000)),
            new ArcData(new Point3d(96.11583412100, 82.19012250544, 0.00000000000),
                new Point3d(97.46124390208, 82.67177439829, 0.00000000000),
                new Point3d(98.17320443105, 83.91081767038, 0.00000000000)),
            new ArcData(new Point3d(98.17320443001, 83.91081767038, 0.00000000000),
                new Point3d(98.55646038662, 85.59273051192, 0.00000000000),
                new Point3d(99.12283685729, 87.22212721925, 0.00000000000)),
            new ArcData(new Point3d(99.12283685729, 87.22212721925, 0.00000000000),
                new Point3d(99.86542646009, 88.77913608826, 0.00000000000),
                new Point3d(100.77517276404, 90.24476823926, 0.00000000000)),
            new ArcData(new Point3d(100.77517276404, 90.24476823926, 0.00000000000),
                new Point3d(102.20059825326, 91.58416471626, 0.00000000000),
                new Point3d(104.04276090315, 92.24162765761, 0.00000000000)),
            new ArcData(new Point3d(104.04276090315, 92.24162765761, 0.00000000000),
                new Point3d(106.62455893899, 92.4188396, 0.00000000000),
                new Point3d(109.20635697483, 92.24162765761, 0.00000000000)),
            new ArcData(new Point3d(109.20635697483, 92.24162765761, 0.00000000000),
                new Point3d(109.38766428380, 90.33553457646, 0.00000000000),
                new Point3d(109.20635697483, 88.42944149531, 0.00000000000)),
            new ArcData(new Point3d(109.20635697483, 88.42944149531, 0.00000000000),
                new Point3d(107.64113094296, 88.35641754421, 0.00000000000),
                new Point3d(106.07590491109, 88.42944149531, 0.00000000000)),
            new ArcData(new Point3d(106.07590491109, 88.42944149531, 0.00000000000),
                new Point3d(104.83539052828, 88.04817677016, 0.00000000000),
                new Point3d(104.04276090315, 87.02056935388, 0.00000000000)),
            new ArcData(new Point3d(104.04276090315, 87.02056935388, 0.00000000000),
                new Point3d(103.27480666706, 84.78942780707, 0.00000000000),
                new Point3d(102.58639017882, 82.53247653392, 0.00000000000)),
            new ArcData(new Point3d(102.58639017882, 82.53247653392, 0.00000000000),
                new Point3d(101.86511563389, 80.77269834792, 0.00000000000),
                new Point3d(100.77517276404, 79.21414749103, 0.00000000000)),
            new ArcData(new Point3d(100.77517276404, 79.21414749103, 0.00000000000),
                new Point3d(99.37189304457, 78.68481475187, 0.00000000000),
                new Point3d(97.87981522137, 78.53285788531, 0.00000000000)),
            new ArcData(new Point3d(97.87981522137, 78.53285788531, 0.00000000000),
                new Point3d(93.92926082081, 78.58839666299, 0.00000000000),
                new Point3d(89.97870642026, 78.5328578853, 0.00000000000)),
            new ArcData(new Point3d(89.97870642026, 78.5328578853, 0.00000000000),
                new Point3d(89.30879064420, 78.4093443311, 0.00000000000),
                new Point3d(88.70797769904, 78.08830453601, 0.00000000000)),
            new ArcData(new Point3d(88.70797769904, 78.08830453601, 0.00000000000),
                new Point3d(87.73521573312, 77.56679015178, 0.00000000000),
                new Point3d(86.65060738924, 77.36217383843, 0.00000000000)),
            new ArcData(new Point3d(86.65060738924, 77.36217383843, 0.00000000000),
                new Point3d(76.90213931146, 76.63400952691, 0.00000000000),
                new Point3d(67.24583604330, 75.11129474026, 0.00000000000)),
            new ArcData(new Point3d(67.24583604330, 75.11129474026, 0.00000000000),
                new Point3d(54.77728321221, 74.7130256015, 0.00000000000),
                new Point3d(42.30873038112, 75.11129474029, 0.00000000000)),
            new ArcData(new Point3d(42.30873038112, 75.11129474029, 0.00000000000),
                new Point3d(41.65667885794, 75.34295325559, 0.00000000000),
                new Point3d(41.22457690904, 75.88343892826, 0.00000000000)),
            new ArcData(new Point3d(41.22457690904, 75.88343892826, 0.00000000000),
                new Point3d(31.91142478783, 51.01938657605, 0.00000000000),
                new Point3d(33.98890137774, 16.16394601204, 0.00000000000)),
            new ArcData(new Point3d(33.98890137774, 16.16394601204, 0.00000000000),
                new Point3d(36.65318046636, 16.04061447383, 0.00000000000),
                new Point3d(39.31745955499, 16.16394601204, 0.00000000000)),
            new ArcData(new Point3d(39.31745955499, 16.16394601204, 0.00000000000),
                new Point3d(39.59029603990, 8.22516827524, 0.00000000000),
                new Point3d(39.31745955499, 0.28639053845, 0.00000000000)),
            new ArcData(new Point3d(39.31745955499, 0.28639053845, 0.00000000000),
                new Point3d(30.00969964442, 0.0, 0.00000000000),
                new Point3d(20.70193973385, 0.28639053845, 0.00000000000)),
            new ArcData(new Point3d(20.70193973385, 0.28639053845, 0.00000000000),
                new Point3d(21.42209908822, 1.0861012816, 0.00000000000),
                new Point3d(21.97417666841, 2.00988540892, 0.00000000000)),
            new ArcData(new Point3d(21.97417666841, 2.00988540892, 0.00000000000),
                new Point3d(22.16443323036, 8.35249838148, 0.00000000000),
                new Point3d(21.97417666841, 14.69511135405, 0.00000000000)),
            new ArcData(new Point3d(21.97417666841, 14.69511135405, 0.00000000000),
                new Point3d(22.91751971942, 15.69350857512, 0.00000000000),
                new Point3d(23.36782291782, 16.99116806529, 0.00000000000)),
            new ArcData(new Point3d(23.36782291782, 16.99116806529, 0.00000000000),
                new Point3d(25.13366583262, 47.70717162499, 0.00000000000),
                new Point3d(29.36403590491, 78.18166989706, 0.00000000000)),
            new ArcData(new Point3d(29.36403590491, 78.18166989706, 0.00000000000),
                new Point3d(27.72584404825, 78.10190743983, 0.00000000000),
                new Point3d(26.08765219159, 78.18166989701, 0.00000000000)),
            new ArcData(new Point3d(26.08765219159, 78.18166989701, 0.00000000000),
                new Point3d(23.60214791278, 80.19065421666, 0.00000000000),
                new Point3d(22.38986588753, 83.14770034546, 0.00000000000)),
            new ArcData(new Point3d(22.38986588753, 83.14770034546, 0.00000000000),
                new Point3d(22.03013014096, 84.83377821022, 0.00000000000),
                new Point3d(21.43177677267, 86.45063986789, 0.00000000000)),
            new ArcData(new Point3d(21.43177677267, 86.45063986789, 0.00000000000),
                new Point3d(20.45707336288, 87.62430486681, 0.00000000000),
                new Point3d(19.02122258524, 88.1399295473, 0.00000000000)),
            new ArcData(new Point3d(19.02122258524, 88.1399295473, 0.00000000000),
                new Point3d(17.23222811099, 88.20998220744, 0.00000000000),
                new Point3d(15.44323363681, 88.13992954748, 0.00000000000)),
            new ArcData(new Point3d(15.44323363681, 88.13992954748, 0.00000000000),
                new Point3d(15.37629964075, 90.28639053845, 0.00000000000),
                new Point3d(15.44323363559, 92.43285152947, 0.00000000000))
        };

        private List<ArcData> _petalSketchArcs = new List<ArcData>()
        {
            new ArcData(new Point3d(0.00000000000, 187.81396319307, 0.00000000000),
                new Point3d(0.00000000000, 187.57705015397, -13.51344554558),
                new Point3d(0.00000000000, 186.29342713558, -26.96787419372)),
            new ArcData(new Point3d(0.00000000000, 186.29342713558, -26.96787419372),
                new Point3d(0.00000000000, 185.28516964806, -29.06336944390),
                new Point3d(0.00000000000, 183.23691660408, -30.16443391632)),
            new ArcData(new Point3d(0.00000000000, 183.23691660408, -30.16443391632),
                new Point3d(0.00000000000, 130.59627018679, -19.85378699770),
                new Point3d(0.00000000000, 77.91601734948, -9.74744957416)),
            new ArcData(new Point3d(0.00000000000, 77.91601734948, -9.74744957416),
                new Point3d(0.00000000000, 75.25013217689, -5.20263457372),
                new Point3d(0.00000000000, 74.41653717094, 0.00000000000))
        };

        [Test(Description = "Позитивный тест геттера SketchArcsCount")]
        public void TestSketchArcsCountGet_CorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const int expectedSketchArcsCount = 45;

            // act
            int actualSketchArcsCount = alloyWheelsData.SketchArcsCount;

            // assert
            Assert.AreEqual(expectedSketchArcsCount, actualSketchArcsCount, 
                "Геттер SketchArcsCount возвращает некорректное значение");
        }

        [Test(Description = "Позитивный тест геттера SketchArcs")]
        public void TestSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            List<ArcData> expectedSketchArcs = _sketchArcs;
            int expectedSketchArcsCount = expectedSketchArcs.Count;

            // act
            List<ArcData> actualSketchArcs = alloyWheelsData.SketchArcs;
            int actualSketchArcsCount = actualSketchArcs.Count;

            // assert
            Assert.AreEqual(expectedSketchArcsCount, actualSketchArcsCount,
                "Геттер SketchArcs возвращает список " 
                + "с некорректным количеством элементов");

            for(int i = 0; i < actualSketchArcsCount; i++)
            {
                ArcData expectedArcData = expectedSketchArcs[i];
                ArcData actualArcData = actualSketchArcs[i];

                const int expectedResult = 1;
                int actualResult = expectedArcData.CompareTo(actualArcData);

                Assert.AreEqual(expectedResult, actualResult, 
                    "Геттер SketchArcs вернул список " 
                    + "с некорректным элементом №" + i);
            }
        }

        [Test(Description = "Позитивный тест геттера PetalSketchArcs")]
        public void TestPetalSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            List<ArcData> expectedPetalSketchArcs = _petalSketchArcs;
            int expectedPetalSketchArcsCount = _petalSketchArcs.Count();

            // act
            List<ArcData> actualPetalSketchArcs = alloyWheelsData.
                PetalSketchArcs;
            int actualPetalSketchArcsCount = actualPetalSketchArcs.Count;

            // assert
            Assert.AreEqual(expectedPetalSketchArcsCount, 
                actualPetalSketchArcsCount, "Геттер PetalSketchArcs " 
                + "возвращает список с некорректным количеством элементов");
            for (int i = 0; i < actualPetalSketchArcsCount; i++)
            {
                ArcData expectedArcData = expectedPetalSketchArcs[i];
                ArcData actualArcData = actualPetalSketchArcs[i];

                const int expectedResult = 1;
                int actualResult = expectedArcData.CompareTo(actualArcData);

                Assert.AreEqual(expectedResult, actualResult,
                    "Геттер PetalSketchArcs вернул список "
                    + "с некорректным элементом №" + i);
            }
        }

        [Test(Description = "Позитивный тест геттера PetalSketchHeight")]
        public void TestPetalSketchHeightGet_CorrectValue()
        {
            // setup
            const double expectedPetalSketchHeight = 113.4;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();

            // act
            double actualPetalSketchHeight = alloyWheelsData.
                PetalSketchHeight;

            // assert
            Assert.AreEqual(expectedPetalSketchHeight, 
                actualPetalSketchHeight, "Геттер PetalSketchHeight возвращает " 
                + "некорректное значение");
        }

        [Test(Description = "Позитивный тест геттера MinDiameter")]
        public void TestMinDiameterGet_CorrectValue()
        {
            // setup
            const double expectedMinDiameter = 101.6;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();

            // act
            double actualMinDiameter = alloyWheelsData.MinDiameter;

            // assert
            Assert.AreEqual(expectedMinDiameter, actualMinDiameter, 
                "Геттер MinDiameter возвращает некорректное значение");
        }

        [Test(Description = "Позитивный тест геттера MaxDiameter")]
        public void TestMaxDiameterGet_CorrectValue()
        {
            // setup
            const double expectedMaxDiameter = 1447.8;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();

            // act
            double actualMaxDiameter = alloyWheelsData.MaxDiameter;

            // assert
            Assert.AreEqual(expectedMaxDiameter, actualMaxDiameter, 
                "Геттер MaxDiameter возвращает некорректное значение");
        }

        [Test(Description = "Позитивный тест сеттера Diameter")]
        public void TestDiameterSet_CorrectValue()
        {
            // setup
            const double expectedDiameter = 220.0;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();

            // act
            alloyWheelsData.Diameter = expectedDiameter;
            double actualDiameter = alloyWheelsData.Diameter;

            // assert
            Assert.AreEqual(expectedDiameter, actualDiameter, 
                "Сеттер Diameter некорректно устанавливает значение");
        }

        [Test(Description = "Негативный тест сеттера Diameter")]
        public void TestDiameterSet_IncorrectValue()
        {
            // setup
            const double wrongDiameter = -100;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                alloyWheelsData.Diameter = wrongDiameter;
            }, "Должно возникать исключение, " 
            +  "если устанавливаемое значение диаметра " 
            + "не входит в допустимый диапазон значений");
        }

        [Test(Description = "Негативный тест сеттера Diameter")]
        public void TestDiameterSet_NanValue()
        {
            // setup
            const double expectedWrongDiameter = double.NaN;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();

            // act
            alloyWheelsData.Diameter = expectedWrongDiameter;
            double actualWrongDiameter = alloyWheelsData.Diameter;

            // assert
            Assert.AreEqual(expectedWrongDiameter, actualWrongDiameter, 
                "При попытке установить свойству Diameter значение double.NaN" 
                +  " не должно возикать исключение");
        }

        [Test(Description = "Позитивный тест геттера " 
            + "MinCentralHoleDiameter")]
        public void TestMinCentralHoleDiameter_CorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            const double expectedMinCentralHoleDiameter = 22.0;

            // act
            double actualMinCentralHoleDiameter = alloyWheelsData.
                MinCentralHoleDiameter;

            // assert
            Assert.AreEqual(expectedMinCentralHoleDiameter, 
                actualMinCentralHoleDiameter, "Геттер MinCentralHoleDiameter"
                + " неверно расчитывает минимальный диаметр" 
                + " центрального отверстия");
        }

        [Test(Description = "Негативный тест геттера " 
            + "MinCentralHoleDiameter")]
        public void TestMinCentralHoleDiameter_IncorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedMinCentralHoleDiameter = double.NaN;

            // act
            double actualMinCentralHoleDiameter = alloyWheelsData.
                MinCentralHoleDiameter;

            // assert
            Assert.AreEqual(expectedMinCentralHoleDiameter,
                actualMinCentralHoleDiameter, "Геттер MinCentralHoleDiameter"
                + " возвращает некорректное значение " 
                + "при неизвестном диаметре");
        }

        [Test(Description = "Позитивный тест геттера "
            + "MaxCentralHoleDiameter")]
        public void TestMaxCentralHoleDiameter_CorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            const double expectedMaxCentralHoleDiameter = 39.6;

            // act
            double actualMaxCentralHoleDiameter = alloyWheelsData.
                MaxCentralHoleDiameter;

            // assert
            Assert.AreEqual(expectedMaxCentralHoleDiameter,
                actualMaxCentralHoleDiameter, "Геттер MaxCentralHoleDiameter"
                + " неверно расчитывает максимальный диаметр"
                + " центрального отверстия");
        }

        [Test(Description = "Негативный тест геттера "
            + "MaxCentralHoleDiameter")]
        public void TestMaxCentralHoleDiameter_IncorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedMaxCentralHoleDiameter = double.NaN;

            // act
            double actualMaxCentralHoleDiameter = alloyWheelsData.
                MaxCentralHoleDiameter;

            // assert
            Assert.AreEqual(expectedMaxCentralHoleDiameter,
                actualMaxCentralHoleDiameter, "Геттер MaxCentralHoleDiameter"
                + " возвращает некорректное значение "
                + "при неизвестном диаметре");
        }

        [Test(Description = "Позитивный тест сеттера CentralHoleDiameter")]
        public void TestCentralHoleDiameterSet_CorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            const double expectedCentralHoleDiameter = 24.0;

            // act
            alloyWheelsData.CentralHoleDiameter = 
                expectedCentralHoleDiameter;
            double actualCentralHoleDiameter = alloyWheelsData.
                CentralHoleDiameter;

            // assert
            Assert.AreEqual(expectedCentralHoleDiameter, 
                actualCentralHoleDiameter, "Сеттер CentralHoleDiameter " 
                + "некорректно устанавливает корректное значение");
        }

        [Test(Description = "Негативный тест сеттера CentralHoleDiameter")]
        public void TestCentralHoleDiameterSet_IncorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            const double wrongCentralHoleDiameter = 40.0;

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                alloyWheelsData.CentralHoleDiameter = 
                wrongCentralHoleDiameter;
            }, "Должно возникать исключение, "
            + "если устанавливаемое значение диаметра центрального отверстия"
            + "не входит в допустимый диапазон значений");
        }

        [Test(Description = "Негативный тест сеттера CentralHoleDiameter")]
        public void TestCentralHoleDiameterSet_NuNValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedCentralHoleDiameter = double.NaN;

            // act
            alloyWheelsData.CentralHoleDiameter = 
                expectedCentralHoleDiameter;
            double actualCentralHoleDiameter = alloyWheelsData.
                CentralHoleDiameter;

            // assert
            Assert.AreEqual(expectedCentralHoleDiameter, 
                actualCentralHoleDiameter, 
                "При попытке установить свойству CentralHoleDiameter" 
                + " значение double.NuN не должно возникать исключения");
        }

        [Test(Description = "Позитивный тест геттера MinWidth")]
        public void TestMinWidthGet_CorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            alloyWheelsData.CentralHoleDiameter = 24.0;
            const double expectedMinWindth = 64.304;

            // act
            double actualMinWidth = alloyWheelsData.MinWidth;

            // assert
            Assert.AreEqual(expectedMinWindth, actualMinWidth, 
                "Геттер  MinWidth возвращает некорректное значение");
		}

        [Test(Description = "Негативный тест геттера MinWidth")]
        public void TestMinWidthGet_IncorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedMinWidth = double.NaN;

            // act
            double actualMinWidth = alloyWheelsData.MinWidth;

            // assert
            Assert.AreEqual(expectedMinWidth, actualMinWidth, 
                "Геттер MinWidth возвращает некорректное значение " 
                + "при незаданном диаметре центрального отверстия");
		}

        [Test(Description = "Позитивный тест геттера MaxWidth")]
        public void TestMaxWidthGet_CorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            alloyWheelsData.CentralHoleDiameter = 24.0;
            const double expectedMaxWindth = 98.0;

            // act
            double actualMaxWidth = alloyWheelsData.MaxWidth;

            // assert
            Assert.AreEqual(expectedMaxWindth, actualMaxWidth,
                "Геттер  MaxWidth возвращает некорректное значение");
        }

        [Test(Description = "Негативный тест геттера MaxWidth")]
        public void TestMaxWidthGet_IncorrectValue()
        {
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedMaxWidth = double.NaN;

            // act
            double actualMaxWidth = alloyWheelsData.MaxWidth;

            // assert
            Assert.AreEqual(expectedMaxWidth, actualMaxWidth,
                "Геттер MaxWidth возвращает некорректное значение "
                + "при незаданном диаметре центрального отверстия");
        }

        [Test(Description = "Позитивный тест сеттера Width")]
        public void TestWidthSet_CorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            alloyWheelsData.CentralHoleDiameter = 24.0;
            const double expectedWidth = 80.0;

            // act
            alloyWheelsData.Width = expectedWidth;
            double actualWidth = alloyWheelsData.Width;

            // assert
            Assert.AreEqual(expectedWidth, actualWidth, 
                "Сеттер Width некорректно устанавливает " 
                + "корректное значение");
		}

        [Test(Description = "Негативный тест сеттера Width")]
        public void TestWidthSet_IncorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            alloyWheelsData.CentralHoleDiameter = 24.0;
            const double wrongWidth = 100.0;

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                alloyWheelsData.Width = wrongWidth;
            }, "При попытке утсановить свойству Width некорректное значение" 
            + " должно возникать исключение");
        }

        [Test(Description = "Негативный тест сеттера Width")]
        public void TestWidthSet_NuNValue()
		{
            // setup;
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedWidth = double.NaN;

            // act
            alloyWheelsData.Width = expectedWidth;
            double actualWidth = alloyWheelsData.Width;

            // assert
            Assert.AreEqual(expectedWidth, actualWidth, 
                "При попытке установить свойству Width " 
                + "значение double.NuN не должно возникать исключение");
		}

        [Test(Description = "Позитивный тест геттера MinOffSet")]
        public void TestMinOffSetGet_CorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            alloyWheelsData.Diameter = 220.0;
            alloyWheelsData.CentralHoleDiameter = 24.0;
            alloyWheelsData.Width = 80.0;
            const double expectedMinOffSet = -2.0;

            // act
            double actualMinOffSet = alloyWheelsData.MinOffSet;

            // assert
            Assert.AreEqual(expectedMinOffSet, actualMinOffSet, 
                "Геттер MinOffSet возвращает некорректное значение");
		}

        [Test(Description = "Негативный тест геттера MinOffSet")]
        public void TestMinOffSetGet_IncorrectValue()
		{
            // setup
            AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
            const double expectedMinOffSet = double.NaN;

            // act
            double actualMinOffSet = alloyWheelsData.MinOffSet;

            // assert
            Assert.AreEqual(expectedMinOffSet, actualMinOffSet, 
                "Геттер MinOffSet возвращает некорректное значение " 
                + "при незаданной посадочной ширине диска");
		}


    }
}
