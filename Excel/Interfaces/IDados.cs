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
       List<string> ListaBlacklist { get; set; }
       List<string> ListaTipoEmailContador { get; set; }
       List<string> ListaTipoEmailEmpresa { get; set; }
       List<Tuple<string, string>> ListaPendencias { get; set; }
       List<Contato> ListaContato { get; }
    }
}
