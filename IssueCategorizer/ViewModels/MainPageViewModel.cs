using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IssueCategorizer.Models;
using IssueCategorizer.Services.Interfaces;

namespace IssueCategorizer.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		private readonly IIssueService issueService;

		[ObservableProperty]
		private string area;

		[ObservableProperty]
		private IssueInputModel inputModel;

		public MainPageViewModel(IIssueService issueService)
		{
			this.issueService = issueService;
			this.InputModel = new IssueInputModel();
		}


		[RelayCommand]
		public void GetArea()
		{
			this.Area = this.issueService.GetPrediction(this.InputModel);
		}
	}
}
