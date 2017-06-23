using System;
using ControleViagem.Helpers;
using ControleViagem.Service;
using Prism.Navigation;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ControleViagem.ViewModels
{
    public class FaceViewModel : BaseViewModel
    {
		public Command ConectarFacebookCommand { get; }
		private readonly AzureService _azureService;

		public FaceViewModel(INavigationService navigationService)
			: base(navigationService)
		{
			//não utilizar toker armazenado
			Settings.AuthToken = string.Empty;
			Settings.UserId = string.Empty;

			//_navigation = navigation;
			_azureService = DependencyService.Get<AzureService>();

			ConectarFacebookCommand = new Command(async () => await ExecuteConectarFacebookCommandAsync());
		}

        private async Task ExecuteConectarFacebookCommandAsync()
        {
            if (Settings.IsLoggedIn)
                await Task.FromResult(true);
            else
                await _azureService.LoginAsync();

        }

         
	}
}

