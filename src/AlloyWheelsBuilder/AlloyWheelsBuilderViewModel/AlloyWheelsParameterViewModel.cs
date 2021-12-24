using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsParameterViewModel
    {
        public AlloyWheelsParameterName Name { get; private set; }

        /// <summary>
        /// Параметры автомобильного диска
        /// </summary>
        private AlloyWheelsParameters _alloyWheelsParameters;

        public string MinValue => _alloyWheelsParameters[Name].GetMinValue(
            _alloyWheelsParameters.ParameterValues).ToString() + " ≤";
       
        public string MaxValue => "≤ " + _alloyWheelsParameters[Name].
            GetMaxValue(_alloyWheelsParameters.ParameterValues).ToString();

        private string _value = "";

        public string Value
		{
            get => _value;
			set
			{
				try
				{
                    _value = value;
                    if (double.TryParse(value, out double parameterValue))
                    {
                        _alloyWheelsParameters[Name].SetValue(
                            _alloyWheelsParameters.ParameterValues, 
                            parameterValue);
                    }
                    else
                    {
                        _alloyWheelsParameters[Name].SetValue(
                            _alloyWheelsParameters.ParameterValues, 
                            double.NaN);
                        string message = 
                            "Ошибка: Данные введены некорректно.\n"
                             + "Параметр: " 
                             + "\"" + _alloyWheelsParameters[Name].
                             RussianName.ToString() + "\".\n"
                             + "Сведения об ошибке: " + "\"" + value + "\""
                            + " не является числом";
                        throw new ArgumentException(message);
                    }
                }
                catch(ArgumentException exception)
				{

				}
			}
		}

        public AlloyWheelsParameterViewModel(
            AlloyWheelsParameters alloyWheelsParameters,
            AlloyWheelsParameterName name)
        {
            _alloyWheelsParameters = alloyWheelsParameters;
            Name = name;
        }
    }
}
