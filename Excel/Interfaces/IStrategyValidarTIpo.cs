using Excel.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using static Excel.Class.FuncoesNovaEstrutura;

namespace Excel.Interfaces
{
    //=============================================================================================================================================================

    public interface IStrategyValidações
    {
        void Execute(string cnpj, string valor, string area);
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoEmailEmpresa : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaTipoEmailContador;
        private readonly List<string> listaTipoEmailEmpresa;
        private readonly List<Tuple<string, string>> listaPendencias;
        private readonly List<Contato> listaContatos;

        public StrategyValidacoesTipoEmailEmpresa(IDados obj)
        {
            this.listaBlacklist = obj.ListaBlacklist;
            this.listaTipoEmailContador = obj.ListaTipoEmailContador;
            this.listaTipoEmailEmpresa = obj.ListaTipoEmailEmpresa;
            this.listaPendencias = obj.ListaPendencias;
            this.listaContatos = obj.ListaContato;
        }

        public void Execute(string cnpj, string valor, string area)
        {
            //Verifica se o e-mail consta na blacklist
            bool existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na lista de email tipo empresa
            bool existeNalistaTipoEmailEmpresa = listaTipoEmailEmpresa.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na lista de email tipo contador
            bool existeNalistaTipoEmailContador = listaTipoEmailContador.Any(c => valor.Contains(c));


            if (existeNalistaTipoEmailContador == false && existeNaBlacklist == false && existeNalistaTipoEmailEmpresa == true)
            {
                //dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                listaContatos.Add(new Contato { CPFCNPJ = cnpj, Tipo = EtipoValor.Email, Valor = valor });
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
        private readonly List<Contato> listaContatos;

        public StrategyValidacoesTipoEmailContador(IDados obj)
        {
            this.listaBlacklist = obj.ListaBlacklist;
            this.listaTipoEmailContador = obj.ListaTipoEmailContador;
            this.listaTipoEmailEmpresa = obj.ListaTipoEmailEmpresa;
            this.listaPendencias = obj.ListaPendencias;
            this.listaContatos = obj.ListaContato;
        }

        public void Execute(string cnpj, string valor, string area)
        {
            //Verifica se o e-mail consta na blacklist
            bool existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na emaillist
            bool existeNalistaTipoEmailEmpresa = listaTipoEmailEmpresa.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na wordlist
            bool existeNalistaTipoEmailContador = listaTipoEmailContador.Any(c => valor.Contains(c)); 


            if (existeNalistaTipoEmailContador == true && existeNaBlacklist == false && existeNalistaTipoEmailEmpresa == false)
            {
                //dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                listaContatos.Add(new Contato { CPFCNPJ = cnpj, Tipo = EtipoValor.EmailContador, Valor = valor });
            }

            if (existeNaBlacklist == false && existeNalistaTipoEmailContador == true && existeNalistaTipoEmailEmpresa == true)
            {
                var item = new Tuple<string, string>(cnpj, valor);
                listaPendencias.Add(item);
            }
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoEmailNaoClassificado : IStrategyValidações
    {
        private readonly List<string> listaBlacklist;
        private readonly List<string> listaTipoEmailContador;
        private readonly List<string> listaTipoEmailEmpresa;
        private readonly List<Contato> listaContatos;

        public StrategyValidacoesTipoEmailNaoClassificado(IDados obj)
        {
            this.listaBlacklist = obj.ListaBlacklist;
            this.listaTipoEmailContador = obj.ListaTipoEmailContador;
            this.listaTipoEmailEmpresa = obj.ListaTipoEmailEmpresa;
            this.listaContatos = obj.ListaContato;
        }

        public void Execute(string cnpj, string valor, string area)
        {
            //Verifica se o e-mail consta na blacklist
            bool existeNaBlacklist = listaBlacklist.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na lista de email tipo empresa
            bool existeNalistaTipoEmailEmpresa = listaTipoEmailEmpresa.Any(c => c.ToUpper().Trim() == valor.ToUpper().Trim());

            //Verifica se o e-mail consta na lista de email tipo contador
            bool existeNalistaTipoEmailContador = listaTipoEmailContador.Any(c => valor.Contains(c));


            if (existeNalistaTipoEmailContador == false && existeNaBlacklist == false && existeNalistaTipoEmailEmpresa == false)
            {
                //dataTable.Rows.Add(new object[2] { cnpj, valor }); //adiociona ao DataTable
                listaContatos.Add(new Contato { CPFCNPJ = cnpj, Tipo = EtipoValor.EmailNaoClassificado, Valor = valor });
            }
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoTelefone : IStrategyValidações
    {
        private readonly List<Contato> listaContatos;

        public StrategyValidacoesTipoTelefone(IDados obj)
        {
            this.listaContatos = obj.ListaContato;
        }


        public void Execute(string cnpj, string valor, string area)
        {
            bool telefoneValido = Regex.IsMatch(valor, @"^[(]{1}\d{2}[)]{1}[ ]\d{4,5}[-]\d{4}");

            if (telefoneValido)
            {
                //dataTable.Rows.Add(new object[2] { cnpj, valor });
                listaContatos.Add(new Contato { CPFCNPJ = cnpj, Tipo = EtipoValor.Telefone, Valor = valor });
            }         
            
        }
    }

    //=============================================================================================================================================================

    public class StrategyValidacoesTipoNuEmpregados : IStrategyValidações
    {
        private readonly List<Contato> listaContatos;

        public StrategyValidacoesTipoNuEmpregados(IDados obj)
        {
            this.listaContatos = obj.ListaContato;
        }

        public void Execute(string cnpj, string valor, string area)
        {
            bool nuEmpregadosValido = Regex.IsMatch(valor, @"^\d{1,10}");

            if (nuEmpregadosValido == false)
            {
                return;
            }

            if (area.ToUpper() == "ÁREA EMPRESÁRIO" && valor == "0")
            {
                    
            }
            else
            {
                //dataTable.Rows.Add(new object[2] { cnpj, valor });
                listaContatos.Add(new Contato { CPFCNPJ = cnpj, Tipo = EtipoValor.NuFuncionaros, Valor = valor });
            }            
        }
    }

    //=============================================================================================================================================================

}