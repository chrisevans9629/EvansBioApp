﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvansBioApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            AboutPageCommand = new DelegateCommand(async ()=> await NavigationService.NavigateAsync("AboutPage"));
        }


        public DelegateCommand AboutPageCommand { get; set; }
    }
}
