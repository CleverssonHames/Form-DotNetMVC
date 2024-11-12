using FormWeb.Models;
using FormWeb.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserInterface _userService;

        public HomeController(IUserInterface userservice)
        {
            _userService = userservice;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var contatos = await _userService.GetUsuario();
            return View(contatos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<PartialViewResult> SetUser(UserModel user)
        {
            var ret = await _userService.SetUser(user);
            return PartialView("PartialView/_AddUserPartialView", ret);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteUser(int id) 
        {
            var ret = await _userService.DeleteUser(id);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> GetUserById(int id) 
        {
            var result = await _userService.GetUserById(id);
            return View("EditUser", result);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserModel model)
        {
            var ret = _userService.UpdateUser(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DropDownAninhado()
        {
            var ret = _userService.DropDown();
            return View(ret);
        }

        public ActionResult DropDown2()
        {
            var ret = _userService.DropDow2();
            return View(ret);
        }
        
        
        public ActionResult FiltrandoDropDown(TiposViewModel modelTipos, int IdTipoA)
        {
            var ret = _userService.FiltrandoDropDownB(modelTipos,IdTipoA);
            return View("DropDown2",ret);
        }

    }
}