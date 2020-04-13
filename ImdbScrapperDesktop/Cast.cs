using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbScrapperDesktop
{
    public enum Role
    {
        Director = 1,
        Writer = 2,
        Actor = 3,
        Creator = 4,
    }
    public class Cast
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BornDetails { get; set; }
        public string BornCity { get; set; }
        public string BornYear { get; set; }
        public string BornMonth { get; set; }
        public string BornDay { get; set; }
        public string BornCountry { get; set; }
        public string ImageUrl { get; set; }

        public List<Movie> Movies;
        public List<string> Images;
        public List<string> JobTitles;

        public List<Role> Roles;
        public Cast()
        {
            this.Roles = new List<Role>();
            this.Movies = new List<Movie>();
            this.Images = new List<string>();
            this.JobTitles = new List<string>();
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
