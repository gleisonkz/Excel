using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Excel.Interfaces;
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
        public enum EtipoValor
        {
            Email = 1,
            NuFuncionaros = 2,
            Telefone = 3,
            EmailContador = 4,
            EmailNaoClassificado = 5
        }

        //=============================================================================================================================================================

        public Dictionary<EtipoValor, string[]> dicTipo = new Dictionary<EtipoValor, string[]>
        {
            { EtipoValor.Email, new [] { "EMAIL" } },
            { EtipoValor.Telefone, new [] { "TELEFONE" } },
            { EtipoValor.EmailContador, new [] { "EMAIL" } },
            { EtipoValor.NuFuncionaros, new [] { "FUNCIONARIOS","EMPREGADOS" } },
            { EtipoValor.EmailNaoClassificado, new [] { "EMAIL" } }
        };

        //=============================================================================================================================================================

        public Funcoes()
        {
        }

        //=============================================================================================================================================================

        public Funcoes(StrategyValidacoesTipoEmailEmpresa strategyValidacoesTipoEmail,
                       StrategyValidacoesTipoEmailContador strategyValidacoesTipoEmailContador,
                       StrategyValidacoesTipoTelefone strategyValidacoesTipoTelefone,
                       StrategyValidacoesTipoNuEmpregados strategyValidacoesTipoNuEmpregados,
                       StrategyValidacoesTipoEmailNaoClassificado strategyValidacoesTipoEmailNaoClassificado,
                       List<Tuple<string, string>> listaPendencias
                       )
        {
            this.strategyValidacoesTipoEmail = strategyValidacoesTipoEmail;
            this.strategyValidacoesTipoEmailContador = strategyValidacoesTipoEmailContador;
            this.strategyValidacoesTipoTelefone = strategyValidacoesTipoTelefone;
            this.strategyValidacoesTipoNuEmpregados = strategyValidacoesTipoNuEmpregados;
            this.strategyValidacoesTipoEmailNaoClassificado = strategyValidacoesTipoEmailNaoClassificado;
            this.listaPendencias = listaPendencias;
        }

        private readonly StrategyValidacoesTipoEmailEmpresa strategyValidacoesTipoEmail;
        private readonly StrategyValidacoesTipoEmailContador strategyValidacoesTipoEmailContador;
        private readonly StrategyValidacoesTipoTelefone strategyValidacoesTipoTelefone;
        private readonly StrategyValidacoesTipoNuEmpregados strategyValidacoesTipoNuEmpregados;
        private readonly StrategyValidacoesTipoEmailNaoClassificado strategyValidacoesTipoEmailNaoClassificado;
        private readonly List<Tuple<string, string>> listaPendencias;

        //=============================================================================================================================================================

        ///<summary>
        ///Recupera informações de uma planilha para preencher o DataTable.
        ///</summary>
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

        //=============================================================================================================================================================

        ///<summary>
        ///Recupera informações de uma planilha para preencher o DataTable de acordo com o tipo valor informado.
        ///</summary>
        public DataTable PreencheDataTableOpenXML(string caminho, EtipoValor Etipo, List<string> listaBlacklist, List<string> listaWordlist, List<string> listaEmaillist, List<Tuple<string,string>> listaPendencias)
        {
            //Cria um array contendo o caminho dos arquivos da pasta selecionada pelo usuário.
            string[] planilhas = Directory.GetFiles(caminho, "*.xlsx");

            var strategy = CreateStrategyValidações(Etipo, listaBlacklist, listaWordlist, listaEmaillist);

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
                var IndiceCNPJCPF = 0 ;


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

                                        if (str.ToUpper().Contains("CNPJ"))
                                        {
                                            IndiceCNPJCPF = indexCells;
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

                                    void RecuperarValor(List<int> lista, int indiceCNPJ, string valor, EtipoValor tipo)
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
                                                    if (indexCells == indiceCNPJ)
                                                    {
                                                        cnpj = cell.InnerText.ToString();
                                                    }

                                                    //VALOR
                                                    if (item == indexCells)
                                                    {
                                                        if (cell.InnerText != "")
                                                        {
                                                            dado = cell.InnerText.ToString();
                                                        }                                                      

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
                                            }

                                            indexCells = 0;

                                            // Verifica se os campos de CNPJ e VALOR são diferentes de nulo e vazio.
                                            var dadosValidos = string.IsNullOrEmpty(cnpj) == false && string.IsNullOrEmpty(dado) == false;

                                            if (dadosValidos)
                                            {
                                                strategy.Execute(cnpj, dado, dtgeral, listaPendencias, area);
                                            }
                                        }


                                    }
                                    RecuperarValor(lstIndices, IndiceCNPJCPF, dado, Etipo);


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

        //=============================================================================================================================================================

        ///<summary>
        ///Escreve as informações contidas no DataTable em um arquivo.
        ///</summary>
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

        //=============================================================================================================================================================

        ///<summary>
        ///Cria a estratégia de validações acordo com tipo informado.
        ///</summary>
        private IStrategyValidações CreateStrategyValidações(EtipoValor etipoValor, List<string> listaBlacklist, List<string> listaWordlist, List<string> listaEmailList)
        {
            IStrategyValidações strategy = null;

            switch (etipoValor)
            {              
                case EtipoValor.Email:
                    strategy =  new StrategyValidacoesTipoEmailEmpresa(listaBlacklist,listaWordlist,listaEmailList, listaPendencias);
                    break;
                case EtipoValor.NuFuncionaros:
                    strategy = new  StrategyValidacoesTipoNuEmpregados(listaBlacklist, listaWordlist);
                    break;
                case EtipoValor.Telefone:
                    strategy = new StrategyValidacoesTipoTelefone(listaBlacklist, listaWordlist);
                    break;
                case EtipoValor.EmailContador:
                    strategy = new StrategyValidacoesTipoEmailContador(listaBlacklist, listaWordlist, listaEmailList, listaPendencias);
                    break;
                case EtipoValor.EmailNaoClassificado:
                    strategy = new StrategyValidacoesTipoEmailNaoClassificado(listaBlacklist, listaWordlist, listaEmailList);
                    break;
                default:
                    break;
            }

            return strategy;
        }

        //=============================================================================================================================================================

    }
}
