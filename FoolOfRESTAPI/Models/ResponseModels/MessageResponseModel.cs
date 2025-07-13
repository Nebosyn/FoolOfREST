namespace FoolOfRESTAPI.Models.ResponseModels
{
    public class MessageResponseModel
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public MessageResponseModel(Message msg)
        {
            Id = msg.Id;
            ChatId = msg.ChatId;
            UserId = msg.UserId;
            Text = msg.Text;
            Date = msg.Date;
        }

    }

}
