using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http.HttpResults;
using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<string?> Login(LoginRequestDTO request)
        {
            //TODO: Change to automapper

            User? user = await _userService.GetByUsername(request.Username);

            if (user != null)
            {

                //Hash password + salt using ID
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: request.Password,
                salt: BitConverter.GetBytes(user.Id),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

                if(user.Password.Equals(hashed)) 
                    return _jwtService.GenerateToken(request.Username);

                return null;
            }

            return null;
        }

        public async Task<string?> Register(RegisterRequestDTO request)
        {
            //TODO: Change to automapper

            User user = new User(0, request.Username, request.Password);

            int id = _userService.GetMaxId().Result + 1;
            user.Id = id;

            //Hash password + salt using ID
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: user.Password,
            salt: BitConverter.GetBytes(id),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            user.Password = hashed;

            await _userService.AddUser(user);

            return _jwtService.GenerateToken(request.Username);
        }
    }
}
