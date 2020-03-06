using System;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Identity;
namespace CasaDeShow.Models {
    public class Evento {

        public int Id { get; set; }
        public string Nome { get; set; }

        public Categoria Categoria { get; set; }
        public CasaShow CasaShow { get; set; }
        public int QuantDeIngressos { get; set; }
        public DateTime Data { get; set; }
        public float ValorDoIngresso { get; set; }

        public string img { get; set; }
       
        public bool Status { get; set; }
        
        
    }
}