using System;
using GalaSoft.MvvmLight.Command;
using ViewModelLib;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsBuilderWindowViewModel"/> 
    /// предназначен для взаимодействия интерфейса и модели
    /// </summary>
    public class AlloyWheelsBuilderWindowViewModel: 
        NotifyDataErrorViewModelBase
    {
        /// <summary>
        /// Параметры автомобильного диска
        /// </summary>
        private AlloyWheelsParameters _alloyWheelsParameters;

        /// <summary>
        /// Возвращает минимальный диаметр
        /// </summary>
        public string MinDiameter { get =>
                _alloyWheelsParameters[AlloyWheelsParameterName.Diameter].
                GetMinValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.NaN).ToString() + " ≤"; }

        /// <summary>
		/// Возвращает максимальный диаметр
		/// </summary>
        public string MaxDiameter { get => "≤ " 
                + _alloyWheelsParameters[AlloyWheelsParameterName.Diameter].
                GetMaxValue(_alloyWheelsParameters.ParameterValues,
                    AlloyWheelsParameterName.NaN).ToString(); }

        /// <summary>
		/// Хранит диаметр
		/// </summary>
        private string _diameter = "";

        /// <summary>
		/// Устанавливает и возвращает диаметр
		/// </summary>
        public string Diameter 
        {
            get => _diameter;
            set
            {
                SetProperty(nameof(Diameter), () =>
                {
                    _diameter = value;
                    if (double.TryParse(value, out double diameter))
					{
                        _alloyWheelsParameters[AlloyWheelsParameterName.Diameter].SetValue(
                            _alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.NaN, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.NaN], diameter);
                    }
                    else
					{
                        _alloyWheelsParameters[AlloyWheelsParameterName.Diameter].SetValue(
                            _alloyWheelsParameters.ParameterValues,
                            AlloyWheelsParameterName.NaN, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.NaN], double.NaN);
                        throw new ArgumentException("\"" + value + "\"" 
                            + " не является вещественным числом и" 
                            + " не может задавать диаметр диска");
                    }
                }, () =>
                {
                    CentralHoleDiameter = "";
                    RaisePropertyChanged(nameof(MinCentralHoleDiameter));
                    RaisePropertyChanged(nameof(MaxCentralHoleDiameter));
                    SpokesCount = "";
                    RaisePropertyChanged(nameof(MinSpokesCount));
                    RaisePropertyChanged(nameof(MaxSpokesCount));
                });
            }
        }

        /// <summary>
		/// Возвращает минимальный диаметр центрального отверстия
		/// </summary>
        public string MinCentralHoleDiameter
        {
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[
                    AlloyWheelsParameterName.CentralHoleDiameter].GetMinValue(
                    _alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.Diameter)))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsParameters[
                        AlloyWheelsParameterName.CentralHoleDiameter].
                        GetMinValue(_alloyWheelsParameters.ParameterValues,
                        AlloyWheelsParameterName.Diameter) + " ≤";
                }
            }
        }

        /// <summary>
		/// Возвращает максимальный диаметр центрального отверстия
		/// </summary>
        public string MaxCentralHoleDiameter
        {
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[
                    AlloyWheelsParameterName.CentralHoleDiameter].GetMaxValue(
                    _alloyWheelsParameters.ParameterValues,
                    AlloyWheelsParameterName.Diameter)))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsParameters[
                        AlloyWheelsParameterName.CentralHoleDiameter].GetMaxValue(
                        _alloyWheelsParameters.ParameterValues,
                        AlloyWheelsParameterName.Diameter);
                }
            }
        }

        /// <summary>
		/// Диаметр центрального отверстия
		/// </summary>
        private string _centralHoleDiameter = "";

        /// <summary>
		/// Устанавливает и возвращает 
        /// значение диаметра центрального отверстия
		/// </summary>
        public string CentralHoleDiameter 
        {
            get => _centralHoleDiameter;
            set
            {
                SetProperty(nameof(CentralHoleDiameter), () =>
                {
                    _centralHoleDiameter = value;
                    if (double.TryParse(value, out double 
                        centralHoleDiametermeter))
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.CentralHoleDiameter].
                            SetValue(_alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.Diameter,  
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.Diameter],
                            centralHoleDiametermeter);
                    }
                    else
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.CentralHoleDiameter].
                            SetValue(_alloyWheelsParameters.ParameterValues,
                            AlloyWheelsParameterName.Diameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.Diameter], double.NaN);
                        throw new ArgumentException("\"" + value + "\""
                            + " не является вещественным числом и"
                            + " не может задавать диаметр центрального" 
                            + " отверстия диска");
                    }
                }, () =>
                {
                    Width = "";
                    DrillDiameter = "";
                    RaisePropertyChanged(nameof(MinWidth));
                    RaisePropertyChanged(nameof(MaxWidth));
                    RaisePropertyChanged(nameof(MinDrillDiameter));
                    RaisePropertyChanged(nameof(MaxDrillDiameter));
                });
            }
        }

        /// <summary>
        /// Возвращает минимальный размер посадочной ширины
        /// </summary>
        public string MinWidth 
        {
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[AlloyWheelsParameterName.Width].
                    GetMinValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.CentralHoleDiameter)))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsParameters[AlloyWheelsParameterName.Width].
                        GetMinValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.CentralHoleDiameter) + " ≤";
                }
            }
        }

        /// <summary>
		/// Возвращает максимальный размер посадочной ширины
		/// </summary>
        public string MaxWidth 
        {
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[AlloyWheelsParameterName.Width].
                    GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.CentralHoleDiameter)))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsParameters[AlloyWheelsParameterName.Width].
                        GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.CentralHoleDiameter);
                }
            }
        }

        /// <summary>
		/// Посадочная ширина
		/// </summary>
        private string _width = "";

        /// <summary>
		/// Устанавливает и возвращает посадочную ширину диска
		/// </summary>
        public string Width 
        {
            get => _width;
            set
            {
                SetProperty(nameof(Width), () =>
                {
                    _width = value;
                    if (double.TryParse(value, out double width))
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.Width].SetValue(
                            _alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.CentralHoleDiameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.CentralHoleDiameter], width);
                    }
                    else
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.Width].SetValue(
                            _alloyWheelsParameters.ParameterValues,
                            AlloyWheelsParameterName.CentralHoleDiameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.CentralHoleDiameter],
                            double.NaN);
                        throw new ArgumentException("\"" + value + "\""
                            + " не является вещественным числом и"
                            + " не может задавать посадочную ширину диска");
                    }
                }, () =>
                {
                    OffSet = "";
                    RaisePropertyChanged(nameof(MinOffSet));
                    RaisePropertyChanged(nameof(MaxOffSet));
                });
            }
        }

        /// <summary>
        /// Возвращает максимальный отрицательный вылет
        /// </summary>
        public string MinOffSet
		{
			get
			{
                if (double.IsNaN(_alloyWheelsParameters[AlloyWheelsParameterName.OffSet].
                    GetMinValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.Width)))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsParameters[AlloyWheelsParameterName.OffSet].
                        GetMinValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.Width) + " ≤";
                }
            }
		}

        /// <summary>
		/// Возвращает максимальный положительный вылет
		/// </summary>
        public string MaxOffSet
		{
			get
			{
                if (double.IsNaN(_alloyWheelsParameters[AlloyWheelsParameterName.OffSet].
                    GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.Width)))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsParameters[AlloyWheelsParameterName.OffSet].
                        GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.Width);
                }
            }
		}

        /// <summary>
		/// Вылет диска
		/// </summary>
        private string _offSet = "";

        /// <summary>
		/// Устанавливает и возвращает вылет диска
		/// </summary>
        public string OffSet
		{
            get => _offSet;
            set
            {
                SetProperty(nameof(OffSet), () =>
                {
                    _offSet = value;
                    if (double.TryParse(value, out double offSet))
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.OffSet].SetValue(
                            _alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.Width, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.Width], offSet);
                    }
                    else
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.OffSet].SetValue(
                            _alloyWheelsParameters.ParameterValues,
                            AlloyWheelsParameterName.Width, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.Width], double.NaN);
                        throw new ArgumentException("\"" + value + "\""
                            + " не является вещественным числом и"
                            + " не может задавать вылет диска");
                    }
                }, null);
            }
        }

        /// <summary>
        /// Возвращает минимальный диаметр сверловки
        /// </summary>
        public string MinDrillDiameter
		{
            get
            {
                if (double.IsNaN(
                    _alloyWheelsParameters[AlloyWheelsParameterName.DrillDiameter].
                    GetMinValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.CentralHoleDiameter)))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsParameters[AlloyWheelsParameterName.DrillDiameter].
                        GetMinValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.CentralHoleDiameter) + " ≤";
                }
            }
        }

        /// <summary>
		/// Возвращает максимальный диаметр сверловки
		/// </summary>
        public string MaxDrillDiameter
        {
            get
            {
                if (double.IsNaN(
                    _alloyWheelsParameters[AlloyWheelsParameterName.DrillDiameter].
                    GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.CentralHoleDiameter)))
                {
                    return "";
                }
                else
                {
                    return "≤ " 
                        + _alloyWheelsParameters[AlloyWheelsParameterName.DrillDiameter].
                        GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.CentralHoleDiameter);
                }
            }
        }

        /// <summary>
		/// Диаметр сверловки
		/// </summary>
        private string _drillDiameter = "";

        /// <summary>
		/// Устанавливает и возвращает диаметр сверловки
		/// </summary>
        public string DrillDiameter 
        {
            get => _drillDiameter;
            set
            {
                SetProperty(nameof(DrillDiameter), () =>
                {
                    _drillDiameter = value;
                    if (double.TryParse(value, out double drillDiameter))
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.DrillDiameter].
                            SetValue(_alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.CentralHoleDiameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.CentralHoleDiameter],
                            drillDiameter);
                    }
                    else
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.DrillDiameter].
                             SetValue(_alloyWheelsParameters.ParameterValues,
                             AlloyWheelsParameterName.CentralHoleDiameter, 
                             AlloyWheelsParameters.ParameterRussianNames[
                                 AlloyWheelsParameterName.CentralHoleDiameter],
                             double.NaN);
                        throw new ArgumentException("\"" + value + "\""
                            + " не является вещественным числом и"
                            + " не может задавать диаметр сверловки");
                    }
                }, () =>
                {
                    DrillingsCount = "";
                    RaisePropertyChanged(nameof(MinDrillingsCount));
                    RaisePropertyChanged(nameof(MaxDrillingsCount));
                });
            }
        }

        /// <summary>
        /// Возвращает минимальное количество отверстий
        /// </summary>
        public string MinDrillingsCount
		{
			get
			{
                if(double.IsNaN(
                    _alloyWheelsParameters[AlloyWheelsParameterName.DrillingsCount].
                    GetMinValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.DrillDiameter)))
				{
                    return "";
				}
				else
				{
                    return _alloyWheelsParameters[AlloyWheelsParameterName.DrillingsCount].
                        GetMinValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.DrillDiameter) + " ≤";
				}
			}
		}

        /// <summary>
		/// Возвращает максимальное количество отверстий
		/// </summary>
        public string MaxDrillingsCount
		{
			get
			{
                if(double.IsNaN(
                    _alloyWheelsParameters[AlloyWheelsParameterName.DrillingsCount].
                    GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.DrillDiameter)))
				{
                    return "";
				}
                else
				{
                    return "≤ " 
                        + _alloyWheelsParameters[AlloyWheelsParameterName.DrillingsCount].
                        GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.DrillDiameter);
				}
			}
		}

        /// <summary>
		/// Количество отверстий
		/// </summary>
        private string _drillingsCount = "";

        /// <summary>
		/// Устанавливает и возвращает количество отверстий
		/// </summary>
        public string DrillingsCount 
        {
            get => _drillingsCount;
            set
            {
                SetProperty(nameof(DrillingsCount), () =>
                {
                    _drillingsCount = value;
                    if (int.TryParse(value, out int drillingsCount))
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.DrillingsCount].
                            SetValue(_alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.DrillDiameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.DrillDiameter], 
                            drillingsCount);
                    }
                    else
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.DrillingsCount].
                            SetValue(_alloyWheelsParameters.ParameterValues,
                            AlloyWheelsParameterName.DrillDiameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.DrillDiameter], double.NaN);
                        throw new ArgumentException("\"" + value + "\""
                            + " не является целым числом и"
                            + " не может определять количество отверстий");
                    }
                }, null);
            }
        }

        /// <summary>
        /// Возвращает минимальное количество спиц
        /// </summary>
        public string MinSpokesCount
		{
            get
			{
                if (double.IsNaN(_alloyWheelsParameters[AlloyWheelsParameterName.SpokesCount].
                    GetMinValue(_alloyWheelsParameters.ParameterValues, 
                    AlloyWheelsParameterName.Diameter)))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsParameters[AlloyWheelsParameterName.SpokesCount].
                        GetMinValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.Diameter) + " ≤";
                }
            }
		}

        /// <summary>
        /// Возвращает максимальное количество спиц
        /// </summary>
        public string MaxSpokesCount
		{
            get
            {
                if (double.IsNaN(_alloyWheelsParameters[AlloyWheelsParameterName.SpokesCount].
                    GetMaxValue(_alloyWheelsParameters.ParameterValues,
                    AlloyWheelsParameterName.Diameter)))
                {
                    return "";
                }
                else
                {
                    return "≤ " 
                        + _alloyWheelsParameters[AlloyWheelsParameterName.SpokesCount].
                        GetMaxValue(_alloyWheelsParameters.ParameterValues, 
                        AlloyWheelsParameterName.Diameter);
                }
            }
        }

        /// <summary>
        /// Количество спиц
        /// </summary>
        private string _spokesCount = "";

        /// <summary>
        /// Устанавливает и возвращает количество спиц
        /// </summary>
        public string SpokesCount 
        {
            get => _spokesCount;
            set
            {
                SetProperty(nameof(SpokesCount), () =>
                {
                    _spokesCount = value;
                    if (int.TryParse(value, out int spokesCount))
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.SpokesCount].SetValue(
                            _alloyWheelsParameters.ParameterValues, 
                            AlloyWheelsParameterName.Diameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.Diameter], spokesCount);
                    }
                    else
                    {
                        _alloyWheelsParameters[AlloyWheelsParameterName.SpokesCount].SetValue(
                            _alloyWheelsParameters.ParameterValues,
                            AlloyWheelsParameterName.Diameter, 
                            AlloyWheelsParameters.ParameterRussianNames[
                                AlloyWheelsParameterName.Diameter], double.NaN);
                        throw new ArgumentException("\"" + value + "\""
                            + " не является целым числом и"
                            + " не может определять количество спиц");
                    }
                }, null);
            }
        }

        /// <summary>
        /// Инициализирует объект класса 
        /// <see cref="AlloyWheelsBuilderWindowViewModel"/>
        /// </summary>
        public AlloyWheelsBuilderWindowViewModel()
		{
            _alloyWheelsParameters = new AlloyWheelsParameters();
            Diameter = "";
		}

        /// <summary>
        /// Команда очистки полей для ввода параметров
        /// </summary>
        private RelayCommand _cancelCommand;

        /// <summary>
        /// Возвращает команду очистки полей для ввода параметров
        /// </summary>
        public RelayCommand CancelCommand
		{
			get
			{
                return _cancelCommand ??
                  (_cancelCommand = new RelayCommand(() =>
                  {
                      Diameter = "";
                  }));
            }
		}

        /// <summary>
        /// Командля построения модели
        /// </summary>
        private RelayCommand _buildCommand;

        /// <summary>
        /// Возвращает команду построения модели
        /// </summary>
        public RelayCommand BuildCommand
		{
			get
			{
                return _buildCommand ??
                  (_buildCommand = new RelayCommand(() =>
                  {
                      AlloyWheelsBuilder alloyWheelsBuilder = 
                      new AlloyWheelsBuilder(_alloyWheelsParameters);
                      alloyWheelsBuilder.Build();
                  }));
            }
		}

        /// <summary>
        /// Устанавливает значение свойства
        /// </summary>
        /// <param name="property">Имя свойства</param>
        /// <param name="setProperty">Метод, 
        /// выполняющий установку значения свойства</param>
        /// <param name="raiseProperties">Метод, 
        /// выполняющий обновление зависимых полей</param>
        private void SetProperty(string property, Action setProperty, 
            Action raiseProperties)
        {
            try
            {
                setProperty();
                RemoveError(property);
            }
            catch (ArgumentException ex)
            {
                AddError(property, ex.Message);
            }

            raiseProperties?.Invoke();
            RaisePropertyChanged(property);
        }
    }
}
