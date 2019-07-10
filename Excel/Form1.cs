using Excel.Class;
using Excel.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        string pathEmailList = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}emaillist.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string versao = $"Versão 1.0.16"; // Váriavel global para controle da versão.    
        List<string> listaBlacklist = new List<string>();
        List<string> listaWordList = new List<string>();
        List<string> listaEmailList = new List<string>();

        //=============================================================================================================================================================

        public Form1()
        {
            InitializeComponent();
            label_versao.Text = versao; // atribui a versão na label.            
        }

        //=============================================================================================================================================================

        public void GravarListaNoArquivo(List<string> lista, string path)
        {
            var sw = new StreamWriter(path, false, Encoding.Default);

            foreach (var item in lista)
            {
                sw.WriteLine(item);
            }
            sw.Dispose();
        }

        //=============================================================================================================================================================

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

                    if (item.IsNullOrEmpty() == false)
                    {
                        lista.Add(item);
                    }
                }
                sr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //=============================================================================================================================================================

        private void BtnExportarClick(object sender, EventArgs e)
        {
            try
            {
                //Recebe os DataTable de cada tipo e atribui a uma variavel.
                var dtEmail = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.Email, listaBlacklist, listaWordList, listaEmailList);
                var dtEmailContador = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.EmailContador, listaBlacklist, listaWordList, listaEmailList);
                var dtTelefone = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.Telefone, listaBlacklist, listaWordList, listaEmailList);
                var dtNuEmpregados = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.NuFuncionaros, listaBlacklist, listaWordList, listaEmailList);                

                if (dtEmail.Rows.Count == 0 && dtEmailContador.Rows.Count == 0 && dtTelefone.Rows.Count == 0 && dtNuEmpregados.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi retornado nenhum registro das planilhas do caminho especificado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Cria os endereço e nomes dos arquivos que serão salvos.
                string caminhoTxtEmail = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-EMPRESA - Qtd {dtEmail.Rows.Count}.txt");
                string caminhoTxtEmailContador = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-CONTADOR - Qtd {dtEmailContador.Rows.Count}.txt");
                string caminhoTxtTelefone = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_TELEFONES - Qtd {dtTelefone.Rows.Count}.txt");
                string caminhoTxtNuEmpregados = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_NuEmpregados - Qtd {dtNuEmpregados.Rows.Count}.txt");

                //Faz a criação dos arquivos de texto e inserção dos dados.
                objFuncoes.Write(dtEmail, caminhoTxtEmail);
                objFuncoes.Write(dtEmailContador, caminhoTxtEmailContador);
                objFuncoes.Write(dtTelefone, caminhoTxtTelefone);
                objFuncoes.Write(dtNuEmpregados, caminhoTxtNuEmpregados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Informações exportadas para " + selectedFolder.ToString(),
            "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //=============================================================================================================================================================

        private void BtnAbrirClick(object sender, EventArgs e)
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

            var dtgeral = objFuncoes.PreencheDataTableOpenXML(selectedFolder, listaBlacklist, listaWordList); //Chama o metodo responsável por preencher o DataTable.

            if (dtgeral.Rows.Count == 0 || dtgeral == null)
            {
                MessageBox.Show("Não foi retornado nenhum registro das planilhas do caminho especificado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BtnExportar.Enabled = true; //Habilita o botão de exportar.
            BtnExportar.Focus(); //Move o tabindex para o botão exportar.
            dataGridView1.DataSource = dtgeral; //Adiciona os valores do DataTable ao Grid.
        }

        //=============================================================================================================================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaArquivoParaLista(listaBlacklist, pathBlacklist);
                CarregaArquivoParaLista(listaWordList, pathWordList);
                CarregaArquivoParaLista(listaEmailList, pathEmailList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================

        private void BtnBlacklistClick(object sender, EventArgs e)
        {
            try
            {
                var n = new Form_Blacklist_Wordlist(listaBlacklist, objFuncoes, 1);
                n.ShowDialog();
                GravarListaNoArquivo(listaBlacklist, pathBlacklist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================

        private void BtnWordlistClick(object sender, EventArgs e)
        {
            try
            {
                var n = new Form_Blacklist_Wordlist(listaWordList, objFuncoes, 2);
                n.ShowDialog();
                GravarListaNoArquivo(listaWordList, pathWordList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================
    }
}
