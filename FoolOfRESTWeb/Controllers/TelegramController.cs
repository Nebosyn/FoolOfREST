using Microsoft.AspNetCore.Mvc;

namespace FoolOfRESTWeb.Controllers;

public class TelegramController : Controller{
    public IActionResult Chats(){
        return View();
    }
}
