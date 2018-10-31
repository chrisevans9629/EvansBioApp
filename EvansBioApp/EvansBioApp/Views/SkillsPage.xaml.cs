using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EvansBioApp.Views
{
    public static class AnimationExt
    {
        public static async Task PreAnimate(this View view, Func<View, Task> viewAction = null)
        {
            if (viewAction == null)
            {
                viewAction = async view1 => await view.ScaleTo(0, 0);
            }
            await viewAction.Invoke(view);
        }
        public static async Task Animate(this View view)
        {
            await view.ScaleTo(1, 250);
        }

        public static async Task AnimateList(this IEnumerable<View> views)
        {

#pragma warning disable 4014
            var children = views.ToList();
            foreach (var child in children)
            {
                child.PreAnimate();
            }
#pragma warning restore 4014

            await Task.Delay(100);
            foreach (var child in children)
            {
                await child.Animate();
            }
        }
    }
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
            await Grid.Children.AnimateList();

        }
    }
}
