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
            this.btn_abrir = new System.Windows.Forms.Button();
            this.btn_exportar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(425, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione a pasta onde estão localizadas as planilhas";
            // 
            // label_caminhoEscolhido
            // 
            this.label_caminhoEscolhido.AutoSize = true;
            this.label_caminhoEscolhido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_caminhoEscolhido.Location = new System.Drawing.Point(472, 294);
            this.label_caminhoEscolhido.Name = "label_caminhoEscolhido";
            this.label_caminhoEscolhido.Size = new System.Drawing.Size(33, 15);
            this.label_caminhoEscolhido.TabIndex = 4;
            this.label_caminhoEscolhido.Text = "C:\\...";
            // 
            // btn_abrir
            // 
            this.btn_abrir.BackColor = System.Drawing.Color.Transparent;
            this.btn_abrir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_abrir.BackgroundImage")));
            this.btn_abrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_abrir.Location = new System.Drawing.Point(472, 350);
            this.btn_abrir.Margin = new System.Windows.Forms.Padding(0);
            this.btn_abrir.Name = "btn_abrir";
            this.btn_abrir.Size = new System.Drawing.Size(75, 66);
            this.btn_abrir.TabIndex = 0;
            this.btn_abrir.TabStop = false;
            this.btn_abrir.UseVisualStyleBackColor = false;
            this.btn_abrir.Click += new System.EventHandler(this.btnAbrirClick);
            // 
            // btn_exportar
            // 
            this.btn_exportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_exportar.BackgroundImage")));
            this.btn_exportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exportar.Enabled = false;
            this.btn_exportar.Location = new System.Drawing.Point(697, 350);
            this.btn_exportar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_exportar.Name = "btn_exportar";
            this.btn_exportar.Size = new System.Drawing.Size(75, 66);
            this.btn_exportar.TabIndex = 1;
            this.btn_exportar.TabStop = false;
            this.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_exportar.UseVisualStyleBackColor = false;
            this.btn_exportar.Click += new System.EventHandler(this.btnExportarClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Abrir";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Exportar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_abrir);
            this.Controls.Add(this.btn_exportar);
            this.Controls.Add(this.label_caminhoEscolhido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extração de Dados Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exportar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_abrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_caminhoEscolhido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

