using FormWeb.Data;
using FormWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FormWeb.Services.Users
{
    public class UserService : IUserInterface
    {
        private readonly BancoContext _context;
        public UserService(BancoContext context)
        {
            _context = context;
        }
        public async Task<UserModel> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                _context.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _context.Users.FirstAsync(a => a.Id == id);
            return user;
            
        }
        public async Task<UserViewModel> GetUsuario()
        {
            UserViewModel usuarios = new UserViewModel();

            usuarios.users = await _context.Users.ToListAsync();

            return usuarios;
        }
        public async Task<UserViewModel> SetUser(UserModel user)
        {
            UserViewModel userView = new UserViewModel();

            if (string.IsNullOrEmpty(user.Nome) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Senha)) 
            {
                
                userView.user = user;
                userView.users = await _context.Users.ToListAsync();
                userView.status = false;
                userView.status_descricao = "Nem todos os campos do formulário foram preenchido, verificar formulário";
                return userView;
            }
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userView.users = await _context.Users.ToListAsync();
            userView.status = true;
            userView.status_descricao = "Usuário cadastrado com sucesso";

            return userView;

        }
        public retornoPadrao UpdateUser(UserModel model)
        {
            retornoPadrao ret = new();
            try
            {
                _context.Users.Update(model);
                _context.SaveChanges();

                ret.status = true;
                ret.status_descricao = "Usuário alterado com sucesso!";

            }
            catch (Exception ex) 
            {
                ret.status = false;
                ret.status_descricao = $"Ocorreu um ao atualizar o usuário: {ex.Message}";
            }

            return ret;
        }
        public TiposViewModel DropDown()
        {
            TiposViewModel tipos = new TiposViewModel();

            tipos.LsTipoAs = _context.TipoAs.ToList();
            tipos.LsTipoBs = _context.TipoBs.ToList();

            return tipos;
        }
        public DropDownViewModel DropDow2()
        {
            DropDownViewModel model = new DropDownViewModel();
            // Ação realizada no repositorio
            model.LsTipoAs = _context.TipoAs.ToList();
            model.LsTipoBs = _context.TipoBs.ToList();
            //Ação realizada no serviço
            model.tipoBFiltrada = model.LsTipoBs;
            return model;
        }
        public List<TipoB> FiltrandoDropDownB(List<TipoB> optionsB, int IdTipoA)
        {
            List<TipoB> filtros = optionsB.Where(a => a.IdTipoA == IdTipoA).ToList();
            return filtros;
        }
    }
}
