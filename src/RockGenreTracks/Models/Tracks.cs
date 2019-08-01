using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockGenreTracks.Models
{
    public class Tracks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ComposerId { get; set; }        
        public string Genre { get; set; }
    }
}