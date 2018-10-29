using Xamarin.Forms;

namespace EvansBioApp.Views
{
    public interface ISkillsPage
    {

    }
    public partial class SkillsPage : ContentPage, ISkillsPage
    {

        public SkillsPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           
            PreAnimate(programming);
            PreAnimate(fsharp);
            PreAnimate(apps);
            PreAnimate(framework);
            PreAnimate(software);
            PreAnimate(blackhole);
            PreAnimate(music);
            PreAnimate(other);

            await Animate(programming);
            await Animate(fsharp);
            await Animate(apps);
            await Animate(framework);
            await Animate(software);
            await Animate(blackhole);
            await Animate(music);
            await Animate(other);

        }


        private async System.Threading.Tasks.Task PreAnimate(View view)
        {
            await view.ScaleTo(0, 0);
        }
        private async System.Threading.Tasks.Task Animate(View view)
        {
            await view.ScaleTo(1);
        }
    }
}
