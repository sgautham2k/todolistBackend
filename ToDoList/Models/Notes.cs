using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Notes
    {
        [Key]
        public int NotesId { get; set; }
        [Required]
        public string NotesTitle { get; set; }
        [Required]
        public string NotesDescription { get; set; }
        public int? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual Register? Register { get; set; }
    }
}
