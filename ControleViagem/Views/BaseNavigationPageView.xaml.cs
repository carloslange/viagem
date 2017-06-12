using Prism.Navigation;
using Xamarin.Forms;

namespace ControleViagem.Views
{
	public partial class BaseNavigationPageView 
		: NavigationPage, INavigationPageOptions 
	{
		public bool ClearNavigationStackOnNavigation
		{
			get { return true; }
		}

		public BaseNavigationPageView()
		{
			InitializeComponent();
		}
	}
}

