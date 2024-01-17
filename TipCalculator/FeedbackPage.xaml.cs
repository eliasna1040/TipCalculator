using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator;

public partial class FeedbackPage : ContentPage
{
    public FeedbackPage()
    {
        InitializeComponent();
    }

    private async void GoToDetailsButton_OnClicked(object? sender, EventArgs e)
    {
        ShellNavigationQueryParameters param = new()
        {
            { "Name", "Elias" },
            { "Address", "Somewhere" },
            { "Age", "19" },
        };
        
        await Shell.Current.GoToAsync(nameof(DetailsPage), param);
    }
}