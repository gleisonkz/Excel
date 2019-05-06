using Excel.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form_Blacklist : Form
    {
        private readonly List<string> listaBlacklist;
        private readonly Funcoes objFuncoes;

        public bool Editando { get; set; }

        public Form_Blacklist()
        {
            InitializeComponent();
        }   

        public Form_Blacklist(List<string> listaBlacklist, Funcoes objFuncoes)
        {
            InitializeComponent();
            this.listaBlacklist = listaBlacklist;
            
            this.objFuncoes = objFuncoes;
        }

        private void Form_Blacklist_Load(object sender, EventArgs e)
        {
            AtualizarListBox();
        } 

        private void Btn_gravar_Click(object sender, EventArgs e)
        {
            var valor = text_valor.Text.ToUpper();

            if (valor.Trim() == "")
            {
                MessageBox.Show("É necessário informar algum texto no campo de e-mail");
                return;                
            }


            if (Editando == false)
            {
                listaBlacklist.Add(valor);
                AtualizarListBox();
            }
            else
            {
                listaBlacklist[ltb_emails.SelectedIndex] = valor;
                AtualizarListBox();
            }

            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            text_valor.Enabled = false;
            text_valor.Text = string.Empty;
            ltb_emails.Enabled = true;
            ltb_emails.Focus();
            
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            Editando = true;
            text_valor.Text = ltb_emails.SelectedItem.ToString();
            btn_gravar.Enabled = true;
            btn_cancelar.Enabled = true;
            text_valor.Enabled = true;
            text_valor.Focus();
        }

        private void Btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_novo_Click(object sender, EventArgs e)
        {
            btn_gravar.Enabled = true;
            btn_cancelar.Enabled = true;
            text_valor.Enabled = true;
            ltb_emails.Enabled = false;
            ltb_emails.SelectedIndex = -1;
            text_valor.Focus();
            Editando = false;

        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            text_valor.Enabled = false;
            text_valor.Text = string.Empty;
            ltb_emails.Enabled = true;
            ltb_emails.Focus();
            Editando = false;

            
        }

        private void AtualizarListBox()
        {
            ltb_emails.Items.Clear();

            foreach (var item in listaBlacklist)
            {
                ltb_emails.Items.Add(item);
            }

            label_numero_registros.Text = $"Qtd registros: {listaBlacklist.Count.ToString()} ";
        }

        private void ApagarListBox(string valor)
        {
            listaBlacklist.Remove(valor);
            AtualizarListBox();

        }

        private void Btn_apagar_Click(object sender, EventArgs e)
        {
            try
            {
                ApagarListBox(ltb_emails.SelectedItem.ToString());
                btn_editar.Enabled = false;
                btn_apagar.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ltb_emails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltb_emails.SelectedIndex != -1)
            {
                btn_editar.Enabled = true;
                btn_apagar.Enabled = true;
            }
            else
            {
                btn_editar.Enabled = false;
                btn_apagar.Enabled = false;
            }
        }
    }
}
