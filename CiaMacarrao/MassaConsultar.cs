using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CiaMacarrao
{
    public partial class MassaConsultar : Form
    {
        private Label label1;
        private TextBox txtMassa;
        private Button btnConsultar;
        private Button btnSair;
        private DataGridView dataGridView1;
        private DataSet mDataSet;
        private SqlDataAdapter mAdapter;

        SqlConnection conMassa = Conexao.getConnection();

        public MassaConsultar()
        {
            InitializeComponent();

            mDataSet = new DataSet();

            try
            {
                conMassa.Open();
                mAdapter = new SqlDataAdapter("SELECT * FROM Massas", conMassa);
                mAdapter.Fill(mDataSet, "Massas");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Massas";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados, favor entrar em contato com a Cia do Macarrão!\n" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conMassa.Close();
            }

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMassa = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Massa:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(623, 324);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtMassa
            // 
            this.txtMassa.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtMassa.Location = new System.Drawing.Point(85, 44);
            this.txtMassa.Name = "txtMassa";
            this.txtMassa.Size = new System.Drawing.Size(566, 26);
            this.txtMassa.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(202)))));
            this.btnConsultar.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(172, 456);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(144, 49);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(202)))));
            this.btnSair.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(355, 456);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(144, 49);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // MassaConsultar
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(688, 517);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtMassa);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "MassaConsultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Massas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mDataSet = new DataSet();
            string nm_massa;

            nm_massa = txtMassa.Text;


            if (!txtMassa.Text.Equals(""))
            {
                mAdapter = new SqlDataAdapter("SELECT * FROM Massas WHERE nm_massa like '%" + nm_massa + "%'", conMassa);
            }

            try
            {
                conMassa.Open();
                mAdapter.Fill(mDataSet, "Massas");
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "Massas";
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar Massa, favor entrar em contato com a Cia do Macarrão!" + ex, "Cia do Macarrão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conMassa.Close();
            }

            txtMassa.Clear();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
