namespace FoolOfRESTWeb.Models.ApiModels{
     public struct MessageApiModel{
        public int Id { get; set; }
        public string ChatId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
