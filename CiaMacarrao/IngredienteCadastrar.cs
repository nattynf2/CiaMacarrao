using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class AdicionaisCadastrar : Form
    {
        public AdicionaisCadastrar()
        {
            InitializeComponent();
        }

        SqlConnection conAdicional = Conexao.getConnection();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string sqlQuery, validarDados;

            validarDados = validarCampos();

            if (string.IsNullOrEmpty(validarDados))
            {

                sqlQuery = "insert into Adicionais (nm_adicional,vl_preco,qt_adicional) values(@Nome,@Preco,@Quantidade)";

                SqlCommand comando = new SqlCommand(sqlQuery, conAdicional);

                comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtAdicional.Text;
                comando.Parameters.Add("@Preco", SqlDbType.Float).Value = float.Parse(txtPrecoAdicional.Text);
                comando.Parameters.Add("@Quantidade", SqlDbType.Int).Value = int.Parse(txtQuantidade.Text);

                try
                {
                    conAdicional.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Adicional cadastrado com Sucesso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar Adicional, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    conAdicional.Close();
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

            if (string.IsNullOrEmpty(txtAdicional.Text))
            {
                return "Favor informar o nome do Adicional!";
            }

            else if (string.IsNullOrEmpty(txtPrecoAdicional.Text))
            {
                return "Favor informar o preço do Adicional!";
            }

            else if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                return "Favor informar a quantidade do Adicional!";
            }

            else
            {
                return "";
            }
        }

        public void limparCampos()
        {
            txtPrecoAdicional.Clear();
            txtAdicional.Clear();
            txtQuantidade.Clear();
        }
    }
}
