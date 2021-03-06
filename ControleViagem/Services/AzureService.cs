﻿﻿using Microsoft.WindowsAzure.MobileServices;
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
	
	}

}
