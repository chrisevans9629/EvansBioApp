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

	    public ContactMePageViewModel(IPageDialogService pageDialog, INavigationService navigationService): base(navigationService) 
	    {
	        _pageDialog = pageDialog;
	        SendCommand = new DelegateCommand(Send, CanSend);
	        SendCommand.ObservesProperty(() => Email);
	        SendCommand.ObservesProperty(() => Subject);
	        SendCommand.ObservesProperty(() => Details);
	    }

	    private bool CanSend()
	    {
	        return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Details) &&
	               !string.IsNullOrWhiteSpace(Subject);
	    }

	    public string Email
	    {
	        get => _email;
	        set => SetProperty(ref _email,value);
	    }

	    public string Details
	    {
	        get => _details;
	        set => SetProperty(ref _details,value);
	    }

	    public string Subject
	    {
	        get => _subject;
	        set => SetProperty(ref _subject,value);
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
