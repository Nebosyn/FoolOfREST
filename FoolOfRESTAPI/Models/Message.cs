using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Id), nameof(ChatId), nameof(UserId))]
public class Message{
    public int Id{get; set;}

    public long ChatId{get; set;}
    public required Chat Chat{get; set;}

    public long UserId{get; set;}
    public required User User{get; set;}

    public required string Text{get; set;}
    public DateTime Date{get; set;}
}
