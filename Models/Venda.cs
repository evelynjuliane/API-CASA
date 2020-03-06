using System;
using System.Collections.Generic;
using CasaDeShow.Areas;
using Microsoft.AspNetCore.Identity;

namespace CasaDeShow.Models {
    public class Venda {
        public int Id { get; set; }
        public string User { get; set; }
         public string Nome { get; set; }

        public int QuantidadeDeIngressos { get; set; }

        public DateTime Data { get; set; }

        public double ValorDeIngressos { get; set; }

        public CasaShow CasaShow { get; set; }
        public Categoria Categoria { get; set; }

       
        public int EventoID { get; set; }
        
        public int QuantidadeComprada{ get; set; }
        public double Total{ get; set; }

        public bool Status { get; set; }

    }
}