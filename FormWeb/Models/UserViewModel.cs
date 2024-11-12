namespace FormWeb.Models
{
    public class UserViewModel : retornoPadrao
    {
        public UserModel user { get; set; } = new UserModel();
        public List<UserModel> users { get; set; } = new();

    }
}
