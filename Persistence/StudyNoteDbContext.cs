using DevStudyNotes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStudyNotes.API.Persistence {
    public class StudyNoteDbContext: DbContext {
        public StudyNoteDbContext(DbContextOptions<StudyNoteDbContext> options): base(options) {
                
        }

        public DbSet<StudyNote> StudyNotes { get; set; }
        public DbSet<StudyNoteReaction> StudyNotesReactions { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<StudyNote>(sn => {
                sn.HasKey(s => s.Id);
                sn.HasMany(s => s.Reactions).WithOne().HasForeignKey(r => r.StudyNoteId).OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<StudyNoteReaction>(snr => {
                snr.HasKey(s => s.Id);
            });
        }

    }
}
