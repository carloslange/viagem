using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace ControleViagem.ViewModels
{
	public class MasterPageViewModel : BaseViewModel
	{
		public MasterPageViewModel(INavigationService navigationService)
			:base(navigationService)
		{
            BotaoCommand = new Command(ExecuteSearchCommand);
          
		}

        public Command BotaoCommand { get; }
 
		private async void ExecuteSearchCommand(object obj)
		{
            var url = "/MasterDetailPageView/BaseNavigationPageView/DetailPageView/Teste";

			var uri = new Uri(url, UriKind.Absolute);

			await base._navigationService.NavigateAsync(uri);
            //base._navigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/Teste");
		}

	}
}
