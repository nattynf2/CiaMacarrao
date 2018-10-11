using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class MolhoConsultar : Form
    {
        private DataSet mDataSet;
        private SqlDataAdapter mAdapter;

        SqlConnection conMolho = Conexao.getConnection();

        public MolhoConsultar()
        {
            InitializeComponent();

            mDataSet = new DataSet();

            try
            {
                conMolho.Open();
                mAdapter = new SqlDataAdapter("SELECT * FROM Molhos", conMolho);
                mAdapter.Fill(mDataSet, "Molhos");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Molhos";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conMolho.Close();
            }

        }
        

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mDataSet = new DataSet();
            string nm_molho;

            nm_molho = txtMolho.Text;


            if (!txtMolho.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Molhos WHERE nm_molho like '%" + nm_molho + "%'", conMolho);
            }

            try
            {
                conMolho.Open();
                mAdapter.Fill(mDataSet, "Molhos");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Molhos";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar Molho, favor entrar em contato com a Cia do Macarrão!" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conMolho.Close();
            }

            txtMolho.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
