﻿using System;
using GalaSoft.MvvmLight.Command;
using ViewModelLib;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsBuilderWindowViewModel: NotifyDataErrorViewModelBase
    {
        private AlloyWheelsData _alloyWheelsData;

        // Диаметр 

        public string MinDiameter { get => _alloyWheelsData.
                MinDiameter.ToString() + " ≤"; }

        public string MaxDiameter { get => "≤ " + _alloyWheelsData.
                MaxDiameter.ToString(); }

        private string _diameter = "";

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
                    RaisePropertyChanged(nameof(MinCentralHoleDiameter));
                    RaisePropertyChanged(nameof(MaxCentralHoleDiameter));
                });
            }
        }

        // Диаметр ЦО

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

        private string _centralHoleDiameter = "";

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
                    RaisePropertyChanged(nameof(MinWidth));
                    RaisePropertyChanged(nameof(MaxWidth));
                    RaisePropertyChanged(nameof(MinDrillDiameter));
                    RaisePropertyChanged(nameof(MaxDrillDiameter));
                });
            }
        }

        // Посадочная ширина

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

        private string _width = "";

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
                    RaisePropertyChanged(nameof(MinOffSet));
                    RaisePropertyChanged(nameof(MaxOffSet));
                });
            }
        }

        // Вылет 

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

        private string _offSet = "";

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

        // Диаметр сверловки

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

        private string _drillDiameter = "";

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
                    RaisePropertyChanged(nameof(MinDrillingsCount));
                    RaisePropertyChanged(nameof(MaxDrillingsCount));
                });
            }
        }

        // Количество отверстий для сверловки

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

        private string _drillingsCount = "";

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

        // Количество спиц

        public string SpokesCount { get; set; }


        public AlloyWheelsBuilderWindowViewModel()
		{
            _alloyWheelsData = new AlloyWheelsData();
		}

        private RelayCommand _cancelCommand;

        public RelayCommand CancelCommand
		{
			get
			{
                return _cancelCommand ??
                  (_cancelCommand = new RelayCommand(() =>
                  {
                      
                  }));
            }
		}

        private RelayCommand _buildCommand;

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
