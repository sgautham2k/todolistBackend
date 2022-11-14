using ToDoList.Models;

namespace ToDoList.Controllers
{
    public interface INotes
    {
        bool AddNotes(Notes n);
        bool EditNotes(int nid, Notes n, int aid);
        bool DeleteNotes(int nid, int aid);

        List<Notes> GetNotesByAppUserId(int? aid);

        List<Notes> GetAllNotes();
    }
}
