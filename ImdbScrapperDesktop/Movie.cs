using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImdbScrapperDesktop
{
    public enum Genre
    {
        Action=1,
        Adventure,
        Animation,
        Biography,
        Comedy,
        Crime,
        Documentary,
        Drama,
        Family,
        Fantasy,
        FilmNoir,
        History,
        Horror,
        Music,
        Musical,
        Mystery,
        Romance,
        SciFi,
        ShortFilm,
        Sport,
        Superhero,
        Thriller,
        War,
        Western,
    }
    public class Movie
    {
        public string MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDate { get; set; }
        public string MovieTitleUrl { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string ImageUrl { get; set; }
        public bool isWatched { get; set; }

        public List<Cast> Casts;
        public List<string> Images;
        public List<Genre> Genres;

        public Movie()
        {
            this.Casts = new List<Cast>();
            this.Images = new List<string>();
            this.Genres = new List<Genre>();
        }

        public override string ToString()
        {
            return MovieName;
        }


    }




}

