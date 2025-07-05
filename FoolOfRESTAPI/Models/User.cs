public class User{
    public int Id{get;set;}
    public string? Username{get;set;}
    public ICollection<Message> Messages{get;} = null!;
}
