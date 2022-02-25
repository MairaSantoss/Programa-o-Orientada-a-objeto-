using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CamadaNegocio; //ligacao com camada de negocio

namespace CamadaApresentacao
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nome endereco cidade
            NCliente.Inserir(textBox2.Text, textBox3.Text, textBox4.Text);
            limparDados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NCliente.Editar(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);
            limparDados();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = NCliente.Mostrar();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void limparDados()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja mesmo apagar?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NCliente.Excluir(Convert.ToInt32(textBox1.Text));
                limparDados();
            }
  

        }


    }
}
