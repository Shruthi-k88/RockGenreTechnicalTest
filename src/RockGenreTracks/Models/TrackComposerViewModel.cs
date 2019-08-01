using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockGenreTracks.Models
{
    public class TrackComposerViewModel
    {
        public string Tracks { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Composers
        {
            get { return FirstName + " " + LastName; }
        }       

        public string Genre { get; set; }
    }
}