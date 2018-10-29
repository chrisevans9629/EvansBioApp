using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;

namespace EvansBioApp.ViewModels
{
	public class ContactMePageViewModel : ViewModelBase
	{
	    private readonly IPageDialogService _pageDialog;
	    private string _details;
	    private string _subject;
	    private string _email;
	    private string _errorMessage;
	    private bool _invalid;

	    public ContactMePageViewModel(IPageDialogService pageDialog, INavigationService navigationService): base(navigationService) 
	    {
	        _pageDialog = pageDialog;
	        SendCommand = new DelegateCommand(Send, CanSend);
	        SendCommand.ObservesProperty(() => Email);
	        SendCommand.ObservesProperty(() => Subject);
	        SendCommand.ObservesProperty(() => Details);
            Validate();
	    }


	    public string ErrorMessage
	    {
	        get => _errorMessage;
	        set => SetProperty(ref _errorMessage,value);
	    }

	    public bool Invalid
	    {
	        get => _invalid;
	        set => SetProperty(ref _invalid,value);
	    }

	    private bool CanSend()
	    {
	        Invalid = !(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Details) &&
	               !string.IsNullOrWhiteSpace(Subject));
	        return !Invalid;
	    }

	    public string Email
	    {
	        get => _email;
	        set => SetProperty(ref _email,value, Validate);
	    }

	    public string Details
	    {
	        get => _details;
	        set => SetProperty(ref _details,value, Validate);
	    }

	    public string Subject
	    {
	        get => _subject;
	        set => base.SetProperty(ref _subject, value, Validate);
	    }

        private void Validate()
        {
            ErrorMessage = "";
            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage += "email cannot be null\n";
            }
            if (string.IsNullOrWhiteSpace(Details))
            {
                ErrorMessage += "details cannot be null\n";
            }
            if (string.IsNullOrWhiteSpace(Subject))
            {
                ErrorMessage += "subject cannot be null\n";
            }
        }

        private async void Send()
	    {
	        await _pageDialog.DisplayAlertAsync("Success!",
	            "Thank you for your message!\nWe have received your message and will reply as soon as we can.", "OK");
	        await NavigationService.GoBackAsync();
	    }

	    public DelegateCommand SendCommand { get; set; }
	}
}
