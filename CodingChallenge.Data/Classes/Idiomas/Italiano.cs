using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Italiano : IIdioma
    {
        public string ListaVacia
        {
            get { return "Lista vuota di forme!"; }
        }
        public string TituloReporte
        {
            get { return "Rapporto sui moduli"; }
        }
        public string Formas
        {
            get { return "formes"; }
        }

        public string Perimetro
        {
            get { return "Perimetro"; }
        }
        public string Area
        {
            get { return "La zona"; }
        }
        public string Total
        {
            get { return "TOTALE"; }
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
                    return cantidad == 1 ? "Quadrato" : "Piazze";
                case FormaGeometrica.Circulo:
                    return cantidad == 1 ? "Cerchio" : "Cerchi";
                case FormaGeometrica.TrianguloEquilatero:
                    return cantidad == 1 ? "Triangolo" : "Triangoli";
                case FormaGeometrica.Trapecio:
                    return cantidad == 1 ? "Trapezio" : "Trapezi";
                case FormaGeometrica.Rectangulo:
                    return cantidad == 1 ? "Rettangolo" : "Rettangoli";
                default:
                    return string.Empty;
            }
        }
    }
}
