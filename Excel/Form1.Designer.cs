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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cPFCNPJDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contatoBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contatoBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPFCNPJDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.contatoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(486, 536);
            this.dataGridView1.TabIndex = 0;
            // 
            // cPFCNPJDataGridViewTextBoxColumn
            // 
            this.cPFCNPJDataGridViewTextBoxColumn.DataPropertyName = "CPFCNPJ";
            this.cPFCNPJDataGridViewTextBoxColumn.HeaderText = "CPFCNPJ";
            this.cPFCNPJDataGridViewTextBoxColumn.Name = "cPFCNPJDataGridViewTextBoxColumn";
            this.cPFCNPJDataGridViewTextBoxColumn.ReadOnly = true;
            this.cPFCNPJDataGridViewTextBoxColumn.Width = 79;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorDataGridViewTextBoxColumn.Width = 56;
            // 
            // contatoBindingSource
            // 
            this.contatoBindingSource.DataSource = typeof(Excel.Class.Contato);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione a pasta onde estão localizadas as planilhas";
            // 
            // label_caminhoEscolhido
            // 
            this.label_caminhoEscolhido.AutoSize = true;
            this.label_caminhoEscolhido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_caminhoEscolhido.Location = new System.Drawing.Point(40, 398);
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
            this.BtnAbrir.Location = new System.Drawing.Point(40, 433);
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
            this.BtnExportar.Location = new System.Drawing.Point(393, 433);
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
            this.label_btn_abrir.Location = new System.Drawing.Point(65, 506);
            this.label_btn_abrir.Name = "label_btn_abrir";
            this.label_btn_abrir.Size = new System.Drawing.Size(28, 13);
            this.label_btn_abrir.TabIndex = 5;
            this.label_btn_abrir.Text = "Abrir";
            // 
            // label_btn_exportar
            // 
            this.label_btn_exportar.AutoSize = true;
            this.label_btn_exportar.Location = new System.Drawing.Point(408, 506);
            this.label_btn_exportar.Name = "label_btn_exportar";
            this.label_btn_exportar.Size = new System.Drawing.Size(46, 13);
            this.label_btn_exportar.TabIndex = 6;
            this.label_btn_exportar.Text = "Exportar";
            // 
            // label_versao
            // 
            this.label_versao.Location = new System.Drawing.Point(355, 2);
            this.label_versao.Name = "label_versao";
            this.label_versao.Size = new System.Drawing.Size(142, 20);
            this.label_versao.TabIndex = 7;
            this.label_versao.Text = "exibe a versão da aplicação";
            this.label_versao.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnBlacklist
            // 
            this.BtnBlacklist.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBlacklist.BackgroundImage = global::Excel.Properties.Resources.Group_Black_Folder_icon;
            this.BtnBlacklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBlacklist.Location = new System.Drawing.Point(307, 433);
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
            this.label_btn_blacklist.Location = new System.Drawing.Point(323, 506);
            this.label_btn_blacklist.Name = "label_btn_blacklist";
            this.label_btn_blacklist.Size = new System.Drawing.Size(46, 13);
            this.label_btn_blacklist.TabIndex = 9;
            this.label_btn_blacklist.Text = "Blacklist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "LstEmailContador";
            // 
            // BtnListaTipoEmailContador
            // 
            this.BtnListaTipoEmailContador.BackgroundImage = global::Excel.Properties.Resources.Group_Black_Folder_icon;
            this.BtnListaTipoEmailContador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnListaTipoEmailContador.Location = new System.Drawing.Point(218, 433);
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
            this.label3.Location = new System.Drawing.Point(124, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "LstEmailEmpresa";
            // 
            // BtnListaTipoEmailEmpresa
            // 
            this.BtnListaTipoEmailEmpresa.BackgroundImage = global::Excel.Properties.Resources.Group_Black_Folder_icon;
            this.BtnListaTipoEmailEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnListaTipoEmailEmpresa.Location = new System.Drawing.Point(127, 433);
            this.BtnListaTipoEmailEmpresa.Margin = new System.Windows.Forms.Padding(0);
            this.BtnListaTipoEmailEmpresa.Name = "BtnListaTipoEmailEmpresa";
            this.BtnListaTipoEmailEmpresa.Size = new System.Drawing.Size(75, 66);
            this.BtnListaTipoEmailEmpresa.TabIndex = 12;
            this.BtnListaTipoEmailEmpresa.TabStop = false;
            this.BtnListaTipoEmailEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnListaTipoEmailEmpresa.UseVisualStyleBackColor = false;
            this.BtnListaTipoEmailEmpresa.Click += new System.EventHandler(this.BtnListaTipoEmailEmpresaClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(971, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(993, 25);
            this.bindingNavigator1.TabIndex = 15;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label_caminhoEscolhido);
            this.splitContainer1.Panel2.Controls.Add(this.BtnExportar);
            this.splitContainer1.Panel2.Controls.Add(this.label_versao);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.BtnAbrir);
            this.splitContainer1.Panel2.Controls.Add(this.BtnListaTipoEmailEmpresa);
            this.splitContainer1.Panel2.Controls.Add(this.label_btn_abrir);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label_btn_exportar);
            this.splitContainer1.Panel2.Controls.Add(this.BtnListaTipoEmailContador);
            this.splitContainer1.Panel2.Controls.Add(this.BtnBlacklist);
            this.splitContainer1.Panel2.Controls.Add(this.label_btn_blacklist);
            this.splitContainer1.Size = new System.Drawing.Size(993, 536);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(993, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extração de Dados Excel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contatoBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.BindingSource contatoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFCNPJDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

