namespace FoolOfRESTAPI.Models.ResponseModels
{
    public class UserResponseModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public UserResponseModel(User user)
        {
            this.Username = user.Username;
            this.Id = user.Id;
        }
    }
}
