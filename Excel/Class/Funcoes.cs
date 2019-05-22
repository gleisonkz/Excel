using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Excel.Class
{
    public class Funcoes
    {
        public Funcoes()
        {
        }

        public enum EtipoValor
        {
            Email = 1,
            NuFuncionaros = 2,
            Telefone = 3,
            EmailContador = 4
        }

        public Dictionary<EtipoValor, string[]> dicTipo = new Dictionary<EtipoValor, string[]>
        {
            { EtipoValor.Email, new [] { "EMAIL" } },
            { EtipoValor.Telefone, new [] { "TELEFONE" } },
            { EtipoValor.EmailContador, new [] { "EMAIL" } },
            { EtipoValor.NuFuncionaros, new [] { "FUNCIONARIOS","EMPREGADOS" } }
        };

        public DataTable PreencheDataTableOpenXML(string caminho, List<string> listaBlacklist, List<string> listaWordlist)
        {
            //Cria um array contendo o caminho dos arquivos da pasta selecionada pelo usuário.
            string[] planilhas = Directory.GetFiles(caminho, "*.xlsx");


            #region Validações
            if (caminho == null)
            {
                //Verificar se foi selecionado algum caminho para realizar a exportação.
                MessageBox.Show("É necessario primeiro selecionar o caminho onde estão os arquivos",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (planilhas.Length == 0)
            {
                //Verificar se no caminho selecionado possui alguma planilha.
                MessageBox.Show("Não existem planilhas no caminho selecionado",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            } 
            #endregion

            DataTable dtgeral = new DataTable();
            var columns = new[] { "CNPJ", "VALOR", }; // Cria um array de string.

            /* Para que seja possível adicionar colunas em um DataTable é necessario que o tipo de objeto a ser adicionado sejá do tipo DataColumn
            portanto o comando abaixo executa (que utiliza uma lambda expression) a projeção do array de 
            string para um array de DataColumn e adiciona ao DT. */

            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            Regex ojbRegex = new System.Text.RegularExpressions.Regex(@"\W+"); //Cria um ojbeto contendo uma regular expression que remove os caracteres especiais

            foreach (var UmaPlanilha in planilhas) //Inicia um loop por para cada arquivo excel encontrada na pasta informada 
            {
                // open the document read-only
                SpreadsheetDocument document = SpreadsheetDocument.Open(UmaPlanilha, false);
                WorkbookPart workbookPart = document.WorkbookPart;
                bool firstRow = true; //Variavel criada para definir que a primeira linha da planilha irá conter as colunas a serem adicionadas 

                // Cria uma lista para que sejam armazenados os índices.
                var lstIndices = new List<int>();

                foreach (WorksheetPart worksheetPart in document.WorkbookPart.WorksheetParts)
                {
                    foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                    {
                        if (sheetData.HasChildren)
                        {
                            foreach (Row row in sheetData.Elements<Row>())
                            {
                                if (firstRow)
                                {
                                    int indexCells = 0; // Variavel criada para controlar o índice da celula

                                    foreach (Cell cell in row.Elements<Cell>()) //Percorre por todas as celulas da linha para encontrar o(s) índice(s) que contem a palavra E-MAIL
                                    {
                                        var str = ojbRegex.Replace(cell.InnerText.ToString().RemoverAcentuacao(), ""); //Recupera o valor da celula removendo os caracteres especiais e acentuações

                                        if (str.ToUpper().Contains("EMAIL"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices

                                        }
                                        if (str.ToUpper().Contains("TELEFONE"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices
                                        }
                                        if (str.ToUpper().Contains("EMPREGADOS") || str.ToUpper().Contains("FUNCIONARIOS"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices
                                        }
                                        indexCells++;
                                    }
                                    firstRow = false;

                                }
                                else // Percorre o restante das linhas para recuperar os valores dos índices identificados
                                {
                                    string cnpj = null;
                                    string valor = null;
                                    string area = null;

                                    void RecuperarValor(List<int> lista, string v)
                                    {
                                        int indexCells = 0;

                                        //Loop para percorrer as celulas da linha por cada índice encontrado e recuperar os valores da celula.
                                        foreach (var item in lista)
                                        {

                                            foreach (Cell cell in row.Elements<Cell>())
                                            {
                                                try
                                                {
                                                    //CNPJ
                                                    if (indexCells == 3)
                                                    {
                                                        cnpj = cell.InnerText.ToString();
                                                    }

                                                    //VALOR
                                                    if (item == indexCells)
                                                    {
                                                        v = cell.InnerText.ToString();

                                                    }
                                                    //AREA
                                                    if (indexCells == 13)
                                                    {
                                                        area = cell.InnerText.ToString();
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    throw ex;
                                                }
                                                indexCells++;

                                                // Verifica se os campos de CNPJ e VALOR são diferentes de nulo e vazio.
                                                var dadosValidos = string.IsNullOrEmpty(cnpj) == false && string.IsNullOrEmpty(v) == false;

                                                if (dadosValidos)
                                                {
                                                    //Verificar se não consta na listablacklist.
                                                    var existe = listaBlacklist.Any(c => c.ToUpper().Trim() == v.ToUpper().Trim());

                                                    if (existe == false)
                                                    {
                                                        dtgeral.Rows.Add(new object[2] { cnpj, v }); //adiociona ao DataTable
                                                    }

                                                }
                                            }

                                            indexCells = 0;
                                        }
                                    }
                                    RecuperarValor(lstIndices, valor);
                                }
                            }
                        }
                    }
                }
                document.Dispose();
            }
            dtgeral = dtgeral.DefaultView.ToTable(true, columns); //Remove os valores duplicados do DataTable
            return dtgeral;
        }

        public DataTable PreencheDataTableOpenXML(string caminho, EtipoValor Etipo, List<string> listaBlacklist, List<string> listaWordlist)
        {
            //Cria um array contendo o caminho dos arquivos da pasta selecionada pelo usuário.
            string[] planilhas = Directory.GetFiles(caminho, "*.xlsx");


            if (caminho == null)
            {
                MessageBox.Show("É necessario primeiro selecionar o caminho onde estão os arquivos",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (planilhas.Length == 0)
            {
                MessageBox.Show("Não existem planilhas no caminho selecionado",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            DataTable dtgeral = new DataTable(); // Instanciação de um novo DataTable.
            var columns = new[] { "CNPJ", "VALOR", }; // Cria um array de string.

            /* Para que seja possível adicionar colunas em um DataTable é necessario que o tipo de objeto a ser adicionado sejá do tipo DataColumn
            portanto o comando abaixo executa (que utiliza uma lambda expression) a projeção do array de 
            string para um array de DataColumn e adiciona ao DT. */

            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());
            Regex ojbRegex = new System.Text.RegularExpressions.Regex(@"\W+"); //Cria um ojbeto contendo uma regular expression que remove os caracteres especiais


            foreach (var UmaPlanilha in planilhas) //Inicia um loop por para cada arquivo excel encontrada na pasta informada 
            {
                // open the document read-only
                SpreadsheetDocument document = SpreadsheetDocument.Open(UmaPlanilha, false);
                WorkbookPart workbookPart = document.WorkbookPart;
                bool firstRow = true; //Variavel criada para definir que a primeira linha da planilha irá conter as colunas a serem adicionadas 

                // Cria uma lista para que sejam armazenados os índices.
                var lstIndices = new List<int>();


                foreach (WorksheetPart worksheetPart in document.WorkbookPart.WorksheetParts)
                {
                    foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                    {
                        if (sheetData.HasChildren)
                        {
                            foreach (Row row in sheetData.Elements<Row>())
                            {
                                if (firstRow)
                                {
                                    int indexCells = 0; // Variavel criada para controlar o índice da celula

                                    foreach (Cell cell in row.Elements<Cell>()) //Percorre por todas as celulas da linha para encontrar o(s) índice(s) que contem a palavra E-MAIL
                                    {
                                        var str = ojbRegex.Replace(cell.InnerText.ToString().RemoverAcentuacao(), ""); //Recupera o valor da celula removendo os caracteres especiais e acentuações

                                        if (dicTipo[Etipo].Any(c => c.Contains(str.ToUpper()) || str.ToUpper().Contains(c)))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices
                                        }

                                        indexCells++;
                                    }
                                    firstRow = false;

                                    

                                }
                                else // Percorre o restante das linhas para recuperar os valores dos índices identificados
                                {
                                    string cnpj = null;
                                    string dado = null;
                                    string area = null;

                                    void RecuperarValor(List<int> lista, string valor, EtipoValor tipo)
                                    {
                                        int indexCells = 0;
                                        
                                        //Loop para percorrer as celulas da linha por cada índice encontrado e recuperar os valores da celula.
                                        foreach (var item in lista)
                                        {

                                            foreach (Cell cell in row.Elements<Cell>())
                                            {
                                                try
                                                {
                                                    //CNPJ
                                                    if (indexCells == 3)
                                                    {
                                                        cnpj = cell.InnerText.ToString();
                                                    }

                                                    //VALOR
                                                    if (item == indexCells)
                                                    {
                                                        dado = cell.InnerText.ToString();

                                                    }
                                                    //AREA
                                                    if (indexCells == 13)
                                                    {
                                                        area = cell.InnerText.ToString();
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    throw ex;
                                                }
                                                indexCells++;

                                                // Verifica se os campos de CNPJ e VALOR são diferentes de nulo e vazio.
                                                var dadosValidos = string.IsNullOrEmpty(cnpj) == false && string.IsNullOrEmpty(dado) == false;

                                                if (dadosValidos)
                                                {
                                                    bool contemCONT = listaWordlist.Any(c => dado.Contains(c)); //Verifica se possui alguma palavra da lista de palavras.


                                                    switch (Etipo)
                                                    {
                                                        case EtipoValor.Email:

                                                            if (contemCONT == false) //Verificar se o e-mail não contém "CONT"
                                                            {
                                                                //Verificar se o e-mail consta na blacklist
                                                                var existe = listaBlacklist.Any(c => c.ToUpper().Trim() == dado.ToUpper().Trim());

                                                                if (!existe)
                                                                {
                                                                    dtgeral.Rows.Add(new object[2] { cnpj, dado }); //adiociona ao DataTable
                                                                }
                                                            }
                                                            break;

                                                        case EtipoValor.NuFuncionaros:

                                                            if (area == "ÁREA EMPRESÁRIO" && dado == "0")
                                                            {
                                                                continue;
                                                            }
                                                            else
                                                            {
                                                                dtgeral.Rows.Add(new object[2] { cnpj, dado });
                                                            }

                                                            break;

                                                        case EtipoValor.Telefone:

                                                            dtgeral.Rows.Add(new object[2] { cnpj, dado });

                                                            break;

                                                        case EtipoValor.EmailContador:

                                                            if (contemCONT == true) //Verificar se o e-mail não contém "CONT"
                                                            {
                                                                //Verificar se o e-mail consta na blacklist
                                                                var existe = listaBlacklist.Any(c => c.ToUpper().Trim() == dado.ToUpper().Trim());

                                                                if (!existe)
                                                                {
                                                                    dtgeral.Rows.Add(new object[2] { cnpj, dado }); //adiociona ao DataTable
                                                                }
                                                            }

                                                            break;
                                                        default:
                                                            MessageBox.Show($"Erro ao informar o tipo de valor a ser verificado");
                                                            break;
                                                    }
                                                    break;
                                                }
                                            }

                                            indexCells = 0;
                                        }
                                    }
                                    RecuperarValor(lstIndices, dado, Etipo);
                                }



                            }
                        }
                    }
                }
                document.Dispose();

            }

            dtgeral = dtgeral.DefaultView.ToTable(true, columns); //Remove os valores duplicados do DataTable
            return dtgeral;
        }

        public void Write(DataTable dt, string outputFilePath)
        {
            using (StreamWriter sw = new StreamWriter(outputFilePath, false))
            {
                foreach (DataRow row in dt.Rows)
                {
                    sw.WriteLine($"{row[0]}\t{row[1]}");
                }
                sw.Close();
            }
        }
    }
}
