using System;
using System.Collections.Generic;

namespace AlloyWheelsBuilderModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsParameter"/> представляет 
    /// задаваемый параметр модели автомобильного диска
    /// </summary>
    public class AlloyWheelsParameter: IComparable
    {
        /// <summary>
        /// Устанавливает и возвращает имя параметра
        /// </summary>
        public AlloyWheelsParameterName Name { get; private set; }

        /// <summary>
        /// Возвращает и устанавливает обозначение параметра 
        /// на пользовательском интерфейсе
        /// </summary>
        public string RussianName { get; private set; }

        /// <summary>
        /// Имя созависимого параметра
        /// </summary>
        public AlloyWheelsParameterName CodependentParameterName {
            get; private set; }

        /// <summary>
        /// Обозначение созависимого параметра на пользовательском интерфейсе
        /// </summary>
        public string CodependentParameterRussianName { get; private set; }

        /// <summary>
        /// Возвращает и устанавливает единицы измерения параметра
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// Если единицей изерения параметра является штука, 
        /// возвращает true, иначе возвращает false
        /// </summary>
        public bool IsCount => Unit == "шт";

        /// <summary>
        /// Номинал параметра
        /// </summary>
        private double _value = double.NaN;

        /// <summary>
        /// Возвращает номинал параметра
        /// </summary>
        public double Value => _value;

        /// <summary>
        /// Устанавливает значение параметра
        /// </summary>
        /// <param name="parameterValues">Словарь, 
        /// содержащий номиналы параметров модели. 
        /// Необходим для получения созависимых параметров.</param>
        /// <param name="codependentParameterRussianName">
        /// Обозначение созависимого параметра 
        /// на пользовательском интерфейсе</param>
        /// <param name="value">Номинал параметра</param>
        public void SetValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues, 
            double value)
        {
            _value = double.NaN;
            if (!double.IsNaN(value))
            {
                if(CodependentParameterName != AlloyWheelsParameterName.NaN)
				{
                    if (double.IsNaN(parameterValues[
                        CodependentParameterName]))
                    {
                        string message = 
                            "Ошибка: Данные введены некорректно.\n"
                           + "Параметр: \"" + RussianName + "\".\n"
                           + "Сведения об ошибке: Невозможно рассчитать "
                           + "диапазон допустимых значений параметра.\n"
                           + "Возможно параметру \"" 
                           + CodependentParameterRussianName
                           + "\" присвоено некорректное значение.";
                        throw new ArgumentException(message);
                    }
                }
                if(IsCount)
				{
                    value = Math.Round(value);
				}
                ValueValidator.AssertNumberInRange(value, GetMinValue(
                    parameterValues), GetMaxValue(parameterValues), 
                    RussianName);
                _value = value;
            }
        }

        /// <summary>
        /// Метод расчета минимально допустимого значения параметра
        /// </summary>
        private Func<Dictionary<AlloyWheelsParameterName, 
            double>, double> _calculateMinValue;

        /// <summary>
        /// Возвращает минимально допустимое значение параметра
        /// </summary>
        /// <param name="parameterValues">Словарь, 
        /// содержащий номиналы параметров модели. 
        /// Необходим для получения созависимых параметров.</param>
        /// <returns>Минимально допустимое значение параметра</returns>
        public double GetMinValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues)
        {
            return CalculateLimitValue(parameterValues, _calculateMinValue);
        }

        /// <summary>
        /// Метод расчета максимально допустимого значения параметра
        /// </summary>
        private readonly Func<Dictionary<AlloyWheelsParameterName, 
            double>, double> _calculateMaxValue;

        /// <summary>
        /// Возвращает максимально допустимое значение параметра
        /// <param name="parameterValues">Словарь, 
        /// содержащий номиналы параметров модели. 
        /// Необходим для получения созависимых параметров.</param>
        /// <returns>Максимально допустимое значение параметра</returns>
        public double GetMaxValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues)
        {
            return CalculateLimitValue(parameterValues, _calculateMaxValue);
        }

        /// <summary>
        /// Расчитывает минимальный или максимальный предел 
        /// значений параметра
        /// </summary>
        /// <param name="parameterValues">Словарь, 
        /// содержащий номиналы параметров модели. 
        /// Необходим для получения созависимых параметров.</param>
        /// <param name="calculateLimitValue">Метод расчета</param>
        /// <returns>Предел значений параметра</returns>
        private double CalculateLimitValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues,
            Func<Dictionary<AlloyWheelsParameterName, double>, 
                double> calculateLimitValue)
		{
            if(CodependentParameterName != AlloyWheelsParameterName.NaN)
            {
                if (double.IsNaN(parameterValues[CodependentParameterName]))
                {
                    return double.NaN;
                }
            }
            return calculateLimitValue.Invoke(parameterValues);
        }

        /// <summary>
        /// Инициализируе поля и свойства класса 
        /// <see cref="AlloyWheelsParameter"/>
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="russianName">Обозначение параметра 
        /// на пользовательском интерфейсе</param>
        /// <param name="calculateMinValue">Метод расчета 
        /// минимально допустимого значения параметра</param>
        /// <param name="calculateMaxValue">Метод расчета 
        /// максимально допустимого значения параметра</param>
        public AlloyWheelsParameter(AlloyWheelsParameterName name, 
            string russianName, 
            AlloyWheelsParameterName codependentParameterName,
            string codependentParameterRussianName,
            Func<Dictionary<AlloyWheelsParameterName, double>, double> 
                calculateMinValue, 
            Func<Dictionary<AlloyWheelsParameterName, double>, double> 
                calculateMaxValue,
            string unit)
		{
            Name = name;
            RussianName = russianName;
            _calculateMinValue = calculateMinValue;
            _calculateMaxValue = calculateMaxValue;
            CodependentParameterName = codependentParameterName;
            CodependentParameterRussianName = 
                codependentParameterRussianName;
            Unit = unit;
        }

        /// <summary>
        /// Спавнивает объекты класса <see cref="AlloyWheelsParameter"/>
        /// </summary>
        /// <param name="alloyWheelsParameter">Обект для сравнения</param>
        /// <returns>Возвращает 0, если объекты равны, иначе 1</returns>
        public int CompareTo(object comparedAlloyWheelsParameter)
		{
            AlloyWheelsParameter alloyWheelsParameter = 
                (AlloyWheelsParameter)comparedAlloyWheelsParameter;
            if(Name == alloyWheelsParameter.Name 
                && RussianName == alloyWheelsParameter.RussianName
                && CodependentParameterName == alloyWheelsParameter.
                CodependentParameterName
                && CodependentParameterRussianName == alloyWheelsParameter.
                CodependentParameterRussianName
                && Unit == alloyWheelsParameter.Unit
                && IsCount == alloyWheelsParameter.IsCount
                && Value.Equals(alloyWheelsParameter.Value))
			{
                return 0;
			}
            return 1;
		}
    }
}
