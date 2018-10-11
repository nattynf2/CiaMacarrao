namespace CiaMacarrao
{
    partial class BebidasCadastrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecoBebida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvarBebida = new System.Windows.Forms.Button();
            this.txtBebida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 132);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(202)))));
            this.btnSair.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(243, 355);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(96, 35);
            this.btnSair.TabIndex = 18;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtQuantidade.Location = new System.Drawing.Point(172, 270);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(67, 26);
            this.txtQuantidade.TabIndex = 17;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MudarNoEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label3.Location = new System.Drawing.Point(77, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Quantidade:";
            // 
            // txtPrecoBebida
            // 
            this.txtPrecoBebida.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtPrecoBebida.Location = new System.Drawing.Point(172, 223);
            this.txtPrecoBebida.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecoBebida.Name = "txtPrecoBebida";
            this.txtPrecoBebida.Size = new System.Drawing.Size(67, 26);
            this.txtPrecoBebida.TabIndex = 15;
            this.txtPrecoBebida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MudarNoEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label2.Location = new System.Drawing.Point(116, 221);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Preço:";
            // 
            // btnSalvarBebida
            // 
            this.btnSalvarBebida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(202)))));
            this.btnSalvarBebida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvarBebida.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.btnSalvarBebida.ForeColor = System.Drawing.Color.White;
            this.btnSalvarBebida.Location = new System.Drawing.Point(60, 355);
            this.btnSalvarBebida.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalvarBebida.Name = "btnSalvarBebida";
            this.btnSalvarBebida.Size = new System.Drawing.Size(96, 35);
            this.btnSalvarBebida.TabIndex = 13;
            this.btnSalvarBebida.Text = "Salvar";
            this.btnSalvarBebida.UseVisualStyleBackColor = false;
            this.btnSalvarBebida.Click += new System.EventHandler(this.btnSalvarBebida_Click);
            // 
            // txtBebida
            // 
            this.txtBebida.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtBebida.Location = new System.Drawing.Point(172, 177);
            this.txtBebida.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBebida.Name = "txtBebida";
            this.txtBebida.Size = new System.Drawing.Size(161, 26);
            this.txtBebida.TabIndex = 12;
            this.txtBebida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MudarNoEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label1.Location = new System.Drawing.Point(110, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Bebida:";
            // 
            // BebidasCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 401);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecoBebida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvarBebida);
            this.Controls.Add(this.txtBebida);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BebidasCadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecoBebida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvarBebida;
        private System.Windows.Forms.TextBox txtBebida;
        private System.Windows.Forms.Label label1;
    }
}