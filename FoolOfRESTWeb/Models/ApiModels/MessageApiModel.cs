namespace FoolOfRESTWeb.Models.ApiModels{
     public struct MessageApiModel{
        public int Id { get; set; }
        public long ChatId { get; set; }
        public ChatApiModel Chat {get; set;}
        public long UserId { get; set; }
        public UserApiModel User {get; set;}
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
