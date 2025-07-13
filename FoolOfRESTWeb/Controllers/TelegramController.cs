using Microsoft.AspNetCore.Mvc;
using FoolOfRESTWeb.Models.ApiModels;

namespace FoolOfRESTWeb.Controllers;

public class TelegramController : Controller{


    public IActionResult Chats(){
        return View();
    }

    public IActionResult Users(){
        ViewData["ApiClient"] = new ApiClient();
        return View();
    }

    [Route("Telegram/User/{id:long}")]
    public IActionResult UserData([FromRoute] long id){
        Console.WriteLine(id);
        ApiClient api = new ApiClient();
        UserApiModel? user = api.GetUserAsync(id).GetAwaiter().GetResult();
        Console.WriteLine(user);
        if (user == null){
            return View("UserNull");
        }
        return View("User", user);
    }
}

    public class ApiClient{

        public HttpClient _client;

        public ApiClient(){
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5001/");
        }

        public async Task<UserApiModel?> GetUserAsync(long id){
            UserApiModel? user = null;
            HttpResponseMessage response = await _client.GetAsync($"users/{id}");
            if (response.IsSuccessStatusCode){
                user = await response.Content.ReadFromJsonAsync<UserApiModel>();
            }

            if (user == null) return user;

            response = await _client.GetAsync($"usermessages/{id}");
            if (response.IsSuccessStatusCode){
                user.Messages = await response.Content.ReadFromJsonAsync<List<MessageApiModel>>();
            }
            return user;
        }

        public async Task<List<MessageApiModel>?> GetUserMessagesAsync(long userId){
            List<MessageApiModel>? messages = null;
            HttpResponseMessage response = await _client.GetAsync($"usersmessages/{userId}");
            if (response.IsSuccessStatusCode){
                messages = await response.Content.ReadFromJsonAsync<List<MessageApiModel>>();
            }
            return messages;
        }
    }
