using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel.Class;
using static Excel.Class.Funcoes;

namespace Excel.Interfaces
{
    //=============================================================================================================================================================

    public interface IStrategyValidações
    {
        void Execute(string cnpj, string valor, DataTable dataTable, string area = "");
    }

    //=============================================================================================================================================================

    public class IStrategyValidaçõesTipoEmail : IStrategyValidações
    {
        private List<string> listaBlacklist;
        private List<string> listaWordlist;
        private List<string> listaEmailList;

        public IStrategyValidaçõesTipoEmail(List<string> listaBlacklist, List<string> listaWordlist, List<string> listaEmailList)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
            this.listaEmailList = listaEmailList;
        }
        public void Execute(string cnpj, string valor, DataTable dataTable, string area = "")
        {
            bool contemCONT = listaWordlist.Any(c => valor.Contains(c)); //Verifica se possui alguma palavra da lista de palavras.

            if (contemCONT == false) //Verificar se o e-mail não contém nenhuma das palavras definidas na wordlist.
            {
                //Verificar se o e-mail consta na blacklist
                var existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());
                var existeNaEmaillist = listaEmailList.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

                if (existeNaBlacklist == false || existeNaEmaillist == true)
                {
                    dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                }
            }
        }
    }

    //=============================================================================================================================================================

    public class IStrategyValidaçõesTipoEmailContador : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaWordlist;
        private readonly List<string> listaEmailList;

        public IStrategyValidaçõesTipoEmailContador(List<string> listaBlacklist, List<string> listaWordlist, List<string> listaEmailList)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
            this.listaEmailList = listaEmailList;
        }
        public void Execute(string cnpj, string valor, DataTable dataTable, string area = "")
        {
            bool contemCONT = listaWordlist.Any(c => valor.Contains(c)); //Verifica se possui alguma palavra da lista de palavras.

            if (contemCONT == true) //Verificar se o e-mail não contém "CONT"
            {
                //Verificar se o e-mail consta na blacklist
                var existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());
                var existeNaEmaillist = listaEmailList.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

                if (existeNaBlacklist == false && existeNaEmaillist == false)
                {
                    dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                }
            }
        }
    }

    //=============================================================================================================================================================

    public class IStrategyValidaçõesTipoTelefone : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaWordlist;

        public IStrategyValidaçõesTipoTelefone(List<string> listaBlacklist, List<string> listaWordlist)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
        }
        public void Execute(string cnpj, string valor, DataTable dataTable, string area = "")
        {
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor });
            }
        }
    }

    //=============================================================================================================================================================

    public class IStrategyValidaçõesTipoNuEmpregados : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaWordlist;

        public IStrategyValidaçõesTipoNuEmpregados(List<string> listaBlacklist, List<string> listaWordlist)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
        }
        public void Execute(string cnpj, string valor, DataTable dataTable,  string area = "")
        {
            {

                if (area == "ÁREA EMPRESÁRIO" && valor == "0")
                {
                    
                }
                else
                {
                    dataTable.Rows.Add(new object[2] { cnpj, valor });
                }
            }
        }
    }

    //=============================================================================================================================================================

}