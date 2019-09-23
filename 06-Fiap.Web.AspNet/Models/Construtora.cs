using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_Fiap.Web.AspNet.Models
{
    public class Construtora
    {
        public int ConstrutoraId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        //Relacionamentos
        public IList<CondominioConstrutora> CondominioConstrutoras { get; set; }

    }
}
