/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Classes.Fomas;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        #endregion

        private readonly decimal _lado;
        private readonly decimal _alto;

        private readonly decimal _ladoB;
        private readonly decimal _ladoC;
        private readonly decimal _ladoD;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal lado)
        {
            Tipo = tipo;
            _lado = lado;
        }

        public FormaGeometrica(int tipo, decimal lado, decimal alto)
        {
            Tipo = tipo;
            _lado = lado;
            _alto = alto;
        }

        public FormaGeometrica(int tipo, decimal lado, decimal ladoB, decimal ladoC, decimal ladoD, decimal alto)
        {
            Tipo = tipo;
            _lado = lado;
            _ladoB = ladoB;
            _ladoC= ladoC;
            _ladoD = ladoD;
            _alto = alto;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            IIdioma Iidioma = ObtenerIdioma(idioma);

            if (!formas.Any())
            {
                sb.Append($"<h1>{Iidioma.ListaVacia}</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{Iidioma.TituloReporte}</h1>");

                var numeroElementos = 0;
                var areaElementos = 0m;
                var perimetroElementos = 0m;

                Dictionary<int, Elemento> diccionarioElementos = new Dictionary<int, Elemento>();

                foreach (var forma in formas)
                {
                    AgregarElemento(diccionarioElementos, ObtenerForma(forma));
                }

                foreach (var values in diccionarioElementos)
                {
                    sb.Append(Iidioma.ObtenerLinea(values.Key, values.Value.Cantidad, values.Value.Area, values.Value.Perimetro));
                    numeroElementos += values.Value.Cantidad;
                    perimetroElementos += values.Value.Perimetro;
                    areaElementos += values.Value.Area;
                }

                // FOOTER
                sb.Append($"{Iidioma.Total}:<br/>");
                sb.Append(numeroElementos + " " + Iidioma.Formas + " ");
                sb.Append(Iidioma.Perimetro + " " + perimetroElementos.ToString("#.##") + " ");
                sb.Append(Iidioma.Area + " " + areaElementos.ToString("#.##"));
            }

            return sb.ToString();
        }

        private static void AgregarElemento(Dictionary<int, Elemento> keyValues, IForma forma)
        {
            if (keyValues.ContainsKey(forma.Tipo))
            {
                keyValues[forma.Tipo].Cantidad += 1;
                keyValues[forma.Tipo].Area += forma.Area();
                keyValues[forma.Tipo].Perimetro += forma.Perimetro();
            }
            else
            {
                keyValues.Add(forma.Tipo, new Elemento() { Cantidad = 1, Area = forma.Area(), Perimetro = forma.Perimetro() });
            }
        }

        private static IIdioma ObtenerIdioma(int idioma)
        {
            switch (idioma)
            {
                case Castellano:
                    return new Castellano();
                case Ingles:
                    return new Ingles();
                case Italiano:
                    return new Italiano();
                default:
                    {   //LogError("Invalid language, the default language is set."); --> Se utiliza el idioma por defecto y se graba en el log información sobre la decisión tomada.  
                        return new Ingles();
                    }
            }
        }

        private static IForma ObtenerForma(FormaGeometrica forma)
        {
            switch (forma.Tipo)
            {
                case Cuadrado:
                    return new Cuadrado(forma._lado);
                case TrianguloEquilatero:
                    return new TrianguloEquilatero(forma._lado);
                case Circulo:
                    return new Circulo(forma._lado);
                case Trapecio:
                    return new Trapecio(forma._lado, forma._ladoB, forma._ladoC, forma._ladoD, forma._alto);
                case Rectangulo:
                    return new Rectangulo(forma._lado, forma._alto);
                default:
                    {     
                        throw new Exception("Invalid form");
                    }
            }
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        
        #region CÓDIGO ANTERIOR

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
        #endregion
    }
}
