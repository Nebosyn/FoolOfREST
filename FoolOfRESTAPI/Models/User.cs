public class User{
    public long Id{get;set;}
    public required string Username{get;set;}
    public ICollection<Message> Messages{get;} = []; 
    public ICollection<Chat> Chats{get;} = [];
}
