using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class PedidoConsultar : Form
    {
        private DataGridView dataGridView1;
        private Button btnPesquisar;
        private Button btnFechar;
        private TextBox txtNumPed;
        private Label label1;
        private DataSet mDataSet;
        private SqlDataAdapter mAdapter;

        SqlConnection conPedido = Conexao.getConnection();

        public PedidoConsultar()
        {
            InitializeComponent();

            mDataSet = new DataSet();
            string nm_usuario, nm_login;

            nm_usuario = CiaMacarrao.Usuarios.nm_usuario;
            nm_login = CiaMacarrao.Usuarios.nm_login;

            if (nm_login == "admin")
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Pedidos", conPedido);
            }
            else
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Pedidos WHERE nm_usuario = '" + nm_usuario + "'", conPedido);
            }

            try
            {
                conPedido.Open();                
                mAdapter.Fill(mDataSet, "Pedidos");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Pedidos";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conPedido.Close();
            }

        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtNumPed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1075, 363);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(202)))));
            this.btnPesquisar.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(340, 454);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(142, 54);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(202)))));
            this.btnFechar.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(580, 454);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(142, 54);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtNumPed
            // 
            this.txtNumPed.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtNumPed.Location = new System.Drawing.Point(178, 38);
            this.txtNumPed.Name = "txtNumPed";
            this.txtNumPed.Size = new System.Drawing.Size(100, 26);
            this.txtNumPed.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Número do Pedido: ";
            // 
            // PedidoConsultar
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumPed);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PedidoConsultar";
            this.Text = "Pedido Consultar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            mDataSet = new DataSet();
            string nm_usuario;
            int id_pedido;

            nm_usuario = CiaMacarrao.Usuarios.nm_usuario;


            if (txtNumPed.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Pedidos WHERE nm_usuario = '" + nm_usuario + "'", conPedido);
            }
            else if (!txtNumPed.Text.Equals(""))
            {
                id_pedido = Convert.ToInt32(txtNumPed.Text);
                mAdapter = new SqlDataAdapter("SELECT * FROM Pedidos WHERE nm_usuario = '" + nm_usuario + "' and id_pedido = " + id_pedido, conPedido);
            }

            try
            {
                conPedido.Open();               
                mAdapter.Fill(mDataSet, "Pedidos");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Pedidos";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar Pedido, favor entrar em contato com a Cia do Macarrão!" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conPedido.Close();
            }
        }
    }
}
