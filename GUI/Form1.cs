using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        Arbol abb = new Arbol();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona p= new Persona();
            p.dni = int.Parse(txtDNI.Text);
            p.nombre = txtNombre.Text;

            abb.Insertar(p);

            txtDNI.Clear();
            txtNombre.Clear();

            abb.Listar(ref lbPersonas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Persona p = abb.Buscar(int.Parse(txtDNI_busq.Text));

            if (p != null)
            {
                MessageBox.Show("Persona encontrada: "+p);
            } else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Persona p = abb.BuscarMenor();
            MessageBox.Show("Menor: "+p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mayor: "+abb.BuscarMayor());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool r = abb.Eliminar(int.Parse(txtDNI_Eliminar.Text));

            if (r==true)
            {
                MessageBox.Show("Persona Eliminada: ");
                abb.Listar(ref lbPersonas);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }
    }
}
