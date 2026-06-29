using InterbankSOA.API.DTOs;

namespace InterbankSOA.API.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync();

        Task<UsuarioDTO> CreateUsuarioAsync(UsuarioCreateDTO usuarioDto);

        Task<string> LoginAsync(LoginRequestDTO loginDto);
    }
}