using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AlloyWheelsBuilderViewModel
{
    public class AlloyWheelsBuilderViewModel: ViewModelBase
    {
        public AlloyWheelsBuilderViewModel()
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

                  }));
            }
		}
    }
}
