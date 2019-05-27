using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Excel.Class.Funcoes;

namespace Excel.Interfaces
{
    public interface IStrategyValidações
    {
        void Execute(string cnpj, string valor, EtipoValor tipo);
    }

    public interface IStrategyValidaçõesTipoEmail : IStrategyValidações
    {
                     
    }

    public interface IStrategyValidaçõesTipoEmailContador : IStrategyValidações
    {

    }

    public interface IStrategyValidaçõesTipoTelefone : IStrategyValidações
    {

    }

    public interface IStrategyValidaçõesTipoNuEmpregados : IStrategyValidações
    {

    }
}
