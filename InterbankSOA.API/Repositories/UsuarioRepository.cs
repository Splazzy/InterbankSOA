using Microsoft.EntityFrameworkCore;
using InterbankSOA.API.Models;

namespace InterbankSOA.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InterbankSOAContext _context;

        public UsuarioRepository(InterbankSOAContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> DniExistsAsync(string dni)
        {
            return await _context.Usuarios.AnyAsync(u => u.Dni == dni);
        }

        public async Task<bool> UsuarioDigitalExistsAsync(string usuarioDigital)
        {
            return await _context.Usuarios.AnyAsync(u => u.UsuarioDigital == usuarioDigital);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Sesion> AddSesionAsync(Sesion sesion)
        {
            await _context.Sesions.AddAsync(sesion);
            await _context.SaveChangesAsync();
            return sesion;
        }
    }
}