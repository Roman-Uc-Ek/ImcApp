using IMCApp.Maui.Models;

namespace IMCApp.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        LimpiarValores();
	}

    private void OnCalcularButtonClicked(object sender, EventArgs e)
    {
        decimal peso;
        bool pesoEsValido = decimal.TryParse(
            PesoLabel.Text, out peso);
        decimal estatura;
        bool estaturaEsValida = decimal.TryParse(
            EstaturaLabel.Text, out estatura);
        if (pesoEsValido && estaturaEsValida)
        {
            decimal imc = CalculadoradeIMC
                .IndiceDeMasaCorporal(peso, estatura);
            ImcLabel.Text = imc.ToString("F4");
            SituacionNuticionalLabel.Text = CalculadoradeIMC.SituacionNutricional(imc);
        } 
    }

    private void OnLimpiarButtonClicked(object sender, EventArgs e)
    {
        LimpiarValores();
    }

    private void LimpiarValores()
    {
        PesoLabel.Text = string.Empty;
        EstaturaLabel.Text = string.Empty;
        ImcLabel.Text = string.Empty;
        SituacionNuticionalLabel.Text = string.Empty;
    }
}