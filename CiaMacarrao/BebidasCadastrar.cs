using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class BebidasCadastrar : Form
    {
        public BebidasCadastrar()
        {
            InitializeComponent();
        }
        
        private void btnSalvarBebida_Click(object sender, EventArgs e)
        {
            string sqlQuery, validaDados;

            validaDados = validarCampos();

            if (string.IsNullOrEmpty(validaDados))
            { 
                SqlConnection conBebida = Conexao.getConnection();

                sqlQuery = "insert into Bebidas (nm_bebida,vl_preco,qt_bebida) values(@Nome,@Preco,@Quantidade)";

                SqlCommand comando = new SqlCommand(sqlQuery, conBebida);

                comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtBebida.Text;
                comando.Parameters.Add("@Preco", SqlDbType.Float).Value = float.Parse(txtPrecoBebida.Text);
                comando.Parameters.Add("@Quantidade", SqlDbType.Int).Value = int.Parse(txtQuantidade.Text);

                try
                {
                    conBebida.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Bebida cadastrada com Sucesso!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar Bebida, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    conBebida.Close();
                }
            }

            else
            {
                MessageBox.Show(validaDados, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limparCampos();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MudarNoEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        public string validarCampos()
        {

            if (string.IsNullOrEmpty(txtBebida.Text))
            {
                return "Favor informar o nome da Bebida!";                 
            }

            else if (string.IsNullOrEmpty(txtPrecoBebida.Text))
            {
                return "Favor informar o preço da Bebida!";                
            }

            else if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                return "Favor informar a quantidade de Bebidas!";
            }

            else
            {
                return "";
            }
        }

        public void limparCampos()
        {

            txtPrecoBebida.Clear();
            txtBebida.Clear();
            txtQuantidade.Clear();
        }

    }
}
