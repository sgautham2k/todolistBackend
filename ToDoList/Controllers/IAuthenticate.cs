using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class LoginModel
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

    }
    public interface IAuthenticate
    {
        LoginModel Login(string uem, string password);
        bool NewRegister(Register r);
        bool ChangePassword(string email, string oldpwd, string newpwd);
        string EncodePasswordToBase64(string password);
    }
}
