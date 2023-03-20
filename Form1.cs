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
    public partial class Form1 : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquileres> alquiler = new List<Alquileres>();
        List<Reportecs> reportes = new List<Reportecs>();
        public Form1()
        {
            InitializeComponent();
        }
        void Leer()
        {
            FileStream stream = new FileStream("archivo1.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Cliente cliente= new Cliente();
                cliente.Nombre = reader.ReadLine();
                cliente.Nit = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();
                clientes.Add(cliente);
            }
            reader.Close();
        }
        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }
        void Leer3()
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


        private void Mostrar3()
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = alquiler;
            dataGridView3.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Leer();
            Mostrar();

            Leer2();
            Mostrar2();
        }
        private void Leer2()
        {

            FileStream stream = new FileStream("archivo2.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa = textBoxPlaca.Text;
                vehiculo.Marca = textBoxMarca.Text;
                vehiculo.Modelo = int.Parse(textBoxModelo.Text);
                vehiculo.Color = textBoxColor.Text;
                vehiculo.Preciokm = int.Parse(textBoxPrecio.Text);
                vehiculos.Add(vehiculo);
            }
            reader.Close();
        }
        private void Mostrar2()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = alquiler;
            dataGridView2.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo vRepetido = vehiculos.Find(a => a.Placa == textBoxPlaca.Text);
            if (vRepetido.Placa == null)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa = textBoxPlaca.Text;
                vehiculo.Marca = textBoxMarca.Text;
                vehiculo.Modelo = int.Parse(textBoxModelo.Text);
                vehiculo.Color = textBoxColor.Text;
                vehiculo.Preciokm = int.Parse(textBoxPrecio.Text);
                vehiculos.Add(vehiculo);
                Guardar();
            }
            else
            {
                MessageBox.Show(vRepetido.Placa + "El vehiculo ya fue ingresado");
            }
        }
        private void Guardar()
        {
            if (File.Exists("archivo2.txt"))
            {
                FileStream stream = new FileStream("archivo2.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);

                foreach (var vehiculo in vehiculos)
                {
                    writer.WriteLine(vehiculo.Placa);
                    writer.WriteLine(vehiculo.Marca);
                    writer.WriteLine(vehiculo.Modelo);
                    writer.WriteLine(vehiculo.Color);
                    writer.WriteLine(vehiculo.Preciokm);
                }
                writer.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reportecs reporte = new Reportecs();
            int mayor = alquiler.Max(al =>al.Km);
            string variable = mayor.ToString();
            labelKM.Text = variable;

            for (int i = 0; i < alquiler.Count; i++)
            {
                for (int j = 0; j < clientes.Count; j++)
                {
                    if(alquiler[i].Nit == clientes[j].Nit)
                    {
                        reporte.Nombre = clientes[j].Nombre;
                    }
                }
                for (int k = 0; k < vehiculos.Count; k++)
                {
                    if (alquiler[i].Placa == vehiculos[k].Placa)
                    {
                        reporte.Placa = vehiculos[k].Placa;
                        reporte.Marca = vehiculos[k].Marca;
                        reporte.FechaDevolucion = alquiler[i].FechaDevolucion;
                        reporte.Total = alquiler[i].Km * vehiculos[k].Preciokm;

                    }
                }
            }
            reportes.Add(reporte);
            Mostrar3();
        }
    }
}
