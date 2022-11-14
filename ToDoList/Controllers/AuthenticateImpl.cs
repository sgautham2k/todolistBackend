using ToDoList.Models;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class Authenticateimpl : IAuthenticate
    {
        readonly ToDoListDbContext db;
        public Authenticateimpl(ToDoListDbContext db)
        {
            this.db = db;
        }
        public bool ChangePassword(string email, string oldpwd, string newpwd)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailAddress == email && x.Password == oldpwd).FirstOrDefault();
                if (olddata == null)
                {
                    throw new Exception("invalid email or password");
                }
                else
                {
                    olddata.Password = newpwd;
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
        public LoginModel Login(string uem, string password)
        {

            var data = (from x in db.Register
                        where (x.EmailAddress == uem || x.UserName == uem) && x.Password == password
                        select new LoginModel
                        {
                            AppUserId = x.AppUserId,
                            Name = x.Name,
                            EmailId = x.EmailAddress
                        }).FirstOrDefault();
            return data;
        }
        public bool NewRegister(Register r)
        {
            try
            {
                var users = db.Register.ToList();
                foreach (var user in users)
                {
                    if (user.UserName == r.UserName || user.EmailAddress == r.EmailAddress)
                    {
                        return false;
                    }
                }
                db.Register.Add(r);
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
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}
