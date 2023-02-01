using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Model.Dto
{
    public class MusicanDEtails
    {
        public int  IdMusician { get; set; }
        public String FirstName { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
