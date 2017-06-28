using Microsoft.WindowsAzure.MobileServices;
using ControleViagem.Authentication;
using ControleViagem.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using ControleViagem.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//endereco de cadastramento de callback do site do facebook
//https://viagemteste.azurewebsites.net/.auth/login/facebook/callback


[assembly: Dependency(typeof(ControleViagem.Service.AzureService))]
namespace ControleViagem.Service
{
	public class AzureService
	{
		static readonly string AppUrl = "https://viagemteste.azurewebsites.net";
		public MobileServiceClient Client { get; set; } = null;

		public void Initialize()
		{
			Client = new MobileServiceClient(AppUrl);

			if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
			{
				Client.CurrentUser = new MobileServiceUser(Settings.UserId)
				{
					MobileServiceAuthenticationToken = Settings.AuthToken
				};
			}
		}

		public async Task<bool> LoginAsync()
		{
			Initialize();

			var auth = DependencyService.Get<IAuthentication>();
			var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

			if (user == null)
			{
				Settings.AuthToken = string.Empty;
				Settings.UserId = string.Empty;

				Device.BeginInvokeOnMainThread(async () =>
				{
					await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível efetuar login, tente novamente.", "OK");
				});
				return false;
			}
			else
			{
				Settings.AuthToken = user.MobileServiceAuthenticationToken;
				Settings.UserId = user.UserId;
			}
			return true;
		}

        public async Task<List<FacebookUser>> GetDadosFace()
        {
			List<FacebookUser> faceUser = null;
			faceUser = await Client.InvokeApiAsync<List<FacebookUser>>("/.auth/me");
            return faceUser;

        }
		
        public async Task GetFotoFace()
        {
		
			
            var client = new HttpClient();
			var fbUser = await client.GetAsync("https://graph.facebook.com/me?access_token=" + Settings.AuthToken);
			var response = await fbUser.Content.ReadAsStringAsync();
			var jo = JObject.Parse(response);
		
			


            //var teste = await Client.InvokeApiAsync("https://graph.facebook.com/me?fields=picture");
			//var teste = await Client.InvokeApiAsync("https://graph.facebook.com/me?access_token=EAAQhnZAII9hIBAIuMe1Dj8ijeQtKRLKGZCuc7wGcxlTR6J9J1MIbnkemhq6rfsgICrScNBdRCQuZAHUmoiKi4NAV7ZA679wr9JI1D1KK9dAoBjLBZBsKJbI6rIBxl2ziixA5d6W10eLL67OrQOCZAX0QVNaDhaZAkZAK53WAm2jj4gZDZD&fields=picture");

		}
	
	}

}
