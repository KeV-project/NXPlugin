using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using GalaSoft.MvvmLight.Command;
using ViewModelLib;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsBuilderWindowViewModel: NotifyDataErrorViewModelBase
    {
        private AlloyWheelsData _alloyWheelsData;

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

        public string MinWidth { get => _alloyWheelsData.
                MinWidth.ToString() + " ≤"; }

        public string MaxWidth { get => "≤ " + _alloyWheelsData.
                MaxWidth.ToString(); }

        private string _width = "";

        public string Width 
        {
            get => _width;
            set
			{
                //SetProperty(nameof(Width), () =>
                //{
                //    _width = value;
                //    if (double.TryParse(value, out double width))
                //    {
                //        _alloyWheelsData.Width = width;
                //    }
                //    else
                //    {
                //        _alloyWheelsData.Width = double.NaN;
                //        throw new ArgumentException(value + " не является "
                //            + "вещественным числом и не может задавать "
                //            + "посадочную ширину диска");
                //    }
                //});
            }
        }

        public string MinCentralHoleDiameter
		{
			get
			{
                if(double.IsNaN(_alloyWheelsData.MinCentralHoleDiameter))
				{
                    return "";
				}
                else
				{
                    return _alloyWheelsData.MinCentralHoleDiameter.
                        ToString() + " ≤";
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
                    return "≤ " + _alloyWheelsData.MaxCentralHoleDiameter.
                        ToString();
                }
            }
        }

        public string CentralHoleDiameter { get; set; }

        public string OffSet { get; set; }

        public string DrillDiameter { get; set; }

        public string DrillingsCount { get; set; }

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
                      AlloyWheelsBuilder alloyWheelsBuilder = new AlloyWheelsBuilder(_alloyWheelsData);
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

            raiseProperties();
            RaisePropertyChanged(property);
        }
    }
}
