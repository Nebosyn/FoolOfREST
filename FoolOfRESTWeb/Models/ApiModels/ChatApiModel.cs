namespace FoolOfRESTWeb.Models.ApiModels
{
    public class ChatApiModel 
    {
        public long Id{get;set;}
        public required string Name{get;set;}
        public List<UserApiModel>? Users {get;set;}
        public List<MessageApiModel>? Messages{get;set;}
    }

}
