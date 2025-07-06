public class Chat{
    public required string Id{get;set;}
    public required string Name{get;set;}
    public List<User> Users {get;set;} = null!;
    public List<Message> Messages{get;set;} = null!;
}
