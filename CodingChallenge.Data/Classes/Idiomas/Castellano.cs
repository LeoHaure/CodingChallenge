using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Castellano : IIdioma
    {
        public string ListaVacia
        {
            get { return "Lista vacía de formas!"; }
        }
        public string TituloReporte
        {
            get { return "Reporte de Formas"; }
        }

        public string Formas
        {
            get { return "formas"; }
        }

        public string Perimetro
        {
            get { return "Perimetro"; }
        }
        public string Area
        {
            get { return "Area"; }
        }
        public string Total
        {
            get { return "TOTAL"; }
        }

        public string ObtenerLinea(int tipo, int cantidad, decimal area, decimal perimetro)
        {
            return $"{cantidad} {TraducirForma(tipo, cantidad)} | {Area} {area:#.##} | {Perimetro} {perimetro:#.##} <br/>";
        }

        private string TraducirForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case FormaGeometrica.Cuadrado:
                   return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                case FormaGeometrica.Circulo:
                    return cantidad == 1 ? "Círculo" : "Círculos";
                case FormaGeometrica.TrianguloEquilatero:
                    return cantidad == 1 ? "Triángulo" : "Triángulos";
                case FormaGeometrica.Trapecio:
                    return cantidad == 1 ? "Trapecio" : "Trapecios";
                case FormaGeometrica.Rectangulo:
                    return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                default:
                    return string.Empty;
            }
        }
    }
}
