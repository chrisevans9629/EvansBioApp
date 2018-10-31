using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EvansBioApp.Views
{
    public partial class ContactMePage : ContentPage
    {
        public ContactMePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Grid.Children.SelectMany(GetChildPanels).AnimateList();
        }

        private IEnumerable<View> GetChildPanels(View arg)
        {
            if (arg is Layout<View> layout)
            {
                var children = layout.Children.ToList();
                return children;
            }
            else
            {
                return new List<View>();
            }
        }
    }
}
