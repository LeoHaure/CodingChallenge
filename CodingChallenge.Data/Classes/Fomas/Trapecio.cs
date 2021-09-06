using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Fomas
{
    class Trapecio : IForma
    {
        private readonly decimal _ladoA;
        private readonly decimal _ladoB;
        private readonly decimal _ladoC;
        private readonly decimal _ladoD;
        private readonly decimal _alto;

        public Trapecio(decimal ladoA, decimal ladoB, decimal ladoC, decimal ladoD, decimal alto)
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
            _ladoD = ladoD;
            _alto = alto;
        }
        public decimal Area()
        {
            return _ladoA * _ladoB * _alto / 2;
        }

        public decimal Perimetro()
        {
            return _ladoA + _ladoB + _ladoC + _ladoD;
        }

        public int Tipo
        {
            get
            {
                return FormaGeometrica.Trapecio;
            }
        }
    }
}
