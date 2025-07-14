namespace FoolOfRESTAPI.Models.ResponseModels
{
    public class MessageResponseModel
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public ChatResponseModel? Chat {get; set;}
        public long UserId { get; set; }
        public UserResponseModel? User {get; set;}
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public MessageResponseModel(Message msg)
        {
            Id = msg.Id;
            ChatId = msg.ChatId;
            Chat = new ChatResponseModel(msg.Chat);
            User = new UserResponseModel(msg.User);
            UserId = msg.UserId;
            Text = msg.Text;
            Date = msg.Date;
        }

    }

}
