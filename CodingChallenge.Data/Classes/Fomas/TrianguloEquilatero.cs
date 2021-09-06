using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Fomas
{
    class TrianguloEquilatero : IForma
    {
        private readonly decimal _lado;
        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }
        public decimal Area()
        {
            return Convert.ToDecimal(Math.Sqrt(3)) * _lado * _lado / 4;
        }

        public decimal Perimetro()
        {
            return _lado * 3;
        }

        public int Tipo
        {
            get
            {
                return FormaGeometrica.TrianguloEquilatero;
            }
        }
    }
}
