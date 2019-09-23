using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_Fiap.Web.AspNet.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }
        public string Numero { get; set; }
        public float AreaUtil { get; set; }
        //Relacionamentos
        public Condominio Condominio { get; set;}
        public int CondominioId { get; set; }
    }
}
