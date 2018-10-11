using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        
        }

        SqlConnection connLogin = Conexao.getConnection();

        public void btnEntrar_Click(object sender, EventArgs e)
        {
            string validarDados;

            validarDados = validarCampos();
            CiaMacarrao.Usuarios.nm_login = txtNome.Text;

            if (string.IsNullOrEmpty(validarDados))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuarios WHERE nm_login = @login and nm_senha = @senha ", connLogin);
                comando.Parameters.Add("@login", SqlDbType.VarChar).Value = txtNome.Text;
                comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtSenha.Text;

                try
                {
                    connLogin.Open();
                    SqlDataReader dr = comando.ExecuteReader();

                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("Favor verificar campos informados com atenção!", "CiaMacarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dr.Read();

                    CiaMacarrao.Usuarios.nm_usuario = Convert.ToString(dr["nm_usuario"]);
                    CiaMacarrao.Usuarios.cpf_usuario = Convert.ToString(dr["nr_cpf"]);
                    CiaMacarrao.Usuarios.id_usuario = Convert.ToString(dr["id_usuario"]);

                    this.Hide();
                    Menu m = new Menu();
                    Login l = new Login();


                    if (txtNome.Text == "admin")
                    {
                        m.cadastroToolStripMenuItem.Visible = true;
                        m.usuarioToolStripMenuItem.Visible = true;
                    }
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    connLogin.Close();
                }
            }

            else
            {
                MessageBox.Show(validarDados, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
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
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                return "É necessário informar o Usuário";
            }

            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                return "É necessário informar a Senha";
            }

            else
            {
                return "";
            }
        }
    }

}
