using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class BebidasConsultar : Form
    {
        private DataSet mDataSet;
        private SqlDataAdapter mAdapter;

        SqlConnection conBebida = Conexao.getConnection();
        
        public BebidasConsultar()
        {
            InitializeComponent();
            
            mDataSet = new DataSet();

            try
            {
                conBebida.Open();
                mAdapter = new SqlDataAdapter("SELECT * FROM Bebidas", conBebida);
                mAdapter.Fill(mDataSet, "Bebidas");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Bebidas";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conBebida.Close();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mDataSet = new DataSet();
            string nm_bebida;

            nm_bebida = txtBebida.Text;


            if (!txtBebida.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Bebidas WHERE nm_bebida like '%" + nm_bebida + "%'", conBebida);
            }

            try
            {
                conBebida.Open();
                mAdapter.Fill(mDataSet, "Bebidas");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Bebidas";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar Bebida, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conBebida.Close();
            }

            txtBebida.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
