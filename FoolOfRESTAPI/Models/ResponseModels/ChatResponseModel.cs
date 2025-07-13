namespace FoolOfRESTAPI.Models.ResponseModels
{
    public class ChatResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ChatResponseModel(Chat chat)
        {
            this.Id = chat.Id;
            this.Name = chat.Name;
        }
    }
}
