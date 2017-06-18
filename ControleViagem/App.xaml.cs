using Prism.Unity;
using Xamarin.Forms;
using ControleViagem.ViewModels;
using ControleViagem.Views;

namespace ControleViagem
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected async override void OnInitialized()
		{
			InitializeComponent();

            await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/DetailPageView");

			//if (Device.Idiom == TargetIdiom.Desktop
			//   || Device.Idiom == TargetIdiom.Tablet)
			//{
			//	await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/DetailPageView");
			//}
			//else 
			//{
			//	//assume it's phone and navigate clean
			//	await NavigationService.NavigateAsync("BaseNavigationPageView/MasterPageView"); 
			//}
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MasterDetailPageView>();
			Container.RegisterTypeForNavigation<MasterPageView>();
			Container.RegisterTypeForNavigation<DetailPageView>();
			Container.RegisterTypeForNavigation<BaseNavigationPageView>();
            Container.RegisterTypeForNavigation<Teste>();
            Container.RegisterTypeForNavigation<FaceView>();
		}
	}
}

