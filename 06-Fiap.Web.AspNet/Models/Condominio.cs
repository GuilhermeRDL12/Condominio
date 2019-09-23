using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _06_Fiap.Web.AspNet.Models
{
    [Table("TblCondominio")]
    public class Condominio
    {
        [HiddenInput]
        public int CondominioId { get; set; }
        [Required, MaxLength(40)]
        public string Nome { get; set; }
        public int Blocos { get; set; }
        public bool Ativo { get; set; }
        public Tipo Tipo { get; set; }

        //Relacionamentos
        public Sindico Sindico { get; set; }
        public int SindicoId { get; set; }

        public IList<Imovel> Imoveis { get; set; }

        public IList<CondominioConstrutora> CondominioConstrutoras { get; set; }

    }
}
