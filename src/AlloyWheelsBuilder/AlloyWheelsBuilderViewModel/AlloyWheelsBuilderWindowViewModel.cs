using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using ViewModelLib;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilderViewModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsBuilderWindowViewModel"/> 
    /// предназначен для взаимодействия интерфейса и модели
    /// </summary>
    public class AlloyWheelsBuilderWindowViewModel :
        NotifyDataErrorViewModelBase
    {
        /// <summary>
        /// Параметры автомобильного диска
        /// </summary>
        private AlloyWheelsParameters _alloyWheelsParameters;

        /// <summary>
        /// Словарь методов, выполняющих обновление зависимых параметров
        /// </summary>
        private Dictionary<AlloyWheelsParameterName, Action> _raiseParameters;

        /// <summary>
        /// Вьюмоделей параметров
        /// </summary>
        private Dictionary<string, AlloyWheelsParameterViewModel> 
            _alloyWheelsParameterViewModels = new Dictionary<string,
                AlloyWheelsParameterViewModel>();

        /// <summary>
        /// Возвращает словарь вьюмоделей
        /// </summary>
        public Dictionary<string, AlloyWheelsParameterViewModel>
            AlloyWheelsParameterViewModels => _alloyWheelsParameterViewModels;

        /// <summary>
        /// Инициализирует объект класса 
        /// <see cref="AlloyWheelsBuilderWindowViewModel"/>
        /// </summary>
        public AlloyWheelsBuilderWindowViewModel()
		{
            _alloyWheelsParameters = new AlloyWheelsParameters();

            _raiseParameters = new Dictionary<AlloyWheelsParameterName, 
                Action>
            {
                { AlloyWheelsParameterName.Diameter, () => 
                    {
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.CentralHoleDiameter.
                            ToString()].Value = "";
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.CentralHoleDiameter.
                            ToString()].UpdateProperties();

                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.SpokesCount.
                            ToString()].Value = "";
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.SpokesCount.
                            ToString()].UpdateProperties();
                    } 
                },
                { AlloyWheelsParameterName.CentralHoleDiameter, () =>
                    {
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.Width.
                            ToString()].Value = "";
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.Width.
                            ToString()].UpdateProperties();

                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.DrillDiameter.
                            ToString()].Value = "";
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.DrillDiameter.
                            ToString()].UpdateProperties();
                    }
                },
                { AlloyWheelsParameterName.Width, () =>
                    {
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.OffSet.
                            ToString()].Value = "";
                         AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.OffSet.
                            ToString()].UpdateProperties();
                    }
                },
                { AlloyWheelsParameterName.OffSet, null},
                { AlloyWheelsParameterName.DrillDiameter, () =>
                    {
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.DrillingsCount.
                            ToString()].Value = "";
                        AlloyWheelsParameterViewModels[
                            AlloyWheelsParameterName.DrillingsCount.
                            ToString()].UpdateProperties();

                    }
                },
                { AlloyWheelsParameterName.DrillingsCount, null},
                { AlloyWheelsParameterName.SpokesCount, null},
            };

            foreach (KeyValuePair<AlloyWheelsParameterName, 
                Action> raiseParameter in _raiseParameters)
			{
                if(raiseParameter.Key != AlloyWheelsParameterName.NaN)
				{
                    AlloyWheelsParameterViewModels.Add(
                    raiseParameter.Key.ToString(),
                    new AlloyWheelsParameterViewModel(
                        _alloyWheelsParameters, raiseParameter.Key));
                    AlloyWheelsParameterViewModels[raiseParameter.Key.ToString()].
                        ValueSetSuccessfully += RemoveError;
                    AlloyWheelsParameterViewModels[raiseParameter.Key.ToString()].
                        ValueSetWithErrors += AddError;
                }
			}

            AlloyWheelsParameterViewModels[AlloyWheelsParameterName.
                Diameter.ToString()].Value = "";
		}

        /// <summary>
        /// Возвращает значение, показывающее, 
        /// нужно ли делать скругление рисунка
        /// </summary>
        public bool IsNeedRounding { get; set; } = false;

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
                      AlloyWheelsParameterViewModels[
                          AlloyWheelsParameterName.Diameter.ToString()].
                          Value = "";
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
                      new AlloyWheelsBuilder(_alloyWheelsParameters, 
                      IsNeedRounding);
                      alloyWheelsBuilder.Build();
                  }));
            }
		}

        /// <summary>
        /// Удаляет параметр из списка ошибок 
        /// и обновляет его зависимые параметры
        /// </summary>
        /// <param name="parameterViewModel"></param>
        /// <param name="eventArgs"></param>
        public void RemoveError(object parameterViewModel, 
            SetParameterValueArgs eventArgs)
		{
            RemoveError(eventArgs.ParameterName.ToString());
            _raiseParameters[eventArgs.ParameterName]?.Invoke();
        }

        /// <summary>
        /// Добавляет парамеетр в список ошибок 
        /// и обновляет его зависимые параметры
        /// </summary>
        /// <param name="parameterViewModel"></param>
        /// <param name="eventArgs"></param>
        private void AddError(object parameterViewModel, 
            SetParameterValueArgs eventArgs)
        {
            AddError(eventArgs.ParameterName.ToString(), 
                eventArgs.Message);
            _raiseParameters[eventArgs.ParameterName]?.Invoke();
        }
    }
}
