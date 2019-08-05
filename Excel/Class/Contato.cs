using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Excel.Class.FuncoesNovaEstrutura;

namespace Excel.Class
{
    public class Contato
    {
        public string CPFCNPJ { get; set; }
        public string Valor { get; set; }
        public EtipoValor Tipo { get; set; }
    }
}
