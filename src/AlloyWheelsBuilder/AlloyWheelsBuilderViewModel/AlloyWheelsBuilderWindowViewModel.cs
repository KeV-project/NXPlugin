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
        private AlloyWheelsData _alloyWheelsData;

        /// <summary>
        /// Возвращает минимальный диаметр
        /// </summary>
        public string MinDiameter { get => _alloyWheelsData.
                MinDiameter.ToString() + " ≤"; }

        /// <summary>
		/// Возвращает максимальный диаметр
		/// </summary>
        public string MaxDiameter { get => "≤ " + _alloyWheelsData.
                MaxDiameter.ToString(); }

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
                        _alloyWheelsData.Diameter = diameter;
                    }
                    else
					{
                        _alloyWheelsData.Diameter = double.NaN;
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
                if (double.IsNaN(_alloyWheelsData.MinCentralHoleDiameter))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsData.MinCentralHoleDiameter + " ≤";
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
                if (double.IsNaN(_alloyWheelsData.MaxCentralHoleDiameter))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsData.MaxCentralHoleDiameter;
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
                        _alloyWheelsData.CentralHoleDiameter = 
                        centralHoleDiametermeter;
                    }
                    else
                    {
                        _alloyWheelsData.CentralHoleDiameter = double.NaN;
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
                if (double.IsNaN(_alloyWheelsData.MinWidth))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsData.MinWidth + " ≤";
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
                if (double.IsNaN(_alloyWheelsData.MaxWidth))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsData.MaxWidth;
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
                        _alloyWheelsData.Width = width;
                    }
                    else
                    {
                        _alloyWheelsData.Width = double.NaN;
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
                if (double.IsNaN(_alloyWheelsData.MinOffSet))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsData.MinOffSet + " ≤";
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
                if (double.IsNaN(_alloyWheelsData.MaxOffSet))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsData.MaxOffSet;
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
                        _alloyWheelsData.OffSet = offSet;
                    }
                    else
                    {
                        _alloyWheelsData.OffSet = double.NaN;
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
                if (double.IsNaN(_alloyWheelsData.MinDrillDiameter))
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsData.MinDrillDiameter + " ≤";
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
                if (double.IsNaN(_alloyWheelsData.MaxDrillDiameter))
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsData.MaxDrillDiameter;
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
                        _alloyWheelsData.DrillDiameter = drillDiameter;
                    }
                    else
                    {
                        _alloyWheelsData.DrillDiameter = double.NaN;
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
                if(_alloyWheelsData.MinDrillingsCount == int.MinValue)
				{
                    return "";
				}
				else
				{
                    return _alloyWheelsData.MinDrillingsCount + " ≤";
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
                if(_alloyWheelsData.MaxDrillingsCount == int.MaxValue)
				{
                    return "";
				}
                else
				{
                    return "≤ " + _alloyWheelsData.MaxDrillingsCount;
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
                        _alloyWheelsData.DrillingsCount = drillingsCount;
                    }
                    else
                    {
                        _alloyWheelsData.DrillingsCount = int.MinValue;
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
                if (_alloyWheelsData.MinSpokesCount == int.MinValue)
                {
                    return "";
                }
                else
                {
                    return _alloyWheelsData.MinSpokesCount + " ≤";
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
                if (_alloyWheelsData.MaxSpokesCount == int.MaxValue)
                {
                    return "";
                }
                else
                {
                    return "≤ " + _alloyWheelsData.MaxSpokesCount;
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
                        _alloyWheelsData.SpokesCount = spokesCount;
                    }
                    else
                    {
                        _alloyWheelsData.SpokesCount = int.MinValue;
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
            _alloyWheelsData = new AlloyWheelsData();
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
                      new AlloyWheelsBuilder(_alloyWheelsData);
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
