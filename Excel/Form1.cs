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
        string pathlistaTipoEmailContador = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}listaTipoEmailContador.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string pathlistaTipoEmailEmpresa = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}listaTipoEmailEmpresa.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string versao = $"Versão 1.0.17"; // Váriavel global para controle da versão.    
        List<string> listaBlacklist = new List<string>();
        List<string> listaTipoEmailContador = new List<string>();
        List<string> listaTipoEmailEmpresa = new List<string>();
        List<Tuple<string, string>> listaPendencias = new List<Tuple<string,string>>();

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
                var dtEmailTipoEmpresa = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.Email, listaBlacklist, listaTipoEmailContador, listaTipoEmailEmpresa, listaPendencias);
                var dtEmailTipoContador = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.EmailContador, listaBlacklist, listaTipoEmailContador, listaTipoEmailEmpresa, listaPendencias);
                var dtEmailTipoNaoClassificado = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.EmailNaoClassificado, listaBlacklist, listaTipoEmailContador, listaTipoEmailEmpresa, listaPendencias);
                var dtTelefone = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.Telefone, listaBlacklist, listaTipoEmailContador, listaTipoEmailEmpresa, listaPendencias);
                var dtNuEmpregados = objFuncoes.PreencheDataTableOpenXML(selectedFolder, Funcoes.EtipoValor.NuFuncionaros, listaBlacklist, listaTipoEmailContador, listaTipoEmailEmpresa, listaPendencias);

                //if (dtEmailTipoEmpresa.Rows.Count == 0 && dtEmailTipoContador.Rows.Count == 0 && dtTelefone.Rows.Count == 0 && dtNuEmpregados.Rows.Count == 0)
                //{
                //    MessageBox.Show("Não foi retornado nenhum registro das planilhas do caminho especificado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //Cria os endereço e nomes dos arquivos que serão salvos.
                string caminhoTxtEmailTipoEmpresa = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-EMPRESA - Qtd {dtEmailTipoEmpresa.Rows.Count}.txt");
                string caminhoTxtEmailTipoContador = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-CONTADOR - Qtd {dtEmailTipoContador.Rows.Count}.txt");
                string caminhoTxtEmailNaoClassificado = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_EMAIL-NÃO_CLASSIFICADO - Qtd {dtEmailTipoNaoClassificado.Rows.Count}.txt");
                string caminhoTxtTelefone = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_TELEFONES - Qtd {dtTelefone.Rows.Count}.txt");
                string caminhoTxtNuEmpregados = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_NuEmpregados - Qtd {dtNuEmpregados.Rows.Count}.txt");
                string caminhoTxtPendencias = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_Pendencias - Qtd {listaPendencias.Count}.txt");

                

                //Faz a criação dos arquivos de texto e inserção dos dados.
                objFuncoes.Write(dtEmailTipoEmpresa, caminhoTxtEmailTipoEmpresa);
                objFuncoes.Write(dtEmailTipoContador, caminhoTxtEmailTipoContador);
                objFuncoes.Write(dtTelefone, caminhoTxtTelefone);
                objFuncoes.Write(dtNuEmpregados, caminhoTxtNuEmpregados);
                objFuncoes.Write(dtEmailTipoNaoClassificado, caminhoTxtEmailNaoClassificado);

                if (listaPendencias.Count > 0)
                {
                    var dtPendencias = listaPendencias.ToDataTable();
                    objFuncoes.Write(dtPendencias, caminhoTxtPendencias);
                }

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

            var dtgeral = objFuncoes.PreencheDataTableOpenXML(selectedFolder, listaBlacklist, listaTipoEmailContador); //Chama o metodo responsável por preencher o DataTable.

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
                CarregaArquivoParaLista(listaTipoEmailContador, pathlistaTipoEmailContador);
                CarregaArquivoParaLista(listaTipoEmailEmpresa, pathlistaTipoEmailEmpresa);
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

        private void BtnListaTipoEmailContadorClick(object sender, EventArgs e)
        {
            try
            {
                var n = new Form_Blacklist_Wordlist(listaTipoEmailContador, objFuncoes, 2);
                n.ShowDialog();
                GravarListaNoArquivo(listaTipoEmailContador, pathlistaTipoEmailContador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================

        private void BtnListaTipoEmailEmpresaClick(object sender, EventArgs e)
        {
            try
            {
                var n = new Form_Blacklist_Wordlist(listaTipoEmailEmpresa, objFuncoes, 3);
                n.ShowDialog();
                GravarListaNoArquivo(listaTipoEmailEmpresa, pathlistaTipoEmailEmpresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================
    }
}
