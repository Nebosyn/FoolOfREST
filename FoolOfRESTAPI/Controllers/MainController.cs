using FoolOfRESTAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoolOfRESTAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        AppDbContext _db;
        public MainController(AppDbContext db) {
            _db = db;
        }

        [Route("messages")]
        [HttpGet]
        public async Task<Ok<IEnumerable<MessageResponseModel>>> Messages()
        {
            List<Message> messages = await _db.Messages.ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }

        [Route("usermessages/{userid}")]
        [HttpGet]
        public async Task<Ok<IEnumerable<MessageResponseModel>>> UsersMessages([FromRoute] int userid)
        {
            List<Message> messages = await _db.Messages.Where(msg => msg.UserId == userid).ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }

        [Route("chatmessages/{chatid}")]
        [HttpGet]
        public async Task<Ok<IEnumerable<MessageResponseModel>>>ChatsMessages([FromRoute] string chatid)
        {
            List<Message> messages = await _db.Messages.Where(msg => msg.ChatId == chatid).ToListAsync();
            return TypedResults.Ok(messages.Select(msg => new MessageResponseModel(msg)));
        }


        [Route("messages/{id}")]
        [HttpGet]
        public async Task<Results<Ok<MessageResponseModel>, NotFound>> MessageById([FromRoute] int id)
        {
            try
            {
                var msg = await _db.Messages.FirstAsync(x => x.Id == id);
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

        [Route("users/{id}")]
        [HttpGet]
        public async Task<Results<Ok<UserResponseModel>, NotFound>> UserById([FromRoute] int id)
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

        [Route("chats/{id}")]
        [HttpGet]
        public async Task<Results<Ok<ChatResponseModel>, NotFound>> ChatById([FromRoute] string id)
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
