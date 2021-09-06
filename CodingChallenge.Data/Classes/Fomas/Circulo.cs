using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Fomas
{
    class Circulo : IForma
    {
        private readonly decimal _lado;

        public Circulo(decimal lado)
        {
            _lado = lado;
        }
        public decimal Area()
        {
            return Convert.ToDecimal(Math.PI) * (_lado / 2) * (_lado / 2); 
        }

        public decimal Perimetro()
        {
            return Convert.ToDecimal(Math.PI) * _lado;
        }

        public int Tipo
        {
            get
            {
                return FormaGeometrica.Circulo;
            }
        }
    }
}
