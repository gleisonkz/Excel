namespace Excel
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label_caminhoEscolhido = new System.Windows.Forms.Label();
            this.BtnAbrir = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.label_btn_abrir = new System.Windows.Forms.Label();
            this.label_btn_exportar = new System.Windows.Forms.Label();
            this.label_versao = new System.Windows.Forms.Label();
            this.BtnBlacklist = new System.Windows.Forms.Button();
            this.label_btn_blacklist = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnListaTipoEmailContador = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnListaTipoEmailEmpresa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(425, 503);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione a pasta onde estão localizadas as planilhas";
            // 
            // label_caminhoEscolhido
            // 
            this.label_caminhoEscolhido.AutoSize = true;
            this.label_caminhoEscolhido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_caminhoEscolhido.Location = new System.Drawing.Point(474, 310);
            this.label_caminhoEscolhido.Name = "label_caminhoEscolhido";
            this.label_caminhoEscolhido.Size = new System.Drawing.Size(33, 15);
            this.label_caminhoEscolhido.TabIndex = 4;
            this.label_caminhoEscolhido.Text = "C:\\...";
            // 
            // BtnAbrir
            // 
            this.BtnAbrir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAbrir.BackgroundImage = global::Excel.Properties.Resources.Generic_Black_Folder_icon;
            this.BtnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAbrir.Location = new System.Drawing.Point(474, 451);
            this.BtnAbrir.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAbrir.Name = "BtnAbrir";
            this.BtnAbrir.Size = new System.Drawing.Size(75, 66);
            this.BtnAbrir.TabIndex = 0;
            this.BtnAbrir.TabStop = false;
            this.BtnAbrir.UseVisualStyleBackColor = false;
            this.BtnAbrir.Click += new System.EventHandler(this.BtnAbrirClick);
            // 
            // BtnExportar
            // 
            this.BtnExportar.BackgroundImage = global::Excel.Properties.Resources.Downloads_Black_Folder_icon;
            this.BtnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExportar.Enabled = false;
            this.BtnExportar.Location = new System.Drawing.Point(832, 451);
            this.BtnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(75, 66);
            this.BtnExportar.TabIndex = 2;
            this.BtnExportar.TabStop = false;
            this.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnExportar.UseVisualStyleBackColor = false;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportarClick);
            // 
            // label_btn_abrir
            // 
            this.label_btn_abrir.AutoSize = true;
            this.label_btn_abrir.Location = new System.Drawing.Point(499, 524);
            this.label_btn_abrir.Name = "label_btn_abrir";
            this.label_btn_abrir.Size = new System.Drawing.Size(28, 13);
            this.label_btn_abrir.TabIndex = 5;
            this.label_btn_abrir.Text = "Abrir";
            // 
            // label_btn_exportar
            // 
            this.label_btn_exportar.AutoSize = true;
            this.label_btn_exportar.Location = new System.Drawing.Point(847, 524);
            this.label_btn_exportar.Name = "label_btn_exportar";
            this.label_btn_exportar.Size = new System.Drawing.Size(46, 13);
            this.label_btn_exportar.TabIndex = 6;
            this.label_btn_exportar.Text = "Exportar";
            // 
            // label_versao
            // 
            this.label_versao.AutoSize = true;
            this.label_versao.Location = new System.Drawing.Point(9, 530);
            this.label_versao.Name = "label_versao";
            this.label_versao.Size = new System.Drawing.Size(140, 13);
            this.label_versao.TabIndex = 7;
            this.label_versao.Text = "exibe a versão da aplicação";
            // 
            // BtnBlacklist
            // 
            this.BtnBlacklist.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBlacklist.BackgroundImage = global::Excel.Properties.Resources.Group_Black_Folder_icon;
            this.BtnBlacklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBlacklist.Location = new System.Drawing.Point(746, 451);
            this.BtnBlacklist.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBlacklist.Name = "BtnBlacklist";
            this.BtnBlacklist.Size = new System.Drawing.Size(75, 66);
            this.BtnBlacklist.TabIndex = 1;
            this.BtnBlacklist.TabStop = false;
            this.BtnBlacklist.UseVisualStyleBackColor = false;
            this.BtnBlacklist.Click += new System.EventHandler(this.BtnBlacklistClick);
            // 
            // label_btn_blacklist
            // 
            this.label_btn_blacklist.AutoSize = true;
            this.label_btn_blacklist.Location = new System.Drawing.Point(762, 524);
            this.label_btn_blacklist.Name = "label_btn_blacklist";
            this.label_btn_blacklist.Size = new System.Drawing.Size(46, 13);
            this.label_btn_blacklist.TabIndex = 9;
            this.label_btn_blacklist.Text = "Blacklist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "LstEmailContador";
            // 
            // BtnListaTipoEmailContador
            // 
            this.BtnListaTipoEmailContador.BackgroundImage = global::Excel.Properties.Resources.Group_Black_Folder_icon;
            this.BtnListaTipoEmailContador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnListaTipoEmailContador.Location = new System.Drawing.Point(657, 451);
            this.BtnListaTipoEmailContador.Margin = new System.Windows.Forms.Padding(0);
            this.BtnListaTipoEmailContador.Name = "BtnListaTipoEmailContador";
            this.BtnListaTipoEmailContador.Size = new System.Drawing.Size(75, 66);
            this.BtnListaTipoEmailContador.TabIndex = 10;
            this.BtnListaTipoEmailContador.TabStop = false;
            this.BtnListaTipoEmailContador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnListaTipoEmailContador.UseVisualStyleBackColor = false;
            this.BtnListaTipoEmailContador.Click += new System.EventHandler(this.BtnListaTipoEmailContadorClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "LstEmailEmpresa";
            // 
            // BtnListaTipoEmailEmpresa
            // 
            this.BtnListaTipoEmailEmpresa.BackgroundImage = global::Excel.Properties.Resources.Group_Black_Folder_icon;
            this.BtnListaTipoEmailEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnListaTipoEmailEmpresa.Location = new System.Drawing.Point(566, 451);
            this.BtnListaTipoEmailEmpresa.Margin = new System.Windows.Forms.Padding(0);
            this.BtnListaTipoEmailEmpresa.Name = "BtnListaTipoEmailEmpresa";
            this.BtnListaTipoEmailEmpresa.Size = new System.Drawing.Size(75, 66);
            this.BtnListaTipoEmailEmpresa.TabIndex = 12;
            this.BtnListaTipoEmailEmpresa.TabStop = false;
            this.BtnListaTipoEmailEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnListaTipoEmailEmpresa.UseVisualStyleBackColor = false;
            this.BtnListaTipoEmailEmpresa.Click += new System.EventHandler(this.BtnListaTipoEmailEmpresaClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(916, 552);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnListaTipoEmailEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnListaTipoEmailContador);
            this.Controls.Add(this.label_btn_blacklist);
            this.Controls.Add(this.BtnBlacklist);
            this.Controls.Add(this.label_versao);
            this.Controls.Add(this.label_btn_exportar);
            this.Controls.Add(this.label_btn_abrir);
            this.Controls.Add(this.BtnAbrir);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.label_caminhoEscolhido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extração de Dados Excel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnAbrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_caminhoEscolhido;
        private System.Windows.Forms.Label label_btn_abrir;
        private System.Windows.Forms.Label label_btn_exportar;
        private System.Windows.Forms.Label label_versao;
        private System.Windows.Forms.Button BtnBlacklist;
        private System.Windows.Forms.Label label_btn_blacklist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnListaTipoEmailContador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnListaTipoEmailEmpresa;
    }
}

