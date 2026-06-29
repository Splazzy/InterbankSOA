using InterbankSOA.API.Models;

namespace InterbankSOA.API.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> AddAsync(Usuario usuario);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> DniExistsAsync(string dni);
        Task<bool> UsuarioDigitalExistsAsync(string usuarioDigital);
        Task<Usuario?> GetByEmailAndPasswordAsync(string email, string claveHash);
        Task<Sesion> AddSesionAsync(Sesion sesion);
    }
}