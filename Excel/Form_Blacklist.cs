﻿using Excel.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form_Blacklist : Form
    {
        private readonly HashSet<string> listaBlacklist;
        //private readonly Funcoes objFuncoes;
        Funcoes objFuncoes = new Funcoes();

        public Form_Blacklist()
        {
            InitializeComponent();
        }

        public Form_Blacklist(HashSet<string> listaBlacklist/*, Funcoes objFuncoes*/)
        {
            InitializeComponent();
            this.listaBlacklist = listaBlacklist;
            
            //this.objFuncoes = objFuncoes;
        }

        private void Form_Blacklist_Load(object sender, EventArgs e)
        {
            AtualizarListBox();
        } 

        private void Btn_gravar_Click(object sender, EventArgs e)
        {
            var valor = text_valor.Text;
            listaBlacklist.Add(valor);
            AtualizarListBox();
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
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

        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            text_valor.Enabled = false;
            ltb_emails.Enabled = true;
            ltb_emails.Focus();
            
        }

        private void AtualizarListBox()
        {
            foreach (var item in listaBlacklist)
            {
                ltb_emails.Items.Add(item);
            }

            label_numero_registros.Text = $"Qtd registros: {listaBlacklist.Count.ToString()} ";
        }
    }
}
