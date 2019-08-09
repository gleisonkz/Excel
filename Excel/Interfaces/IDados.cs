using Excel.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Interfaces
{
    public interface IDados
    {
        HashSet<string> ListaBlacklist { get; set; }
        HashSet<string> ListaTipoEmailContador { get; set; }
        HashSet<string> ListaTipoEmailEmpresa { get; set; }
        List<Tuple<string, string>> ListaPendencias { get; set; }
        List<Contato> ListaContato { get; }
    }
}
