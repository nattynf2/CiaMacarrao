using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class IngredienteConsultar : Form
    {
        private DataSet mDataSet;
        private SqlDataAdapter mAdapter;

        SqlConnection conAdicinal = Conexao.getConnection();

        public IngredienteConsultar()
        {
            InitializeComponent();

            mDataSet = new DataSet();

            try
            {
                conAdicinal.Open();
                mAdapter = new SqlDataAdapter("SELECT * FROM Adicionais", conAdicinal);
                mAdapter.Fill(mDataSet, "Adicionais");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Adicionais";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conAdicinal.Close();
            }

        }     
       

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mDataSet = new DataSet();
            string nm_adicional;

            nm_adicional = txtAdicional.Text;


            if (!txtAdicional.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Adicionais WHERE nm_adicional like '%" + nm_adicional + "%'", conAdicinal);
            }

            try
            {
                conAdicinal.Open();
                mAdapter.Fill(mDataSet, "Adicionais");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Adicionais";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar Adicional, favor entrar em contato com a Cia do Macarrão!" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conAdicinal.Close();
            }

            txtAdicional.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
