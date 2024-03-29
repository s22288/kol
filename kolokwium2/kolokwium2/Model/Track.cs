﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Model
{
    public class Track
    {
        public int IdTrack { get; set; }
    
        public String TrackName { get; set; }
    public float Duration { get; set; }
    
    public int IdMusicAlbum { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
        public Album Album { get; set; }
    }
}
