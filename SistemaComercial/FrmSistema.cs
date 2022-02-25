using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaApresentacao;

namespace SistemaComercial
{
    public partial class FrmSistema : Form
    {
        public FrmSistema()
        {
            InitializeComponent();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //quando clica na interface, leva pra outra tela, acima tem o suing da cama de apresentacao

            FrmProdutos formp = new FrmProdutos();
            formp.Show();

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente formp = new FrmCliente();
            formp.Show();

        }

    }
}
