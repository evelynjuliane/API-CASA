using System;
using System.ComponentModel.DataAnnotations;
using CasaDeShow.Models;

namespace CasaDeShow.DTO
{
    public class EventoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public int CasaShowID { get; set; }
        [Required]
        public int QuantDeIngressos { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public float ValorDoIngresso{ get; set; }
 
        
        public string img { get; set; }
        
    }
}