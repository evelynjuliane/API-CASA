using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CasaDeShow.DTO {
    public class CategoriaDTO {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string img { get; set; }

    }
}