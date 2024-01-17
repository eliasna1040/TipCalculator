using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Models;

namespace TipCalculator;

[QueryProperty(nameof(Person), nameof(Person))]
public partial class DetailsPage : ContentPage
{
    public Person? Person { set => BindingContext = value; }

    public DetailsPage()
    {
        InitializeComponent();
    }

    private void GoBackButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}