using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class MolhoCadastrar : Form
    {
        public MolhoCadastrar()
        {
            InitializeComponent();
        }

        SqlConnection conMolho = Conexao.getConnection();

        private void btnSalvarMolho_Click(object sender, EventArgs e)
        {
            string sqlQuery, validarDados;

            validarDados = validarCampos();           

            if(string.IsNullOrEmpty(validarDados))
            {
                sqlQuery = "insert into Molhos (nm_molho,vl_preco,qt_molho) values(@Nome,@Preco,@Quantidade)";
                SqlCommand comando = new SqlCommand(sqlQuery, conMolho);
                comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtTipoMolho.Text;
                comando.Parameters.Add("@Preco", SqlDbType.Float).Value = float.Parse(txtPrecoMolho.Text);
                comando.Parameters.Add("@Quantidade", SqlDbType.Int).Value = int.Parse(txtQuantidade.Text);

                try
                {
                    conMolho.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Molho cadastrado com Sucesso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar Molho, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    conMolho.Close();
                }
            }

            else
            {
                MessageBox.Show(validarDados, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limparCampos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string validarCampos()
        {
            if (string.IsNullOrEmpty(txtTipoMolho.Text))
            {
                return "Favor informar o nome do Molho!";
            }

            else if (string.IsNullOrEmpty(txtPrecoMolho.Text))
            {
                return "Favor informar o preço do Molho!";
            }

            else if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                return "Favor informar a quantidade do Molho!";
            }

            else
            {
                return "";
            }
        }

        public void limparCampos()
        {
            txtPrecoMolho.Clear();
            txtTipoMolho.Clear();
            txtQuantidade.Clear();
        }
    }
}

