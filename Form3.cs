using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPASO2
{
    public partial class Form3 : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquileres> alquiler = new List<Alquileres>();
        List<Reportecs> reportes = new List<Reportecs>();
        public Form3()
        {
            InitializeComponent();
        }
        void Leer2()
        {
            FileStream stream = new FileStream("archivo3.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alquileres alquileres = new Alquileres();
                alquileres.Placa = reader.ReadLine();
                alquileres.Nit = reader.ReadLine();
                alquileres.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                alquileres.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                alquileres.Km = Convert.ToInt32(reader.ReadLine());
                alquiler.Add(alquileres);
            }
            reader.Close();
        }
        private void Mostrar2()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alquiler;
            dataGridView1.Refresh();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Leer();
            Mostrar();
        }
    }
}
