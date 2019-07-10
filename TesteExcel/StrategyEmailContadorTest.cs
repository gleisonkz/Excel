using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Excel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Excel.Class.Funcoes;

namespace TesteExcel
{
    [TestClass]
    public class StrategyEmailContadorTest
    {
        public Dictionary<EtipoValor, string[]> dicTipo = new Dictionary<EtipoValor, string[]>
        {
            { EtipoValor.Email, new [] { "EMAIL" } },
            { EtipoValor.Telefone, new [] { "TELEFONE" } },
            { EtipoValor.EmailContador, new [] { "EMAIL" } },
            { EtipoValor.NuFuncionaros, new [] { "FUNCIONARIOS","EMPREGADOS" } }
        };

        public class Contato
        {
            public EtipoValor Tipo { get; set; }
        }

        public void LeituraDoArquivo()
        {
            var dicStrategy = new Dictionary<EtipoValor, IStrategyValidações>();

            var listaContato = new List<Contato>();
            var columns = new string[0];
            var Rows = new string[0];
            var planilhas = new string[0];

            //Leitura
            foreach (var itemPlanilha in planilhas)
            {
                foreach (var itemTipo in dicTipo)
                {
                    var indiceDaColuna = -1;
                    var firstRow = true;

                    foreach (var row in Rows)
                    {
                        if (firstRow)
                        {

                            for (int indexColumn = 0; indexColumn < columns.Length; indexColumn++)
                            {
                                if (itemTipo.Value.Contains(columns[indexColumn]))
                                {
                                    indiceDaColuna = indexColumn;
                                    firstRow = false;
                                    break;
                                }
                            }

                            if (indiceDaColuna == -1)
                                continue;
                        }
                        else
                        {
                            foreach (var rowCell in Rows)
                            {
                                var strategy = dicStrategy[itemTipo.Key];

                                string cnpj = null;
                                string valor = null;

                                //strategy.Execute(cnpj, valor, listaContato);
                                //listaContato.Add(new Contato { Tipo = itemTipo.Key });
                            }
                        }
                    }

                }
            }

        }


        [TestMethod]
        public void TesteEmailNaoEncontradoWordList()
        {
            var strategy = new IStrategyValidaçõesTipoEmailContador(new List<string>(), new List<string> { "teste@feomerciomg.org.br" }, new List<string>());

            DataTable dtgeral = new DataTable();
            var columns = new[] { "CNPJ", "VALOR", };
            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            strategy.Execute("17271982000159", "gleison@feomerciomg.org.br", dtgeral);

            Assert.IsFalse(dtgeral.Rows.Count > 0);
        }

        [TestMethod]
        public void TesteEmailEncontradoWordListSemBlacklist()
        {
            var strategy = new IStrategyValidaçõesTipoEmailContador(new List<string>(), new List<string> { "gleison@feomerciomg.org.br" }, new List<string>());

            DataTable dtgeral = new DataTable();
            var columns = new[] { "CNPJ", "VALOR", };
            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            strategy.Execute("17271982000159", "gleison@feomerciomg.org.br", dtgeral);

            Assert.AreEqual(1, dtgeral.Rows.Count);
        }

        [TestMethod]
        public void TesteEmailEncontradoWordListComBlacklist()
        {
            var strategy = new IStrategyValidaçõesTipoEmailContador(new List<string> { "gleison@feomerciomg.org.br" }, new List<string> { "gleison@feomerciomg.org.br" }, new List<string>());

            DataTable dtgeral = new DataTable();
            var columns = new[] { "CNPJ", "VALOR", };
            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            strategy.Execute("17271982000159", "gleison@feomerciomg.org.br", dtgeral);

            Assert.AreEqual(0, dtgeral.Rows.Count);
        }
        [TestMethod]
        public void TesteEmailEncontradoWordListSemBlacklistComEmailList()
        {
            var strategy = new IStrategyValidaçõesTipoEmailContador(new List<string> { "teste@feomerciomg.org.br" }, new List<string> { "gleison@feomerciomg.org.br" }, new List<string> { "gleison@feomerciomg.org.br" });

            DataTable dtgeral = new DataTable();
            var columns = new[] { "CNPJ", "VALOR", };
            dtgeral.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            strategy.Execute("17271982000159", "gleison@feomerciomg.org.br", dtgeral);

            Assert.AreEqual(0, dtgeral.Rows.Count);
        }

    }
}
