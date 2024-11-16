using FormWeb.Models;

namespace FormWeb.Services.Users
{
    public interface IUserInterface
    {
        public Task<UserViewModel> SetUser(UserModel user);
        public Task<UserViewModel> GetUsuario();
        public Task<UserModel> DeleteUser(int id);
        public Task<UserModel> GetUserById(int id);
        public retornoPadrao UpdateUser(UserModel model);
        public TiposViewModel DropDown();
        public DropDownViewModel  DropDow2();
        public List<TipoB> FiltrandoDropDownB(List<TipoB> optionsB, int IdTipoA);
    }
}
