using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project02_MovieWebsite.Models
{
    public class Genres
    {
        [Key]
        public int GenreID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}