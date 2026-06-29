namespace InterbankSOA.API.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
    }
}