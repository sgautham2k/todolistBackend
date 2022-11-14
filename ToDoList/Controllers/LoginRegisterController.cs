using ToDoList.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "todolist")]
    public class LoginRegisterController : ControllerBase
    {
        readonly ToDoListDbContext db;
        readonly IAuthenticate auth;
        public LoginRegisterController(ToDoListDbContext db, IAuthenticate auth)
        {
            this.db = db;
            this.auth = auth;
        }
        [HttpPost]
        [Route("/api/RegisterLogin/NewRegister")]
        public bool Post([FromBody] Register r)
        {
            r.Password = auth.EncodePasswordToBase64(r.Password);
            return auth.NewRegister(r);
        }
        [HttpGet]
        [Route("/api/RegisterLogin/Login/{uem}/{pwd}")]
        public LoginModel Get(string uem, string pwd)
        {
            pwd = auth.EncodePasswordToBase64(pwd);
            return auth.Login(uem, pwd);
        }
        [HttpPut]
        [Route("/api/RegisterLogin/UpdatePwd/{email}/{oldp}/{newp}")]
        public bool Put(string email, string oldp, string newp)
        {
            oldp = auth.EncodePasswordToBase64(oldp);
            newp = auth.EncodePasswordToBase64(newp);
            return auth.ChangePassword(email, oldp, newp);
        }
    }
}
