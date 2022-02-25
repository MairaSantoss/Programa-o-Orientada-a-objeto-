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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = Nproduto.Mostrar();
            label6.Visible = true;
            label6.Text = "Total de registros: " + Convert.ToString(dataGridView1.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nproduto.Inserir(textBox2.Text, Convert.ToDouble(textBox3.Text), Convert.ToInt32(textBox4.Text));
            limparDados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //converte o codigo tbm
            Nproduto.Editar(Convert.ToInt32(textBox1.Text),textBox2.Text, Convert.ToDouble(textBox3.Text), Convert.ToInt32(textBox4.Text));
            limparDados();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Você deseja mesmo apagar?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Nproduto.Excluir(Convert.ToInt32(textBox1.Text));
                limparDados();
            }
            
        }

        public void limparDados()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {

        }
    }
}
