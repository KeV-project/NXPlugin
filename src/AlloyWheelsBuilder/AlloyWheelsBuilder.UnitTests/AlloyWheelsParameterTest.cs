using System;
using System.Collections.Generic;
using NUnit.Framework;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
    [TestFixture]
    class AlloyWheelsParameterTest
    {
        [TestCase(TestName = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter = 
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const AlloyWheelsParameterName expectedName = 
                AlloyWheelsParameterName.Width;

            // act
            AlloyWheelsParameterName actualName = alloyWheelsParameter.Name;

            // assert
            Assert.AreEqual(expectedName, actualName, 
                "Геттер Name возвращает некорректное значение");
        }

        [TestCase(TestName = "Позитивный тест геттера RussianName")]
        public void TestRussianNameGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const string expectedRussianName = "Посадочная ширина Lп";

            // act
            string actualRussianName = alloyWheelsParameter.RussianName;

            // assert
            Assert.AreEqual(expectedRussianName, actualRussianName, 
                "Геттер RussianName возвращает некорректное занчение");
        }

        [TestCase(TestName = "Позитивный тест геттера " 
            + "CodependentParameterName")]
        public void TestCodependentParameterNameGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const AlloyWheelsParameterName expectedName =
                AlloyWheelsParameterName.CentralHoleDiameter;

            // act
            AlloyWheelsParameterName actualName = alloyWheelsParameter.
                CodependentParameterName;

            // assert
            Assert.AreEqual(expectedName, actualName, "Геттер " 
                + "CodependentParameterName возвращает " 
                + "некорректное значение");
        }

        [TestCase(TestName = "Позитивный тест геттера " 
            + "CodependentParameterRussianName")]
        public void TestCodependentParameterRussianNameGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const string expectedRussianName = "Диаметр ЦО ØDIA";

            // act
            string actualRussianName = alloyWheelsParameter.
                CodependentParameterRussianName;

            // assert
            Assert.AreEqual(expectedRussianName, actualRussianName,
                "Геттер CodependentParameterRussianName " 
                + "возвращает некорректное занчение");
        }

        [TestCase(TestName = "Позитивный тест геттера Unit")]
        public void TestUnitGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const string expectedUnit = "мм";

            // act
            string actualUnit = alloyWheelsParameter.Unit;

            // act
            Assert.AreEqual(expectedUnit, actualUnit, 
                "Геттер Unit возвращает некорректное значение");
        }

        [TestCase(TestName = "Негативный тест геттера IsCount")]
        public void TestIsCountGet_IncorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const bool expectedIsCount = false;

            // act
            bool actualIsCount = alloyWheelsParameter.IsCount;

            // assert
            Assert.AreEqual(expectedIsCount, actualIsCount, 
                "Геттер IsCount возвращает некорректное значение, " +
                "когда единицей измерения параметра не является штука");
        }

        [TestCase(TestName = "Позитивный тест геттера IsCount")]
        public void TestIsCountGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter =
                new AlloyWheelsParameter(AlloyWheelsParameterName.
                DrillDiameter, "Диаметр сверловки B",
                AlloyWheelsParameterName.CentralHoleDiameter,
                "Диаметр ЦО ØDIA", (Dictionary<AlloyWheelsParameterName,
                double> parameterValues) => { return 0.0; },
                (Dictionary<AlloyWheelsParameterName,
                double> parameterValues) => { return 0.0; }, "шт");
            const bool expectedIsCount = true;

            // act
            bool actualIsCount = alloyWheelsParameter.IsCount;

            // assert
            Assert.AreEqual(expectedIsCount, actualIsCount, 
                "Геттер IsCount возвращает некорректное значение, " +
                "когда единицей измерения является штука");
        }

        [TestCase(TestName = "Позитивный тест геттера Value")]
        public void TestValueGet_CorrectValue()
        {
            // setup
            AlloyWheelsParameter alloyWheelsParameter = 
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const double expectedValue = double.NaN;

            // act
            double actualValue = alloyWheelsParameter.Value;

            // assert
            Assert.AreEqual(expectedValue, actualValue, 
                "Геттер Value возвращает некорректные значения");
        }

        [TestCase(double.NaN, AlloyWheelsParameterName.Width, 
            "Метод SetValue некорректно обрабатвает значение double.NuN",  
            TestName = "Позитивный тест метода SetValue, " 
            + "когда value равно NuN")]
        [TestCase(220.0, AlloyWheelsParameterName.Diameter, 
            "Метода SetValue некорректно устанавливает корректное значение " 
            + "параметру без созависимых параметров",  
            TestName = "Позитивный тест метода SetValue, " 
            + "когда параметр не имеет созависимых параметров " 
            + "и не является количественным")]
        public void TestValueSet_CorrectValue(double expectedValue, 
            AlloyWheelsParameterName parameterName, string message)
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;

            // act
            alloyWheelsParameters[parameterName].SetValue(
                alloyWheelsParameters.ParameterValues, expectedValue);
            double actualValue = alloyWheelsParameters[parameterName].Value;

            // assert
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(22.0, AlloyWheelsParameterName.CentralHoleDiameter,
            220.0, "Метода SetValue некорректно устанавливает " 
            + "корректное значение не количественного параметра " 
            + "при определенном значении созависимого параметра",
            TestName = "Позитивный тест метода SetValue, " 
            + "когда value не является количественным параметром, " 
            + "а его созависимые параметры определены")]
        [TestCase(4, AlloyWheelsParameterName.SpokesCount,
            220.0, "Метода SetValue некорректно устанавливает "
            + "корректное значение количественного параметра "
            + "при определенном значении созависимого параметра",
            TestName = "Позитивный тест метода SetValue, "
            + "когда value является количественным параметром, "
            + "а его созависимые параметры определены")]
        public void TestValueSet_CorrectValue(double expectedValue,
            AlloyWheelsParameterName parameterName, 
            double codependentParameterValue, string message)
		{
            // setup
            AlloyWheelsParameters alloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            alloyWheelsParameters[alloyWheelsParameters[parameterName].
                CodependentParameterName].SetValue(alloyWheelsParameters.
                ParameterValues, codependentParameterValue);

            // act
            alloyWheelsParameters[parameterName].SetValue(
                alloyWheelsParameters.ParameterValues, expectedValue);
            double actualValue = alloyWheelsParameters[parameterName].Value;

            // assert
            Assert.AreEqual(expectedValue, actualValue, message);
		}

        [TestCase(10.0, AlloyWheelsParameterName.CentralHoleDiameter,
            220.0, "Должно возникнуть исключение при попытке установить " 
            + "некорректное значение не количественному параметру",
            TestName = "Негативный тест метода SetValue, " +
            "когда value - не количественный параметр, " +
            "a созависимый параметр определен")]
        [TestCase(-1, AlloyWheelsParameterName.SpokesCount, 220.0,
            "Должно возникнуть исключение при попытке установить "
            + "некорректное значение количественному параметру",
            TestName = "Негативный тест метода SetValue, " +
            "когда value - количественный параметр " 
            + "и созависимый параметр определен")]
        public void TestValueSet_IncorrectValue(double incorrectValue,
            AlloyWheelsParameterName parameterName, 
            double codependentParameterValue, string message)
		{
            // setup
            AlloyWheelsParameters alloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            alloyWheelsParameters[alloyWheelsParameters[parameterName].
                CodependentParameterName].SetValue(alloyWheelsParameters.
                ParameterValues, codependentParameterValue);

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                alloyWheelsParameters[parameterName].SetValue(
                    alloyWheelsParameters.ParameterValues, incorrectValue);
            }, message);
		}

        [TestCase(90.0, AlloyWheelsParameterName.Diameter, 
            "Должно возникать исключение, "
            + "при попытке установить значение не входящее в допустимый "
            + "диапазон параметру без созависимых параметров",
            TestName = "Негaтивный тест метода SetValue, " 
            + "когда параметр не имеет созависимых параметров")]
        [TestCase(22.0, AlloyWheelsParameterName.CentralHoleDiameter,
            "Должно возникать исключение " 
            + "при попытке установить значение параметру, " +
            "созависимый параметр которого не определен",
            TestName = "Негативный тест метода SetValue, " +
            "когда значение созависимого параметра не определено")]
        public void TestValueSet_IncorrectValue(double expectedValue,
            AlloyWheelsParameterName parameterName, string message)
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                alloyWheelsParameters[parameterName].SetValue(
                    alloyWheelsParameters.ParameterValues,
                    expectedValue);
            }, message);
        }

        [TestCase(101.6, AlloyWheelsParameterName.Diameter, 
            "Метод GetMinValue возвращает некорректное " 
            + "минимально допустимое значение параметра, " +
            "который не имеет созависимых параметров",
            TestName = "Позитивный тест метода GetMinValue, " +
            "когда параметр не имеет созависимых параметров")]
        [TestCase(double.NaN, AlloyWheelsParameterName.CentralHoleDiameter,
            "Когда созависимый параметр не задан, " +
            "метод GetMinValue должен вернуть double.NuN",
            TestName = "Позитивный тест метода GetMinValue, " +
            "когда созависимый параметр не определен")]
        public void TestGetMinValue_CorrectValue(double expectedValue,
            AlloyWheelsParameterName parameterName, string message)
		{
            // setup
            AlloyWheelsParameters alloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;

            // act
            double actualValue = alloyWheelsParameters[parameterName].
                GetMinValue(alloyWheelsParameters.ParameterValues);

            // assert
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(22.0, AlloyWheelsParameterName.CentralHoleDiameter,
            220.0, "Метод некорректно рассчитывает минимально допустимое " 
            + "значение параметра при задоном значении " 
            + "созависимого параметра",
            TestName = "Позитивный тест метода GetMinValue, " +
            "когда созависимый параметр определен")]
        public void TestGetMinValue_CorrectValue(double expectedValue,
            AlloyWheelsParameterName parameterName, 
            double codependentParameterValue, string message)
		{
            // setup 
            AlloyWheelsParameters alloyWheelsParameters = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            alloyWheelsParameters[alloyWheelsParameters[parameterName].
                CodependentParameterName].SetValue(alloyWheelsParameters.
                ParameterValues, codependentParameterValue);

            // act
            double actualValue = alloyWheelsParameters[parameterName].
                GetMinValue(alloyWheelsParameters.ParameterValues);

            // assert
            Assert.AreEqual(expectedValue, actualValue, message);
		}

        [TestCase(1447.8, AlloyWheelsParameterName.Diameter,
           "Метод GetMaxValue возвращает некорректное "
           + " допустимое значение параметра, " +
           "который не имеет созависимых параметров",
           TestName = "Позитивный тест метода GetMaxValue, " +
           "когда параметр не имеет созависимых параметров")]
        [TestCase(double.NaN, AlloyWheelsParameterName.CentralHoleDiameter,
           "Когда созависимый параметр не задан, " +
           "метод GetMaxValue должен вернуть double.NuN",
           TestName = "Позитивный тест метода GetMaxValue, " +
           "когда созависимый параметр не определен")]
        public void TestGetMaxValue_CorrectValue(double expectedValue,
           AlloyWheelsParameterName parameterName, string message)
        {
            // setup
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;

            // act
            double actualValue = alloyWheelsParameters[parameterName].
                GetMaxValue(alloyWheelsParameters.ParameterValues);

            // assert
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(39.6, AlloyWheelsParameterName.CentralHoleDiameter,
            220.0, "Метод некорректно рассчитывает максимально допустимое "
            + "значение параметра при задоном значении "
            + "созависимого параметра",
            TestName = "Позитивный тест метода GetMaxValue, " +
            "когда созависимый параметр определен")]
        public void TestGetMaxValue_CorrectValue(double expectedValue,
            AlloyWheelsParameterName parameterName,
            double codependentParameterValue, string message)
        {
            // setup 
            AlloyWheelsParameters alloyWheelsParameters =
                AlloyWheelsParametersTestData.AlloyWheelsParameters;
            alloyWheelsParameters[alloyWheelsParameters[parameterName].
                CodependentParameterName].SetValue(alloyWheelsParameters.
                ParameterValues, codependentParameterValue);

            // act
            double actualValue = alloyWheelsParameters[parameterName].
                GetMaxValue(alloyWheelsParameters.ParameterValues);

            // assert
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(TestName = "Позитивый тест метода CompareTo")]
        public void TestCompareTo_CorrectValue()
		{
            // setup
            AlloyWheelsParameter alloyWheelsParameter = 
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            AlloyWheelsParameter comparedAlloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameter;
            const int expectedResult = 0;

            // act
            int actualResult = alloyWheelsParameter.CompareTo(
                comparedAlloyWheelsParameter);

            // assert
            Assert.AreEqual(expectedResult, actualResult, 
                "Метод CompareTo неверно сравнивает одинаковые объекты");
		}

        [TestCase(TestName = "Негативный тест метода CompareTo")]
        public void TestCompareTo_IncorrectValue()
		{
            // setup
            AlloyWheelsParameter alloyWheelsParameter = 
                AlloyWheelsParametersTestData.AlloyWheelsParameters[
                    AlloyWheelsParameterName.Diameter];
            AlloyWheelsParameter comparedAlloyWheelsParameter =
                AlloyWheelsParametersTestData.AlloyWheelsParameters[
                    AlloyWheelsParameterName.Width];
            const int expectedResult= 1;

            // act
            int actualResult = alloyWheelsParameter.CompareTo(
                comparedAlloyWheelsParameter);

            // assert
            Assert.AreEqual(expectedResult, actualResult, 
                "Метод CompareTo неверно сравнивает разные объекты");
        }

        [TestCase(TestName = "Позитивный тест конструктора")]
        public void TestConstructor_CorrectValue()
		{
            // setup
            const AlloyWheelsParameterName expectedParameterName = 
                AlloyWheelsParameterName.Diameter;
            const string expectedRussianName = "Диаметр ЦО ØDIA";
            const AlloyWheelsParameterName expectedCodependentParameterName = 
                AlloyWheelsParameterName.NaN;
            const string expectedCodependentParameterRussianName = "-";
            const double expectedValue = double.NaN;
            const double expectedMinValue = 1.0;
            const double expectedMaxValue = 2.0;
            const string expectedUnit = "мм";

            AlloyWheelsParameter alloyWheelsParameter = 
                new AlloyWheelsParameter(expectedParameterName,
                expectedRussianName, expectedCodependentParameterName,
                expectedCodependentParameterRussianName, 
                (Dictionary<AlloyWheelsParameterName,
                double> parameterValues) => { return 1.0; },
                (Dictionary<AlloyWheelsParameterName,
                double> parameterValues) => { return 2.0; }, "мм");

            // act
            AlloyWheelsParameterName actualParameterName = 
                alloyWheelsParameter.Name;
            string actualRussianName = alloyWheelsParameter.RussianName;
            AlloyWheelsParameterName actualCodependentParameterName = 
                alloyWheelsParameter.CodependentParameterName;
            string actualCodependentRussianParameterName = 
                alloyWheelsParameter.CodependentParameterRussianName;
            double actualValue = alloyWheelsParameter.Value;
            double actualMinValue = alloyWheelsParameter.GetMinValue(null);
            double actualMaxValue = alloyWheelsParameter.GetMaxValue(null);
            string actualUnit = alloyWheelsParameter.Unit;

            // assert
            Assert.AreEqual(expectedParameterName, actualParameterName, 
                "Конструктор неверно инициализировал имя параметра");
            Assert.AreEqual(expectedRussianName, actualRussianName, 
                "Конструктор неверно инициализировал обозначение параметра " 
                + "на пользовательском интерфейсе");
            Assert.AreEqual(expectedCodependentParameterName, 
                actualCodependentParameterName, "Конструктор неверно " 
                + "инициализировал имя созависимого параметра");
            Assert.AreEqual(expectedCodependentParameterRussianName, 
                actualCodependentRussianParameterName, 
                "Конструктор неверно инициализировал " 
                + "обозначение созависимого параметра " 
                + "на пользовательском интерфейсе");
            Assert.AreEqual(expectedValue, actualValue, "Конструктор неверно " 
                + "инициализировал номинал элемента");
            Assert.AreEqual(expectedMinValue, actualMinValue, 
                "Конструктор неверно инициализировал " 
                + "минимально допустимое значение параметра");
            Assert.AreEqual(expectedMaxValue, actualMaxValue, 
                "конструктор неверо инифиализировал максимально " 
                + "допустимое значение параметра");
            Assert.AreEqual(expectedUnit, actualUnit, "Конструктор неверно " 
                + "инициализировал единицу измеренияпараметра");
        }
    }
}
