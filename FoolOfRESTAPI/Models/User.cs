public class User{
    public int Id{get;set;}
    public required string Username{get;set;}
    public ICollection<Message> Messages{get;} = []; 
    public ICollection<Chat> Chats{get;} = [];
}
