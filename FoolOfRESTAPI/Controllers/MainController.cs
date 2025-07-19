using FoolOfRESTAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoolOfRESTAPI.Controllers
{
    [ApiController]
    public class MainController: ControllerBase
    {
        private readonly AppDbContext _db;
        public MainController(AppDbContext db){
            _db = db;
        }

        static private bool ApiKeyVerification(IHeaderDictionary header){
            if (ApiKey.Key == null) {return true;}
            if (!header.TryGetValue("APIKEY",out var key)){return false;}
            if (key != ApiKey.Key) {return false;}
            return true;
        }

        [Route("messages/")]
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<MessageResponseModel>>, UnauthorizedHttpResult>> Messages()
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            List<Message> messages = await _db.Messages
                .Include(msg => msg.User)
                .AsSplitQuery()
                .Include(msg => msg.Chat)
                .ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }

        [Route("usermessages/{userid}")]
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<MessageResponseModel>>, UnauthorizedHttpResult>> UsersMessages([FromRoute] long userid)
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            List<Message> messages = await _db.Messages
                .Where(msg => msg.UserId == userid)
                .Include(msg => msg.User)
                .AsSplitQuery()
                .Include(msg => msg.Chat)
                .ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }

        [Route("chatmessages/{chatid}")]
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<MessageResponseModel>>, UnauthorizedHttpResult>> ChatsMessages([FromRoute] long chatid)
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            List<Message> messages = await _db.Messages
                .Where(msg => msg.ChatId == chatid)
                .Include(msg => msg.User)
                .AsSplitQuery()
                .Include(msg => msg.Chat)
                .ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }

        [Route("chatusers/{chatid}")]
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<UserResponseModel>>, UnauthorizedHttpResult>>ChatsUsers([FromRoute] long chatid)
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            Chat chat = await _db.Chats
                .Include(chat => chat.Users)
                .FirstAsync(chat => chat.Id ==  chatid);
            return TypedResults.Ok(chat.Users.Select(user => new UserResponseModel(user)));
        }

        [Route("messages/{id}")]
        [HttpGet]
        public async Task<Results<Ok<MessageResponseModel>, NotFound, UnauthorizedHttpResult>> MessageById([FromRoute] int id)
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            Message? message = await _db.Messages
                .Include(msg => msg.User)
                .AsSplitQuery()
                .Include(msg => msg.Chat)
                .FirstAsync(x => x.Id == id);
            if (message == null) {return TypedResults.NotFound();}
            MessageResponseModel response = new(message);
            return TypedResults.Ok(response);
        }

        [Route("users/")]
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<UserResponseModel>>, UnauthorizedHttpResult>> Users(){
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            List<User> users = await _db.Users.ToListAsync();
            return TypedResults.Ok(users.Select(msg => new UserResponseModel(msg)));
        }

        [Route("users/{id}")]
        [HttpGet]
        public async Task<Results<Ok<UserResponseModel>, NotFound, UnauthorizedHttpResult>> UserById([FromRoute] long id)
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            var response = await _db.Users.FirstAsync(x => x.Id == id);
            if (response == null) {return TypedResults.NotFound();}
            return TypedResults.Ok(new UserResponseModel(response));
        }

        [Route("chats")]
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<ChatResponseModel>>,UnauthorizedHttpResult>> Chats(){
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            List<Chat> chats = await _db.Chats.ToListAsync();
            return TypedResults.Ok(chats.Select(msg => new ChatResponseModel(msg)));
        }

        [Route("chats/{id}")]
        [HttpGet]
        public async Task<Results<Ok<ChatResponseModel>, NotFound, UnauthorizedHttpResult>> ChatById([FromRoute] long id)
        {
            if (ApiKeyVerification(Request.Headers) == false) {return TypedResults.Unauthorized();}
            var response = await _db.Chats.FirstAsync(x => x.Id == id);
            if (response == null) return TypedResults.NotFound();
            return TypedResults.Ok(new ChatResponseModel(response));
        }
        }
    }
