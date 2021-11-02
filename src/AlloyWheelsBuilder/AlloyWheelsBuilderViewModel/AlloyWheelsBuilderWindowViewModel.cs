using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using ViewModelLib;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsBuilderWindowViewModel: NotifyDataErrorViewModelBase
    {
        private AlloyWheelsData _alloyWheelsData;

        public string Diameter 
        {
            get => _alloyWheelsData.Diameter.ToString();
            set
            {
                SetProperty(nameof(Diameter), () =>
                {
                    double.TryParse(value, out double diameter);
                    _alloyWheelsData.Diameter = diameter;
                });
            }
        }

        public string Width { get; set; }

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

        private void SetProperty(string property, Action setProperty)
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

            RaisePropertyChanged(property);
        }
    }
}
