using Prism.Commands;
using Prism.Mvvm;

namespace EvansBioApp.ViewModels
{
    public class MainPageButton : BindableBase
    {
        public MainPageButton(DelegateCommand cmd, string title, string subTitle, string image)
        {
            ImageLocation = image;
            Command = cmd;
            Title = title;
            SubTitle = subTitle;
        }

        public string ImageLocation { get;  }

        public DelegateCommand Command { get;  }
        public string Title { get;  }

        public string SubTitle { get; }
    }
}