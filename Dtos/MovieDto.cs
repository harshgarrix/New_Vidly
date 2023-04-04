using New_Vidly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace New_Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte GenreTypesId { get; set; }

        public GenreTypesDto GenreTypes { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}