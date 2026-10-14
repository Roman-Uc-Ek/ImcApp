using IMCApp.Maui.Models;
using IMCApp.Maui.ViewModels;

namespace IMCApp.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModels();
       
	}
}