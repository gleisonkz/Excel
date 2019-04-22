﻿using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Excel.Class
{
    class Funcoes
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
               
        public DataTable PreencheDataTable(string caminho)
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


            string guiaPlanilha = "Sheet1"; // Cria uma variavel com o nome da guia da planilha que será lida.
            DataTable dtgeral = new DataTable(); // Instanciação de um novo DataTable.
            var columns = new[] { "CNPJ", "VALOR", }; // Cria um array de string.

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

                    // Cria uma lista para que sejam armazenados os índices.
                    var lstIndicesEmails = new List<int>();
                    var lstIndicesTelefones = new List<int>();
                    var lstIndicesNuFuncionarios = new List<int>();

                    // Loop para percorrer a primeira linha da planilha e identificar os índices das colunas.

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
                                if (str.ToUpper().Contains("FUNCIONÁRIOS") || str.ToUpper().Contains("EMPREGADOS") || str.ToUpper().Contains("FUNCIONARIOS"))
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

                                    if (cnpj != "" && cnpj != null) //Verifica se o CNPJ é vazio ou nulo
                                    {

                                        if (valor != "" && valor != null) //Verifica se o campo VALOR é vazio ou nulo
                                        {

                                            if (valor == "0" && area.ToUpper() == "ÁREA EMPRESÁRIO") // Verifica se o valor é 0 e pertence a área do empresário
                                            {
                                                continue;
                                            }

                                            else
                                            {
                                                dtgeral.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
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
            dtgeral = dtgeral.DefaultView.ToTable(true, columns); //Remove os valores duplicados do DataTable

            return dtgeral;
        }

        public DataTable PreencheDataTable(string caminho, EtipoValor Etipo)
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


            string guiaPlanilha = "Sheet1"; // Cria uma variavel com o nome da guia da planilha que será lida.
            DataTable dtgeral = new DataTable(); // Instanciação de um novo DataTable.
            var columns = new[] { "CNPJ", "VALOR", }; // Cria um array de string.

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

                    // Cria uma lista para que sejam armazenados os índices.
                    var lstIndices = new List<int>();

                    // Loop para percorrer a primeira linha da planilha e identificar os índices das colunas.

                    foreach (IXLRow row in workSheet.Rows())
                    {
                        if (firstRow) //Usa a primeira linha para adicionar as colunas no DataTable.
                        {
                            Regex ojbRegex = new System.Text.RegularExpressions.Regex(@"\W"); //Cria um ojbeto contendo uma regular expression que remove os caracteres especiais

                            int indexCells = 0; // Variavel criada para controlar o índice da celula

                            foreach (IXLCell cell in row.Cells()) //Percorre por todas as celulas da linha para encontrar o(s) índice(s) que contem a palavra E-MAIL
                            {
                                var str = ojbRegex.Replace(cell.Value.ToString(), ""); //Recupera o valor da celula removendo os caracteres especiais


                                switch (Etipo)
                                {
                                    case EtipoValor.Email:

                                        if (str.ToUpper().Contains("EMAIL"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices

                                        }
                                        break;
                                    case EtipoValor.NuFuncionaros:

                                        if (str.ToUpper().Contains("FUNCIONÁRIOS"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices
                                        }
                                        break;
                                    case EtipoValor.Telefone:

                                        if (str.ToUpper().Contains("TELEFONE"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices
                                        }
                                        break;
                                    case EtipoValor.EmailContador:

                                        if (str.ToUpper().Contains("EMAIL"))
                                        {
                                            lstIndices.Add(indexCells); //Adiciona a lista de índices

                                        }
                                        break;
                                    default:
                                        MessageBox.Show($"Erro ao informar o tipo de valor a ser verificado");
                                        break;
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

                                            //TIPO VALOR - Nuempregados - Telefone - parametro passado no construtor
                                            if (item == indexCells)
                                            {
                                                dado = cell.Value.ToString();

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


                                        switch (Etipo)
                                        {
                                            case EtipoValor.Email:


                                                if (cnpj != "" && cnpj != null) //Verifica se o CNPJ é vazio ou nulo
                                                {
                                                    if (dado != "" && dado != null) //Verifica se o campo VALOR é vazio ou nulo
                                                    {
                                                        bool contemCONT = dado.Contains("CONT"); //Discarta os registros que contenham "CONT"

                                                        if (contemCONT == false) //adiociona ao DataTable
                                                        {
                                                            dtgeral.Rows.Add(new object[2] { cnpj, dado });
                                                        }

                                                    }
                                                }
                                                break;

                                            case EtipoValor.NuFuncionaros:

                                                if (cnpj != "" && cnpj != null) //Verifica se o CNPJ é vazio ou nulo
                                                {
                                                    if (dado != "" && dado != null) //Verifica se o campo VALOR é vazio ou nulo
                                                    {
                                                        if (area == "ÁREA EMPRESÁRIO" && dado == "0")
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            dtgeral.Rows.Add(new object[2] { cnpj, dado });
                                                        }

                                                    }
                                                }
                                                break;

                                            case EtipoValor.Telefone:

                                                if (cnpj != "" && cnpj != null) //Verifica se o CNPJ é vazio ou nulo
                                                {
                                                    if (dado != "" && dado != null) //Verifica se o campo VALOR é vazio ou nulo
                                                    {
                                                        dtgeral.Rows.Add(new object[2] { cnpj, dado });
                                                    }
                                                }
                                                break;

                                            case EtipoValor.EmailContador:

                                                if (cnpj != "" && cnpj != null) //Verifica se o CNPJ é vazio ou nulo
                                                {
                                                    if (dado != "" && dado != null) //Verifica se o campo VALOR é vazio ou nulo
                                                    {
                                                        bool contemCONT = dado.Contains("CONT"); //Discarta os registros que contenham "CONT"

                                                        if (contemCONT) //adiociona ao DataTable
                                                        {
                                                            dtgeral.Rows.Add(new object[2] { cnpj, dado });
                                                        }

                                                    }
                                                }
                                                break;
                                            default:
                                                MessageBox.Show($"Erro ao informar o tipo de valor a ser verificado");
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

            dtgeral = dtgeral.DefaultView.ToTable(true, columns); //Remove os valores duplicados do DataTable
            return dtgeral; // Retorna o DataTable tratado.
        }

        public void Write(DataTable dt, string outputFilePath)
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
    }
}
  