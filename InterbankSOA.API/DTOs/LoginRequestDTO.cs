namespace InterbankSOA.API.DTOs
{
    public class LoginRequestDTO
    {
        public string Email { get; set; } = null!;
        public string ClaveHash { get; set; } = null!;
    }
}