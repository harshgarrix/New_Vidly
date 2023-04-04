using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace New_Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreTypes GenreTypes { get; set; }
        
        [Display(Name = "Genre Type")]
        [Required]
        public byte GenreTypesId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}