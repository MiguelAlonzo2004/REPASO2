using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPASO2
{
    class Vehiculo
    {
        string placa;
        string marca;
        int modelo;
        string color;
        int preciokm;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public int Preciokm { get => preciokm; set => preciokm = value; }
        public string Color { get => color; set => color = value; }
    }
}
