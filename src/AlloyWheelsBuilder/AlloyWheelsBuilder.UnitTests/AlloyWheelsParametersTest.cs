using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
	[TestFixture]
	class AlloyWheelsParametersTest
	{
        [TestCase(TestName = "Позитивный тест геттера SketchArcsCount")]
        public void TestSketchArcsCountGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            const int expectedSketchArcsCount = 45;

            // act
            int actualSketchArcsCount = alloyWheelsParameters.SketchArcsCount;

            // assert
            Assert.AreEqual(expectedSketchArcsCount, actualSketchArcsCount,
                "Геттер SketchArcsCount возвращает некорректное значение");
        }

        [TestCase(TestName = "Позитивный тест геттера SketchArcs")]
        public void TestSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            List<ArcData> expectedSketchArcs = AlloyWheelsParametersTestData.
                SketchArcs;
            int expectedSketchArcsCount = expectedSketchArcs.Count;

            // act
            List<ArcData> actualSketchArcs = alloyWheelsParameters.
                SketchArcs;
            int actualSketchArcsCount = actualSketchArcs.Count;

            // assert
            Assert.AreEqual(expectedSketchArcsCount, actualSketchArcsCount,
                "Геттер SketchArcs возвращает список "
                + "с некорректным количеством элементов");

            for (int i = 0; i < actualSketchArcsCount; i++)
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

        [TestCase(TestName = "Позитивный тест геттера PetalSketchArcs")]
        public void TestPetalSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            List<ArcData> expectedPetalSketchArcs = 
                AlloyWheelsParametersTestData.PetalSketchArcs;
            int expectedPetalSketchArcsCount = expectedPetalSketchArcs.
                Count();

            // act
            List<ArcData> actualPetalSketchArcs = alloyWheelsParameters.
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

        [TestCase(TestName = "Позитивный тест геттера PetalSketchHeight")]
        public void TestPetalSketchHeightGet_CorrectValue()
        {
            // setup
            const double expectedPetalSketchHeight = 113.4;
            AlloyWheelsParameters alloyWheelsParameters =
                 AlloyWheelsParametersTestData.AlloyWheelsParameters;

            // act
            double actualPetalSketchHeight = alloyWheelsParameters.
                PetalSketchHeight;

            // assert
            Assert.AreEqual(expectedPetalSketchHeight,
                actualPetalSketchHeight, "Геттер PetalSketchHeight " +
                "возвращает некорректное значение");
        }

        [TestCase(TestName = "Позитивный тест индексатора")]
        public void TestIndexer_CorrectValue()
		{
            // setup
            AlloyWheelsParameter expectedAlloyWheelsParameter = 
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            AlloyWheelsParameters alloyWheelsParameters = 
                new AlloyWheelsParameters();
            const int expectedResult = 0;

            // act
            AlloyWheelsParameter actualAlloyWheelsParameter = 
                alloyWheelsParameters[AlloyWheelsParameterName.Width];
            int actualResult = expectedAlloyWheelsParameter.CompareTo(
                actualAlloyWheelsParameter);

            // assert
            Assert.AreEqual(expectedResult, actualResult, 
                "Индексатор вернул неверный объект");
		}

        [TestCase(TestName = "Позитивный тест геттера ParameterValues")]
        public void TestParameterValues_CorrectValue()
		{
            // setup
            AlloyWheelsParameters expectedAlloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            Dictionary<AlloyWheelsParameterName, double> 
                expectedParameterValues = 
                new Dictionary<AlloyWheelsParameterName, double>();
            foreach (AlloyWheelsParameterName parameterName in 
                AlloyWheelsParametersTestData.ParameterNames)
            {
                expectedParameterValues.Add(parameterName,
                    expectedAlloyWheelsParameters[parameterName].Value);
            }
            int expectedParameterValuesCount = expectedParameterValues.Count;

            // act
            AlloyWheelsParameters actualAlloyWheelsParameters =
                new AlloyWheelsParameters();
            Dictionary<AlloyWheelsParameterName, double> 
                actualParameterValues = actualAlloyWheelsParameters.
                ParameterValues;
            int actualParameterValuesCount = actualParameterValues.Count;

            // assert
            Assert.AreEqual(actualParameterValuesCount, 
                expectedParameterValuesCount, "Геттер ParameterValues " 
                + "возвращает некорректное число элементов");
            foreach(AlloyWheelsParameterName parameterName in 
                AlloyWheelsParametersTestData.ParameterNames)
			{
                double expectedValue = expectedParameterValues[parameterName];
                double actualValue = actualParameterValues[parameterName];

                Assert.AreEqual(expectedValue, actualValue, 
                    "Геттер ParameterValues возвратил некорректное " 
                    + "значение элемента " + parameterName);
			}
        }

        [TestCase(TestName = "Позитивный тест конструктора")]
        public void TestConstuctror_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;

            // assert
            foreach (AlloyWheelsParameterName parameterName in
                AlloyWheelsParametersTestData.ParameterNames)
            {
                AlloyWheelsParameter alloyWheelsParameter =
                    alloyWheelsParameters[parameterName];

                AlloyWheelsParameterName expectedName = parameterName;
                AlloyWheelsParameterName actualName = alloyWheelsParameter.
                    Name;
                Assert.AreEqual(expectedName, actualName, 
                    "Конструктор неверно инициализировал имя параметра" 
                    + parameterName);

                string expectedRussianName = AlloyWheelsParametersTestData.
                    ParameterRussianNames[parameterName];
                string actualRussianName = alloyWheelsParameter.RussianName;
                Assert.AreEqual(expectedRussianName, actualRussianName,
                    "Конструктор неверно инициализировал "
                    + "обозначение параметра" + parameterName
                    + "на пользовательском интерфейсе");

                AlloyWheelsParameterName expectedCodependentParameterName = 
                    alloyWheelsParameters[parameterName].
                    CodependentParameterName;
                AlloyWheelsParameterName actualCodependentParameterName = 
                    alloyWheelsParameter.
                    CodependentParameterName;
                Assert.AreEqual(expectedCodependentParameterName, 
                    actualCodependentParameterName,
                    "Конструктор неверно инициализировал имя созависимого параметра"
                    + parameterName);

                string expectedCodependentParameterRussianName = 
                    AlloyWheelsParametersTestData.ParameterRussianNames[
                        alloyWheelsParameters[parameterName].
                        CodependentParameterName];
                string actualCodependentParameterRussianName = alloyWheelsParameter.
                    CodependentParameterRussianName;
                Assert.AreEqual(expectedCodependentParameterRussianName, 
                    actualCodependentParameterRussianName,
                    "Конструктор неверно инициализировал "
                    + "обозначение созависимого параметра" + parameterName
                    + "на пользовательском интерфейсе");

                double expectedMinValue = double.NaN;
                double expectedMaxValue = double.NaN;

                if (parameterName== AlloyWheelsParameterName.Diameter)
				{
                    expectedMinValue = 101.6;
                    expectedMaxValue = 1447.8;
				}

                double actualMinValue = alloyWheelsParameter.GetMinValue(
                    alloyWheelsParameters.ParameterValues);
                double actulMaxValue = alloyWheelsParameter.GetMaxValue(
                    alloyWheelsParameters.ParameterValues);
                Assert.AreEqual(expectedMinValue, actualMinValue, 
                    "Конструктор неверно инициализирует матод " 
                    + "для рассчета минимально допустимого значения " 
                    + "параметра");
                Assert.AreEqual(expectedMaxValue, actulMaxValue,
                    "Конструктор неверно инициализирует матод "
                    + "для рассчета максимально допустимого значения "
                    + "параметра");

                string expectedUnit = AlloyWheelsParametersTestData.
                    Units[parameterName];
                string actualUnit = alloyWheelsParameter.Unit;
                Assert.AreEqual(expectedUnit, actualUnit, 
                    "Конструктор неверно инициализировал " 
                    + "единицу измерения параметра " + parameterName);
            }
		}
    }
}
