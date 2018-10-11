using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class MassaCadastrar : Form
    {
        public MassaCadastrar()
        {
            InitializeComponent();

        }

        SqlConnection conMassa = Conexao.getConnection();

        private void btnSalvarMassa_Click(object sender, EventArgs e)
        {
            string sqlQuery, validarDados;

            validarDados = validarCampos();

            if (string.IsNullOrEmpty(validarDados))
            {
                sqlQuery = "insert into Massas (nm_massa,vl_preco,qt_massa) values(@Nome,@Preco,@Quantidade)";

                SqlCommand comando = new SqlCommand(sqlQuery, conMassa);

                comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtTipoMassa.Text;
                comando.Parameters.Add("@Preco", SqlDbType.Float).Value = float.Parse(txtPrecoMassa.Text);
                comando.Parameters.Add("@Quantidade", SqlDbType.Int).Value = int.Parse(txtQuantidade.Text);

                try
                {
                    conMassa.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Massa cadastrado com Sucesso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar Adicional, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    conMassa.Close();
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

            if (string.IsNullOrEmpty(txtTipoMassa.Text))
            {
                return "Favor informar o nome da Massa!";
            }

            else if (string.IsNullOrEmpty(txtPrecoMassa.Text))
            {
                return "Favor informar o preço da Massa!";
            }

            else if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                return "Favor informar a quantidade da Massa!";
            }

            else
            {
                return "";
            }
        }

        public void limparCampos()
        {
            txtPrecoMassa.Clear();
            txtTipoMassa.Clear();
            txtQuantidade.Clear();
        }
    }
}
