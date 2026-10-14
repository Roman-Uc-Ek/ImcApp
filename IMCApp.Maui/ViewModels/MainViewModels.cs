using IMCApp.Maui.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace IMCApp.Maui.ViewModels
{
    public class MainViewModels : INotifyPropertyChanged
    {
        private string _peso;
        public string Peso
        {
            get => _peso;
            set
            {
                if (_peso != value)
                {
                    _peso = value;
                    OnPropertyChanged(nameof(Peso));
                }
            }
        }

        private string _estatura;
        public string Estatura
        {
            get => _estatura;
            set
            {
                if (_estatura != value)
                {
                    _estatura = value;
                    OnPropertyChanged(nameof(Estatura));
                }
            }
        }
        private string _imc;
        public string IMC
        {
            get => _imc;
            set
            {
                if (_imc != value)
                {
                    _imc = value;
                    OnPropertyChanged(nameof(IMC));
                }
            }
        }

        private string _situacionNutricional;
        public string SituacionNutricional
        {
            get=> _situacionNutricional;
            set
            {
                if (_situacionNutricional != value)
                {
                    _situacionNutricional = value;
                    OnPropertyChanged(nameof(SituacionNutricional));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        public ICommand CalcularCommand {  get; private set; }
        public ICommand LimpiarCommand { get; private set; }

        public MainViewModels()
        {
            LimpiarValores();
            CalcularCommand = new Command (Calcular);
            LimpiarCommand = new Command(LimpiarValores);
        }
        /*public MainViewModels()
        {
            Peso = string.Empty;
            Estatura = string.Empty;
            IMC = string.Empty;
            SituacionNutricional = string.Empty;
        }*/
        private void LimpiarValores()
        {
            Peso = string.Empty;
            Estatura= string.Empty;
            IMC = string.Empty;
            SituacionNutricional = string.Empty;
        }

        public void Calcular()
        {
            decimal peso;
            bool pesoEsValido = decimal.TryParse(
                Peso, out peso);
            decimal estatura;
            bool estaturaEsValida = decimal.TryParse(
                Estatura, out estatura);
            if (pesoEsValido && estaturaEsValida)
            {
                decimal imc = CalculadoradeIMC
                    .IndiceDeMasaCorporal(peso, estatura);
                IMC = imc.ToString("F4");
                SituacionNutricional= CalculadoradeIMC.SituacionNutricional(imc);
            }
        }
    }
}
