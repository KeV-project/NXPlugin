using System;
using GalaSoft.MvvmLight;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsParameterViewModel: ViewModelBase
    {
        public AlloyWheelsParameterName Name { get; private set; }

        /// <summary>
        /// Параметры автомобильного диска
        /// </summary>
        private AlloyWheelsParameters _alloyWheelsParameters;

        public string MinValue
        {
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[Name].GetMinValue(
                    _alloyWheelsParameters.ParameterValues)))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsParameters[Name].GetMinValue(
                        _alloyWheelsParameters.ParameterValues) + " ≤";
                }
            }
        }
       
        public string MaxValue
        {
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[Name].GetMaxValue(
                   _alloyWheelsParameters.ParameterValues)))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsParameters[Name].GetMaxValue(
                        _alloyWheelsParameters.ParameterValues);
                }
            }
        }

        public event EventHandler<SetParameterValueArgs> ValueSetWithErrors;

        public event EventHandler<SetParameterValueArgs> ValueSetSuccessfully;

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
                    RaisePropertyChanged(Name.ToString());
                    ValueSetWithErrors?.Invoke(this, 
                        new SetParameterValueArgs(Name, exception.Message));  
                }
                RaisePropertyChanged(Name.ToString());
                ValueSetSuccessfully?.Invoke(this,
                    new SetParameterValueArgs(Name, ""));
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
