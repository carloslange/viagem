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
 
		private void ExecuteSearchCommand(object obj)
		{
            //base._navigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/DetailPageView/Teste");
            base._navigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/Teste");
		}

	}
}
