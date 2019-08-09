using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Excel.Class.FuncoesNovaEstrutura;

namespace Excel.Class
{
    //public class ContatoComparer : IEqualityComparer<Contato>
    //{
    //    public static ContatoComparer Instance { get; } = new ContatoComparer();

    //    private ContatoComparer()
    //    {

    //    }
    //    public bool Equals(Contato x, Contato y)
    //    {
    //        return x.Equals(y);
    //    }

    //    public int GetHashCode(Contato obj)
    //    {
    //        return obj.CPFCNPJ.GetHashCode();
    //    }
    //}

    public class Contato : IEquatable<Contato>
    {
        public string CPFCNPJ { get; set; }
        public string Valor { get; set; }
        public EtipoValor Tipo { get; set; }

        public bool Equals(Contato other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;

            if (Object.ReferenceEquals(this, other))
                return false;

            if (this.CPFCNPJ.Equals(other.CPFCNPJ) && this.Valor.Equals(other.Valor) && this.Tipo.Equals(other.Tipo))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            var hashCNPJ = (this.CPFCNPJ ?? "").GetHashCode();
            var hashValor = (this.Valor ?? "").GetHashCode();
            var hashTipo = this.Tipo.GetHashCode();
            return hashCNPJ ^ hashValor ^ hashTipo;
        }
    }
}
