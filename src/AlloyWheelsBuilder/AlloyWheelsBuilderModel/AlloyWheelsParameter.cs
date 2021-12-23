using System;
using System.Collections.Generic;

namespace AlloyWheelsBuilderModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsParameter"/> представляет 
    /// задаваемый параметр модели автомобильного диска
    /// </summary>
    public class AlloyWheelsParameter
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
        /// <param name="codependentParameterName">
        /// Имя созависимого параметра</param>
        /// <param name="codependentParameterRussianName">
        /// Обозначение созависимого параметра 
        /// на пользовательском интерфейсе</param>
        /// <param name="value">Номинал параметра</param>
        public void SetValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues,
            AlloyWheelsParameterName codependentParameterName, 
            string codependentParameterRussianName, double value)
        {
            _value = double.NaN;
            if (!double.IsNaN(value))
            {
                if(codependentParameterName != AlloyWheelsParameterName.NaN)
				{
                    if (double.IsNaN(parameterValues[
                        codependentParameterName]))
                    {
                        string message = 
                            "Ошибка: Данные введены некорректно.\n"
                           + "Параметр: \"" + RussianName + "\".\n"
                           + "Сведения об ошибке: Невозможно рассчитать "
                           + "диапазон допустимых значений параметра.\n"
                           + "Возможно параметру \"" 
                           + codependentParameterRussianName
                           + "\" присвоено некорректное значение.";
                        throw new ArgumentException(message);
                    }
                }
                ValueValidator.AssertNumberInRange(value, GetMinValue(
                    parameterValues, codependentParameterName), GetMaxValue(
                    parameterValues, codependentParameterName), RussianName);
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
        /// <param name="codependentParameterName">
        /// Имя созависимого параметра</param>
        /// <returns>Минимально допустимое значение параметра</returns>
        public double GetMinValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues, 
            AlloyWheelsParameterName codependentParameterName)
        {
            return CalculateLimitValue(parameterValues, 
                codependentParameterName, _calculateMinValue);
        }

        /// <summary>
        /// Метод расчета максимально допустимого значения параметра
        /// </summary>
        private Func<Dictionary<AlloyWheelsParameterName, 
            double>, double> _calculateMaxValue;

        /// <summary>
        /// Возвращает максимально допустимое значение параметра
        /// <param name="parameterValues">Словарь, 
        /// содержащий номиналы параметров модели. 
        /// Необходим для получения созависимых параметров.</param>
        /// <param name="codependentParameterName">
        /// Имя созависимого параметра</param>
        /// <returns>Максимально допустимое значение параметра</returns>
        public double GetMaxValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues, 
            AlloyWheelsParameterName codependentParameterName)
        {
            return CalculateLimitValue(parameterValues, 
                codependentParameterName, _calculateMaxValue);
        }

        /// <summary>
        /// Расчитывает минимальный или максимальный предел 
        /// значений параметра
        /// </summary>
        /// <param name="parameterValues">Словарь, 
        /// содержащий номиналы параметров модели. 
        /// Необходим для получения созависимых параметров.</param>
        /// <param name="codependentParameterName">
        /// Имя созависимого параметра</param>
        /// <param name="calculateLimitValue">Метод расчета</param>
        /// <returns>Предел значений параметра</returns>
        private double CalculateLimitValue(
            Dictionary<AlloyWheelsParameterName, double> parameterValues, 
            AlloyWheelsParameterName codependentParameterName,
            Func<Dictionary<AlloyWheelsParameterName, double>, 
                double> calculateLimitValue)
		{
            if(codependentParameterName != AlloyWheelsParameterName.NaN)
            {
                if (double.IsNaN(parameterValues[codependentParameterName]))
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
            Func<Dictionary<AlloyWheelsParameterName, double>, double> 
                calculateMinValue, 
            Func<Dictionary<AlloyWheelsParameterName, double>, double> 
                calculateMaxValue)
		{
            Name = name;
            RussianName = russianName;
            _calculateMinValue = calculateMinValue;
            _calculateMaxValue = calculateMaxValue;
        }
    }
}
