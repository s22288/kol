using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Model
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
