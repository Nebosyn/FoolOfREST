public class Chat{
    public required long Id{get;set;}
    public required string Name{get;set;}
    public List<User> Users {get;set;} = null!;
    public List<Message> Messages{get;set;} = null!;
}
