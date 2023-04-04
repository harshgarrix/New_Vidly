using New_Vidly.Migrations;
using New_Vidly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace New_Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreTypes> genreTypes { get; set; }
        //public Movie Movie { get; set; }
        
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public byte? GenreTypesId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        [Required]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreTypesId = movie.GenreTypesId;
            DateAdded = movie.DateAdded;
            NumberInStock = movie.NumberInStock;    
            ReleaseDate = movie.ReleaseDate;
        }
    }
}