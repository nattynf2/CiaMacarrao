using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class PedidoCadastrar : Form
    {
        public PedidoCadastrar()
        {
            InitializeComponent();

            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtNome.Text = CiaMacarrao.Usuarios.nm_usuario;
            txtCpf.Text = CiaMacarrao.Usuarios.cpf_usuario;
        }

        SqlConnection conPedido = Conexao.getConnection();


        float valorTotal = 0;
        float precoMassa = 0;
        float precoMolho = 0;
        float precoAdd = 0;
        float precoBebida = 0;


        private void PedidoCadastrar_Load(object sender, EventArgs e)
        {
            txtCpf.Focus();
            
            try
            {
                conPedido.Open();

                // **** BUSCA AS MASSAS****
                // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                SqlCommand cmdMassa = new SqlCommand("SELECT nm_massa FROM Massas ORDER BY nm_massa DESC", conPedido);

                //RETORNA DADOS DO SQL
                SqlDataReader readerMassa = cmdMassa.ExecuteReader();

                // CARREGA OS DADOS EM UMA TABELA
                DataTable tabelaMassa = new DataTable();
                tabelaMassa.Load(readerMassa);
                DataRow rowMassa = tabelaMassa.NewRow(); // PARA NÃO TRAZER DADOS NULOS
                rowMassa["nm_massa"] = "";
                tabelaMassa.Rows.InsertAt(rowMassa, 0);

                //PASSANDO DADOS PARA O CAMPO
                this.cbMassas.DataSource = tabelaMassa;
                this.cbMassas.ValueMember = "nm_massa";
                this.cbMassas.DisplayMember = "nm_massa";

                //CHAMA O METODO PARA CARREGAR O VALOR DO ITEM SELECIONADO
                this.cbMassas.SelectedIndexChanged += new System.EventHandler(cbMassas_SelectedIndexChanged);

                //************************************************************************************************
                // **** BUSCA OS MOLHOS****
                // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                SqlCommand cmdMolho = new SqlCommand("SELECT nm_molho FROM Molhos ORDER BY nm_molho DESC", conPedido);

                //RETORNA DADOS DO SQL
                SqlDataReader readerMolho = cmdMolho.ExecuteReader();

                // CARREGA OS DADOS EM UMA TABELA
                DataTable tabelaMolho = new DataTable();
                tabelaMolho.Load(readerMolho);
                DataRow rowMolho = tabelaMolho.NewRow(); // PARA NÃO TRAZER DADOS NULOS
                rowMolho["nm_molho"] = "";
                tabelaMolho.Rows.InsertAt(rowMolho, 0);

                this.cbMolhos.DataSource = tabelaMolho;
                this.cbMolhos.ValueMember = "nm_molho";
                this.cbMolhos.DisplayMember = "nm_molho";

                //CHAMA O METODO PARA CARREGAR O VALOR DO ITEM SELECIONADO
                this.cbMolhos.SelectedIndexChanged += new System.EventHandler(cbMolhos_SelectedIndexChanged);

                //************************************************************************************************
                // **** BUSCA OS ADICIONAIS****
                // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                SqlCommand cmdAdd = new SqlCommand("SELECT nm_adicional FROM Adicionais ORDER BY nm_adicional DESC", conPedido);

                //RETORNA DADOS DO SQL
                SqlDataReader readerAdd = cmdAdd.ExecuteReader();

                // CARREGA OS DADOS EM UMA TABELA
                DataTable tabelaAdd = new DataTable();
                tabelaAdd.Load(readerAdd);
                DataRow rowAdd = tabelaAdd.NewRow(); // PARA NÃO TRAZER DADOS NULOS
                rowAdd["nm_adicional"] = "";
                tabelaAdd.Rows.InsertAt(rowAdd, 0);

                this.cbAdd.DataSource = tabelaAdd;
                this.cbAdd.ValueMember = "nm_adicional";
                this.cbAdd.DisplayMember = "nm_adicional";

                //CHAMA O METODO PARA CARREGAR O VALOR DO ITEM SELECIONADO
                this.cbAdd.SelectedIndexChanged += new System.EventHandler(cbAdd_SelectedIndexChanged);

                //************************************************************************************************
                // **** BUSCA AS BEBIDAS****
                // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                SqlCommand cmdBebidas = new SqlCommand("SELECT nm_bebida FROM Bebidas ORDER BY nm_bebida DESC", conPedido);

                //RETORNA DADOS DO SQL
                SqlDataReader readerBebidas = cmdBebidas.ExecuteReader();

                // CARREGA OS DADOS EM UMA TABELA
                DataTable tabelaBebidas = new DataTable();
                tabelaBebidas.Load(readerBebidas);
                DataRow rowBebidas = tabelaBebidas.NewRow(); // PARA NÃO TRAZER DADOS NULOS
                rowBebidas["nm_bebida"] = "";
                tabelaBebidas.Rows.InsertAt(rowBebidas, 0);

                this.cbBebida.DataSource = tabelaBebidas;
                this.cbBebida.ValueMember = "nm_bebida";
                this.cbBebida.DisplayMember = "nm_bebida";

                //CHAMA O METODO PARA CARREGAR O VALOR DO ITEM SELECIONADO
                this.cbBebida.SelectedIndexChanged += new System.EventHandler(cbBebida_SelectedIndexChanged);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // para retornar o erro que deu ao tentar armazenar os dados.
            }

            finally
            {
                conPedido.Close();
            }

        }
        
        private void cbMassas_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (!ActiveControl.Name.Equals("btnFinalizar"))
                {
                    conPedido.Open();

                    // **** BUSCA VALOR DO ITEM ESCOLIDO****
                    // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                    string index;

                    index = cbMassas.SelectedValue.ToString();

                    SqlCommand cmdPrMas = new SqlCommand("SELECT vl_preco FROM Massas WHERE nm_massa = '" + index + "'", conPedido);
                    //RETORNA DADOS DO SQL
                    SqlDataReader readerPrMas = cmdPrMas.ExecuteReader();
                    // CARREGA OS DADOS EM UMA TABELA
                    readerPrMas.Read();
                    precoMassa = Convert.ToSingle(readerPrMas["vl_preco"]);
                    txtValorMassas.Text = Convert.ToString("R$" + precoMassa);

                    valorTotal += precoMassa;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // para retornar o erro que deu ao tentar armazenar os dados.
            }

            finally
            {
                conPedido.Close();
            }
        }

        private void cbMolhos_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (!ActiveControl.Name.Equals("btnFinalizar"))
                {
                    conPedido.Open();

                    // **** BUSCA VALOR DO ITEM ESCOLIDO****
                    // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                    string index;

                    index = cbMolhos.SelectedValue.ToString();

                    SqlCommand cmdPrMol = new SqlCommand("SELECT vl_preco FROM Molhos WHERE nm_molho = '" + index + "'", conPedido);
                    //RETORNA DADOS DO SQL
                    SqlDataReader readerPrMol = cmdPrMol.ExecuteReader();
                    // CARREGA OS DADOS EM UMA TABELA
                    readerPrMol.Read();
                    precoMolho = Convert.ToSingle(readerPrMol["vl_preco"]);
                    txtValorMolhos.Text = Convert.ToString("R$" + precoMolho);

                    valorTotal += precoMolho;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // para retornar o erro que deu ao tentar armazenar os dados.
            }

            finally
            {
                conPedido.Close();
            }
        }

        private void cbAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            
            {
                if (!ActiveControl.Name.Equals("btnFinalizar"))
                {
                    conPedido.Open();

                    // **** BUSCA VALOR DO ITEM ESCOLIDO****
                    // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                    string index;

                    index = cbAdd.SelectedValue.ToString();

                    SqlCommand cmdPrAdd = new SqlCommand("SELECT vl_preco FROM Adicionais WHERE nm_adicional = '" + index + "'", conPedido);
                    //RETORNA DADOS DO SQL
                    SqlDataReader readerPrAdd = cmdPrAdd.ExecuteReader();
                    // CARREGA OS DADOS EM UMA TABELA
                    readerPrAdd.Read();
                    precoAdd = Convert.ToSingle(readerPrAdd["vl_preco"]);
                    txtValorAdd.Text = Convert.ToString("R$" + precoAdd);

                    valorTotal = precoAdd;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // para retornar o erro que deu ao tentar armazenar os dados.
            }

            finally
            {
                conPedido.Close();
            }
        }

        private void cbBebida_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (! ActiveControl.Name.Equals("btnFinalizar"))
                {
                    conPedido.Open();

                    // **** BUSCA VALOR DO ITEM ESCOLIDO****
                    // INSTANCIO UM NOVO CAMANDO PARA SER EXECUTADO NO BANCO
                    string index;

                    index = cbBebida.SelectedValue.ToString();

                    SqlCommand cmdPrBebida = new SqlCommand("SELECT vl_preco FROM Bebidas WHERE nm_bebida = '" + index + "'", conPedido);
                    //RETORNA DADOS DO SQL
                    SqlDataReader readerPrBebida = cmdPrBebida.ExecuteReader();
                    // CARREGA OS DADOS EM UMA TABELA
                    readerPrBebida.Read();
                    precoBebida = Convert.ToSingle(readerPrBebida["vl_preco"]);
                    txtValorBebida.Text = Convert.ToString("R$" + precoBebida);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // para retornar o erro que deu ao tentar armazenar os dados.
            }

            finally
            {
                conPedido.Close();
            }
        }

        public void qtdComida_ValueChanged(object sender, EventArgs e)
        {
            if(qtdBebida.Value != 0 || qtdComida.Value !=0)
            {
                valorTotal = (precoMassa + precoMolho + precoAdd);
                valorTotal = (valorTotal * Convert.ToSingle(qtdComida.Value));
                valorTotal = valorTotal + (precoBebida * Convert.ToSingle(qtdBebida.Value));
                txtValorTotal.Text = Convert.ToString("R$ " + valorTotal);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            string nm_usuario;
            int id_pedido;

            if (txtValorTotal.Text =="")
            {
                MessageBox.Show("É obrigatório selecionar algum item! ", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            nm_usuario = CiaMacarrao.Usuarios.nm_usuario;

            SqlCommand comando = new SqlCommand("insert into Pedidos (nm_massa, nm_molho, nm_adicional, qtd_comida, nm_bebida, qtd_bebida, valor_total, dt_pedido, nm_usuario) VALUES (@Massa, @Molho, @Adicional, @QtdComida, @Bebida, @QtdBebida, @ValorTotal, GETDATE(), @usuario) SELECT SCOPE_IDENTITY() Pedidos", conPedido);
            comando.Parameters.Add("@Massa", SqlDbType.VarChar).Value = cbMassas.Text;
            comando.Parameters.Add("@Molho", SqlDbType.VarChar).Value = cbMolhos.Text;
            comando.Parameters.Add("@Adicional", SqlDbType.VarChar).Value = cbAdd.Text;
            comando.Parameters.Add("@QtdComida", SqlDbType.Int).Value = int.Parse(qtdComida.Text);
            comando.Parameters.Add("@Bebida", SqlDbType.VarChar).Value = cbBebida.Text;
            comando.Parameters.Add("@QtdBebida", SqlDbType.Int).Value = int.Parse(qtdBebida.Text);
            comando.Parameters.Add("@ValorTotal", SqlDbType.Float).Value = valorTotal;
            comando.Parameters.Add("@usuario", SqlDbType.VarChar).Value = nm_usuario;

            try
            {
                conPedido.Open();                
                id_pedido = Convert.ToInt32(comando.ExecuteScalar());
                MessageBox.Show("Pedido feito com sucesso!\nSeu número de Pedido é : " + id_pedido, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception)
            {
                MessageBox.Show("Erro ao Finalizar pedido, Favor entrar em contato com a Cia do Macarrão!", "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            finally
            {
                conPedido.Close();

            }

            limparCampos();
            
        }

        public void limparCampos()
        {
            txtValorAdd.Clear();
            txtValorBebida.Clear();
            txtValorMassas.Clear();
            txtValorMolhos.Clear();
            cbAdd.DataSource = null;
            cbBebida.DataSource = null;
            cbMassas.DataSource = null;
            cbMolhos.DataSource = null;
            qtdBebida.Value = 0;
            qtdComida.Value = 0;
            txtValorTotal.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        
    }

}
