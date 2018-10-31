using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EvansBioApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Grid.Children.AnimateList();
        }
    }
}
