using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsBuilderWindowViewModel: ViewModelBase
    {
        private string _diameter;

        public double Diameter { get; set; }

        private string _width;

        public double Width { get; set; }

        private string _centralHoleDiameter;

        public double CentralHoleDiameter { get; set; }

        private string _offSet;

        public double OffSet { get; set; }

        private string _drillDiameter;

        public double DrillDiameter { get; set; }

        private int _drillingsCount;

        public int DrillingsCount { get; set; }

        private int _spokesCount;

        public int SpokesCount { get; set; }


        public AlloyWheelsBuilderWindowViewModel()
		{

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
                      AlloyWheelsData alloyWheelsData = new AlloyWheelsData();
                      AlloyWheelsBuilder.Build(alloyWheelsData);
                  }));
            }
		}
    }
}
