using Excel.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form1 : Form
    {
        Funcoes objFuncoes = new Funcoes(); // Instanciação da Classe Funções.
        string selectedFolder = null; // Váriavel goblal utilizada para armazenar a caminho da pasta selecionada.
        string pathBlacklist = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}blacklist.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string pathWordList = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}wordlist.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string versao = "Versão 1.0.14"; // Váriavel global para controle da versão.

        List<string> listaBlacklist = new List<string>();
        List<string> listaWordList = new List<string>();

        public void CarregaArquivoParaLista(List<string> lista, string path)
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    GravarListaNoArquivo(lista, path);
                }


                var sr = new StreamReader(path, Encoding.Default);

                while (!sr.EndOfStream)
                {
                    var item = sr.ReadLine();
                    lista.Add(item);
                }
                sr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void GravarListaNoArquivo(List<string> lista, string path)
        {
            var sw = new StreamWriter(path, false, Encoding.Default);

            foreach (var item in lista)
            {
                sw.WriteLine(item);
            }
            sw.Dispose();

        }

        public Form1()
        {
            InitializeComponent();
            label_versao.Text = versao; // atribui a versão na label.

        }

        private void btnExportarClick(object sender, EventArgs e)
        {
            //Cria os endereço e nomes dos arquivos que serão salvos.
            string caminhoTxtEmail = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-EMPRESA.txt");
            string caminhoTxtEmailContador = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-CONTADOR.txt");
            string caminhoTxtTelefone = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_TELEFONES.txt");
            string caminhoTxtNuEmpregados = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_NuEmpregados.txt");

            //Recebe os DataTable de cada tipo e atribui a uma variavel.
            var dtEmail = objFuncoes.PreencheDataTable(selectedFolder, Funcoes.EtipoValor.Email, listaBlacklist, listaWordList);
            var dtEmailContador = objFuncoes.PreencheDataTable(selectedFolder, Funcoes.EtipoValor.EmailContador, listaBlacklist, listaWordList);
            var dtTelefone = objFuncoes.PreencheDataTable(selectedFolder, Funcoes.EtipoValor.Telefone, listaBlacklist, listaWordList);
            var dtNuEmpregados = objFuncoes.PreencheDataTable(selectedFolder, Funcoes.EtipoValor.NuFuncionaros, listaBlacklist, listaWordList);

            //Faz a criação dos arquivos de texto e inserção dos dados.
            objFuncoes.Write(dtEmail, caminhoTxtEmail);
            objFuncoes.Write(dtEmailContador, caminhoTxtEmailContador);
            objFuncoes.Write(dtTelefone, caminhoTxtTelefone);
            objFuncoes.Write(dtNuEmpregados, caminhoTxtNuEmpregados);

            MessageBox.Show("Informações exportadas para " + selectedFolder.ToString(),
            "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAbrirClick(object sender, EventArgs e)
        {
            FolderBrowserDialog Abrir = new FolderBrowserDialog(); //Instanciação da classe para abrir caixa de dialogo.
            Abrir.RootFolder = Environment.SpecialFolder.Desktop; //Defini o local padrão onde será aberto a caixa de dialogo.
            var result = Abrir.ShowDialog();
            if (result != DialogResult.OK) //Verifica se foi selecionado algum caminho pela caixa de dialogo, caso contrario retorna.
            {
                return;
            }

            selectedFolder = Abrir.SelectedPath; //Atribui o caminho selecionado em uma variavel.
            label_caminhoEscolhido.Text = selectedFolder; //Exibe o caminho selecionado na label.
            var dtgeral = objFuncoes.PreencheDataTable(selectedFolder, listaBlacklist); //Chama o metodo responsável por preencher o DataTable.

            if (dtgeral == null)
            {
                return;
            }

            btn_exportar.Enabled = true; //Habilita o botão de exportar.
            btn_exportar.Focus(); //Move o tabindex para o botão exportar.
            dataGridView1.DataSource = dtgeral; //Adiciona os valores do DataTable ao Grid.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaArquivoParaLista(listaBlacklist, pathBlacklist);
            CarregaArquivoParaLista(listaWordList, pathWordList);
        }

        private void btnBlacklistClick(object sender, EventArgs e)
        {
            var n = new Form_Blacklist_Wordlist(listaBlacklist, objFuncoes, 1);
            n.ShowDialog();
            GravarListaNoArquivo(listaBlacklist, pathBlacklist);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var n = new Form_Blacklist_Wordlist(listaWordList, objFuncoes, 2);
            n.ShowDialog();
            GravarListaNoArquivo(listaWordList, pathWordList);
        }
    }
}
