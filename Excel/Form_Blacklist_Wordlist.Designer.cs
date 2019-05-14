namespace Excel
{
    partial class Form_Blacklist_Wordlist
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
            this.label_itens = new System.Windows.Forms.Label();
            this.ltb_emails = new System.Windows.Forms.ListBox();
            this.btn_gravar = new System.Windows.Forms.Button();
            this.text_valor = new System.Windows.Forms.TextBox();
            this.label_textbox = new System.Windows.Forms.Label();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_novo = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_editar
            // 
            this.btn_editar.Enabled = false;
            this.btn_editar.Location = new System.Drawing.Point(159, 396);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(99, 46);
            this.btn_editar.TabIndex = 15;
            this.btn_editar.TabStop = false;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.Btn_editar_Click);
            // 
            // btn_apagar
            // 
            this.btn_apagar.Enabled = false;
            this.btn_apagar.Location = new System.Drawing.Point(369, 396);
            this.btn_apagar.Name = "btn_apagar";
            this.btn_apagar.Size = new System.Drawing.Size(98, 46);
            this.btn_apagar.TabIndex = 16;
            this.btn_apagar.TabStop = false;
            this.btn_apagar.Text = "Apagar";
            this.btn_apagar.UseVisualStyleBackColor = true;
            this.btn_apagar.Click += new System.EventHandler(this.Btn_apagar_Click);
            // 
            // label_numero_registros
            // 
            this.label_numero_registros.Location = new System.Drawing.Point(14, 408);
            this.label_numero_registros.Name = "label_numero_registros";
            this.label_numero_registros.Size = new System.Drawing.Size(121, 23);
            this.label_numero_registros.TabIndex = 18;
            this.label_numero_registros.Text = "Qtd Registros: 0";
            this.label_numero_registros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_itens
            // 
            this.label_itens.Location = new System.Drawing.Point(17, 149);
            this.label_itens.Name = "label_itens";
            this.label_itens.Size = new System.Drawing.Size(182, 23);
            this.label_itens.TabIndex = 19;
            this.label_itens.Text = "Lista de itens registrados";
            this.label_itens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ltb_emails.SelectedIndexChanged += new System.EventHandler(this.Ltb_emails_SelectedIndexChanged);
            // 
            // btn_gravar
            // 
            this.btn_gravar.Enabled = false;
            this.btn_gravar.Location = new System.Drawing.Point(212, 54);
            this.btn_gravar.Name = "btn_gravar";
            this.btn_gravar.Size = new System.Drawing.Size(140, 38);
            this.btn_gravar.TabIndex = 13;
            this.btn_gravar.TabStop = false;
            this.btn_gravar.Text = "Gravar";
            this.btn_gravar.UseVisualStyleBackColor = true;
            this.btn_gravar.Click += new System.EventHandler(this.BtnGravarClick);
            // 
            // text_valor
            // 
            this.text_valor.Enabled = false;
            this.text_valor.Location = new System.Drawing.Point(72, 28);
            this.text_valor.MaxLength = 50;
            this.text_valor.Name = "text_valor";
            this.text_valor.Size = new System.Drawing.Size(280, 20);
            this.text_valor.TabIndex = 11;
            // 
            // label_textbox
            // 
            this.label_textbox.Location = new System.Drawing.Point(18, 26);
            this.label_textbox.Name = "label_textbox";
            this.label_textbox.Size = new System.Drawing.Size(54, 23);
            this.label_textbox.TabIndex = 21;
            this.label_textbox.Text = "Email:";
            this.label_textbox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Location = new System.Drawing.Point(473, 396);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(98, 46);
            this.btn_fechar.TabIndex = 17;
            this.btn_fechar.TabStop = false;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.Btn_fechar_Click);
            // 
            // btn_novo
            // 
            this.btn_novo.Location = new System.Drawing.Point(265, 396);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(98, 46);
            this.btn_novo.TabIndex = 22;
            this.btn_novo.TabStop = false;
            this.btn_novo.Text = "Novo";
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Click += new System.EventHandler(this.Btn_novo_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Enabled = false;
            this.btn_cancelar.Location = new System.Drawing.Point(72, 54);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(140, 38);
            this.btn_cancelar.TabIndex = 23;
            this.btn_cancelar.TabStop = false;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Form_Blacklist_Wordlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 470);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_novo);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_apagar);
            this.Controls.Add(this.label_numero_registros);
            this.Controls.Add(this.label_itens);
            this.Controls.Add(this.btn_gravar);
            this.Controls.Add(this.text_valor);
            this.Controls.Add(this.label_textbox);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.ltb_emails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Blacklist_Wordlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blacklist / Wordlist - Inserir / Editar";
            this.Load += new System.EventHandler(this.Form_Blacklist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_apagar;
        private System.Windows.Forms.Label label_numero_registros;
        private System.Windows.Forms.Label label_itens;
        private System.Windows.Forms.ListBox ltb_emails;
        private System.Windows.Forms.Button btn_gravar;
        private System.Windows.Forms.TextBox text_valor;
        private System.Windows.Forms.Label label_textbox;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.Button btn_cancelar;
    }
}