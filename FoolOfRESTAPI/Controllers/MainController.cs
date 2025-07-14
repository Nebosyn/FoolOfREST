using FoolOfRESTAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoolOfRESTAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        AppDbContext _db;
        public MainController(AppDbContext db){
            _db = db;
        }

        [Route("messages/")]
        [HttpGet]
        public async Task<Ok<IEnumerable<MessageResponseModel>>> Messages()
        {
            List<Message> messages = await _db.Messages
                .Include(msg => msg.User)
                .AsSplitQuery()
                .Include(msg => msg.Chat)
                .ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }

        [Route("usermessages/{userid}")]
        [HttpGet]
        public async Task<Ok<IEnumerable<MessageResponseModel>>> UsersMessages([FromRoute] long userid)
        {
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
        public async Task<Ok<IEnumerable<MessageResponseModel>>> ChatsMessages([FromRoute] long chatid)
        {
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
        public async Task<Ok<IEnumerable<UserResponseModel>>>ChatsUsers([FromRoute] long chatid)
        {
            Chat chat = await _db.Chats
                .Include(chat => chat.Users)
                .FirstAsync(chat => chat.Id ==  chatid);
            return TypedResults.Ok(chat.Users.Select(user => new UserResponseModel(user)));
        }

        [Route("messages/{id}")]
        [HttpGet]
        public async Task<Results<Ok<MessageResponseModel>, NotFound>> MessageById([FromRoute] int id)
        {
            try
            {
                var msg = await _db.Messages
                    .Include(msg => msg.User)
                    .AsSplitQuery()
                    .Include(msg => msg.Chat)
                    .FirstAsync(x => x.Id == id);
                MessageResponseModel response = new(msg);
                return TypedResults.Ok(response);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no elements.")
                {
                    return TypedResults.NotFound();
                }
                throw;
            }
        }

        [Route("users/")]
        [HttpGet]
        public async Task<Ok<IEnumerable<UserResponseModel>>> Users(){
            List<User> users = await _db.Users.ToListAsync();
            return TypedResults.Ok(users.Select(msg => new UserResponseModel(msg)));
        }

        [Route("users/{id}")]
        [HttpGet]
        public async Task<Results<Ok<UserResponseModel>, NotFound>> UserById([FromRoute] long id)
        {
            try
            {
                var res = await _db.Users.FirstAsync(x => x.Id == id);
                return TypedResults.Ok(new UserResponseModel(res));
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no elements.")
                {
                    return TypedResults.NotFound();
                }
                throw;
            }
        }

        [Route("chats")]
        [HttpGet]
        public async Task<Ok<IEnumerable<ChatResponseModel>>> Chats(){
            List<Chat> chats = await _db.Chats.ToListAsync();
            return TypedResults.Ok(chats.Select(msg => new ChatResponseModel(msg)));
        }

        [Route("chats/{id}")]
        [HttpGet]
        public async Task<Results<Ok<ChatResponseModel>, NotFound>> ChatById([FromRoute] long id)
        {
            try
            {
                var res = await _db.Chats.FirstAsync(x => x.Id == id);
                return TypedResults.Ok(new ChatResponseModel(res));
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no elements.")
                {
                    return TypedResults.NotFound();
                }
                throw;
            }
        }
    }

}
