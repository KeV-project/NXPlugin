using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlloyWheelsBuilderModel;
using AlloyWheelsBuilder.UnitTests.TestData;

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

        /// <summary>
        /// Выполняет проверку дуг для построения эскизов
        /// </summary>
        /// <param name="expectedSketchArcs">Ожидаемое значение</param>
        /// <param name="actualSketchArcs">Полученное значение</param>
        /// <param name="propertyName">Имя свойства</param>
        private void AssertSketchArcs(List<ArcData> expectedSketchArcs, 
            List<ArcData> actualSketchArcs, string propertyName)
		{
            int expectedSketchArcsCount = expectedSketchArcs.Count;
            int actualSketchArcsCount = actualSketchArcs.Count;

            Assert.AreEqual(expectedSketchArcsCount, actualSketchArcsCount,
                "Геттер " + propertyName + " вернул список " 
                + "с некорректным числом элементов");

            for(int i = 0; i < expectedSketchArcsCount; i++)
			{
                ArcData expectedArcData = expectedSketchArcs[i];
                ArcData actualArcData = actualSketchArcs[i];

                const int expectedResult = 1;
                int actualResult = expectedArcData.CompareTo(actualArcData);

                Assert.AreEqual(expectedResult, actualResult,
                    "Геттер " + propertyName + " вернул список "
                    + "с некорректным элементом №" + i);
            }
		}

        [TestCase(TestName = "Позитивный тест геттера SketchArcs")]
        public void TestSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            List<ArcData> expectedSketchArcs = AlloyWheelsParametersTestData.
                SketchArcs;

            // act
            List<ArcData> actualSketchArcs = alloyWheelsParameters.
                SketchArcs;

            // assert
            AssertSketchArcs(expectedSketchArcs, actualSketchArcs, 
                nameof(alloyWheelsParameters.SketchArcs));
        }

        [TestCase(TestName = "Позитивный тест геттера PetalSketchArcs")]
        public void TestPetalSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            List<ArcData> expectedPetalSketchArcs = 
                AlloyWheelsParametersTestData.PetalSketchArcs;

            // act
            List<ArcData> actualPetalSketchArcs = alloyWheelsParameters.
                PetalSketchArcs;

            // assert
            AssertSketchArcs(expectedPetalSketchArcs, actualPetalSketchArcs,
                nameof(alloyWheelsParameters.PetalSketchArcs));
        }

        [TestCase(TestName = "Позитивный тест геттера RoundPetalSketchArcs")]
        public void TestRoundPetalSketchArcsGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            List<ArcData> expectedRoundPetalSketchArcs =
                AlloyWheelsParametersTestData.RoundPetalSketchArcs;

            // act
            List<ArcData> actualRoundPetalSketchArcs = alloyWheelsParameters.
                RoundPetalSketchArcs;

            // assert
            AssertSketchArcs(expectedRoundPetalSketchArcs, 
                actualRoundPetalSketchArcs,
                nameof(alloyWheelsParameters.PetalSketchArcs));
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
