using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class UsuarioConsultar : Form
    {

        private DataSet mDataSet;
        private SqlDataAdapter mAdapter;

        SqlConnection conUsuario = Conexao.getConnection();

        public UsuarioConsultar()
        {
            InitializeComponent();            

            mDataSet = new DataSet();

            try
            {
                conUsuario.Open();
                mAdapter = new SqlDataAdapter("SELECT * FROM Usuarios", conUsuario);
                mAdapter.Fill(mDataSet, "Usuarios");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Usuarios";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conUsuario.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCpf.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtEndereco.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtNumero.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            txtId.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            txtCpf.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtTel.Enabled = true;

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            mDataSet = new DataSet();
            string letra;

            letra = txtNome.Text;


            if (!txtNome.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Usuarios WHERE nm_usuario like '%" + letra + "%'", conUsuario);
            }
            else if (txtNome.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Usuarios", conUsuario);

                txtCpf.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();
                txtId.Clear();
                txtNumero.Clear();
                txtTel.Clear();
                txtId.Enabled = true;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;

            }

            try
            {
                conUsuario.Open();
                mAdapter.Fill(mDataSet, "Usuarios");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Usuarios";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar Usuário, favor entrar em contato com a Cia do Macarrão!" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conUsuario.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string sqlQuery;
            txtCpf.Mask = "";

            sqlQuery = "UPDATE Usuarios SET nm_usuario = @nm_usuario, nr_cpf = @cpf, nm_email = @nm_email, nm_endereco = @endereco, nr_endereco = @nr, nr_tel = @tel WHERE id_usuario = @id";
            
            SqlCommand comando = new SqlCommand(sqlQuery, conUsuario);

            comando.Parameters.Add("@id", SqlDbType.VarChar).Value = txtId.Text;
            comando.Parameters.Add("@nm_usuario", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@cpf", SqlDbType.VarChar).Value = txtCpf.Text;
            comando.Parameters.Add("@nm_email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@nr", SqlDbType.Int).Value = Convert.ToInt32(txtNumero.Text);
            comando.Parameters.Add("@tel", SqlDbType.VarChar).Value = txtTel.Text;
            try
            {
                conUsuario.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Alterado com sucesso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                 MessageBox.Show("Erro ao alterar o usuario, favor entrar em contato com o Provedor!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conUsuario.Close();
            }

            txtTel.Clear();
            txtNumero.Clear();
            txtNome.Clear();
            txtId.Clear();
            txtEndereco.Clear();
            txtEmail.Clear();
            txtCpf.Clear();
            txtCpf.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtTel.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sqlQuery;

            if (txtId.Text == "1")
            {
                MessageBox.Show("Você não tem permissão para isso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                sqlQuery = "DELETE FROM Usuarios where id_usuario = @id";

                SqlCommand comando = new SqlCommand(sqlQuery, conUsuario);
                comando.Parameters.Add("@id", SqlDbType.VarChar).Value = txtId.Text;

                try
                {
                    conUsuario.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Usuario Excluido com sucesso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir o usuario, favor entrar em contato com o Provedor!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    conUsuario.Close();
                }

                txtTel.Clear();
                txtNumero.Clear();
                txtNome.Clear();
                txtId.Clear();
                txtEndereco.Clear();
                txtEmail.Clear();
                txtCpf.Clear();
                txtCpf.Enabled = false;
                txtEmail.Enabled = false;
                txtEndereco.Enabled = false;
                txtNumero.Enabled = false;
                txtTel.Enabled = false;
            }
        }
    }
}
