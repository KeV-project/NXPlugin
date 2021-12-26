using System;
using ViewModelLib;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsParameterViewModel"/> 
    /// представляет VM параметра
    /// </summary>
    public class AlloyWheelsParameterViewModel : NotifyDataErrorViewModelBase
    {
        /// <summary>
        /// Устанавливает и возвращает имя параметра
        /// </summary>
        public AlloyWheelsParameterName Name { get; private set; }

        /// <summary>
        /// Возвращает обозначение параметра на пользовательском интерфейсе
        /// </summary>
        public string RussianName => _alloyWheelsParameters[Name].
            RussianName;

        /// <summary>
        /// Возвращает единицу измерения параметра
        /// </summary>
        public string Unit => _alloyWheelsParameters[Name].Unit;

        /// <summary>
        /// Параметры автомобильного диска
        /// </summary>
        private AlloyWheelsParameters _alloyWheelsParameters;

        /// <summary>
        /// Возвращает минимально домустимое значение параметра
        /// </summary>
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
       
        /// <summary>
        /// Возвращает максимально допустимое значение параметра
        /// </summary>
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

        /// <summary>
        /// Значение параметра
        /// </summary>
        private string _value = "";

        /// <summary>
        /// Устанавливает и возвращает значение параметра
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                SetProperty(nameof(Value), () =>
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
                });
            }
        }

        /// <summary>
        /// Обновляет значение параметра и 
        /// его минимальное и максимальное значения
        /// </summary>
        public void UpdateProperties()
        {
            RaisePropertyChanged(nameof(MinValue));
            RaisePropertyChanged(nameof(MaxValue));
            RaisePropertyChanged(nameof(Value));
        }

        /// <summary>
        /// Инициализирует поля и свойства объекта 
        /// <see cref="AlloyWheelsParameterViewModel"/>
        /// </summary>
        /// <param name="alloyWheelsParameters">Параметры 
        /// модели</param>
        /// <param name="name">Тия параметра</param>
        public AlloyWheelsParameterViewModel(
            AlloyWheelsParameters alloyWheelsParameters,
            AlloyWheelsParameterName name)
        {
            _alloyWheelsParameters = alloyWheelsParameters;
            Name = name;
        }

        /// <summary>
        /// Событие, возникающее при попытке установить 
        /// некорректное значение свойству <see cref="Value"/>
        /// </summary>
        public event EventHandler<SetParameterValueArgs>
           ValueSetWithErrors;

        /// <summary>
        /// Событие, возникающее после установки 
        /// корректного значения свойства <see cref="Value"/>
        /// </summary>
        public event EventHandler<SetParameterValueArgs>
            ValueSetSuccessfully;

        /// <summary>
        /// Устанавливает свойству новое значение
        /// </summary>
        /// <param name="propertyName">Имя свойста</param>
        /// <param name="setProperty">Метод, выполняющий валидацию 
        /// и установку значения/param>
        private void SetProperty(string propertyName, Action setProperty)
		{
			try
			{
				setProperty();
				RemoveError(propertyName);
                ValueSetSuccessfully?.Invoke(this, new SetParameterValueArgs(
                    Name, ""));
            }
			catch (ArgumentException ex)
			{
				AddError(propertyName, ex.Message);
                ValueSetWithErrors?.Invoke(this, new SetParameterValueArgs(
                    Name, ex.Message));
            }

			RaisePropertyChanged(propertyName);
		}
	}
}
