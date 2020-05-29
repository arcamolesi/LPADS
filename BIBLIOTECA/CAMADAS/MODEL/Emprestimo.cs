using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA.CAMADAS.MODEL
{
    public class Emprestimo
    {
        public int id { get; set; }
        public int clienteID { get; set; }
        public string nomeCli { get; set; }
        public DateTime data { get; set; }

    }
}
