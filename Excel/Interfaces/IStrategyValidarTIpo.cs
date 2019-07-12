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
        void Execute(string cnpj, string valor, DataTable dataTable, List<Tuple<string,string>> listaPendencias, string area = "");
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoEmailEmpresa : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaTipoEmailContador;
        private readonly List<string> listaTipoEmailEmpresa;
        private readonly List<Tuple<string, string>> listaPendencias;

        public StrategyValidacoesTipoEmailEmpresa(List<string> listaBlacklist, List<string> listaTipoEmailContador, List<string> listaTipoEmailEmpresa, List<Tuple<string, string>> listaPendencias)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaTipoEmailContador = listaTipoEmailContador;
            this.listaTipoEmailEmpresa = listaTipoEmailEmpresa;
            this.listaPendencias = listaPendencias;
        }

        public void Execute(string cnpj, string valor, DataTable dataTable, List<Tuple<string, string>> listaPendencias, string area = "")
        {
            //Verifica se o e-mail consta na blacklist
            bool existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na emaillist
            bool existeNalistaTipoEmailEmpresa = listaTipoEmailEmpresa.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na wordlist
            bool existeNalistaTipoEmailContador = listaTipoEmailContador.Any(c => valor.Contains(c));


            if (existeNalistaTipoEmailContador == false && existeNaBlacklist == false && existeNalistaTipoEmailEmpresa == true)
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
            }

            if (existeNaBlacklist == false && existeNalistaTipoEmailContador == true && existeNalistaTipoEmailEmpresa == true)
            {
                var item = new Tuple<string, string>( cnpj, valor + '\t' + "Registro existente nas duas listas de classificações" );
                listaPendencias.Add(item);
            }
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoEmailContador : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaTipoEmailContador;
        private readonly List<string> listaTipoEmailEmpresa;
        private readonly List<Tuple<string, string>> listaPendencias;

        public StrategyValidacoesTipoEmailContador(List<string> listaBlacklist, List<string> listaTipoEmailContador, List<string> listaTipoEmailEmpresa, List<Tuple<string, string>> listaPendencias)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaTipoEmailContador = listaTipoEmailContador;
            this.listaTipoEmailEmpresa = listaTipoEmailEmpresa;
            this.listaPendencias = listaPendencias;
        }

        public void Execute(string cnpj, string valor, DataTable dataTable, List<Tuple<string, string>> listaPendencias, string area = "")
        {
            //Verifica se o e-mail consta na blacklist
            bool existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na emaillist
            bool existeNalistaTipoEmailEmpresa = listaTipoEmailEmpresa.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na wordlist
            bool existeNalistaTipoEmailContador = listaTipoEmailContador.Any(c => valor.Contains(c)); 


            if (existeNalistaTipoEmailContador == true && existeNaBlacklist == false && existeNalistaTipoEmailEmpresa == false)
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
            }

            //if (existeNaBlacklist == false && existeNalistaTipoEmailContador == true && existeNalistaTipoEmailEmpresa == true)
            //{
            //    var item = new Tuple<string, string>(cnpj, valor);
            //    listaPendencias.Add(item);
            //}
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoEmailNaoClassificado : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaWordlist;
        private readonly List<string> listaEmailList;

        public StrategyValidacoesTipoEmailNaoClassificado(List<string> listaBlacklist, List<string> listaWordlist, List<string> listaEmailList)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
            this.listaEmailList = listaEmailList;
        }

        public void Execute(string cnpj, string valor, DataTable dataTable, List<Tuple<string, string>> listaPendencias, string area = "")
        {
            //Verifica se o e-mail consta na blacklist
            bool existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na emaillist
            bool existeNaEmaillist = listaEmailList.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na wordlist
            bool existeNaWordlist = listaWordlist.Any(c => valor.Contains(c));


            if (existeNaWordlist == false && existeNaBlacklist == false && existeNaEmaillist == false)
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
            }
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoTelefone : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaWordlist;

        public StrategyValidacoesTipoTelefone(List<string> listaBlacklist, List<string> listaWordlist)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
        }

        public void Execute(string cnpj, string valor, DataTable dataTable, List<Tuple<string, string>> listaPendencias, string area = "")
        {
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor });
            }
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoNuEmpregados : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaWordlist;

        public StrategyValidacoesTipoNuEmpregados(List<string> listaBlacklist, List<string> listaWordlist)
        {
            this.listaBlacklist = listaBlacklist;
            this.listaWordlist = listaWordlist;
        }

        public void Execute(string cnpj, string valor, DataTable dataTable, List<Tuple<string, string>> listaPendencias, string area = "")
        {
            
            if (area.ToUpper() == "ÁREA EMPRESÁRIO" && valor == "0")
            {
                    
            }
            else
            {
                dataTable.Rows.Add(new object[2] { cnpj, valor });
            }
            
        }
    }

    //=============================================================================================================================================================

}