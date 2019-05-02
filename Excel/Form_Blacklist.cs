using Excel.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form_Blacklist : Form
    {
        public Form_Blacklist()
        {
            InitializeComponent();
        }

        private void Form_Blacklist_Load(object sender, EventArgs e)
        {
            Funcoes objFuncoes = new Funcoes(); // Instanciação da Classe Funções.
            objFuncoes.PreencheBlacklist();

            foreach (var item in objFuncoes.listaBlacklist)
            {
                ltb_emails.Items.Add(item);
            }


            label_numero_registros.Text = $"Qtd registros: {objFuncoes.listaBlacklist.Count.ToString()} ";

        }
    }
}
