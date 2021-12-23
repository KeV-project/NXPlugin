using System;
using System.Collections.Generic;
using System.Windows;
using AlloyWheelsBuilderViewModel;

namespace AlloyWheelsBuilderView
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class AlloyWheelsBuilderWindow : Window
	{
		public AlloyWheelsBuilderWindow()
		{
			InitializeComponent();
			DataContext = new AlloyWheelsBuilderWindowViewModel();
		}
	}
}
