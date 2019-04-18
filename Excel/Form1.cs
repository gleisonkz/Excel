using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace Excel
{
    public partial class Form1 : Form
    {
        public void criaDataTableGeral()
        {
            // Cria um array contendo o caminho dos arquivos da pasta selecionada pelo usuário.
            string[] planilhas = Directory.GetFiles(selectedFolder, "*.xlsx");


            // Verifica se no caminho selecionado pelo usuário possui algum arquivo.
            if (planilhas.Length == 0)
            {
                MessageBox.Show("Não existem planilhas no caminho selecionado",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string guiaPlanilha = "Sheet1"; // Cria uma variavel com o nome da guia da planilha que será lida.
            DataTable dtgeral = new DataTable(); // Instanciação de um novo DataTable.
            var columns = new[] { "CNPJ", "VALOR",}; // Cria um array de string.

            /* Para que seja possível adicionar colunas em um DataTable é necessario que o tipo de objeto a ser adicionado sejá do tipo DataColumn
            portanto o comando abaixo executa (que utiliza uma lambda expression) a projeção do array de 
            string para um array de DataColumn e adiciona ao DT. */

            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());            

            foreach (var UmaPlanilha in planilhas) //Inicia um loop por para cada arquivo excel encontrada na pasta informada 
            {
                //Abre o arquivo excel utilizando uma instancia do ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(UmaPlanilha)) //Cria uma instancia contendo uma pasta de trabalho
                {
                    //Read the first Sheet from Excel file.
                    //Faz a leitura da primeira planilha do arquivo
                    IXLWorksheet workSheet = workBook.Worksheet(guiaPlanilha); //adiciona uma guia de planilha a pasta de trabalho criada

                    bool firstRow = true; //Variavel criada para definir que a primeira linha da planilha irá conter as colunas a serem adicionadas 

                    //Cria uma lista para que sejam armazenados os índices.
                    var lstIndicesEmails = new List<int>(); 
                    var lstIndicesTelefones = new List<int>();
                    var lstIndicesNuFuncionarios = new List<int>();

                    //Loop para percorrer a primeira linha da planilha e identificar os índices das colunas.

                    foreach (IXLRow row in workSheet.Rows())
                    {                        
                        if (firstRow) //Usa a primeira linha para adicionar as colunas no DataTable.
                        {
                            Regex ojbRegex = new System.Text.RegularExpressions.Regex(@"\W"); //Cria um ojbeto contendo uma regular expression que remove os caracteres especiais

                            int indexCells = 0; // Variavel criada para controlar o índice da celula

                            foreach (IXLCell cell in row.Cells()) //Percorre por todas as celulas da linha para encontrar o(s) índice(s) que contem a palavra E-MAIL
                            {
                                var str = ojbRegex.Replace(cell.Value.ToString(), ""); //Recupera o valor da celula removendo os caracteres especiais

                                if (str.ToUpper().Contains("EMAIL")) 
                                {
                                    lstIndicesEmails.Add(indexCells); //Adiciona a lista de índices
                                                                     
                                }
                                if (str.ToUpper().Contains("TELEFONE"))
                                {
                                    lstIndicesTelefones.Add(indexCells); //Adiciona a lista de índices
                                }
                                if (str.ToUpper().Contains("FUNCIONÁRIOS"))
                                {
                                    lstIndicesNuFuncionarios.Add(indexCells); //Adiciona a lista de índices
                                }
                                indexCells++;
                                
                            }
                            firstRow = false;
                        }
                        else // Percorre o restante das linhas para recuperar os valores dos índices identificados
                        {
                            string cnpj = null;
                            string email = null;
                            string area = null;
                            string nuEmpregados = null;
                            string telefone = null;

                            void RecuperarValor(List<int> lista, string valor)
                            {
                                int indexCells = 0;

                                //Retornar a coleção de celulas usadas e não usadas da linha, pois por padrão o row.Cells ignora as celulas em branco.
                                var celulasDaLinha = row.Cells(false);

                                //Loop para percorrer as celulas da linha por cada índice encontrado e recuperar os valores da celula.

                                foreach (var item in lista)
                                {

                                    foreach (IXLCell cell in celulasDaLinha)
                                    {
                                        try
                                        {
                                            //CNPJ
                                            if (indexCells == 3)
                                            {
                                                cnpj = cell.Value.ToString();
                                            }

                                            //EMAIL - Nuempregados - Telefone - parametro passado no construtor
                                            if (item == indexCells)
                                            {
                                                valor = cell.Value.ToString();
                                                
                                            }

                                            //AREA
                                            if (indexCells == 13)
                                            {
                                                area = cell.Value.ToString();
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                        indexCells++;
                                    }

                                    indexCells = 0;

                                    //Verifica se o CNPJ e Valor são diferentes de vazio ou nullos

                                    if (cnpj != "" && cnpj != null)
                                    {

                                        if (valor != "" && valor != null)
                                        {

                                            if (valor == "0" && area.ToUpper() == "ÁREA EMPRESÁRIO")
                                            {
                                                continue;
                                            }

                                            else
                                            {
                                                dtgeral.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DT GERAL
                                            }

                                            continue;

                                        }
                                    }                                    
                                }                                                                
                            }

                            RecuperarValor(lstIndicesEmails, email);
                            RecuperarValor(lstIndicesNuFuncionarios, nuEmpregados);
                            RecuperarValor(lstIndicesTelefones, telefone);                                                                                                                                  
                        }
                    }
                }
            }
            dtgeral = dtgeral.DefaultView.ToTable(true, columns);
            dataGridView1.DataSource = dtgeral;
        }

        string selectedFolder = null;


        public Form1()
        {
            InitializeComponent();
        }

        public static void Write(DataTable dt, string outputFilePath)
        {
            //int[] maxLengths = new int[dt.Columns.Count];

            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    maxLengths[i] = dt.Columns[i].ColumnName.Length;

            //    foreach (DataRow row in dt.Rows)
            //    {
            //        if (!row.IsNull(i))
            //        {
            //            int length = row[i].ToString().Length;

            //            if (length > maxLengths[i])
            //            {
            //                maxLengths[i] = length;
            //            }
            //        }
            //    }
            //}

            using (StreamWriter sw = new StreamWriter(outputFilePath, false))
            {
                //for (int i = 0; i < dt.Columns.Count; i++)
                //{
                //    sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                //}

                //sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    sw.WriteLine($"{row[0]}\t{row[1]}");

                    //for (int i = 0; i < dt.Columns.Count; i++)
                    //{
                    //    if (!row.IsNull(i))
                    //    {
                    //        sw.Write(row[i].ToString());
                    //        if (i % 2 == 0)
                    //        {
                    //            sw.Write('\t');
                    //        }

                    //    }
                    //    else
                    //    {
                    //        sw.Write(new string(' ', maxLengths[i] + 2));
                    //    }
                    //}

                    //sw.WriteLine();

                }

                sw.Close();
            }
        }


        private void btnExportarClick(object sender, EventArgs e) 
        {
            if (selectedFolder == null)
            {
                MessageBox.Show("É necessario primeiro selecionar o caminho onde estão os arquivos",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] planilhas = Directory.GetFiles(selectedFolder, "*.xlsx");

            if (planilhas.Length == 0)
            {
                MessageBox.Show("Não existem planilhas no caminho selecionado",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //endereço de onde cada arquivo txt será salvo

            string caminhotxt = (selectedFolder + $@"\Exported_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}.txt");
            string caminhotxtCont = (selectedFolder + $@"\Exported_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}-CONTADOR.txt");
            string caminhotxtTelefone = (selectedFolder + $@"\Exported_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}-TELEFONES.txt");
            string caminhotxtNuEmpregados = (selectedFolder + $@"\Exported_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}-NuEmpregados.txt");
            string worksheet = "Sheet1";


            //Cria um novo DataTable para cada tipo de informação
            DataTable dt = new DataTable();
            DataTable dtCont = new DataTable();
            DataTable dtTelefone = new DataTable();
            DataTable dtNuEmpregados = new DataTable();

            //Criando um array de Colunas            
            var columns = new[] { "CNPJ", "EMAIL" };
            var columnsTel = new[] { "CNPJ", "TELEFONE" };
            var columnsNuEmpregados = new[] { "CNPJ", "NuEmpregados" };

            //Realiza a projeção das colunas para um Array de DataColumn e adiociona as colunas aos respectivos DataTables            
            dt.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());
            dtCont.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());
            dtTelefone.Columns.AddRange(columnsTel.Select(c => new DataColumn(c)).ToArray());
            dtNuEmpregados.Columns.AddRange(columnsNuEmpregados.Select(c => new DataColumn(c)).ToArray());

            foreach (var UmaPlanilha in planilhas) // Realiza os procedimentos abaixo para cada planilha enontrada
            {
                //Abre o planilha utilizando o ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(UmaPlanilha)) //Instaciação do objeto passando como parametro o caminho da planilha identificada.
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(worksheet);

                    bool firstRow = true;
                    var lst = new List<int>(); //Cria uma lista para que sejam armazenados os índices das colunas de e-mails.
                    var lstTelefone = new List<int>(); //Cria uma lista para que sejam armazenados os índices das colunas de telefones.
                    var lstNuEmpregados = new List<int>(); //Cria uma lista para que sejam armazenados os índices das colunas de NuEmpregados.

                    //Loop para percorrer as linhas da planilha.

                    foreach (IXLRow row in workSheet.Rows())
                    {
                        if (firstRow)   //Usa a primeira linha para definir e adicionar as colunas no DataTable.
                        {
                            Regex obj = new System.Text.RegularExpressions.Regex(@"\W"); //Cria um ojbeto constendo uma regular expression que remove os caracteres especiais.

                            var indexCells = 0;

                            //Percorre por toda a linha para encontrar o(s) índice(s) que contem a palavra E-MAIL / TELEFONE / EMPREGADOS/FUNCIONARIOS

                            foreach (IXLCell cell in row.Cells())
                            {
                                var columName = cell.Value.ToString();
                                var str = obj.Replace(cell.Value.ToString(), "");
                                if (str.ToUpper().Contains("EMAIL"))
                                {
                                    lst.Add(indexCells);
                                }
                                if (str.ToUpper().Contains("TELEFONE"))
                                {
                                    lstTelefone.Add(indexCells);
                                }
                                if (str.ToUpper().Contains("FUNCIONARIOS") || (str.ToUpper().Contains("EMPREGADOS")))
                                {
                                    lstNuEmpregados.Add(indexCells);
                                }

                                indexCells++;
                            }

                            firstRow = false;
                        }

                        // Percorre as celulas da linha para identificar o E-MAIL E CNPJ
                        else
                        {
                            int indexCells = 0;
                            string cnpj = null;
                            string email = string.Empty;
                            string telefone = null;
                            string nuEmpregados = null;
                            string area = null;
                            var celulas = row.Cells(false); //Retornar a coleção de celulas usadas e não usadas


                            foreach (var item in lst)
                            {
                                foreach (IXLCell cell in celulas)
                                {
                                    try
                                    {
                                        //CNPJ
                                        if (indexCells == 3)
                                        {
                                            cnpj = cell.Value.ToString();
                                        }

                                        //EMAIL
                                        if (item == indexCells)
                                        {
                                            email = cell.Value.ToString();
                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                    indexCells++;
                                }

                                indexCells = 0;

                                //Verifica se o EMAIL e CNPJ são diferentes de vazio ou nullos e remove os que contem "CONT"

                                bool contemSIND = email.Contains("SIND");
                                bool contemCONT = email.Contains("CONT");

                                if (cnpj != "" && email != "" && email != null && contemCONT == false) //adiociona ao DT PRINCIPAL
                                {
                                    dt.Rows.Add(new object[2] { cnpj, email });
                                }

                                if (contemCONT) //adiociona ao DT CONTADOR
                                {
                                    dtCont.Rows.Add(new object[2] { cnpj, email });
                                }
                            }

                            // SEGUNDO FOREACH (A SER REMOVIDO) PARA INSERIR OS DADOS DE TELEFONE NO DATATABLE

                            foreach (var itemT in lstTelefone)
                            {

                                foreach (IXLCell cell in celulas)
                                {
                                    try
                                    {
                                        //CNPJ
                                        if (indexCells == 3)
                                        {
                                            cnpj = cell.Value.ToString();
                                        }

                                        //TELEFONE
                                        if (itemT == indexCells)
                                        {
                                            telefone = cell.Value.ToString();
                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                    indexCells++;
                                }

                                indexCells = 0;

                                //Verifica se o CNPJ é diferente de vazio ou nullo

                                if (cnpj != "" && telefone != "" && telefone != null) //adiociona ao DT TELEFONE
                                {
                                    dtTelefone.Rows.Add(new object[2] { cnpj, telefone });
                                }

                                // TERCEIRO FOREACH (A SER REMOVIDO) PARA INSERIR OS DADOS DE TELEFONE NO DATATABLE

                                foreach (var itemNT in lstNuEmpregados)
                                {

                                    foreach (IXLCell cell in celulas)
                                    {
                                        try
                                        {
                                            //CNPJ
                                            if (indexCells == 3)
                                            {
                                                cnpj = cell.Value.ToString();
                                            }

                                            //AREA
                                            if (indexCells == 13)
                                            {
                                                area = cell.Value.ToString();
                                            }

                                            //NU EMPREGADOS
                                            if (itemNT == indexCells)
                                            {
                                                nuEmpregados = cell.Value.ToString();
                                                break;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                        indexCells++;
                                    }

                                    indexCells = 0;

                                    //Verifica se o CNPJ é diferente de vazio ou nullo

                                    if (cnpj != "" && nuEmpregados != "" && nuEmpregados != null) //adiociona ao DT NuEmpregados
                                    {
                                        if (area == "ÁREA EMPRESÁRIO" && nuEmpregados == "0")
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            dtNuEmpregados.Rows.Add(new object[2] { cnpj, nuEmpregados });
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                // Remoção de valores duplicados da DataTable

                dt = dt.DefaultView.ToTable(true, columns); // retornar o DataTable removendo as linhas duplicadas
                dtCont = dtCont.DefaultView.ToTable(true, columns);
                dtTelefone = dtTelefone.DefaultView.ToTable(true, columnsTel);
                dtNuEmpregados = dtNuEmpregados.DefaultView.ToTable(true, columnsNuEmpregados);
                Write(dt, caminhotxt);
                Write(dtCont, caminhotxtCont);
                Write(dtTelefone, caminhotxtTelefone);
                Write(dtNuEmpregados, caminhotxtNuEmpregados);


            }
            MessageBox.Show("Informações exportadas para " + selectedFolder.ToString(),
            "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAbrirClick(object sender, EventArgs e)
        {
            FolderBrowserDialog Abrir = new FolderBrowserDialog();
            Abrir.RootFolder = Environment.SpecialFolder.Desktop;
            var result = Abrir.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            btn_exportar.Enabled = true;
            selectedFolder = Abrir.SelectedPath;
            label_caminhoEscolhido.Text = selectedFolder;
            criaDataTableGeral();
        }
    }
}
