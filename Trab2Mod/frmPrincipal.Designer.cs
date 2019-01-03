namespace Trab2Mod
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnAcesso = new System.Windows.Forms.Button();
            this.btnLoja = new System.Windows.Forms.Button();
            this.btnSala = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTopo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlTopo.Controls.Add(this.btnAcesso);
            this.pnlTopo.Controls.Add(this.btnLoja);
            this.pnlTopo.Controls.Add(this.btnSala);
            this.pnlTopo.Controls.Add(this.btnRelatorio);
            this.pnlTopo.Controls.Add(this.btnUsuario);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1156, 98);
            this.pnlTopo.TabIndex = 0;
            // 
            // btnAcesso
            // 
            this.btnAcesso.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAcesso.FlatAppearance.BorderSize = 2;
            this.btnAcesso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcesso.Image = ((System.Drawing.Image)(resources.GetObject("btnAcesso.Image")));
            this.btnAcesso.Location = new System.Drawing.Point(482, 12);
            this.btnAcesso.Name = "btnAcesso";
            this.btnAcesso.Size = new System.Drawing.Size(80, 80);
            this.btnAcesso.TabIndex = 7;
            this.btnAcesso.UseVisualStyleBackColor = true;
            this.btnAcesso.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLoja
            // 
            this.btnLoja.Enabled = false;
            this.btnLoja.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLoja.FlatAppearance.BorderSize = 2;
            this.btnLoja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoja.Image = ((System.Drawing.Image)(resources.GetObject("btnLoja.Image")));
            this.btnLoja.Location = new System.Drawing.Point(131, 12);
            this.btnLoja.Name = "btnLoja";
            this.btnLoja.Size = new System.Drawing.Size(80, 80);
            this.btnLoja.TabIndex = 6;
            this.btnLoja.UseVisualStyleBackColor = true;
            this.btnLoja.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSala
            // 
            this.btnSala.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSala.FlatAppearance.BorderSize = 2;
            this.btnSala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSala.Image = ((System.Drawing.Image)(resources.GetObject("btnSala.Image")));
            this.btnSala.Location = new System.Drawing.Point(250, 12);
            this.btnSala.Name = "btnSala";
            this.btnSala.Size = new System.Drawing.Size(80, 80);
            this.btnSala.TabIndex = 5;
            this.btnSala.UseVisualStyleBackColor = true;
            this.btnSala.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRelatorio.FlatAppearance.BorderSize = 2;
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorio.Image")));
            this.btnRelatorio.Location = new System.Drawing.Point(369, 12);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(80, 80);
            this.btnRelatorio.TabIndex = 4;
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUsuario.FlatAppearance.BorderSize = 2;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuario.Image")));
            this.btnUsuario.Location = new System.Drawing.Point(12, 12);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(80, 80);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Controls.Add(this.lblHora);
            this.panel2.Controls.Add(this.lblData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 483);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 37);
            this.panel2.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(22, 15);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(41, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "usuario";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(1088, 15);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(28, 13);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "hora";
            this.lblHora.Click += new System.EventHandler(this.lblHora_Click);
            // 
            // lblData
            // 
            this.lblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(930, 15);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(28, 13);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "data";
            this.lblData.Click += new System.EventHandler(this.lblData_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1156, 385);
            this.panel3.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(497, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(629, 303);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 520);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTopo);
            this.MinimumSize = new System.Drawing.Size(1172, 558);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associados de Plantão";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.pnlTopo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblData;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLoja;
        private System.Windows.Forms.Button btnSala;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnAcesso;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}