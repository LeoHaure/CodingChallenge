using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Fomas
{
    class Rectangulo : IForma
    {
        private readonly decimal _lado;
        private readonly decimal _alto;

        public Rectangulo(decimal lado, decimal alto)
        {
            _lado = lado;
            _alto = alto;
        }

        public decimal Area()
        {
            return _lado * _alto;
        }

        public decimal Perimetro()
        {
            return (2 * _lado) + (2 * _alto);
        }
        public int Tipo
        {
            get
            {
                return FormaGeometrica.Rectangulo;
            }
        }
    }
}
