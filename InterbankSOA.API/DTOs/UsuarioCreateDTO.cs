namespace InterbankSOA.API.DTOs
{
    public class UsuarioCreateDTO
    {
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string ClaveHash { get; set; } = null!;
    }
}