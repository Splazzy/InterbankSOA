using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using InterbankSOA.API.DTOs;
using InterbankSOA.API.Models;
using InterbankSOA.API.Repositories;

namespace InterbankSOA.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            
            return usuarios.Select(u => new UsuarioDTO
            {
                IdUsuario = u.IdUsuario,
                Dni = u.Dni,
                Nombre = u.Nombre,
                ApellidoPaterno = u.ApellidoPaterno,
                Email = u.Email,
                Celular = u.Celular
            });
        }

        // NUEVO
     public async Task<UsuarioDTO> CreateUsuarioAsync(UsuarioCreateDTO usuarioDto)
        {
            if (await _usuarioRepository.EmailExistsAsync(usuarioDto.Email))
            {
                throw new InvalidOperationException("El correo electrónico ya está registrado.");
            }

            if (await _usuarioRepository.DniExistsAsync(usuarioDto.Dni))
            {
                throw new InvalidOperationException("El DNI ya está registrado.");
            }

            var usuarioDigitalBase = (usuarioDto.Nombre.Substring(0, 1) + usuarioDto.ApellidoPaterno).ToLower();
            var usuarioDigital = usuarioDigitalBase;
            var suffix = 1;
            while (await _usuarioRepository.UsuarioDigitalExistsAsync(usuarioDigital))
            {
                usuarioDigital = $"{usuarioDigitalBase}{suffix++}";
            }

            var nuevoUsuario = new Usuario
            {
                Dni = usuarioDto.Dni,
                Nombre = usuarioDto.Nombre,
                ApellidoPaterno = usuarioDto.ApellidoPaterno,
                ApellidoMaterno = usuarioDto.ApellidoMaterno,
                Email = usuarioDto.Email,
                Celular = usuarioDto.Celular,
                ClaveHash = HashPassword(usuarioDto.ClaveHash),

                // --- CAMPOS INTERNOS ASIGNADOS AUTOMÁTICAMENTE ---
                FechaRegistro = DateTime.UtcNow,
                Estado = true,
                UsuarioDigital = usuarioDigital,
                PerfilRiesgo = "BAJO",
                TarjetaCreditos = new List<TarjetaCredito>
                {
                    new TarjetaCredito
                    {
                        NumeroEnmascarado = GenerateRandomCreditCardNumber(),
                        AliasTarjeta = "Tarjeta Principal",
                        LimiteCredito = 5000m,
                        DeudaTotal = 0m,
                        FechaVencimiento = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(4)),
                        DiaPago = 5,
                        DiaCierre = 25,
                        CvvDinamico = GenerateRandomCvv(),
                        EstadoActivo = true
                    }
                }
            };

            var usuarioCreado = await _usuarioRepository.AddAsync(nuevoUsuario);

            return new UsuarioDTO
            {
                IdUsuario = usuarioCreado.IdUsuario,
                Dni = usuarioCreado.Dni,
                Nombre = usuarioCreado.Nombre,
                ApellidoPaterno = usuarioCreado.ApellidoPaterno,
                Email = usuarioCreado.Email,
                Celular = usuarioCreado.Celular
            };
        }

        public async Task<string> LoginAsync(LoginRequestDTO loginDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Email);
            if (usuario == null || !VerifyPassword(loginDto.ClaveHash, usuario.ClaveHash))
            {
                throw new InvalidOperationException("Email o contraseña incorrectos.");
            }

            var sesion = new Sesion
            {
                IdUsuario = usuario.IdUsuario,
                TokenHash = Guid.NewGuid().ToString("N"),
                FechaCreacion = DateTime.UtcNow,
                UltimoAcceso = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddHours(8),
                DireccionIp = "127.0.0.1",
                EstadoActivo = true
            };

            await _usuarioRepository.AddSesionAsync(sesion);

            return $"Bienvenido a la banca movil interbank, {usuario.Nombre}!";
        }

        private static string HashPassword(string password)
        {
            const int iterations = 100_000;
            const int saltSize = 16;
            const int hashSize = 32;

            var salt = RandomNumberGenerator.GetBytes(saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                hashSize);

            return $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.', 3);
            if (parts.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out var iterations))
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[1]);
            var expectedHash = Convert.FromBase64String(parts[2]);
            var computedHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(expectedHash, computedHash);
        }

        private static string GenerateRandomCreditCardNumber()
    {
        var bin = new[] { "4539", "4556", "4916", "4024", "5204", "5300" };
        var prefix = bin[Random.Shared.Next(bin.Length)];
        var digits = prefix;

        for (var i = 0; i < 11; i++)
        {
            digits += Random.Shared.Next(0, 10);
        }

        var checkDigit = CalculateLuhnCheckDigit(digits);
        digits += checkDigit;

        return string.Join(" ", Enumerable.Range(0, 4).Select(i => i < 3 ? "****" : digits.Substring(12, 4)));
    }

    private static string GenerateRandomCvv()
    {
        return Random.Shared.Next(100, 1000).ToString();
    }

    private static string CalculateLuhnCheckDigit(string digits)
    {
        var sum = 0;
        var reversed = digits.Reverse().ToArray();

        for (var i = 0; i < reversed.Length; i++)
        {
            var digit = reversed[i] - '0';
            if (i % 2 == 0)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }
            sum += digit;
        }

        var mod = sum % 10;
        return (mod == 0 ? 0 : 10 - mod).ToString();
    }
    }
}