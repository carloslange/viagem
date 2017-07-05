using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;

namespace ControleViagem.ViewModels
{
    public class MoedaViewModel : BaseViewModel
    {
		public Command ConverterMoedaCommand { get; }

		public MoedaViewModel(INavigationService navigationService)
            : base(navigationService)
		{
            ConverterMoedaCommand = new Command(async () => await ExecuteConverterMoedaCommandAsync());
        }

        private async Task ExecuteConverterMoedaCommandAsync()
        {
            Euro = "123";
            Dolar = "555";
            
        }
               
		private string _euro;
		public string Euro
		{
		  get { return _euro; }
		  set
		  {
		      SetProperty(ref _euro, value);
		  }
		}

		private string _dolar;
		public string Dolar
		{
		  get { return _dolar; }
		  set
		  {
		      SetProperty(ref _dolar, value);
		  }
		}

	}
}


