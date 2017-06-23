using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControleViagem.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
		protected readonly INavigationService _navigationService;

		public DelegateCommand<string> NavigateCommand { get; set; }

		public BaseViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavigateCommand = new DelegateCommand<string>(Navigate);
		}

		private async void Navigate(string name)
		{
			await _navigationService.NavigateAsync(name);
		}


		//public event PropertyChangedEventHandler PropertyChanged;

		//protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		//{
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}

		//protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		//{
		//	if (EqualityComparer<T>.Default.Equals(storage, value))
		//	{
		//		return false;
		//	}

		//	storage = value;
		//	OnPropertyChanged(propertyName);
		//	return true;
		//}


		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		public virtual void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}
