namespace FoolOfRESTWeb.Models.ApiModels
{
    public class UserApiModel 
    {
        public int Id { get; set;}
        public required string Username { get; set;}
        public List<MessageApiModel>? Messages{get; set;}
    }
}
