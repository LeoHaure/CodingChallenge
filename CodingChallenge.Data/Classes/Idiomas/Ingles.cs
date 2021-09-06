using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Ingles: IIdioma
    {
        public string ListaVacia
        {
            get { return "Empty list of shapes!"; }
        }
        public string TituloReporte
        {
            get { return "Shapes report"; }
        }
        public string Formas
        {
            get { return "shapes"; }
        }

        public string Perimetro
        {
            get { return "Perimeter"; }
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
                    return cantidad == 1 ? "Square" : "Squares";
                case FormaGeometrica.Circulo:
                    return cantidad == 1 ? "Circle" : "Circles";
                case FormaGeometrica.TrianguloEquilatero:
                    return cantidad == 1 ? "Triangle" : "Triangles";
                case FormaGeometrica.Trapecio:
                    return cantidad == 1 ? "Trapeze" : "Trapezes";
                case FormaGeometrica.Rectangulo:
                    return cantidad == 1 ? "Rectangle" : "Rectangles";
                default:
                    return string.Empty;
            }
        }
    }
}
