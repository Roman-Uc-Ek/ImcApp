using System;
using System.Collections.Generic;
using System.Text;

namespace IMCApp.Maui.Models
{
    public static class CalculadoradeIMC
    {
        public static decimal IndiceDeMasaCorporal(
            decimal peso, decimal estatura)
        {
            return peso/(estatura * estatura);
        }

        public static string SituacionNutricional(
            decimal imc)
        {
            if (imc < 18.5m)
            {
                return "Peso bajo";
            }
            if (imc < 25.0m)
            {
                return "Peso normal";
            }
            if (imc < 30.0m)
            {
                return "Sobrepeso";
            }
            if(imc < 40.0m)
            {
                return "Obesidad";
            }
            return "Obcidad extrema"; 
        }
    }
}
