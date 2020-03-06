using System.ComponentModel.DataAnnotations;
using CasaDeShow.Models;

namespace CasaDeShow.DTO
{
    public class CasaShowDTO
    {
       
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Local { get; set; }
    }
}