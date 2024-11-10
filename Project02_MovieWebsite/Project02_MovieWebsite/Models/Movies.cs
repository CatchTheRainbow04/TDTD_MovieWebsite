using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project02_MovieWebsite.Models
{
    public class Movies
    {
        [Key]
        public int MovieID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ReleaseYear { get; set; }
        public Nullable<int> Duration { get; set; }
        public string VideoURL { get; set; }
        public string ThumbnailURL { get; set; }

        [Range(1.0, 5.0, ErrorMessage = "Rating must be between 1 and 5 !")]
        public Nullable<double> Rating { get; set; }

        public Nullable<int> GenreID { get; set; }

        public virtual Genres Genres { get; set; }
    }
}