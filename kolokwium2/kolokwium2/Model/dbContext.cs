using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Model
{
    public class dbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> MusicianTracks { get; set; }        public DbSet<Album> Albums { get; set; }        public DbSet<Track> Tracks { get; set; }        public  DbSet<MusicLabel> MusicLabels { get; set; }

        public dbContext()
        {
        }        public dbContext(DbContextOptions<dbContext> options) : base(options)        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasKey(sc => new { sc.IdMusician, sc.IdTrack });
                m.HasOne(sc => sc.Musician).WithMany(s => s.Musician_Tracks).HasForeignKey(sc => sc.IdMusician);
                m.HasOne(sc => sc.Track).WithMany(s => s.Musician_Tracks).HasForeignKey(sc => sc.IdTrack);
                m.HasData(new Musician_Track { IdMusician = 1, IdTrack = 1 });

            });
            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(ms => ms.IdMusician);
                m.Property(ms => ms.FirstName).HasMaxLength(30).IsRequired();
                m.Property(ms => ms.LastName).HasMaxLength(50).IsRequired();
                m.Property(ms => ms.Nickname).HasMaxLength(20).IsRequired();
                m.HasData(new Musician { IdMusician = 1, FirstName = "Michal", LastName = "Kowalski", Nickname = "niewiem" });
            });
            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(tr => tr.IdTrack);
                t.Property(tr => tr.TrackName).HasMaxLength(20).IsRequired();
                t.Property(tr => tr.Duration);
                t.HasOne(tr => tr.Album).WithMany(d => d.Tracks).HasForeignKey(tr => tr.IdMusicAlbum);
                t.HasData(new Track { IdTrack = 1, TrackName = "dobry track", Duration = 124,IdMusicAlbum=1 });

            });
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(al => al.IdAlbum);
                a.Property(al => al.AlbumName).HasMaxLength(30).IsRequired();
                a.Property(al => al.PublishedDate);
                a.HasOne(al => al.MusicLabel).WithMany(d => d.Albums).HasForeignKey(al => al.IdMusicLabel);
                a.HasData(new Album { IdAlbum = 1, AlbumName = "dobry album", PublishedDate = DateTime.Now, IdMusicLabel = 1 });
            });
            modelBuilder.Entity<MusicLabel>(ml => {
                ml.HasKey(m => m.IdMusicLabel);
                ml.Property(m => m.Name).HasMaxLength(50).IsRequired();
                ml.HasData(new MusicLabel { IdMusicLabel = 1, Name = "Dobry label" });
            });

        }
    }
}
