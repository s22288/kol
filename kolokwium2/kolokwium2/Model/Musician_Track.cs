﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Model
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }        public int IdMusician { get; set; }        public Musician Musician { get; set; }        public Track Track { get; set; }
    }
}
