using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace EvansBioApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private MainPageButton _selectedButton;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Chris Evans";
            AboutPageCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync("AboutPage"));
            SkillsPageCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync("SkillsPage"));
            ContactMePageCommand =
                new DelegateCommand(async () => await NavigationService.NavigateAsync("ContactMePage"));
            DelegateCommands = new ObservableCollection<MainPageButton>()
            {
                new MainPageButton(AboutPageCommand, "About Me", "Who I am and what I do", "Assets/MainTree.png", "Assets/MainPerson.png"),
                new MainPageButton(SkillsPageCommand, "My Skills", "My strength and proficiencies", "Assets/MainCSharp.png", "Assets/MainCode.png"),
                new MainPageButton(ContactMePageCommand, "Contact Me", "Need more information?  Let me know!", "Assets/MainPhone.png", "Assets/MainContact.png")
            };
        }

        public MainPageButton SelectedButton
        {
            get => _selectedButton;
            set { SetProperty(ref _selectedButton, value, () =>
            {
                if (SelectedButton != null)
                {
                    //SelectedButton.Command.Execute();
                    SelectedButton = null;
                }
            }); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            SelectedButton = null;
        }

        public ObservableCollection<MainPageButton> DelegateCommands { get; set; }
        public DelegateCommand ContactMePageCommand { get; set; }
        public DelegateCommand SkillsPageCommand { get; set; }
        public DelegateCommand AboutPageCommand { get; set; }
    }
}
