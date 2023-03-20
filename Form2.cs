using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPASO2
{
    public partial class Form2 : Form
    {
        Vehiculo vehiculo = new Vehiculo();
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquileres> alquiler = new List<Alquileres>();
        List<Reportecs> reportes = new List<Reportecs>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo vRepetido = vehiculos.Find(a => a.Placa == textBoxPlaca.Text);
            if (vRepetido.Placa == null)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa = textBoxNombre.Text;
                vehiculo.Marca = textBoxApellido.Text;
                vehiculo.Modelo = textBoxDireccion.Text;
                vehiculo.Color = dateTimePickerNacimiento.Value;
                vehiculo.Preciokm = textBoxPrecio.Text;
                vehiculos.Add(persona);
            }
            else
            {
                MessageBox.Show(pRepetida.Nombre + "La persona ya existe");
            }
        }
    }
}
