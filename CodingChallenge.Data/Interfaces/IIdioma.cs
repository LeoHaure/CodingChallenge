using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interfaces
{
    interface IIdioma
    {
        string ListaVacia { get; }
        string TituloReporte { get; }
        string Formas { get; }
        string Perimetro { get; }
        string Area { get; }
        string Total { get; }

        string ObtenerLinea(int tipo, int cantidad, decimal area, decimal perimetro);

        //string TraducirForma(int tipo, int cantidad);
    }
}
