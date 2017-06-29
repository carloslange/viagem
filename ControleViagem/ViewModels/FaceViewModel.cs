﻿using System;
using ControleViagem.Helpers;
using ControleViagem.Service;
using Prism.Navigation;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControleViagem.ViewModels
{
    public class FaceViewModel : BaseViewModel
    {
		public Command ConectarFacebookCommand { get; }
        public Command DadosFacebookCommand { get; }
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

            DadosFacebookCommand = new Command(async () => await ExecuteDadosFacebookCommandAsync());
		}

        private async Task ExecuteConectarFacebookCommandAsync()
        {
            if (Settings.IsLoggedIn)
                await Task.FromResult(true);
            else
                await _azureService.LoginAsync();
            
			UserId = Settings.UserId;
			Token = Settings.AuthToken;
        }

		private async Task ExecuteDadosFacebookCommandAsync()
		{
			
			var a = await _azureService.GetDadosFace();

            UserId = a[0].user_claims[2].val;
			Token = a[0].user_claims[1].val;

            //await _azureService.GetFotoFace(a[0].user_claims[0].val);

		}

		private string _userId;
		public string UserId
		{
			get { return _userId; }
			set
			{
				SetProperty(ref _userId, value);
			}
		}

		private string _token;
		public string Token
		{
			get { return _token; }
			set
			{
				SetProperty(ref _token, value);
			}
		}


	}
}

