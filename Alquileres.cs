using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPASO2
{
    class Alquileres
    {
        string nit;
        string placa;
        DateTime fechaAlquiler;
        DateTime fechaDevolucion;
        int km;

        public string Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public DateTime FechaAlquiler { get => fechaAlquiler; set => fechaAlquiler = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public int Km { get => km; set => km = value; }
    }
}
