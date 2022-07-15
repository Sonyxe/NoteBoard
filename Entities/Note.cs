using System;

namespace NoteBoard.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }

        public Note(string category, string title, string notes)
        {
            Id = Guid.NewGuid();
            Category = category;
            Title = title;
            Notes = notes;
        }
    }
}
