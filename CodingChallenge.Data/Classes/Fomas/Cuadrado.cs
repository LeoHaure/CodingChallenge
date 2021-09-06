using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Fomas
{
    class Cuadrado : IForma
    {
        private readonly decimal _lado;
        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }
        public decimal Area()
        {
            return _lado * _lado;
        }

        public decimal Perimetro()
        {
            return _lado * 4;
        }

        public int Tipo
        {
            get
            {
                return FormaGeometrica.Cuadrado;
            }
        }
    }
}
