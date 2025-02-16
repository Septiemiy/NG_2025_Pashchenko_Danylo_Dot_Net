using Microsoft.AspNetCore.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Verify(LoginModel model)
        {
            var users = new List<LoginDataBaseModel>
            {
                new LoginDataBaseModel(1, "Danylo", "1111", true),
                new LoginDataBaseModel(2, "Perdilo", "2222", false),
                new LoginDataBaseModel(3, "Kukich", "3333", false),
                new LoginDataBaseModel(4, "Admin", "4444", true),
                new LoginDataBaseModel(5, "Soyjak", "5555", false)
            };

            if(String.IsNullOrEmpty(model.Username))
            {
                return View();
            }    

            var verifiedUser = users.FirstOrDefault(user =>
                               user.Username == model.Username &&
                               user.Password == model.Password);

            if(verifiedUser != null)
            {
                return View("~/Views/Home/Privacy.cshtml", verifiedUser);
            }
            else
            {
                return View("Username or password invalid".Clone());
            }

                
        }
    }
}
