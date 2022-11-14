using System.Security.Cryptography;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class NotesImpl : INotes
    {
        readonly ToDoListDbContext db;
        public NotesImpl(ToDoListDbContext db)
        {
            this.db = db;
        }
        public bool AddNotes(Notes n)
        {
            try
            {
                var notes = db.Notes.ToList();
                foreach (var note in notes)
                {
                    if (note.NotesTitle == n.NotesTitle)
                    {
                        return false;
                    }
                }
                db.Notes.Add(n);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public bool EditNotes(int nid, Notes n, int aid)
        {
            try
            {
                var olddata = db.Notes.Where(x => x.NotesId == nid && x.AppUserId == aid).FirstOrDefault();
                if (olddata != null)
                {
                    olddata.NotesTitle = n.NotesTitle;
                    olddata.NotesDescription = n.NotesDescription;
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public bool DeleteNotes(int nid, int aid)
        {
            try
            {
                var olddata = db.Notes.Where(x => x.NotesId == nid && x.AppUserId == aid).FirstOrDefault();
                if (olddata != null)
                {
                    db.Notes.Remove(olddata);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public List<Notes> GetNotesByAppUserId(int? aid)
        {
            return db.Notes.Where(x => x.AppUserId == aid).ToList();
        }

        public List<Notes> GetAllNotes()
        {
            return db.Notes.ToList();
        }
    }
}
