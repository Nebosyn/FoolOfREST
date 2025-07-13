namespace FoolOfRESTWeb.Models.ApiModels{
     public struct MessageApiModel{
        public int Id { get; set; }
        public long ChatId { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
