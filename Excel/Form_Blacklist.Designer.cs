namespace Excel
{
    partial class Form_Blacklist
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
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_apagar = new System.Windows.Forms.Button();
            this.label_numero_registros = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ltb_emails = new System.Windows.Forms.ListBox();
            this.btn_gravar = new System.Windows.Forms.Button();
            this.text_nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_configuracoes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(262, 393);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(99, 44);
            this.btn_editar.TabIndex = 15;
            this.btn_editar.TabStop = false;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            // 
            // btn_apagar
            // 
            this.btn_apagar.Location = new System.Drawing.Point(367, 393);
            this.btn_apagar.Name = "btn_apagar";
            this.btn_apagar.Size = new System.Drawing.Size(99, 44);
            this.btn_apagar.TabIndex = 16;
            this.btn_apagar.TabStop = false;
            this.btn_apagar.Text = "Apagar";
            this.btn_apagar.UseVisualStyleBackColor = true;
            // 
            // label_numero_registros
            // 
            this.label_numero_registros.Location = new System.Drawing.Point(17, 414);
            this.label_numero_registros.Name = "label_numero_registros";
            this.label_numero_registros.Size = new System.Drawing.Size(135, 23);
            this.label_numero_registros.TabIndex = 18;
            this.label_numero_registros.Text = "Qtd Registros: 0";
            this.label_numero_registros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Lista de emails registrados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ltb_emails
            // 
            this.ltb_emails.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltb_emails.FormattingEnabled = true;
            this.ltb_emails.ItemHeight = 14;
            this.ltb_emails.Location = new System.Drawing.Point(17, 175);
            this.ltb_emails.Name = "ltb_emails";
            this.ltb_emails.Size = new System.Drawing.Size(554, 200);
            this.ltb_emails.TabIndex = 14;
            // 
            // btn_gravar
            // 
            this.btn_gravar.Location = new System.Drawing.Point(87, 56);
            this.btn_gravar.Name = "btn_gravar";
            this.btn_gravar.Size = new System.Drawing.Size(112, 38);
            this.btn_gravar.TabIndex = 13;
            this.btn_gravar.TabStop = false;
            this.btn_gravar.Text = "Gravar";
            this.btn_gravar.UseVisualStyleBackColor = true;
            // 
            // text_nome
            // 
            this.text_nome.Location = new System.Drawing.Point(87, 30);
            this.text_nome.MaxLength = 50;
            this.text_nome.Name = "text_nome";
            this.text_nome.Size = new System.Drawing.Size(274, 20);
            this.text_nome.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Email:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Location = new System.Drawing.Point(472, 393);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(99, 44);
            this.btn_fechar.TabIndex = 17;
            this.btn_fechar.TabStop = false;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            // 
            // btn_configuracoes
            // 
            this.btn_configuracoes.Location = new System.Drawing.Point(157, 393);
            this.btn_configuracoes.Name = "btn_configuracoes";
            this.btn_configuracoes.Size = new System.Drawing.Size(99, 44);
            this.btn_configuracoes.TabIndex = 22;
            this.btn_configuracoes.TabStop = false;
            this.btn_configuracoes.Text = "Configurações";
            this.btn_configuracoes.UseVisualStyleBackColor = true;
            // 
            // Form_Blacklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 470);
            this.Controls.Add(this.btn_configuracoes);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_apagar);
            this.Controls.Add(this.label_numero_registros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_gravar);
            this.Controls.Add(this.text_nome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.ltb_emails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Blacklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blacklist - Inserir / Editar";
            this.Load += new System.EventHandler(this.Form_Blacklist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_apagar;
        private System.Windows.Forms.Label label_numero_registros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ltb_emails;
        private System.Windows.Forms.Button btn_gravar;
        private System.Windows.Forms.TextBox text_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_configuracoes;
    }
}