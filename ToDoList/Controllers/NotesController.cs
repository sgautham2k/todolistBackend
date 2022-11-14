using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "todolist")]
    public class NotesController : ControllerBase
    {
        readonly ToDoListDbContext db;
        readonly INotes nt;
        public NotesController(ToDoListDbContext db, INotes nt)
        {
            this.db = db;
            this.nt = nt;
        }

        [HttpPost]
        [Route("/NotesInfo/AddNotes")]
        public bool Post([FromBody] Notes n)
        {
            return nt.AddNotes(n);
        }

        [HttpPut]
        [Route("/NotesInfo/EditNotes/{nid}/{aid}")]
        public bool Put([FromBody] Notes n, int nid, int aid)
        {
            return nt.EditNotes(nid, n, aid);
        }

        [HttpDelete]
        [Route("/NotesInfo/DeleteNotes/{nid}/{aid}")]
        public bool Delete(int nid, int aid)
        {
            return nt.DeleteNotes(nid, aid);
        }

        [HttpGet]
        [Route("/NotesInfo/GetNotesByAppUserId/{aid}")]
        public List<Notes> GetNotesByAppUserId(int? aid)
        {
            return nt.GetNotesByAppUserId(aid);
        }

        [HttpGet]
        [Route("/NotesInfo/GetAllNotes")]
        public List<Notes> GetAllNotes()
        {
            return nt.GetAllNotes();
        }
    }
}
