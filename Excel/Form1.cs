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
            string[] planilhas = Directory.GetFiles(selectedFolder, "*.xlsx");

            if (planilhas.Length == 0)
            {
                MessageBox.Show("Não existem planilhas no caminho selecionado",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string worksheet = "Sheet1";
            DataTable dtgeral = new DataTable();
            var columns = new[] { "CNPJ", "EMAIL" };
            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());


            foreach (var UmaPlanilha in planilhas)
            {
                //Open the Excel file using ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(UmaPlanilha))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(worksheet);

                    bool firstRow = true;
                    var lst = new List<int>(); //Cria uma lista para que sejam armazenados os índices

                    //Loop para percorrer as linhas da planilha.

                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Usa a primeira linha para adicionar as colunas no DataTable.

                        if (firstRow)
                        {
                            //Cria um ojbeto constendo uma regular expression que remove os caracteres especiais

                            Regex obj = new System.Text.RegularExpressions.Regex(@"\W");

                            var indexCells = 0;

                            //Percorre por toda a linha para encontrar o(s) índice(s) que contem a palavra E-MAIL

                            foreach (IXLCell cell in row.Cells())
                            {
                                var columName = cell.Value.ToString();
                                var str = obj.Replace(cell.Value.ToString(), "");
                                if (str.ToUpper().Contains("EMAIL"))
                                {
                                    lst.Add(indexCells);
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
                            var celulas = row.Cells(false); //Retornar a coleção de celulas usadas e não usadas


                            foreach (var item in lst)
                            {
                                string email = string.Empty;
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

                                if (cnpj != "" && email != "" && email != null) //adiociona ao DT GERAL
                                {
                                    dtgeral.Rows.Add(new object[2] { cnpj, email });
                                }

                                dtgeral = dtgeral.DefaultView.ToTable(true, columns);
                                dataGridView1.DataSource = dtgeral;
                            }
                        }
                    }
                }
            }
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

            string caminhotxt = (selectedFolder + $@"\Exported_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}.txt");
            string caminhotxtCont = (selectedFolder + $@"\Exported_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}-CONTADOR.txt");
            string worksheet = "Sheet1";


            //Create a new DataTable.
            DataTable dt = new DataTable();
            DataTable dtCont = new DataTable();

            //Criando um array de Colunas            
            var columns = new[] { "CNPJ", "EMAIL" };

            dt.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());
            dtCont.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            foreach (var UmaPlanilha in planilhas)
            {
                //Open the Excel file using ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(UmaPlanilha))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(worksheet);

                    bool firstRow = true;
                    var lst = new List<int>(); //Cria uma lista para que sejam armazenados os índices

                    //Loop para percorrer as linhas da planilha.

                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Usa a primeira linha para adicionar as colunas no DataTable.

                        if (firstRow)
                        {
                            //Cria um ojbeto constendo uma regular expression que remove os caracteres especiais

                            Regex obj = new System.Text.RegularExpressions.Regex(@"\W");

                            var indexCells = 0;

                            //Percorre por toda a linha para encontrar o(s) índice(s) que contem a palavra E-MAIL

                            foreach (IXLCell cell in row.Cells())
                            {
                                var columName = cell.Value.ToString();
                                var str = obj.Replace(cell.Value.ToString(), "");
                                if (str.ToUpper().Contains("EMAIL"))
                                {
                                    lst.Add(indexCells);
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
                            var celulas = row.Cells(false); //Retornar a coleção de celulas usadas e não usadas


                            foreach (var item in lst)
                            {
                                string email = string.Empty;
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
                        }
                    }
                }
            }

            // Remoção de valores duplicados da DataTable

            dt = dt.DefaultView.ToTable(true, columns); // retornar o DataTable removendo as linhas duplicadas
            dtCont = dtCont.DefaultView.ToTable(true, columns);
            Write(dt, caminhotxt);
            Write(dtCont, caminhotxtCont);

            MessageBox.Show("Informações exportadas para " + selectedFolder.ToString(),
                "Exportação Concluída",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnAbrirClick(object sender, EventArgs e)
        {
            FolderBrowserDialog Abrir = new FolderBrowserDialog();
            Abrir.RootFolder = Environment.SpecialFolder.MyComputer;
            var result = Abrir.ShowDialog();
            if(result != DialogResult.OK)
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