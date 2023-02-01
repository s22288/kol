using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Model
{
    public class Album
    {
        public int IdAlbum { get; set; }public String AlbumName { get; set; }
        public DateTime PublishedDate { get; set; }public int IdMusicLabel { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
        public MusicLabel MusicLabel { get; set; }
    }
}
