using Autofac;
using Excel.Class;
using Excel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Excel.Class.FuncoesNovaEstrutura;

namespace Excel
{
    public partial class Form1 : Form, IDados
    {
        FuncoesNovaEstrutura objFuncoesNovaestrutura = null; // Instanciação da Classe Funções.
        string selectedFolder = null; // Váriavel goblal utilizada para armazenar a caminho da pasta selecionada.
        string pathBlacklist = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}blacklist.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string pathlistaTipoEmailContador = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}listaTipoEmailContador.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string pathlistaTipoEmailEmpresa = $"{ AppDomain.CurrentDomain.BaseDirectory.ToString()}listaTipoEmailEmpresa.txt"; // Váriavel goblal utilizada para armazenar a caminho da blacklist.
        string versao = $"Versão 2.0.0"; // Váriavel global para controle da versão.    

        public HashSet<string> ListaBlacklist { get; set; } = new HashSet<string>();
        public HashSet<string> ListaTipoEmailContador { get; set; } = new HashSet<string>();
        public HashSet<string> ListaTipoEmailEmpresa { get; set; } = new HashSet<string>();
        public List<Tuple<string, string>> ListaPendencias { get; set; } = new List<Tuple<string, string>>();
        public List<Contato> ListaContato { get; } = new List<Contato>();

        //=============================================================================================================================================================

        public Form1()
        {
            InitializeComponent();
            label_versao.Text = versao; // atribui a versão na label.              
        }

        //=============================================================================================================================================================

        public void GravarListaNoArquivo(HashSet<string> lista, string path)
        {
            var sw = new StreamWriter(path, false, Encoding.Default);

            foreach (var item in lista)
            {
                sw.WriteLine(item.ToUpper().Trim());
            }
            sw.Dispose();
        }

        //=============================================================================================================================================================

        public void CarregaArquivoParaLista(HashSet<string> lista, string path)
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
                        lista.Add(item.ToUpper().Trim());
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
                string caminhoTxtPendencias = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_Pendencias - Qtd {ListaPendencias.Distinct().ToList().Count}.txt");
                Dictionary<EtipoValor, string> dicListaDados = new Dictionary<EtipoValor, string>();
                //dicListaDados.Add(EtipoValor.Email, caminhoTxtEmailTipoEmpresa);
                List<EtipoValor> lst = Enum.GetValues(typeof(EtipoValor)).Cast<EtipoValor>().ToList();
                Type type = typeof(EtipoValor);

                foreach (var itemEnumerado in lst)
                {
                    var attr2 = type.GetField(itemEnumerado.ToString())
                                    .GetCustomAttributes(false)
                                    .OfType<EtipoValorAttribute>()
                                    .Single();

                    var lstContato = ListaContato.Where(c => c.Tipo == itemEnumerado).Distinct().ToList();
                    var path = (selectedFolder + $@"\Exported_at_{DateTime.Now.ToString("dd-MM-yyyy")}_as_{DateTime.Now.ToString("H'h'mm")}_{attr2.Descricao} - Qtd {lstContato.Count}.txt");
                    objFuncoesNovaestrutura.Write(lstContato, path);
                }

                if (ListaPendencias.Count > 0)
                {
                    var listaSemDuplicados = ListaPendencias.Distinct().ToList();
                    List<Contato> listaPendencias = new List<Contato>();
                    listaSemDuplicados.ForEach(a => listaPendencias.Add(new Contato { CPFCNPJ = a.Item1, Tipo = EtipoValor.Email, Valor = a.Item2 }));
                    objFuncoesNovaestrutura.Write(listaPendencias, caminhoTxtPendencias);
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
            ListaContato.Clear();
            FolderBrowserDialog Abrir = new FolderBrowserDialog(); //Instanciação da classe para abrir caixa de dialogo.
            Abrir.RootFolder = Environment.SpecialFolder.Desktop; //Defini o local padrão onde será aberto a caixa de dialogo.
            var result = Abrir.ShowDialog();
            if (result != DialogResult.OK) //Verifica se foi selecionado algum caminho pela caixa de dialogo, caso contrario retorna.
            {
                return;
            }

            selectedFolder = Abrir.SelectedPath; //Atribui o caminho selecionado em uma variavel.
            label_caminhoEscolhido.Text = selectedFolder; //Exibe o caminho selecionado na label.


            Thread threadAbrir = new Thread(new ThreadStart(() =>
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    Action inicio = () =>
                    {
                        BtnExportar.Enabled = false; //Habilita o botão de exportar.
                    };

                    this.Invoke(inicio);

                    objFuncoesNovaestrutura.LeituraDoArquivo(selectedFolder, ListaBlacklist, ListaTipoEmailContador, ListaTipoEmailEmpresa, ListaPendencias);

                    if (ListaContato.Count == 0)
                    {
                        Action message = () =>
                        {
                            MessageBox.Show("Não foi retornado nenhum registro das planilhas do caminho especificado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };

                        this.Invoke(message);
                        return;
                    }

                    Action final = () =>
                    {
                        BtnExportar.Enabled = true; //Habilita o botão de exportar.
                        BtnExportar.Focus(); //Move o tabindex para o botão exportar.
                        contatoBindingSource.Clear();
                        contatoBindingSource.DataSource = ListaContato.Distinct(); //Adiciona os valores da lista no Grid.                        
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    };

                    this.Invoke(final);
                }
                catch (Exception ex)
                {
                    Action message = () =>
                    {
                        MessageBox.Show($"Houve o seguinte erro {ex.Message}");
                    };
                    this.Invoke(message);
                }
            }));

            threadAbrir.Start();
        }

        //=============================================================================================================================================================

        private void Form1_Load(object sender, EventArgs e)
        {


            try
            {
                CarregaArquivoParaLista(ListaBlacklist, pathBlacklist);
                CarregaArquivoParaLista(ListaTipoEmailContador, pathlistaTipoEmailContador);
                CarregaArquivoParaLista(ListaTipoEmailEmpresa, pathlistaTipoEmailEmpresa);
                this.objFuncoesNovaestrutura = Program.Container.Resolve<FuncoesNovaEstrutura>();

                this.objFuncoesNovaestrutura.OnProcessPlan += ObjFuncoesNovaestrutura_OnProcessPlan;
                this.objFuncoesNovaestrutura.OnProgressPlan += ObjFuncoesNovaestrutura_OnProgressPlan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Tem certeza que deseja fechar?", "", MessageBoxButtons.YesNo) == DialogResult.No;
            base.OnClosing(e);
        }

        //=============================================================================================================================================================

        protected override void OnClosed(EventArgs e)
        {
            this.objFuncoesNovaestrutura.OnProcessPlan -= ObjFuncoesNovaestrutura_OnProcessPlan;
            this.objFuncoesNovaestrutura.OnProgressPlan -= ObjFuncoesNovaestrutura_OnProgressPlan;

            base.OnClosed(e);
        }

        //=============================================================================================================================================================

        private void ObjFuncoesNovaestrutura_OnProgressPlan(string arg1, int arg2)
        {
            Action progress = () =>
            {
                this.toolStripProgressBar1.Value = arg2 > 100 ? 100 : arg2;
            };

            this.Invoke(progress);
        }

        //=============================================================================================================================================================

        private void ObjFuncoesNovaestrutura_OnProcessPlan(int arg1, int arg2)
        {

        }

        //=============================================================================================================================================================
                
        private void BtnBlacklistClick(object sender, EventArgs e)
        {
            try
            {
                var n = new Form_Blacklist_Wordlist(ListaBlacklist, objFuncoesNovaestrutura, 1);
                n.ShowDialog();
                GravarListaNoArquivo(ListaBlacklist, pathBlacklist);
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
                var n = new Form_Blacklist_Wordlist(ListaTipoEmailContador, objFuncoesNovaestrutura, 2);
                n.ShowDialog();
                GravarListaNoArquivo(ListaTipoEmailContador, pathlistaTipoEmailContador);
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
                var n = new Form_Blacklist_Wordlist(ListaTipoEmailEmpresa, objFuncoesNovaestrutura, 3);
                n.ShowDialog();
                GravarListaNoArquivo(ListaTipoEmailEmpresa, pathlistaTipoEmailEmpresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============================================================================================================================================================
    }
}
