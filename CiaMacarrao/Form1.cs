using System;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }
        
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioConsultar uc = new UsuarioConsultar();
            uc.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MassaCadastrar macadas = new MassaCadastrar();
            macadas.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MassaConsultar macons = new MassaConsultar();
            macons.ShowDialog();
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MolhoConsultar mocons = new MolhoConsultar();
            mocons.ShowDialog();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MolhoCadastrar mocadas = new MolhoCadastrar();
            mocadas.ShowDialog();
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AdicionaisCadastrar ingcadas = new AdicionaisCadastrar();
            ingcadas.ShowDialog();
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            IngredienteConsultar ingcons = new IngredienteConsultar();
            ingcons.ShowDialog();
        }

        private void cadastrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BebidasCadastrar bebiCadas = new BebidasCadastrar();
            bebiCadas.ShowDialog();
        }

        private void solicitarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PedidoCadastrar pc = new PedidoCadastrar();
            pc.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidoConsultar pcon = new PedidoConsultar();
            pcon.ShowDialog();
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            BebidasConsultar becon = new BebidasConsultar();
            becon.ShowDialog();
        }
    }
}
