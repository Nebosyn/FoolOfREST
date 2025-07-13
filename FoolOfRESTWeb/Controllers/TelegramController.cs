using Microsoft.AspNetCore.Mvc;
using FoolOfRESTWeb.Models.ApiModels;

namespace FoolOfRESTWeb.Controllers;

public class TelegramController : Controller{


    public IActionResult Chats(){
        ViewData["ApiClient"] = new ApiClient();
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

            user.Messages = await GetUserMessagesAsync(user.Id);
            return user;
        }

        public async Task<List<UserApiModel>?> GetUsers(){
            List<UserApiModel>? users = null; 
            HttpResponseMessage response = await _client.GetAsync("users/");
            Console.Write("Status code:");
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode){
                users = await response.Content.ReadFromJsonAsync<List<UserApiModel>>();
            }
            if (users != null){
                Console.WriteLine("Adding messages");
                foreach (UserApiModel user in users){
                    user.Messages = await GetUserMessagesAsync(user.Id);
                }
            }
            return users;
        }


        public async Task<List<ChatApiModel>?> GetChats(){
            List<ChatApiModel>? chats = null; 
            HttpResponseMessage response = await _client.GetAsync("chats/");
            Console.Write("Status code:");
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode){
                chats = await response.Content.ReadFromJsonAsync<List<ChatApiModel>>();
            }
            if (chats != null){
                Console.WriteLine("Adding messages");
                foreach (ChatApiModel chat in chats){
                    chat.Messages = await GetChatMessagesAsync(chat.Id);
                    //chat.Users = await GetChatUsersAsync(chat.Id);
                }
            }
            return chats;
        }

        public async Task<List<MessageApiModel>?> GetChatMessagesAsync(long chatId){
            List<MessageApiModel>? messages = null;
            HttpResponseMessage response = await _client.GetAsync($"chatmessages/{chatId}");
            Console.WriteLine($"ChatMessages code: {response.StatusCode}");
            if (response.IsSuccessStatusCode){
                return await response.Content.ReadFromJsonAsync<List<MessageApiModel>>();
            }
            return messages;
        }

        public async Task<List<MessageApiModel>?> GetUserMessagesAsync(long userId){
            List<MessageApiModel>? messages = null;
            HttpResponseMessage response = await _client.GetAsync($"usermessages/{userId}");
            Console.WriteLine($"UserMessages code: {response.StatusCode}");
            if (response.IsSuccessStatusCode){
                return await response.Content.ReadFromJsonAsync<List<MessageApiModel>>();
            }
            return messages;
        }
    }
