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
    public interface IStrategyValidações
    {
        void Execute(string cnpj, string valor, EtipoValor tipo, DataTable dataTable, List<string> listaBlacklist, List<string> listaWordlist, string area = "");
    }

    public class IStrategyValidaçõesTipoEmail : IStrategyValidações
    {
        public void Execute(string cnpj, string valor, EtipoValor tipo, DataTable dataTable, List<string> listaBlacklist, List<string> listaWordlist, string area = "")
        {
            bool contemCONT = listaWordlist.Any(c => cnpj.Contains(c)); //Verifica se possui alguma palavra da lista de palavras.

            if (contemCONT == false) //Verificar se o e-mail não contém nenhuma das palavras definidas na wordlist.
            {
                //Verificar se o e-mail consta na blacklist
                var existe = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

                if (!existe)
                {
                    dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                }
            }
        }
    }

    public class IStrategyValidaçõesTipoEmailContador : IStrategyValidações
    {
        public void Execute(string cnpj, string valor, EtipoValor tipo, DataTable dataTable, List<string> listaBlacklist, List<string> listaWordlist, string area = "")
        {
            bool contemCONT = listaWordlist.Any(c => cnpj.Contains(c)); //Verifica se possui alguma palavra da lista de palavras.

            if (contemCONT == true) //Verificar se o e-mail não contém "CONT"
            {
                //Verificar se o e-mail consta na blacklist
                var existe = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

                if (!existe)
                {
                    dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                }
            }
        }
    }

    public class IStrategyValidaçõesTipoTelefone : IStrategyValidações
    {
        public void Execute(string cnpj, string valor, EtipoValor tipo, DataTable dataTable, List<string> listaBlacklist, List<string> listaWordlist, string area = "")
        {
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor });
            }
        }
    }

    public class IStrategyValidaçõesTipoNuEmpregados : IStrategyValidações
    {
        public void Execute(string cnpj, string valor, EtipoValor tipo, DataTable dataTable, List<string> listaBlacklist, List<string> listaWordlist, string area = "")
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



}