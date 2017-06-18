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
            FacebookCommand = new Command(ExecuteFacebookCommand);
		}

        public Command BotaoCommand { get; }
        public Command FacebookCommand { get; }
 
		private async void ExecuteSearchCommand()
		{
            var url = "/MasterDetailPageView/BaseNavigationPageView/DetailPageView/Teste";

			var uri = new Uri(url, UriKind.Absolute);

			await base._navigationService.NavigateAsync(uri);
            //base._navigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/Teste");
		}

		private async void ExecuteFacebookCommand()
		{
			var url = "/MasterDetailPageView/BaseNavigationPageView/DetailPageView/FaceView";

			var uri = new Uri(url, UriKind.Absolute);

			await base._navigationService.NavigateAsync(uri);
		}
	}
}
